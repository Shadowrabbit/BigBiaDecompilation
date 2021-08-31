using System;
using Tutorial;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class TutorialDerivedClassTestEnumInnerWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(DerivedClass.TestEnumInner), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(DerivedClass.TestEnumInner), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(DerivedClass.TestEnumInner), L, null, 3, 0, 0);
			Utils.RegisterObject(L, translator, -4, "E3", DerivedClass.TestEnumInner.E3);
			Utils.RegisterObject(L, translator, -4, "E4", DerivedClass.TestEnumInner.E4);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(TutorialDerivedClassTestEnumInnerWrap.__CastFrom));
			Utils.EndClassRegister(typeof(DerivedClass.TestEnumInner), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushTutorialDerivedClassTestEnumInner(L, (DerivedClass.TestEnumInner)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for Tutorial.DerivedClass.TestEnumInner! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "E3"))
				{
					objectTranslator.PushTutorialDerivedClassTestEnumInner(L, DerivedClass.TestEnumInner.E3);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "E4"))
					{
						return Lua.luaL_error(L, "invalid string for Tutorial.DerivedClass.TestEnumInner!");
					}
					objectTranslator.PushTutorialDerivedClassTestEnumInner(L, DerivedClass.TestEnumInner.E4);
				}
			}
			return 1;
		}
	}
}
