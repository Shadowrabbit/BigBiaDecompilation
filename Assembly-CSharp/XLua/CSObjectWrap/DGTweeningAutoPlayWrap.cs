using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningAutoPlayWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(AutoPlay), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(AutoPlay), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(AutoPlay), L, null, 5, 0, 0);
			Utils.RegisterObject(L, translator, -4, "None", AutoPlay.None);
			Utils.RegisterObject(L, translator, -4, "AutoPlaySequences", AutoPlay.AutoPlaySequences);
			Utils.RegisterObject(L, translator, -4, "AutoPlayTweeners", AutoPlay.AutoPlayTweeners);
			Utils.RegisterObject(L, translator, -4, "All", AutoPlay.All);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningAutoPlayWrap.__CastFrom));
			Utils.EndClassRegister(typeof(AutoPlay), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningAutoPlay(L, (AutoPlay)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.AutoPlay! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "None"))
				{
					objectTranslator.PushDGTweeningAutoPlay(L, AutoPlay.None);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "AutoPlaySequences"))
				{
					objectTranslator.PushDGTweeningAutoPlay(L, AutoPlay.AutoPlaySequences);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "AutoPlayTweeners"))
				{
					objectTranslator.PushDGTweeningAutoPlay(L, AutoPlay.AutoPlayTweeners);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "All"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.AutoPlay!");
					}
					objectTranslator.PushDGTweeningAutoPlay(L, AutoPlay.All);
				}
			}
			return 1;
		}
	}
}
