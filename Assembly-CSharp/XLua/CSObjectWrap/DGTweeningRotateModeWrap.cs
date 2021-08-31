using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningRotateModeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(RotateMode), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(RotateMode), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(RotateMode), L, null, 5, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Fast", RotateMode.Fast);
			Utils.RegisterObject(L, translator, -4, "FastBeyond360", RotateMode.FastBeyond360);
			Utils.RegisterObject(L, translator, -4, "WorldAxisAdd", RotateMode.WorldAxisAdd);
			Utils.RegisterObject(L, translator, -4, "LocalAxisAdd", RotateMode.LocalAxisAdd);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningRotateModeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(RotateMode), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningRotateMode(L, (RotateMode)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.RotateMode! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Fast"))
				{
					objectTranslator.PushDGTweeningRotateMode(L, RotateMode.Fast);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "FastBeyond360"))
				{
					objectTranslator.PushDGTweeningRotateMode(L, RotateMode.FastBeyond360);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "WorldAxisAdd"))
				{
					objectTranslator.PushDGTweeningRotateMode(L, RotateMode.WorldAxisAdd);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "LocalAxisAdd"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.RotateMode!");
					}
					objectTranslator.PushDGTweeningRotateMode(L, RotateMode.LocalAxisAdd);
				}
			}
			return 1;
		}
	}
}
