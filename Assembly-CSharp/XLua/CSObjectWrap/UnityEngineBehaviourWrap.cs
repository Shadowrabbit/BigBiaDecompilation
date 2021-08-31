using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineBehaviourWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Behaviour);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 2, 1, -1);
			Utils.RegisterFunc(L, -2, "enabled", new lua_CSFunction(UnityEngineBehaviourWrap._g_get_enabled));
			Utils.RegisterFunc(L, -2, "isActiveAndEnabled", new lua_CSFunction(UnityEngineBehaviourWrap._g_get_isActiveAndEnabled));
			Utils.RegisterFunc(L, -1, "enabled", new lua_CSFunction(UnityEngineBehaviourWrap._s_set_enabled));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineBehaviourWrap.__CreateInstance), 1, 0, 0);
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
					Behaviour o = new Behaviour();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Behaviour constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_enabled(IntPtr L)
		{
			try
			{
				Behaviour behaviour = (Behaviour)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, behaviour.enabled);
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
		private static int _g_get_isActiveAndEnabled(IntPtr L)
		{
			try
			{
				Behaviour behaviour = (Behaviour)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, behaviour.isActiveAndEnabled);
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
		private static int _s_set_enabled(IntPtr L)
		{
			try
			{
				((Behaviour)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).enabled = Lua.lua_toboolean(L, 2);
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
