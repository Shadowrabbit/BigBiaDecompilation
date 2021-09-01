using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using XLua.LuaDLL;
using XLua.TemplateEngine;

namespace XLua
{
	public class LuaEnv : IDisposable
	{
		internal IntPtr L
		{
			get
			{
				if (this.rawL == IntPtr.Zero)
				{
					throw new InvalidOperationException("this lua env had disposed!");
				}
				return this.rawL;
			}
		}

		internal object luaEnvLock
		{
			get
			{
				return this.luaLock;
			}
		}

		public LuaEnv()
		{
			if (Lua.xlua_get_lib_version() != 105)
			{
				throw new InvalidProgramException("wrong lib version expect:" + 105.ToString() + " but got:" + Lua.xlua_get_lib_version().ToString());
			}
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				LuaIndexes.LUA_REGISTRYINDEX = Lua.xlua_get_registry_index();
				this.rawL = Lua.luaL_newstate();
				Lua.luaopen_xlua(this.rawL);
				Lua.luaopen_i64lib(this.rawL);
				this.translator = new ObjectTranslator(this, this.rawL);
				this.translator.createFunctionMetatable(this.rawL);
				this.translator.OpenLib(this.rawL);
				ObjectTranslatorPool.Instance.Add(this.rawL, this.translator);
				Lua.lua_atpanic(this.rawL, new lua_CSFunction(StaticLuaCallbacks.Panic));
				Lua.lua_pushstdcallcfunction(this.rawL, new lua_CSFunction(StaticLuaCallbacks.Print), 0);
				if (Lua.xlua_setglobal(this.rawL, "print") != 0)
				{
					throw new Exception("call xlua_setglobal fail!");
				}
				LuaTemplate.OpenLib(this.rawL);
				this.AddSearcher(new lua_CSFunction(StaticLuaCallbacks.LoadBuiltinLib), 2);
				this.AddSearcher(new lua_CSFunction(StaticLuaCallbacks.LoadFromCustomLoaders), 3);
				this.AddSearcher(new lua_CSFunction(StaticLuaCallbacks.LoadFromResource), 4);
				this.AddSearcher(new lua_CSFunction(StaticLuaCallbacks.LoadFromStreamingAssetsPath), -1);
				this.DoString(this.init_xlua, "Init", null);
				this.init_xlua = null;
				this.AddBuildin("socket.core", new lua_CSFunction(StaticLuaCallbacks.LoadSocketCore));
				this.AddBuildin("socket", new lua_CSFunction(StaticLuaCallbacks.LoadSocketCore));
				this.AddBuildin("CS", new lua_CSFunction(StaticLuaCallbacks.LoadCS));
				Lua.lua_newtable(this.rawL);
				Lua.xlua_pushasciistring(this.rawL, "__index");
				Lua.lua_pushstdcallcfunction(this.rawL, new lua_CSFunction(StaticLuaCallbacks.MetaFuncIndex), 0);
				Lua.lua_rawset(this.rawL, -3);
				Lua.xlua_pushasciistring(this.rawL, "LuaIndexs");
				Lua.lua_newtable(this.rawL);
				Lua.lua_pushvalue(this.rawL, -3);
				Lua.lua_setmetatable(this.rawL, -2);
				Lua.lua_rawset(this.rawL, LuaIndexes.LUA_REGISTRYINDEX);
				Lua.xlua_pushasciistring(this.rawL, "LuaNewIndexs");
				Lua.lua_newtable(this.rawL);
				Lua.lua_pushvalue(this.rawL, -3);
				Lua.lua_setmetatable(this.rawL, -2);
				Lua.lua_rawset(this.rawL, LuaIndexes.LUA_REGISTRYINDEX);
				Lua.xlua_pushasciistring(this.rawL, "LuaClassIndexs");
				Lua.lua_newtable(this.rawL);
				Lua.lua_pushvalue(this.rawL, -3);
				Lua.lua_setmetatable(this.rawL, -2);
				Lua.lua_rawset(this.rawL, LuaIndexes.LUA_REGISTRYINDEX);
				Lua.xlua_pushasciistring(this.rawL, "LuaClassNewIndexs");
				Lua.lua_newtable(this.rawL);
				Lua.lua_pushvalue(this.rawL, -3);
				Lua.lua_setmetatable(this.rawL, -2);
				Lua.lua_rawset(this.rawL, LuaIndexes.LUA_REGISTRYINDEX);
				Lua.lua_pop(this.rawL, 1);
				Lua.xlua_pushasciistring(this.rawL, "xlua_main_thread");
				Lua.lua_pushthread(this.rawL);
				Lua.lua_rawset(this.rawL, LuaIndexes.LUA_REGISTRYINDEX);
				Lua.xlua_pushasciistring(this.rawL, "xlua_csharp_namespace");
				if (Lua.xlua_getglobal(this.rawL, "CS") != 0)
				{
					throw new Exception("get CS fail!");
				}
				Lua.lua_rawset(this.rawL, LuaIndexes.LUA_REGISTRYINDEX);
				this.translator.Alias(typeof(Type), "System.MonoType");
				if (Lua.xlua_getglobal(this.rawL, "_G") != 0)
				{
					throw new Exception("get _G fail!");
				}
				this.translator.Get<LuaTable>(this.rawL, -1, out this._G);
				Lua.lua_pop(this.rawL, 1);
				this.errorFuncRef = Lua.get_error_func_ref(this.rawL);
				if (LuaEnv.initers != null)
				{
					for (int i = 0; i < LuaEnv.initers.Count; i++)
					{
						LuaEnv.initers[i](this, this.translator);
					}
				}
				this.translator.CreateArrayMetatable(this.rawL);
				this.translator.CreateDelegateMetatable(this.rawL);
				this.translator.CreateEnumerablePairs(this.rawL);
			}
		}

		public static void AddIniter(Action<LuaEnv, ObjectTranslator> initer)
		{
			if (LuaEnv.initers == null)
			{
				LuaEnv.initers = new List<Action<LuaEnv, ObjectTranslator>>();
			}
			LuaEnv.initers.Add(initer);
		}

		public LuaTable Global
		{
			get
			{
				return this._G;
			}
		}

		public T LoadString<T>(byte[] chunk, string chunkName = "chunk", LuaTable env = null)
		{
			object luaEnvLock = this.luaEnvLock;
			T result;
			lock (luaEnvLock)
			{
				if (typeof(T) != typeof(LuaFunction) && !typeof(T).IsSubclassOf(typeof(Delegate)))
				{
					throw new InvalidOperationException(typeof(T).Name + " is not a delegate type nor LuaFunction");
				}
				IntPtr l = this.L;
				int num = Lua.lua_gettop(l);
				if (Lua.xluaL_loadbuffer(l, chunk, chunk.Length, chunkName) != 0)
				{
					this.ThrowExceptionFromError(num);
				}
				if (env != null)
				{
					env.push(l);
					Lua.lua_setfenv(l, -2);
				}
				T t = (T)((object)this.translator.GetObject(l, -1, typeof(T)));
				Lua.lua_settop(l, num);
				result = t;
			}
			return result;
		}

		public T LoadString<T>(string chunk, string chunkName = "chunk", LuaTable env = null)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(chunk);
			return this.LoadString<T>(bytes, chunkName, env);
		}

		public LuaFunction LoadString(string chunk, string chunkName = "chunk", LuaTable env = null)
		{
			return this.LoadString<LuaFunction>(chunk, chunkName, env);
		}

		public object[] DoString(byte[] chunk, string chunkName = "chunk", LuaTable env = null)
		{
			object luaEnvLock = this.luaEnvLock;
			object[] result;
			lock (luaEnvLock)
			{
				IntPtr l = this.L;
				int oldTop = Lua.lua_gettop(l);
				int num = Lua.load_error_func(l, this.errorFuncRef);
				if (Lua.xluaL_loadbuffer(l, chunk, chunk.Length, chunkName) == 0)
				{
					if (env != null)
					{
						env.push(l);
						Lua.lua_setfenv(l, -2);
					}
					if (Lua.lua_pcall(l, 0, -1, num) == 0)
					{
						Lua.lua_remove(l, num);
						return this.translator.popValues(l, oldTop);
					}
					this.ThrowExceptionFromError(oldTop);
				}
				else
				{
					this.ThrowExceptionFromError(oldTop);
				}
				result = null;
			}
			return result;
		}

		public object[] DoString(string chunk, string chunkName = "chunk", LuaTable env = null)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(chunk);
			return this.DoString(bytes, chunkName, env);
		}

		private void AddSearcher(lua_CSFunction searcher, int index)
		{
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.L;
				Lua.xlua_getloaders(l);
				if (!Lua.lua_istable(l, -1))
				{
					throw new Exception("Can not set searcher!");
				}
				uint num = Lua.xlua_objlen(l, -1);
				index = ((index < 0) ? ((int)((ulong)num + (ulong)((long)index) + 2UL)) : index);
				for (int i = (int)(num + 1U); i > index; i--)
				{
					Lua.xlua_rawgeti(l, -1, (long)(i - 1));
					Lua.xlua_rawseti(l, -2, (long)i);
				}
				Lua.lua_pushstdcallcfunction(l, searcher, 0);
				Lua.xlua_rawseti(l, -2, (long)index);
				Lua.lua_pop(l, 1);
			}
		}

		public void Alias(Type type, string alias)
		{
			this.translator.Alias(type, alias);
		}

		private static bool ObjectValidCheck(object obj)
		{
			return !(obj is UnityEngine.Object) || obj as UnityEngine.Object != null;
		}

		public void Tick()
		{
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.L;
				Queue<LuaEnv.GCAction> obj = this.refQueue;
				lock (obj)
				{
					while (this.refQueue.Count > 0)
					{
						LuaEnv.GCAction gcaction = this.refQueue.Dequeue();
						this.translator.ReleaseLuaBase(l, gcaction.Reference, gcaction.IsDelegate);
					}
				}
				this.last_check_point = this.translator.objects.Check(this.last_check_point, this.max_check_per_tick, this.object_valid_checker, this.translator.reverseMap);
			}
		}

		public void GC()
		{
			this.Tick();
		}

		public LuaTable NewTable()
		{
			object luaEnvLock = this.luaEnvLock;
			LuaTable result;
			lock (luaEnvLock)
			{
				IntPtr l = this.L;
				int newTop = Lua.lua_gettop(l);
				Lua.lua_newtable(l);
				LuaTable luaTable = (LuaTable)this.translator.GetObject(l, -1, typeof(LuaTable));
				Lua.lua_settop(l, newTop);
				result = luaTable;
			}
			return result;
		}

		public void Dispose()
		{
			this.FullGc();
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
			this.Dispose(true);
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}

		public virtual void Dispose(bool dispose)
		{
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				if (!this.disposed)
				{
					this.Tick();
					if (!this.translator.AllDelegateBridgeReleased())
					{
						throw new InvalidOperationException("try to dispose a LuaEnv with C# callback!");
					}
					ObjectTranslatorPool.Instance.Remove(this.L);
					Lua.lua_close(this.L);
					this.translator = null;
					this.rawL = IntPtr.Zero;
					this.disposed = true;
				}
			}
		}

		public void ThrowExceptionFromError(int oldTop)
		{
			object luaEnvLock = this.luaEnvLock;
			bool flag = false;
			try
			{
				Monitor.Enter(luaEnvLock, ref flag);
				object obj = this.translator.GetObject(this.L, -1);
				Lua.lua_settop(this.L, oldTop);
				Exception ex = obj as Exception;
				if (ex != null)
				{
					throw ex;
				}
				if (obj == null)
				{
					obj = "Unknown Lua Error";
				}
				throw new LuaException(obj.ToString());
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(luaEnvLock);
					goto IL_5A;
				}
				goto IL_5A;
				IL_5A:;
			}
		}

		internal void equeueGCAction(LuaEnv.GCAction action)
		{
			Queue<LuaEnv.GCAction> obj = this.refQueue;
			lock (obj)
			{
				this.refQueue.Enqueue(action);
			}
		}

		public void AddLoader(LuaEnv.CustomLoader loader)
		{
			this.customLoaders.Add(loader);
		}

		public void AddBuildin(string name, lua_CSFunction initer)
		{
			if (!Utils.IsStaticPInvokeCSFunction(initer))
			{
				throw new Exception("initer must be static and has MonoPInvokeCallback Attribute!");
			}
			this.buildin_initer.Add(name, initer);
		}

		public int GcPause
		{
			get
			{
				object luaEnvLock = this.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					int num = Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSETPAUSE, 200);
					Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSETPAUSE, num);
					result = num;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnvLock;
				lock (luaEnvLock)
				{
					Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSETPAUSE, value);
				}
			}
		}

		public int GcStepmul
		{
			get
			{
				object luaEnvLock = this.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					int num = Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSETSTEPMUL, 200);
					Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSETSTEPMUL, num);
					result = num;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnvLock;
				lock (luaEnvLock)
				{
					Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSETSTEPMUL, value);
				}
			}
		}

		public void FullGc()
		{
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				Lua.lua_gc(this.L, LuaGCOptions.LUA_GCCOLLECT, 0);
			}
		}

		public void StopGc()
		{
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSTOP, 0);
			}
		}

		public void RestartGc()
		{
			object luaEnvLock = this.luaEnvLock;
			lock (luaEnvLock)
			{
				Lua.lua_gc(this.L, LuaGCOptions.LUA_GCRESTART, 0);
			}
		}

		public bool GcStep(int data)
		{
			object luaEnvLock = this.luaEnvLock;
			bool result;
			lock (luaEnvLock)
			{
				result = (Lua.lua_gc(this.L, LuaGCOptions.LUA_GCSTEP, data) != 0);
			}
			return result;
		}

		public int Memroy
		{
			get
			{
				object luaEnvLock = this.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					result = Lua.lua_gc(this.L, LuaGCOptions.LUA_GCCOUNT, 0);
				}
				return result;
			}
		}

		public const string CSHARP_NAMESPACE = "xlua_csharp_namespace";

		public const string MAIN_SHREAD = "xlua_main_thread";

		internal IntPtr rawL;

		private LuaTable _G;

		internal ObjectTranslator translator;

		internal int errorFuncRef = -1;

		internal object luaLock = new object();

		private const int LIB_VERSION_EXPECT = 105;

		private static List<Action<LuaEnv, ObjectTranslator>> initers;

		private int last_check_point;

		private int max_check_per_tick = 20;

		private Func<object, bool> object_valid_checker = new Func<object, bool>(LuaEnv.ObjectValidCheck);

		private bool disposed;

		private Queue<LuaEnv.GCAction> refQueue = new Queue<LuaEnv.GCAction>();

		private string init_xlua = " \r\n            local metatable = {}\r\n            local rawget = rawget\r\n            local setmetatable = setmetatable\r\n            local import_type = xlua.import_type\r\n            local import_generic_type = xlua.import_generic_type\r\n            local load_assembly = xlua.load_assembly\r\n\r\n            function metatable:__index(key) \r\n                local fqn = rawget(self,'.fqn')\r\n                fqn = ((fqn and fqn .. '.') or '') .. key\r\n\r\n                local obj = import_type(fqn)\r\n\r\n                if obj == nil then\r\n                    -- It might be an assembly, so we load it too.\r\n                    obj = { ['.fqn'] = fqn }\r\n                    setmetatable(obj, metatable)\r\n                elseif obj == true then\r\n                    return rawget(self, key)\r\n                end\r\n\r\n                -- Cache this lookup\r\n                rawset(self, key, obj)\r\n                return obj\r\n            end\r\n\r\n            function metatable:__newindex()\r\n                error('No such type: ' .. rawget(self,'.fqn'), 2)\r\n            end\r\n\r\n            -- A non-type has been called; e.g. foo = System.Foo()\r\n            function metatable:__call(...)\r\n                local n = select('#', ...)\r\n                local fqn = rawget(self,'.fqn')\r\n                if n > 0 then\r\n                    local gt = import_generic_type(fqn, ...)\r\n                    if gt then\r\n                        return rawget(CS, gt)\r\n                    end\r\n                end\r\n                error('No such type: ' .. fqn, 2)\r\n            end\r\n\r\n            CS = CS or {}\r\n            setmetatable(CS, metatable)\r\n\r\n            typeof = function(t) return t.UnderlyingSystemType end\r\n            cast = xlua.cast\r\n            if not setfenv or not getfenv then\r\n                local function getfunction(level)\r\n                    local info = debug.getinfo(level + 1, 'f')\r\n                    return info and info.func\r\n                end\r\n\r\n                function setfenv(fn, env)\r\n                  if type(fn) == 'number' then fn = getfunction(fn + 1) end\r\n                  local i = 1\r\n                  while true do\r\n                    local name = debug.getupvalue(fn, i)\r\n                    if name == '_ENV' then\r\n                      debug.upvaluejoin(fn, i, (function()\r\n                        return env\r\n                      end), 1)\r\n                      break\r\n                    elseif not name then\r\n                      break\r\n                    end\r\n\r\n                    i = i + 1\r\n                  end\r\n\r\n                  return fn\r\n                end\r\n\r\n                function getfenv(fn)\r\n                  if type(fn) == 'number' then fn = getfunction(fn + 1) end\r\n                  local i = 1\r\n                  while true do\r\n                    local name, val = debug.getupvalue(fn, i)\r\n                    if name == '_ENV' then\r\n                      return val\r\n                    elseif not name then\r\n                      break\r\n                    end\r\n                    i = i + 1\r\n                  end\r\n                end\r\n            end\r\n\r\n            xlua.hotfix = function(cs, field, func)\r\n                if func == nil then func = false end\r\n                local tbl = (type(field) == 'table') and field or {[field] = func}\r\n                for k, v in pairs(tbl) do\r\n                    local cflag = ''\r\n                    if k == '.ctor' then\r\n                        cflag = '_c'\r\n                        k = 'ctor'\r\n                    end\r\n                    local f = type(v) == 'function' and v or nil\r\n                    xlua.access(cs, cflag .. '__Hotfix0_'..k, f) -- at least one\r\n                    pcall(function()\r\n                        for i = 1, 99 do\r\n                            xlua.access(cs, cflag .. '__Hotfix'..i..'_'..k, f)\r\n                        end\r\n                    end)\r\n                end\r\n                xlua.private_accessible(cs)\r\n            end\r\n            xlua.getmetatable = function(cs)\r\n                return xlua.metatable_operation(cs)\r\n            end\r\n            xlua.setmetatable = function(cs, mt)\r\n                return xlua.metatable_operation(cs, mt)\r\n            end\r\n            xlua.setclass = function(parent, name, impl)\r\n                impl.UnderlyingSystemType = parent[name].UnderlyingSystemType\r\n                rawset(parent, name, impl)\r\n            end\r\n            \r\n            local base_mt = {\r\n                __index = function(t, k)\r\n                    local csobj = t['__csobj']\r\n                    local func = csobj['<>xLuaBaseProxy_'..k]\r\n                    return function(_, ...)\r\n                         return func(csobj, ...)\r\n                    end\r\n                end\r\n            }\r\n            base = function(csobj)\r\n                return setmetatable({__csobj = csobj}, base_mt)\r\n            end\r\n            ";

		internal List<LuaEnv.CustomLoader> customLoaders = new List<LuaEnv.CustomLoader>();

		internal Dictionary<string, lua_CSFunction> buildin_initer = new Dictionary<string, lua_CSFunction>();

		internal struct GCAction
		{
			public int Reference;

			public bool IsDelegate;
		}

		public delegate byte[] CustomLoader(ref string filepath);
	}
}
