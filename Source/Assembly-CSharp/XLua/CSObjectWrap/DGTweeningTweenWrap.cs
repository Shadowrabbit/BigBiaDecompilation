using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningTweenWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Tween);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 57, 22, 18, -1);
			Utils.RegisterFunc(L, -3, "Complete", new lua_CSFunction(DGTweeningTweenWrap._m_Complete));
			Utils.RegisterFunc(L, -3, "Flip", new lua_CSFunction(DGTweeningTweenWrap._m_Flip));
			Utils.RegisterFunc(L, -3, "ForceInit", new lua_CSFunction(DGTweeningTweenWrap._m_ForceInit));
			Utils.RegisterFunc(L, -3, "Goto", new lua_CSFunction(DGTweeningTweenWrap._m_Goto));
			Utils.RegisterFunc(L, -3, "Kill", new lua_CSFunction(DGTweeningTweenWrap._m_Kill));
			Utils.RegisterFunc(L, -3, "Pause", new lua_CSFunction(DGTweeningTweenWrap._m_Pause));
			Utils.RegisterFunc(L, -3, "Play", new lua_CSFunction(DGTweeningTweenWrap._m_Play));
			Utils.RegisterFunc(L, -3, "PlayBackwards", new lua_CSFunction(DGTweeningTweenWrap._m_PlayBackwards));
			Utils.RegisterFunc(L, -3, "PlayForward", new lua_CSFunction(DGTweeningTweenWrap._m_PlayForward));
			Utils.RegisterFunc(L, -3, "Restart", new lua_CSFunction(DGTweeningTweenWrap._m_Restart));
			Utils.RegisterFunc(L, -3, "Rewind", new lua_CSFunction(DGTweeningTweenWrap._m_Rewind));
			Utils.RegisterFunc(L, -3, "SmoothRewind", new lua_CSFunction(DGTweeningTweenWrap._m_SmoothRewind));
			Utils.RegisterFunc(L, -3, "TogglePause", new lua_CSFunction(DGTweeningTweenWrap._m_TogglePause));
			Utils.RegisterFunc(L, -3, "GotoWaypoint", new lua_CSFunction(DGTweeningTweenWrap._m_GotoWaypoint));
			Utils.RegisterFunc(L, -3, "WaitForCompletion", new lua_CSFunction(DGTweeningTweenWrap._m_WaitForCompletion));
			Utils.RegisterFunc(L, -3, "WaitForRewind", new lua_CSFunction(DGTweeningTweenWrap._m_WaitForRewind));
			Utils.RegisterFunc(L, -3, "WaitForKill", new lua_CSFunction(DGTweeningTweenWrap._m_WaitForKill));
			Utils.RegisterFunc(L, -3, "WaitForElapsedLoops", new lua_CSFunction(DGTweeningTweenWrap._m_WaitForElapsedLoops));
			Utils.RegisterFunc(L, -3, "WaitForPosition", new lua_CSFunction(DGTweeningTweenWrap._m_WaitForPosition));
			Utils.RegisterFunc(L, -3, "WaitForStart", new lua_CSFunction(DGTweeningTweenWrap._m_WaitForStart));
			Utils.RegisterFunc(L, -3, "CompletedLoops", new lua_CSFunction(DGTweeningTweenWrap._m_CompletedLoops));
			Utils.RegisterFunc(L, -3, "Delay", new lua_CSFunction(DGTweeningTweenWrap._m_Delay));
			Utils.RegisterFunc(L, -3, "Duration", new lua_CSFunction(DGTweeningTweenWrap._m_Duration));
			Utils.RegisterFunc(L, -3, "Elapsed", new lua_CSFunction(DGTweeningTweenWrap._m_Elapsed));
			Utils.RegisterFunc(L, -3, "ElapsedPercentage", new lua_CSFunction(DGTweeningTweenWrap._m_ElapsedPercentage));
			Utils.RegisterFunc(L, -3, "ElapsedDirectionalPercentage", new lua_CSFunction(DGTweeningTweenWrap._m_ElapsedDirectionalPercentage));
			Utils.RegisterFunc(L, -3, "IsActive", new lua_CSFunction(DGTweeningTweenWrap._m_IsActive));
			Utils.RegisterFunc(L, -3, "IsBackwards", new lua_CSFunction(DGTweeningTweenWrap._m_IsBackwards));
			Utils.RegisterFunc(L, -3, "IsComplete", new lua_CSFunction(DGTweeningTweenWrap._m_IsComplete));
			Utils.RegisterFunc(L, -3, "IsInitialized", new lua_CSFunction(DGTweeningTweenWrap._m_IsInitialized));
			Utils.RegisterFunc(L, -3, "IsPlaying", new lua_CSFunction(DGTweeningTweenWrap._m_IsPlaying));
			Utils.RegisterFunc(L, -3, "Loops", new lua_CSFunction(DGTweeningTweenWrap._m_Loops));
			Utils.RegisterFunc(L, -3, "PathGetPoint", new lua_CSFunction(DGTweeningTweenWrap._m_PathGetPoint));
			Utils.RegisterFunc(L, -3, "PathGetDrawPoints", new lua_CSFunction(DGTweeningTweenWrap._m_PathGetDrawPoints));
			Utils.RegisterFunc(L, -3, "PathLength", new lua_CSFunction(DGTweeningTweenWrap._m_PathLength));
			Utils.RegisterFunc(L, -3, "SetAutoKill", new lua_CSFunction(DGTweeningTweenWrap._m_SetAutoKill));
			Utils.RegisterFunc(L, -3, "SetId", new lua_CSFunction(DGTweeningTweenWrap._m_SetId));
			Utils.RegisterFunc(L, -3, "SetLink", new lua_CSFunction(DGTweeningTweenWrap._m_SetLink));
			Utils.RegisterFunc(L, -3, "SetTarget", new lua_CSFunction(DGTweeningTweenWrap._m_SetTarget));
			Utils.RegisterFunc(L, -3, "SetLoops", new lua_CSFunction(DGTweeningTweenWrap._m_SetLoops));
			Utils.RegisterFunc(L, -3, "SetEase", new lua_CSFunction(DGTweeningTweenWrap._m_SetEase));
			Utils.RegisterFunc(L, -3, "SetRecyclable", new lua_CSFunction(DGTweeningTweenWrap._m_SetRecyclable));
			Utils.RegisterFunc(L, -3, "SetUpdate", new lua_CSFunction(DGTweeningTweenWrap._m_SetUpdate));
			Utils.RegisterFunc(L, -3, "OnStart", new lua_CSFunction(DGTweeningTweenWrap._m_OnStart));
			Utils.RegisterFunc(L, -3, "OnPlay", new lua_CSFunction(DGTweeningTweenWrap._m_OnPlay));
			Utils.RegisterFunc(L, -3, "OnPause", new lua_CSFunction(DGTweeningTweenWrap._m_OnPause));
			Utils.RegisterFunc(L, -3, "OnRewind", new lua_CSFunction(DGTweeningTweenWrap._m_OnRewind));
			Utils.RegisterFunc(L, -3, "OnUpdate", new lua_CSFunction(DGTweeningTweenWrap._m_OnUpdate));
			Utils.RegisterFunc(L, -3, "OnStepComplete", new lua_CSFunction(DGTweeningTweenWrap._m_OnStepComplete));
			Utils.RegisterFunc(L, -3, "OnComplete", new lua_CSFunction(DGTweeningTweenWrap._m_OnComplete));
			Utils.RegisterFunc(L, -3, "OnKill", new lua_CSFunction(DGTweeningTweenWrap._m_OnKill));
			Utils.RegisterFunc(L, -3, "OnWaypointChange", new lua_CSFunction(DGTweeningTweenWrap._m_OnWaypointChange));
			Utils.RegisterFunc(L, -3, "SetAs", new lua_CSFunction(DGTweeningTweenWrap._m_SetAs));
			Utils.RegisterFunc(L, -3, "SetDelay", new lua_CSFunction(DGTweeningTweenWrap._m_SetDelay));
			Utils.RegisterFunc(L, -3, "SetRelative", new lua_CSFunction(DGTweeningTweenWrap._m_SetRelative));
			Utils.RegisterFunc(L, -3, "SetSpeedBased", new lua_CSFunction(DGTweeningTweenWrap._m_SetSpeedBased));
			Utils.RegisterFunc(L, -3, "DOTimeScale", new lua_CSFunction(DGTweeningTweenWrap._m_DOTimeScale));
			Utils.RegisterFunc(L, -2, "isRelative", new lua_CSFunction(DGTweeningTweenWrap._g_get_isRelative));
			Utils.RegisterFunc(L, -2, "active", new lua_CSFunction(DGTweeningTweenWrap._g_get_active));
			Utils.RegisterFunc(L, -2, "fullPosition", new lua_CSFunction(DGTweeningTweenWrap._g_get_fullPosition));
			Utils.RegisterFunc(L, -2, "playedOnce", new lua_CSFunction(DGTweeningTweenWrap._g_get_playedOnce));
			Utils.RegisterFunc(L, -2, "position", new lua_CSFunction(DGTweeningTweenWrap._g_get_position));
			Utils.RegisterFunc(L, -2, "timeScale", new lua_CSFunction(DGTweeningTweenWrap._g_get_timeScale));
			Utils.RegisterFunc(L, -2, "isBackwards", new lua_CSFunction(DGTweeningTweenWrap._g_get_isBackwards));
			Utils.RegisterFunc(L, -2, "id", new lua_CSFunction(DGTweeningTweenWrap._g_get_id));
			Utils.RegisterFunc(L, -2, "stringId", new lua_CSFunction(DGTweeningTweenWrap._g_get_stringId));
			Utils.RegisterFunc(L, -2, "intId", new lua_CSFunction(DGTweeningTweenWrap._g_get_intId));
			Utils.RegisterFunc(L, -2, "target", new lua_CSFunction(DGTweeningTweenWrap._g_get_target));
			Utils.RegisterFunc(L, -2, "onPlay", new lua_CSFunction(DGTweeningTweenWrap._g_get_onPlay));
			Utils.RegisterFunc(L, -2, "onPause", new lua_CSFunction(DGTweeningTweenWrap._g_get_onPause));
			Utils.RegisterFunc(L, -2, "onRewind", new lua_CSFunction(DGTweeningTweenWrap._g_get_onRewind));
			Utils.RegisterFunc(L, -2, "onUpdate", new lua_CSFunction(DGTweeningTweenWrap._g_get_onUpdate));
			Utils.RegisterFunc(L, -2, "onStepComplete", new lua_CSFunction(DGTweeningTweenWrap._g_get_onStepComplete));
			Utils.RegisterFunc(L, -2, "onComplete", new lua_CSFunction(DGTweeningTweenWrap._g_get_onComplete));
			Utils.RegisterFunc(L, -2, "onKill", new lua_CSFunction(DGTweeningTweenWrap._g_get_onKill));
			Utils.RegisterFunc(L, -2, "onWaypointChange", new lua_CSFunction(DGTweeningTweenWrap._g_get_onWaypointChange));
			Utils.RegisterFunc(L, -2, "easeOvershootOrAmplitude", new lua_CSFunction(DGTweeningTweenWrap._g_get_easeOvershootOrAmplitude));
			Utils.RegisterFunc(L, -2, "easePeriod", new lua_CSFunction(DGTweeningTweenWrap._g_get_easePeriod));
			Utils.RegisterFunc(L, -2, "debugTargetId", new lua_CSFunction(DGTweeningTweenWrap._g_get_debugTargetId));
			Utils.RegisterFunc(L, -1, "fullPosition", new lua_CSFunction(DGTweeningTweenWrap._s_set_fullPosition));
			Utils.RegisterFunc(L, -1, "timeScale", new lua_CSFunction(DGTweeningTweenWrap._s_set_timeScale));
			Utils.RegisterFunc(L, -1, "isBackwards", new lua_CSFunction(DGTweeningTweenWrap._s_set_isBackwards));
			Utils.RegisterFunc(L, -1, "id", new lua_CSFunction(DGTweeningTweenWrap._s_set_id));
			Utils.RegisterFunc(L, -1, "stringId", new lua_CSFunction(DGTweeningTweenWrap._s_set_stringId));
			Utils.RegisterFunc(L, -1, "intId", new lua_CSFunction(DGTweeningTweenWrap._s_set_intId));
			Utils.RegisterFunc(L, -1, "target", new lua_CSFunction(DGTweeningTweenWrap._s_set_target));
			Utils.RegisterFunc(L, -1, "onPlay", new lua_CSFunction(DGTweeningTweenWrap._s_set_onPlay));
			Utils.RegisterFunc(L, -1, "onPause", new lua_CSFunction(DGTweeningTweenWrap._s_set_onPause));
			Utils.RegisterFunc(L, -1, "onRewind", new lua_CSFunction(DGTweeningTweenWrap._s_set_onRewind));
			Utils.RegisterFunc(L, -1, "onUpdate", new lua_CSFunction(DGTweeningTweenWrap._s_set_onUpdate));
			Utils.RegisterFunc(L, -1, "onStepComplete", new lua_CSFunction(DGTweeningTweenWrap._s_set_onStepComplete));
			Utils.RegisterFunc(L, -1, "onComplete", new lua_CSFunction(DGTweeningTweenWrap._s_set_onComplete));
			Utils.RegisterFunc(L, -1, "onKill", new lua_CSFunction(DGTweeningTweenWrap._s_set_onKill));
			Utils.RegisterFunc(L, -1, "onWaypointChange", new lua_CSFunction(DGTweeningTweenWrap._s_set_onWaypointChange));
			Utils.RegisterFunc(L, -1, "easeOvershootOrAmplitude", new lua_CSFunction(DGTweeningTweenWrap._s_set_easeOvershootOrAmplitude));
			Utils.RegisterFunc(L, -1, "easePeriod", new lua_CSFunction(DGTweeningTweenWrap._s_set_easePeriod));
			Utils.RegisterFunc(L, -1, "debugTargetId", new lua_CSFunction(DGTweeningTweenWrap._s_set_debugTargetId));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningTweenWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "DG.Tweening.Tween does not have a constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Complete(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					t.Complete();
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool withCallbacks = Lua.lua_toboolean(L, 2);
					t.Complete(withCallbacks);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Complete!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Flip(IntPtr L)
		{
			int result;
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Flip();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ForceInit(IntPtr L)
		{
			int result;
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ForceInit();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Goto(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					float to = (float)Lua.lua_tonumber(L, 2);
					bool andPlay = Lua.lua_toboolean(L, 3);
					t.Goto(to, andPlay);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float to2 = (float)Lua.lua_tonumber(L, 2);
					t.Goto(to2, false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Goto!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Kill(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool complete = Lua.lua_toboolean(L, 2);
					t.Kill(complete);
					return 0;
				}
				if (num == 1)
				{
					t.Kill(false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Kill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Pause(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween o = ((Tween)objectTranslator.FastGetCSObj(L, 1)).Pause<Tween>();
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Play(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween o = ((Tween)objectTranslator.FastGetCSObj(L, 1)).Play<Tween>();
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PlayBackwards(IntPtr L)
		{
			int result;
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PlayBackwards();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PlayForward(IntPtr L)
		{
			int result;
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PlayForward();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Restart(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					bool includeDelay = Lua.lua_toboolean(L, 2);
					float changeDelayTo = (float)Lua.lua_tonumber(L, 3);
					t.Restart(includeDelay, changeDelayTo);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeDelay2 = Lua.lua_toboolean(L, 2);
					t.Restart(includeDelay2, -1f);
					return 0;
				}
				if (num == 1)
				{
					t.Restart(true, -1f);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Restart!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Rewind(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeDelay = Lua.lua_toboolean(L, 2);
					t.Rewind(includeDelay);
					return 0;
				}
				if (num == 1)
				{
					t.Rewind(true);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Rewind!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SmoothRewind(IntPtr L)
		{
			int result;
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).SmoothRewind();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TogglePause(IntPtr L)
		{
			int result;
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).TogglePause();
				result = 0;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GotoWaypoint(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					int waypointIndex = Lua.xlua_tointeger(L, 2);
					bool andPlay = Lua.lua_toboolean(L, 3);
					t.GotoWaypoint(waypointIndex, andPlay);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int waypointIndex2 = Lua.xlua_tointeger(L, 2);
					t.GotoWaypoint(waypointIndex2, false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.GotoWaypoint!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_WaitForCompletion(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				YieldInstruction o = ((Tween)objectTranslator.FastGetCSObj(L, 1)).WaitForCompletion();
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_WaitForRewind(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				YieldInstruction o = ((Tween)objectTranslator.FastGetCSObj(L, 1)).WaitForRewind();
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_WaitForKill(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				YieldInstruction o = ((Tween)objectTranslator.FastGetCSObj(L, 1)).WaitForKill();
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_WaitForElapsedLoops(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int elapsedLoops = Lua.xlua_tointeger(L, 2);
				YieldInstruction o = t.WaitForElapsedLoops(elapsedLoops);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_WaitForPosition(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				float position = (float)Lua.lua_tonumber(L, 2);
				YieldInstruction o = t.WaitForPosition(position);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_WaitForStart(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Coroutine o = ((Tween)objectTranslator.FastGetCSObj(L, 1)).WaitForStart();
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_CompletedLoops(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CompletedLoops();
				Lua.xlua_pushinteger(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Delay(IntPtr L)
		{
			int result;
			try
			{
				float num = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Delay();
				Lua.lua_pushnumber(L, (double)num);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Duration(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeLoops = Lua.lua_toboolean(L, 2);
					float num2 = t.Duration(includeLoops);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 1)
				{
					float num3 = t.Duration(true);
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Duration!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Elapsed(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeLoops = Lua.lua_toboolean(L, 2);
					float num2 = t.Elapsed(includeLoops);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 1)
				{
					float num3 = t.Elapsed(true);
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.Elapsed!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ElapsedPercentage(IntPtr L)
		{
			try
			{
				Tween t = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeLoops = Lua.lua_toboolean(L, 2);
					float num2 = t.ElapsedPercentage(includeLoops);
					Lua.lua_pushnumber(L, (double)num2);
					return 1;
				}
				if (num == 1)
				{
					float num3 = t.ElapsedPercentage(true);
					Lua.lua_pushnumber(L, (double)num3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.ElapsedPercentage!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ElapsedDirectionalPercentage(IntPtr L)
		{
			int result;
			try
			{
				float num = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ElapsedDirectionalPercentage();
				Lua.lua_pushnumber(L, (double)num);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_IsActive(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsActive();
				Lua.lua_pushboolean(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_IsBackwards(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsBackwards();
				Lua.lua_pushboolean(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_IsComplete(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsComplete();
				Lua.lua_pushboolean(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_IsInitialized(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsInitialized();
				Lua.lua_pushboolean(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_IsPlaying(IntPtr L)
		{
			int result;
			try
			{
				bool value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).IsPlaying();
				Lua.lua_pushboolean(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Loops(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).Loops();
				Lua.xlua_pushinteger(L, value);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PathGetPoint(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				float pathPercentage = (float)Lua.lua_tonumber(L, 2);
				Vector3 val = t.PathGetPoint(pathPercentage);
				objectTranslator.PushUnityEngineVector3(L, val);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PathGetDrawPoints(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int subdivisionsXSegment = Lua.xlua_tointeger(L, 2);
					Vector3[] o = t.PathGetDrawPoints(subdivisionsXSegment);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1)
				{
					Vector3[] o2 = t.PathGetDrawPoints(10);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.PathGetDrawPoints!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PathLength(IntPtr L)
		{
			int result;
			try
			{
				float num = ((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PathLength();
				Lua.lua_pushnumber(L, (double)num);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetAutoKill(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tween.SetAutoKill<Tween>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool autoKillOnCompletion = Lua.lua_toboolean(L, 2);
					Tween o2 = tween.SetAutoKill(autoKillOnCompletion);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetAutoKill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetId(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int intId = Lua.xlua_tointeger(L, 2);
					Tween o = t.SetId(intId);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					Tween o2 = t.SetId(@object);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string stringId = Lua.lua_tostring(L, 2);
					Tween o3 = t.SetId(stringId);
					objectTranslator.Push(L, o3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetId!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetLink(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<GameObject>(L, 2))
				{
					GameObject gameObject = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
					Tween o = t.SetLink(gameObject);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<GameObject>(L, 2) && objectTranslator.Assignable<LinkBehaviour>(L, 3))
				{
					GameObject gameObject2 = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
					LinkBehaviour behaviour;
					objectTranslator.Get<LinkBehaviour>(L, 3, out behaviour);
					Tween o2 = t.SetLink(gameObject2, behaviour);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetLink!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetTarget(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				object @object = objectTranslator.GetObject(L, 2, typeof(object));
				Tween o = t.SetTarget(@object);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetLoops(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int loops = Lua.xlua_tointeger(L, 2);
					Tween o = t.SetLoops(loops);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<LoopType>(L, 3))
				{
					int loops2 = Lua.xlua_tointeger(L, 2);
					LoopType loopType;
					objectTranslator.Get(L, 3, out loopType);
					Tween o2 = t.SetLoops(loops2, loopType);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetLoops!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetEase(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Ease>(L, 2))
				{
					Ease ease;
					objectTranslator.Get(L, 2, out ease);
					Tween o = t.SetEase(ease);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<AnimationCurve>(L, 2))
				{
					AnimationCurve animCurve = (AnimationCurve)objectTranslator.GetObject(L, 2, typeof(AnimationCurve));
					Tween o2 = t.SetEase(animCurve);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<EaseFunction>(L, 2))
				{
					EaseFunction @delegate = objectTranslator.GetDelegate<EaseFunction>(L, 2);
					Tween o3 = t.SetEase(@delegate);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Ease>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Ease ease2;
					objectTranslator.Get(L, 2, out ease2);
					float overshoot = (float)Lua.lua_tonumber(L, 3);
					Tween o4 = t.SetEase(ease2, overshoot);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Ease>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Ease ease3;
					objectTranslator.Get(L, 2, out ease3);
					float amplitude = (float)Lua.lua_tonumber(L, 3);
					float period = (float)Lua.lua_tonumber(L, 4);
					Tween o5 = t.SetEase(ease3, amplitude, period);
					objectTranslator.Push(L, o5);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetEase!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetRecyclable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tween.SetRecyclable<Tween>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool recyclable = Lua.lua_toboolean(L, 2);
					Tween o2 = tween.SetRecyclable(recyclable);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetRecyclable!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetUpdate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isIndependentUpdate = Lua.lua_toboolean(L, 2);
					Tween o = t.SetUpdate(isIndependentUpdate);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<UpdateType>(L, 2))
				{
					UpdateType updateType;
					objectTranslator.Get(L, 2, out updateType);
					Tween o2 = t.SetUpdate(updateType);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UpdateType>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					UpdateType updateType2;
					objectTranslator.Get(L, 2, out updateType2);
					bool isIndependentUpdate2 = Lua.lua_toboolean(L, 3);
					Tween o3 = t.SetUpdate(updateType2, isIndependentUpdate2);
					objectTranslator.Push(L, o3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetUpdate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnStart(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnStart(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnPlay(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnPlay(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnPause(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnPause(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnRewind(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnRewind(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnUpdate(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnUpdate(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnStepComplete(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnStepComplete(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnComplete(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnComplete(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnKill(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Tween o = t.OnKill(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnWaypointChange(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback<int> @delegate = objectTranslator.GetDelegate<TweenCallback<int>>(L, 2);
				Tween o = t.OnWaypointChange(@delegate);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetAs(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Tween>(L, 2))
				{
					Tween asTween = (Tween)objectTranslator.GetObject(L, 2, typeof(Tween));
					Tween o = t.SetAs(asTween);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<TweenParams>(L, 2))
				{
					TweenParams tweenParams = (TweenParams)objectTranslator.GetObject(L, 2, typeof(TweenParams));
					Tween o2 = t.SetAs(tweenParams);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetAs!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetDelay(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween t = (Tween)objectTranslator.FastGetCSObj(L, 1);
				float delay = (float)Lua.lua_tonumber(L, 2);
				Tween o = t.SetDelay(delay);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetRelative(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tween.SetRelative<Tween>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isRelative = Lua.lua_toboolean(L, 2);
					Tween o2 = tween.SetRelative(isRelative);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetRelative!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetSpeedBased(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = tween.SetSpeedBased<Tween>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isSpeedBased = Lua.lua_toboolean(L, 2);
					Tween o2 = tween.SetSpeedBased(isSpeedBased);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Tween.SetSpeedBased!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOTimeScale(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween target = (Tween)objectTranslator.FastGetCSObj(L, 1);
				float endValue = (float)Lua.lua_tonumber(L, 2);
				float duration = (float)Lua.lua_tonumber(L, 3);
				TweenerCore<float, float, FloatOptions> o = target.DOTimeScale(endValue, duration);
				objectTranslator.Push(L, o);
				result = 1;
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_isRelative(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, tween.isRelative);
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
		private static int _g_get_active(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, tween.active);
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
		private static int _g_get_fullPosition(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)tween.fullPosition);
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
		private static int _g_get_playedOnce(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, tween.playedOnce);
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
		private static int _g_get_position(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)tween.position);
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
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)tween.timeScale);
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
		private static int _g_get_isBackwards(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, tween.isBackwards);
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
		private static int _g_get_id(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushAny(L, tween.id);
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
		private static int _g_get_stringId(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, tween.stringId);
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
		private static int _g_get_intId(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, tween.intId);
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
		private static int _g_get_target(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushAny(L, tween.target);
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
		private static int _g_get_onPlay(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onPlay);
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
		private static int _g_get_onPause(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onPause);
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
		private static int _g_get_onRewind(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onRewind);
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
		private static int _g_get_onUpdate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onUpdate);
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
		private static int _g_get_onStepComplete(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onStepComplete);
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
		private static int _g_get_onComplete(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onComplete);
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
		private static int _g_get_onKill(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onKill);
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
		private static int _g_get_onWaypointChange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween tween = (Tween)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, tween.onWaypointChange);
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
		private static int _g_get_easeOvershootOrAmplitude(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)tween.easeOvershootOrAmplitude);
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
		private static int _g_get_easePeriod(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)tween.easePeriod);
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
		private static int _g_get_debugTargetId(IntPtr L)
		{
			try
			{
				Tween tween = (Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, tween.debugTargetId);
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
		private static int _s_set_fullPosition(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).fullPosition = (float)Lua.lua_tonumber(L, 2);
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
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).timeScale = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_isBackwards(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).isBackwards = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_id(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).id = objectTranslator.GetObject(L, 2, typeof(object));
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
		private static int _s_set_stringId(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).stringId = Lua.lua_tostring(L, 2);
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
		private static int _s_set_intId(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).intId = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_target(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).target = objectTranslator.GetObject(L, 2, typeof(object));
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
		private static int _s_set_onPlay(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onPlay = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onPause(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onPause = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onRewind(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onRewind = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onUpdate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onUpdate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onStepComplete(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onStepComplete = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onComplete(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onComplete = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onKill(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onKill = objectTranslator.GetDelegate<TweenCallback>(L, 2);
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
		private static int _s_set_onWaypointChange(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((Tween)objectTranslator.FastGetCSObj(L, 1)).onWaypointChange = objectTranslator.GetDelegate<TweenCallback<int>>(L, 2);
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
		private static int _s_set_easeOvershootOrAmplitude(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).easeOvershootOrAmplitude = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_easePeriod(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).easePeriod = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_debugTargetId(IntPtr L)
		{
			try
			{
				((Tween)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).debugTargetId = Lua.lua_tostring(L, 2);
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
