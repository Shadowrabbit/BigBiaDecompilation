using System;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestFooExtensionWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(FooExtension);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestFooExtensionWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "XLuaTest.FooExtension does not have a constructor!");
		}
	}
}
