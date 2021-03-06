using System;
using DG.Tweening;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningShortcutExtensionsWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(ShortcutExtensions);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningShortcutExtensionsWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "DG.Tweening.ShortcutExtensions does not have a constructor!");
		}
	}
}
