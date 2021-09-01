using System;
using UnityEngine;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestLuaBehaviourWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(LuaBehaviour);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 2, 2, -1);
			Utils.RegisterFunc(L, -2, "luaScript", new lua_CSFunction(XLuaTestLuaBehaviourWrap._g_get_luaScript));
			Utils.RegisterFunc(L, -2, "injections", new lua_CSFunction(XLuaTestLuaBehaviourWrap._g_get_injections));
			Utils.RegisterFunc(L, -1, "luaScript", new lua_CSFunction(XLuaTestLuaBehaviourWrap._s_set_luaScript));
			Utils.RegisterFunc(L, -1, "injections", new lua_CSFunction(XLuaTestLuaBehaviourWrap._s_set_injections));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestLuaBehaviourWrap.__CreateInstance), 1, 0, 0);
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
					LuaBehaviour o = new LuaBehaviour();
					objectTranslator.Push(L, o);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.LuaBehaviour constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_luaScript(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				LuaBehaviour luaBehaviour = (LuaBehaviour)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, luaBehaviour.luaScript);
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
		private static int _g_get_injections(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				LuaBehaviour luaBehaviour = (LuaBehaviour)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, luaBehaviour.injections);
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
		private static int _s_set_luaScript(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((LuaBehaviour)objectTranslator.FastGetCSObj(L, 1)).luaScript = (TextAsset)objectTranslator.GetObject(L, 2, typeof(TextAsset));
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _s_set_injections(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((LuaBehaviour)objectTranslator.FastGetCSObj(L, 1)).injections = (Injection[])objectTranslator.GetObject(L, 2, typeof(Injection[]));
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return 0;
		}
	}
}
