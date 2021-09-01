using System;
using Tutorial;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class TutorialCSCallLuaItfDBridge : LuaBase, CSCallLua.ItfD
	{
		public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
			return new TutorialCSCallLuaItfDBridge(reference, luaenv);
		}

		public TutorialCSCallLuaItfDBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		int CSCallLua.ItfD.add(int a, int b)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			int result;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "add");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function add");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				Lua.xlua_pushinteger(l, a);
				Lua.xlua_pushinteger(l, b);
				if (Lua.lua_pcall(l, 3, 1, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				int num2 = Lua.xlua_tointeger(l, num + 1);
				Lua.lua_settop(l, num - 1);
				result = num2;
			}
			return result;
		}

		int CSCallLua.ItfD.f1
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "f1");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					int num = Lua.xlua_tointeger(l, -1);
					Lua.lua_pop(l, 2);
					result = num;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "f1");
					Lua.xlua_pushinteger(l, value);
					if (Lua.xlua_psettable(l, -3) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					Lua.lua_pop(l, 1);
				}
			}
		}

		int CSCallLua.ItfD.f2
		{
			get
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				int result;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "f2");
					if (Lua.xlua_pgettable(l, -2) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					int num = Lua.xlua_tointeger(l, -1);
					Lua.lua_pop(l, 2);
					result = num;
				}
				return result;
			}
			set
			{
				object luaEnvLock = this.luaEnv.luaEnvLock;
				lock (luaEnvLock)
				{
					IntPtr l = this.luaEnv.L;
					int oldTop = Lua.lua_gettop(l);
					Lua.lua_getref(l, this.luaReference);
					Lua.xlua_pushasciistring(l, "f2");
					Lua.xlua_pushinteger(l, value);
					if (Lua.xlua_psettable(l, -3) != 0)
					{
						this.luaEnv.ThrowExceptionFromError(oldTop);
					}
					Lua.lua_pop(l, 1);
				}
			}
		}
	}
}
