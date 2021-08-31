using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineKeyframeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Keyframe);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 7, 7, -1);
			Utils.RegisterFunc(L, -2, "time", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_time));
			Utils.RegisterFunc(L, -2, "value", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_value));
			Utils.RegisterFunc(L, -2, "inTangent", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_inTangent));
			Utils.RegisterFunc(L, -2, "outTangent", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_outTangent));
			Utils.RegisterFunc(L, -2, "inWeight", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_inWeight));
			Utils.RegisterFunc(L, -2, "outWeight", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_outWeight));
			Utils.RegisterFunc(L, -2, "weightedMode", new lua_CSFunction(UnityEngineKeyframeWrap._g_get_weightedMode));
			Utils.RegisterFunc(L, -1, "time", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_time));
			Utils.RegisterFunc(L, -1, "value", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_value));
			Utils.RegisterFunc(L, -1, "inTangent", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_inTangent));
			Utils.RegisterFunc(L, -1, "outTangent", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_outTangent));
			Utils.RegisterFunc(L, -1, "inWeight", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_inWeight));
			Utils.RegisterFunc(L, -1, "outWeight", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_outWeight));
			Utils.RegisterFunc(L, -1, "weightedMode", new lua_CSFunction(UnityEngineKeyframeWrap._s_set_weightedMode));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineKeyframeWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float time = (float)Lua.lua_tonumber(L, 2);
					float value = (float)Lua.lua_tonumber(L, 3);
					Keyframe keyframe = new Keyframe(time, value);
					objectTranslator.Push(L, keyframe);
					return 1;
				}
				if (Lua.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float time2 = (float)Lua.lua_tonumber(L, 2);
					float value2 = (float)Lua.lua_tonumber(L, 3);
					float inTangent = (float)Lua.lua_tonumber(L, 4);
					float outTangent = (float)Lua.lua_tonumber(L, 5);
					Keyframe keyframe2 = new Keyframe(time2, value2, inTangent, outTangent);
					objectTranslator.Push(L, keyframe2);
					return 1;
				}
				if (Lua.lua_gettop(L) == 7 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 7))
				{
					float time3 = (float)Lua.lua_tonumber(L, 2);
					float value3 = (float)Lua.lua_tonumber(L, 3);
					float inTangent2 = (float)Lua.lua_tonumber(L, 4);
					float outTangent2 = (float)Lua.lua_tonumber(L, 5);
					float inWeight = (float)Lua.lua_tonumber(L, 6);
					float outWeight = (float)Lua.lua_tonumber(L, 7);
					Keyframe keyframe3 = new Keyframe(time3, value3, inTangent2, outTangent2, inWeight, outWeight);
					objectTranslator.Push(L, keyframe3);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.Push(L, default(Keyframe));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Keyframe constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_time(IntPtr L)
		{
			try
			{
				Keyframe keyframe;
				ObjectTranslatorPool.Instance.Find(L).Get<Keyframe>(L, 1, out keyframe);
				Lua.lua_pushnumber(L, (double)keyframe.time);
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
		private static int _g_get_value(IntPtr L)
		{
			try
			{
				Keyframe keyframe;
				ObjectTranslatorPool.Instance.Find(L).Get<Keyframe>(L, 1, out keyframe);
				Lua.lua_pushnumber(L, (double)keyframe.value);
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
		private static int _g_get_inTangent(IntPtr L)
		{
			try
			{
				Keyframe keyframe;
				ObjectTranslatorPool.Instance.Find(L).Get<Keyframe>(L, 1, out keyframe);
				Lua.lua_pushnumber(L, (double)keyframe.inTangent);
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
		private static int _g_get_outTangent(IntPtr L)
		{
			try
			{
				Keyframe keyframe;
				ObjectTranslatorPool.Instance.Find(L).Get<Keyframe>(L, 1, out keyframe);
				Lua.lua_pushnumber(L, (double)keyframe.outTangent);
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
		private static int _g_get_inWeight(IntPtr L)
		{
			try
			{
				Keyframe keyframe;
				ObjectTranslatorPool.Instance.Find(L).Get<Keyframe>(L, 1, out keyframe);
				Lua.lua_pushnumber(L, (double)keyframe.inWeight);
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
		private static int _g_get_outWeight(IntPtr L)
		{
			try
			{
				Keyframe keyframe;
				ObjectTranslatorPool.Instance.Find(L).Get<Keyframe>(L, 1, out keyframe);
				Lua.lua_pushnumber(L, (double)keyframe.outWeight);
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
		private static int _g_get_weightedMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				objectTranslator.Push(L, keyframe.weightedMode);
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
		private static int _s_set_time(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				keyframe.time = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.Update(L, 1, keyframe);
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
		private static int _s_set_value(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				keyframe.value = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.Update(L, 1, keyframe);
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
		private static int _s_set_inTangent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				keyframe.inTangent = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.Update(L, 1, keyframe);
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
		private static int _s_set_outTangent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				keyframe.outTangent = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.Update(L, 1, keyframe);
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
		private static int _s_set_inWeight(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				keyframe.inWeight = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.Update(L, 1, keyframe);
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
		private static int _s_set_outWeight(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				keyframe.outWeight = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.Update(L, 1, keyframe);
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
		private static int _s_set_weightedMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Keyframe keyframe;
				objectTranslator.Get<Keyframe>(L, 1, out keyframe);
				WeightedMode weightedMode;
				objectTranslator.Get<WeightedMode>(L, 2, out weightedMode);
				keyframe.weightedMode = weightedMode;
				objectTranslator.Update(L, 1, keyframe);
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
