using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestBaseTestWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(BaseTest);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 3, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "Foo", new lua_CSFunction(XLuaTestBaseTestWrap._m_Foo));
			Utils.RegisterFunc(L, -3, "Proxy", new lua_CSFunction(XLuaTestBaseTestWrap._m_Proxy));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(XLuaTestBaseTestWrap._m_ToString));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestBaseTestWrap.__CreateInstance), 1, 0, 0);
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
					BaseTest o = new BaseTest();
					objectTranslator.Push(L, o);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.BaseTest constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Foo(IntPtr L)
		{
			int result;
			try
			{
				BaseTestBase<InnerTypeTest> baseTestBase = (BaseTest)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int p = Lua.xlua_tointeger(L, 2);
				baseTestBase.Foo(p);
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Proxy(IntPtr L)
		{
			int result;
			try
			{
				BaseTest baseTest = (BaseTest)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int p = Lua.xlua_tointeger(L, 2);
				baseTest.Proxy(p);
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToString(IntPtr L)
		{
			int result;
			try
			{
				string str = ((BaseTest)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ToString();
				Lua.lua_pushstring(L, str);
				result = 1;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}
	}
}
