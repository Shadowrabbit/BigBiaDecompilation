using System;
using System.Collections;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class SystemCollectionsIEnumeratorBridge : LuaBase, IEnumerator
	{
		public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
			return new SystemCollectionsIEnumeratorBridge(reference, luaenv);
		}

		public SystemCollectionsIEnumeratorBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		bool IEnumerator.MoveNext()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			bool result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "MoveNext");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function MoveNext");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				bool flag2 = Lua.lua_toboolean(l, num + 1);
				Lua.lua_settop(l, num - 1);
				result = flag2;
			}
			return result;
		}

		void IEnumerator.Reset()
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "Reset");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function Reset");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				if (Lua.lua_pcall(l, 1, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}

		object IEnumerator.Current
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				object result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					ObjectTranslator translator = this.luaEnv.translator;
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "Current");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					object @object = translator.GetObject(l, -1, typeof(object));
					Lua.lua_pop(l, 2);
					result = @object;
				}
				return result;
			}
		}
	}
}
