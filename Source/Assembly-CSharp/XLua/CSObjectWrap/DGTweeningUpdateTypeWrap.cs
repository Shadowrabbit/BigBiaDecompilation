using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningUpdateTypeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(UpdateType), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(UpdateType), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(UpdateType), L, null, 5, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Normal", UpdateType.Normal);
			Utils.RegisterObject(L, translator, -4, "Late", UpdateType.Late);
			Utils.RegisterObject(L, translator, -4, "Fixed", UpdateType.Fixed);
			Utils.RegisterObject(L, translator, -4, "Manual", UpdateType.Manual);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningUpdateTypeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(UpdateType), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningUpdateType(L, (UpdateType)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.UpdateType! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Normal"))
				{
					objectTranslator.PushDGTweeningUpdateType(L, UpdateType.Normal);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Late"))
				{
					objectTranslator.PushDGTweeningUpdateType(L, UpdateType.Late);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Fixed"))
				{
					objectTranslator.PushDGTweeningUpdateType(L, UpdateType.Fixed);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "Manual"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.UpdateType!");
					}
					objectTranslator.PushDGTweeningUpdateType(L, UpdateType.Manual);
				}
			}
			return 1;
		}
	}
}
