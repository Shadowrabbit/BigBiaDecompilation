using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestPeddingWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Pedding);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 1, 1, -1);
			Utils.RegisterFunc(L, -2, "c", new lua_CSFunction(XLuaTestPeddingWrap._g_get_c));
			Utils.RegisterFunc(L, -1, "c", new lua_CSFunction(XLuaTestPeddingWrap._s_set_c));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestPeddingWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushXLuaTestPedding(L, default(Pedding));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.Pedding constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_c(IntPtr L)
		{
			try
			{
				Pedding pedding;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out pedding);
				Lua.xlua_pushinteger(L, (int)pedding.c);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_c(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Pedding val;
				objectTranslator.Get(L, 1, out val);
				val.c = (byte)Lua.xlua_tointeger(L, 2);
				objectTranslator.UpdateXLuaTestPedding(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}
	}
}
