using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningPathModeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(PathMode), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(PathMode), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(PathMode), L, null, 5, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Ignore", PathMode.Ignore);
			Utils.RegisterObject(L, translator, -4, "Full3D", PathMode.Full3D);
			Utils.RegisterObject(L, translator, -4, "TopDown2D", PathMode.TopDown2D);
			Utils.RegisterObject(L, translator, -4, "Sidescroller2D", PathMode.Sidescroller2D);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningPathModeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(PathMode), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningPathMode(L, (PathMode)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.PathMode! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Ignore"))
				{
					objectTranslator.PushDGTweeningPathMode(L, PathMode.Ignore);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Full3D"))
				{
					objectTranslator.PushDGTweeningPathMode(L, PathMode.Full3D);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "TopDown2D"))
				{
					objectTranslator.PushDGTweeningPathMode(L, PathMode.TopDown2D);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "Sidescroller2D"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.PathMode!");
					}
					objectTranslator.PushDGTweeningPathMode(L, PathMode.Sidescroller2D);
				}
			}
			return 1;
		}
	}
}
