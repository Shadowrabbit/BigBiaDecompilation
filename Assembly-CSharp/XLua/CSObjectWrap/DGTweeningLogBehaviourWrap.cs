using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningLogBehaviourWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(LogBehaviour), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(LogBehaviour), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(LogBehaviour), L, null, 4, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Default", LogBehaviour.Default);
			Utils.RegisterObject(L, translator, -4, "Verbose", LogBehaviour.Verbose);
			Utils.RegisterObject(L, translator, -4, "ErrorsOnly", LogBehaviour.ErrorsOnly);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(DGTweeningLogBehaviourWrap.__CastFrom));
			Utils.EndClassRegister(typeof(LogBehaviour), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushDGTweeningLogBehaviour(L, (LogBehaviour)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for DG.Tweening.LogBehaviour! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "Default"))
				{
					objectTranslator.PushDGTweeningLogBehaviour(L, LogBehaviour.Default);
				}
				else if (Lua.xlua_is_eq_str(L, 1, "Verbose"))
				{
					objectTranslator.PushDGTweeningLogBehaviour(L, LogBehaviour.Verbose);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "ErrorsOnly"))
					{
						return Lua.luaL_error(L, "invalid string for DG.Tweening.LogBehaviour!");
					}
					objectTranslator.PushDGTweeningLogBehaviour(L, LogBehaviour.ErrorsOnly);
				}
			}
			return 1;
		}
	}
}
