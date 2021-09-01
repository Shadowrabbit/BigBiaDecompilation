using System;
using Tutorial;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class TutorialBaseClassWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(BaseClass);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 2, 1, 1, -1);
			Utils.RegisterFunc(L, -3, "BMFunc", new lua_CSFunction(TutorialBaseClassWrap._m_BMFunc));
			Utils.RegisterFunc(L, -3, "GetSomeBaseData", new lua_CSFunction(TutorialBaseClassWrap._m_GetSomeBaseData));
			Utils.RegisterFunc(L, -2, "BMF", new lua_CSFunction(TutorialBaseClassWrap._g_get_BMF));
			Utils.RegisterFunc(L, -1, "BMF", new lua_CSFunction(TutorialBaseClassWrap._s_set_BMF));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(TutorialBaseClassWrap.__CreateInstance), 2, 1, 1);
			Utils.RegisterFunc(L, -4, "BSFunc", new lua_CSFunction(TutorialBaseClassWrap._m_BSFunc_xlua_st_));
			Utils.RegisterFunc(L, -2, "BSF", new lua_CSFunction(TutorialBaseClassWrap._g_get_BSF));
			Utils.RegisterFunc(L, -1, "BSF", new lua_CSFunction(TutorialBaseClassWrap._s_set_BSF));
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
					BaseClass o = new BaseClass();
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
			return Lua.luaL_error(L, "invalid arguments to Tutorial.BaseClass constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_BSFunc_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				BaseClass.BSFunc();
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
		private static int _m_BMFunc(IntPtr L)
		{
			int result;
			try
			{
				((BaseClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).BMFunc();
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
		private static int _m_GetSomeBaseData(IntPtr L)
		{
			int result;
			try
			{
				int someBaseData = ((BaseClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetSomeBaseData();
				Lua.xlua_pushinteger(L, someBaseData);
				result = 1;
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
		private static int _g_get_BMF(IntPtr L)
		{
			try
			{
				BaseClass baseClass = (BaseClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, baseClass.BMF);
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
		private static int _g_get_BSF(IntPtr L)
		{
			try
			{
				Lua.xlua_pushinteger(L, BaseClass.BSF);
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
		private static int _s_set_BMF(IntPtr L)
		{
			try
			{
				((BaseClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).BMF = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_BSF(IntPtr L)
		{
			try
			{
				BaseClass.BSF = Lua.xlua_tointeger(L, 1);
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
