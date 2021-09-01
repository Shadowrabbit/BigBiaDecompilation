using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningPathTypeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(PathType), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(PathType), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(PathType), L, null, 4, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Linear", PathType.Linear);
			Utils.RegisterObject(L, translator, -4, "CatmullRom", PathType.CatmullRom);
			Utils.RegisterObject(L, translator, -4, "CubicBezier", PathType.CubicBezier);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningPathTypeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(PathType), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningPathType(L, (PathType)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.PathType! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Linear"))
				{
					objectTranslator.PushDGTweeningPathType(L, PathType.Linear);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "CatmullRom"))
				{
					objectTranslator.PushDGTweeningPathType(L, PathType.CatmullRom);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "CubicBezier"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.PathType!");
					}
					objectTranslator.PushDGTweeningPathType(L, PathType.CubicBezier);
				}
			}
			return 1;
		}
	}
}
