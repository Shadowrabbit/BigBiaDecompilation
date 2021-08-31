using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineTimeWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Time);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineTimeWrap.__CreateInstance), 1, 25, 6);
			Utils.RegisterFunc(L, -2, "time", new lua_CSFunction(UnityEngineTimeWrap._g_get_time));
			Utils.RegisterFunc(L, -2, "timeAsDouble", new lua_CSFunction(UnityEngineTimeWrap._g_get_timeAsDouble));
			Utils.RegisterFunc(L, -2, "timeSinceLevelLoad", new lua_CSFunction(UnityEngineTimeWrap._g_get_timeSinceLevelLoad));
			Utils.RegisterFunc(L, -2, "timeSinceLevelLoadAsDouble", new lua_CSFunction(UnityEngineTimeWrap._g_get_timeSinceLevelLoadAsDouble));
			Utils.RegisterFunc(L, -2, "deltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_deltaTime));
			Utils.RegisterFunc(L, -2, "fixedTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_fixedTime));
			Utils.RegisterFunc(L, -2, "fixedTimeAsDouble", new lua_CSFunction(UnityEngineTimeWrap._g_get_fixedTimeAsDouble));
			Utils.RegisterFunc(L, -2, "unscaledTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_unscaledTime));
			Utils.RegisterFunc(L, -2, "unscaledTimeAsDouble", new lua_CSFunction(UnityEngineTimeWrap._g_get_unscaledTimeAsDouble));
			Utils.RegisterFunc(L, -2, "fixedUnscaledTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_fixedUnscaledTime));
			Utils.RegisterFunc(L, -2, "fixedUnscaledTimeAsDouble", new lua_CSFunction(UnityEngineTimeWrap._g_get_fixedUnscaledTimeAsDouble));
			Utils.RegisterFunc(L, -2, "unscaledDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_unscaledDeltaTime));
			Utils.RegisterFunc(L, -2, "fixedUnscaledDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_fixedUnscaledDeltaTime));
			Utils.RegisterFunc(L, -2, "fixedDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_fixedDeltaTime));
			Utils.RegisterFunc(L, -2, "maximumDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_maximumDeltaTime));
			Utils.RegisterFunc(L, -2, "smoothDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_smoothDeltaTime));
			Utils.RegisterFunc(L, -2, "maximumParticleDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_maximumParticleDeltaTime));
			Utils.RegisterFunc(L, -2, "timeScale", new lua_CSFunction(UnityEngineTimeWrap._g_get_timeScale));
			Utils.RegisterFunc(L, -2, "frameCount", new lua_CSFunction(UnityEngineTimeWrap._g_get_frameCount));
			Utils.RegisterFunc(L, -2, "renderedFrameCount", new lua_CSFunction(UnityEngineTimeWrap._g_get_renderedFrameCount));
			Utils.RegisterFunc(L, -2, "realtimeSinceStartup", new lua_CSFunction(UnityEngineTimeWrap._g_get_realtimeSinceStartup));
			Utils.RegisterFunc(L, -2, "realtimeSinceStartupAsDouble", new lua_CSFunction(UnityEngineTimeWrap._g_get_realtimeSinceStartupAsDouble));
			Utils.RegisterFunc(L, -2, "captureDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._g_get_captureDeltaTime));
			Utils.RegisterFunc(L, -2, "captureFramerate", new lua_CSFunction(UnityEngineTimeWrap._g_get_captureFramerate));
			Utils.RegisterFunc(L, -2, "inFixedTimeStep", new lua_CSFunction(UnityEngineTimeWrap._g_get_inFixedTimeStep));
			Utils.RegisterFunc(L, -1, "fixedDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._s_set_fixedDeltaTime));
			Utils.RegisterFunc(L, -1, "maximumDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._s_set_maximumDeltaTime));
			Utils.RegisterFunc(L, -1, "maximumParticleDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._s_set_maximumParticleDeltaTime));
			Utils.RegisterFunc(L, -1, "timeScale", new lua_CSFunction(UnityEngineTimeWrap._s_set_timeScale));
			Utils.RegisterFunc(L, -1, "captureDeltaTime", new lua_CSFunction(UnityEngineTimeWrap._s_set_captureDeltaTime));
			Utils.RegisterFunc(L, -1, "captureFramerate", new lua_CSFunction(UnityEngineTimeWrap._s_set_captureFramerate));
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
					Time o = new Time();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Time constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_time(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.time);
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
		private static int _g_get_timeAsDouble(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, Time.timeAsDouble);
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
		private static int _g_get_timeSinceLevelLoad(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.timeSinceLevelLoad);
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
		private static int _g_get_timeSinceLevelLoadAsDouble(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, Time.timeSinceLevelLoadAsDouble);
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
		private static int _g_get_deltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.deltaTime);
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
		private static int _g_get_fixedTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.fixedTime);
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
		private static int _g_get_fixedTimeAsDouble(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, Time.fixedTimeAsDouble);
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
		private static int _g_get_unscaledTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.unscaledTime);
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
		private static int _g_get_unscaledTimeAsDouble(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, Time.unscaledTimeAsDouble);
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
		private static int _g_get_fixedUnscaledTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.fixedUnscaledTime);
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
		private static int _g_get_fixedUnscaledTimeAsDouble(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, Time.fixedUnscaledTimeAsDouble);
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
		private static int _g_get_unscaledDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.unscaledDeltaTime);
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
		private static int _g_get_fixedUnscaledDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.fixedUnscaledDeltaTime);
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
		private static int _g_get_fixedDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.fixedDeltaTime);
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
		private static int _g_get_maximumDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.maximumDeltaTime);
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
		private static int _g_get_smoothDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.smoothDeltaTime);
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
		private static int _g_get_maximumParticleDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.maximumParticleDeltaTime);
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
		private static int _g_get_timeScale(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.timeScale);
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
		private static int _g_get_frameCount(IntPtr L)
		{
			try
			{
				Lua.xlua_pushinteger(L, Time.frameCount);
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
		private static int _g_get_renderedFrameCount(IntPtr L)
		{
			try
			{
				Lua.xlua_pushinteger(L, Time.renderedFrameCount);
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
		private static int _g_get_realtimeSinceStartup(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.realtimeSinceStartup);
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
		private static int _g_get_realtimeSinceStartupAsDouble(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, Time.realtimeSinceStartupAsDouble);
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
		private static int _g_get_captureDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)Time.captureDeltaTime);
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
		private static int _g_get_captureFramerate(IntPtr L)
		{
			try
			{
				Lua.xlua_pushinteger(L, Time.captureFramerate);
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
		private static int _g_get_inFixedTimeStep(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, Time.inFixedTimeStep);
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
		private static int _s_set_fixedDeltaTime(IntPtr L)
		{
			try
			{
				Time.fixedDeltaTime = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_maximumDeltaTime(IntPtr L)
		{
			try
			{
				Time.maximumDeltaTime = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_maximumParticleDeltaTime(IntPtr L)
		{
			try
			{
				Time.maximumParticleDeltaTime = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_timeScale(IntPtr L)
		{
			try
			{
				Time.timeScale = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_captureDeltaTime(IntPtr L)
		{
			try
			{
				Time.captureDeltaTime = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_captureFramerate(IntPtr L)
		{
			try
			{
				Time.captureFramerate = Lua.xlua_tointeger(L, 1);
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
