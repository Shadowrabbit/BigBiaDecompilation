using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningTweenTypeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(TweenType), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(TweenType), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(TweenType), L, null, 4, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Tweener", TweenType.Tweener);
			Utils.RegisterObject(L, translator, -4, "Sequence", TweenType.Sequence);
			Utils.RegisterObject(L, translator, -4, "Callback", TweenType.Callback);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningTweenTypeWrap.__CastFrom));
			Utils.EndClassRegister(typeof(TweenType), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningTweenType(L, (TweenType)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.TweenType! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Tweener"))
				{
					objectTranslator.PushDGTweeningTweenType(L, TweenType.Tweener);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Sequence"))
				{
					objectTranslator.PushDGTweeningTweenType(L, TweenType.Sequence);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "Callback"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.TweenType!");
					}
					objectTranslator.PushDGTweeningTweenType(L, TweenType.Callback);
				}
			}
			return 1;
		}
	}
}
