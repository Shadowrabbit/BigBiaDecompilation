using System;
using Tutorial;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class TutorialTestEnumWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(TestEnum), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(TestEnum), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(TestEnum), L, null, 3, 0, 0);
			Utils.RegisterObject(L, translator, -4, "E1", TestEnum.E1);
			Utils.RegisterObject(L, translator, -4, "E2", TestEnum.E2);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(TutorialTestEnumWrap.__CastFrom));
			Utils.EndClassRegister(typeof(TestEnum), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushTutorialTestEnum(L, (TestEnum)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for Tutorial.TestEnum! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "E1"))
				{
					objectTranslator.PushTutorialTestEnum(L, TestEnum.E1);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "E2"))
					{
						return Lua.luaL_error(L, "invalid string for Tutorial.TestEnum!");
					}
					objectTranslator.PushTutorialTestEnum(L, TestEnum.E2);
				}
			}
			return 1;
		}
	}
}
