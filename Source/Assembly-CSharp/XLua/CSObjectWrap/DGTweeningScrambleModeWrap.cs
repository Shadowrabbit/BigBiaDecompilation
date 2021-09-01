using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningScrambleModeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(ScrambleMode), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(ScrambleMode), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(ScrambleMode), L, null, 7, 0, 0);
			Utils.RegisterObject(L, translator, -4, "None", ScrambleMode.None);
			Utils.RegisterObject(L, translator, -4, "All", ScrambleMode.All);
			Utils.RegisterObject(L, translator, -4, "Uppercase", ScrambleMode.Uppercase);
			Utils.RegisterObject(L, translator, -4, "Lowercase", ScrambleMode.Lowercase);
			Utils.RegisterObject(L, translator, -4, "Numerals", ScrambleMode.Numerals);
			Utils.RegisterObject(L, translator, -4, "Custom", ScrambleMode.Custom);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningScrambleModeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(ScrambleMode), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningScrambleMode(L, (ScrambleMode)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.ScrambleMode! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "None"))
				{
					objectTranslator.PushDGTweeningScrambleMode(L, ScrambleMode.None);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "All"))
				{
					objectTranslator.PushDGTweeningScrambleMode(L, ScrambleMode.All);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Uppercase"))
				{
					objectTranslator.PushDGTweeningScrambleMode(L, ScrambleMode.Uppercase);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Lowercase"))
				{
					objectTranslator.PushDGTweeningScrambleMode(L, ScrambleMode.Lowercase);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Numerals"))
				{
					objectTranslator.PushDGTweeningScrambleMode(L, ScrambleMode.Numerals);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "Custom"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.ScrambleMode!");
					}
					objectTranslator.PushDGTweeningScrambleMode(L, ScrambleMode.Custom);
				}
			}
			return 1;
		}
	}
}
