using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningLoopTypeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(LoopType), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(LoopType), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(LoopType), L, null, 4, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Restart", LoopType.Restart);
			Utils.RegisterObject(L, translator, -4, "Yoyo", LoopType.Yoyo);
			Utils.RegisterObject(L, translator, -4, "Incremental", LoopType.Incremental);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningLoopTypeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(LoopType), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningLoopType(L, (LoopType)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.LoopType! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Restart"))
				{
					objectTranslator.PushDGTweeningLoopType(L, LoopType.Restart);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Yoyo"))
				{
					objectTranslator.PushDGTweeningLoopType(L, LoopType.Yoyo);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "Incremental"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.LoopType!");
					}
					objectTranslator.PushDGTweeningLoopType(L, LoopType.Incremental);
				}
			}
			return 1;
		}
	}
}
