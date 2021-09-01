using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestMyEnumWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(MyEnum), L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeof(MyEnum), L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeof(MyEnum), L, null, 3, 0, 0);
			Utils.RegisterObject(L, translator, -4, "E1", MyEnum.E1);
			Utils.RegisterObject(L, translator, -4, "E2", MyEnum.E2);
			Utils.RegisterFunc(L, -4, "__CastFrom", new lua_CSFunction(XLuaTestMyEnumWrap.__CastFrom));
			Utils.EndClassRegister(typeof(MyEnum), L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CastFrom(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes luaTypes = Lua.lua_type(L, 1);
			if (luaTypes == LuaTypes.LUA_TNUMBER)
			{
				objectTranslator.PushXLuaTestMyEnum(L, (MyEnum)Lua.xlua_tointeger(L, 1));
			}
			else
			{
				if (luaTypes != LuaTypes.LUA_TSTRING)
				{
					return Lua.luaL_error(L, "invalid lua type for XLuaTest.MyEnum! Expect number or string, got + " + luaTypes.ToString());
				}
				if (Lua.xlua_is_eq_str(L, 1, "E1"))
				{
					objectTranslator.PushXLuaTestMyEnum(L, MyEnum.E1);
				}
				else
				{
					if (!Lua.xlua_is_eq_str(L, 1, "E2"))
					{
						return Lua.luaL_error(L, "invalid string for XLuaTest.MyEnum!");
					}
					objectTranslator.PushXLuaTestMyEnum(L, MyEnum.E2);
				}
			}
			return 1;
		}
	}
}
