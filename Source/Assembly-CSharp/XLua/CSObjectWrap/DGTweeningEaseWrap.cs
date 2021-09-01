using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningEaseWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(Ease), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(Ease), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(Ease), L, null, 39, 0, 0);
			Utils.RegisterEnumType(L, typeof(Ease));
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningEaseWrap.__CastFrom));
			Utils.EndClassRegister(typeof(Ease), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes != LuaTypes.LUA_TNUMBER)
			{
				if (luaTypes == LuaTypes.LUA_TSTRING)
				{
					try
					{
						objectTranslator.TranslateToEnumToTop(L, typeof(Ease), 1);
						return 1;
					}
					catch (Exception ex)
					{
						string str = "cast to ";
						Type typeFromHandle = typeof(Ease);
						string str2 = (typeFromHandle != null) ? typeFromHandle.ToString() : null;
						string str3 = " exception:";
						Exception ex2 = ex;
						return Lua.luaL_error(L, str + str2 + str3 + ((ex2 != null) ? ex2.ToString() : null));
					}
				}
				return Lua.luaL_error(L, "invalid lua type for DG.Tweening.Ease! Expect number or string, got + " + luaTypes.ToString());
			}
			objectTranslator.PushDGTweeningEase(L, (Ease)Lua.xlua_tointeger(L, 1));
			return 1;
		}
	}
}
