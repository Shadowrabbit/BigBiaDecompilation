using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestMyStructWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(MyStruct);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 4, 4, -1);
			Utils.RegisterFunc(L, -2, "a", new lua_CSFunction(XLuaTestMyStructWrap._g_get_a));
			Utils.RegisterFunc(L, -2, "b", new lua_CSFunction(XLuaTestMyStructWrap._g_get_b));
			Utils.RegisterFunc(L, -2, "c", new lua_CSFunction(XLuaTestMyStructWrap._g_get_c));
			Utils.RegisterFunc(L, -2, "e", new lua_CSFunction(XLuaTestMyStructWrap._g_get_e));
			Utils.RegisterFunc(L, -1, "a", new lua_CSFunction(XLuaTestMyStructWrap._s_set_a));
			Utils.RegisterFunc(L, -1, "b", new lua_CSFunction(XLuaTestMyStructWrap._s_set_b));
			Utils.RegisterFunc(L, -1, "c", new lua_CSFunction(XLuaTestMyStructWrap._s_set_c));
			Utils.RegisterFunc(L, -1, "e", new lua_CSFunction(XLuaTestMyStructWrap._s_set_e));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestMyStructWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					int p = Lua.xlua_tointeger(L, 2);
					int p2 = Lua.xlua_tointeger(L, 3);
					MyStruct val = new MyStruct(p, p2);
					objectTranslator.PushXLuaTestMyStruct(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushXLuaTestMyStruct(L, default(MyStruct));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.MyStruct constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_a(IntPtr L)
		{
			try
			{
				MyStruct myStruct;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out myStruct);
				Lua.xlua_pushinteger(L, myStruct.a);
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
		private static int _g_get_b(IntPtr L)
		{
			try
			{
				MyStruct myStruct;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out myStruct);
				Lua.xlua_pushinteger(L, myStruct.b);
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
		private static int _g_get_c(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MyStruct myStruct;
				objectTranslator.Get(L, 1, out myStruct);
				objectTranslator.PushDecimal(L, myStruct.c);
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
		private static int _g_get_e(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MyStruct myStruct;
				objectTranslator.Get(L, 1, out myStruct);
				objectTranslator.PushXLuaTestPedding(L, myStruct.e);
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
		private static int _s_set_a(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MyStruct val;
				objectTranslator.Get(L, 1, out val);
				val.a = Lua.xlua_tointeger(L, 2);
				objectTranslator.UpdateXLuaTestMyStruct(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_b(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MyStruct val;
				objectTranslator.Get(L, 1, out val);
				val.b = Lua.xlua_tointeger(L, 2);
				objectTranslator.UpdateXLuaTestMyStruct(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_c(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MyStruct val;
				objectTranslator.Get(L, 1, out val);
				decimal c;
				objectTranslator.Get(L, 2, out c);
				val.c = c;
				objectTranslator.UpdateXLuaTestMyStruct(L, 1, val);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_e(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				MyStruct val;
				objectTranslator.Get(L, 1, out val);
				Pedding e;
				objectTranslator.Get(L, 2, out e);
				val.e = e;
				objectTranslator.UpdateXLuaTestMyStruct(L, 1, val);
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
