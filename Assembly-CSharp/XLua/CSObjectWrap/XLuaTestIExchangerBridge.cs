using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestIExchangerBridge : LuaBase, IExchanger
	{
		public static LuaBase __Create(int reference, LuaEnv luaenv)
		{
			return new XLuaTestIExchangerBridge(reference, luaenv);
		}

		public XLuaTestIExchangerBridge(int reference, LuaEnv luaenv) : base(reference, luaenv)
		{
		}

		void IExchanger.exchange(Array arr)
		{
			object luaEnvLock = this.luaEnv.luaEnvLock;
			lock (luaEnvLock)
			{
				IntPtr l = this.luaEnv.L;
				int num = Lua.load_error_func(l, this.luaEnv.errorFuncRef);
				ObjectTranslator translator = this.luaEnv.translator;
				Lua.lua_getref(l, this.luaReference);
				Lua.xlua_pushasciistring(l, "exchange");
				if (Lua.xlua_pgettable(l, -2) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				if (!Lua.lua_isfunction(l, -1))
				{
					Lua.xlua_pushasciistring(l, "no such function exchange");
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_pushvalue(l, -2);
				Lua.lua_remove(l, -3);
				translator.Push(l, arr);
				if (Lua.lua_pcall(l, 2, 0, num) != 0)
				{
					this.luaEnv.ThrowExceptionFromError(num - 1);
				}
				Lua.lua_settop(l, num - 1);
			}
		}
	}
}
