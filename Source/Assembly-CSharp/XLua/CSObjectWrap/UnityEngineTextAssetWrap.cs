using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineTextAssetWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(TextAsset);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 1, 2, 0, -1);
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineTextAssetWrap._m_ToString));
			Utils.RegisterFunc(L, -2, "bytes", new lua_CSFunction(UnityEngineTextAssetWrap._g_get_bytes));
			Utils.RegisterFunc(L, -2, "text", new lua_CSFunction(UnityEngineTextAssetWrap._g_get_text));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineTextAssetWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 1)
				{
					TextAsset o = new TextAsset();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (Lua.lua_gettop(L) == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					TextAsset o2 = new TextAsset(Lua.lua_tostring(L, 2));
					objectTranslator.Push(L, o2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.TextAsset constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToString(IntPtr L)
		{
			int result;
			try
			{
				string str = ((TextAsset)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ToString();
				Lua.lua_pushstring(L, str);
				result = 1;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_bytes(IntPtr L)
		{
			try
			{
				TextAsset textAsset = (TextAsset)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, textAsset.bytes);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_text(IntPtr L)
		{
			try
			{
				TextAsset textAsset = (TextAsset)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, textAsset.text);
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 1;
		}
	}
}
