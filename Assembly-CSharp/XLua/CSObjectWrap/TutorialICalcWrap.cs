using System;
using Tutorial;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class TutorialICalcWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(ICalc);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 1, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "add", new lua_CSFunction(TutorialICalcWrap._m_add));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(TutorialICalcWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "Tutorial.ICalc does not have a constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_add(IntPtr L)
		{
			int result;
			try
			{
				ICalc calc = (ICalc)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int a = Lua.xlua_tointeger(L, 2);
				int b = Lua.xlua_tointeger(L, 3);
				int value = calc.add(a, b);
				Lua.xlua_pushinteger(L, value);
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
	}
}
