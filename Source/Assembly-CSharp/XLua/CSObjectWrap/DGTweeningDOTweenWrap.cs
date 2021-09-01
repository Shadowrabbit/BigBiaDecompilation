using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningDOTweenWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(DOTween);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningDOTweenWrap.__CreateInstance), 45, 21, 21);
			Utils.RegisterFunc(L, -4, "Init", new lua_CSFunction(DGTweeningDOTweenWrap._m_Init_xlua_st_));
			Utils.RegisterFunc(L, -4, "SetTweensCapacity", new lua_CSFunction(DGTweeningDOTweenWrap._m_SetTweensCapacity_xlua_st_));
			Utils.RegisterFunc(L, -4, "Clear", new lua_CSFunction(DGTweeningDOTweenWrap._m_Clear_xlua_st_));
			Utils.RegisterFunc(L, -4, "ClearCachedTweens", new lua_CSFunction(DGTweeningDOTweenWrap._m_ClearCachedTweens_xlua_st_));
			Utils.RegisterFunc(L, -4, "Validate", new lua_CSFunction(DGTweeningDOTweenWrap._m_Validate_xlua_st_));
			Utils.RegisterFunc(L, -4, "ManualUpdate", new lua_CSFunction(DGTweeningDOTweenWrap._m_ManualUpdate_xlua_st_));
			Utils.RegisterFunc(L, -4, "To", new lua_CSFunction(DGTweeningDOTweenWrap._m_To_xlua_st_));
			Utils.RegisterFunc(L, -4, "ToAxis", new lua_CSFunction(DGTweeningDOTweenWrap._m_ToAxis_xlua_st_));
			Utils.RegisterFunc(L, -4, "ToAlpha", new lua_CSFunction(DGTweeningDOTweenWrap._m_ToAlpha_xlua_st_));
			Utils.RegisterFunc(L, -4, "Punch", new lua_CSFunction(DGTweeningDOTweenWrap._m_Punch_xlua_st_));
			Utils.RegisterFunc(L, -4, "Shake", new lua_CSFunction(DGTweeningDOTweenWrap._m_Shake_xlua_st_));
			Utils.RegisterFunc(L, -4, "ToArray", new lua_CSFunction(DGTweeningDOTweenWrap._m_ToArray_xlua_st_));
			Utils.RegisterFunc(L, -4, "Sequence", new lua_CSFunction(DGTweeningDOTweenWrap._m_Sequence_xlua_st_));
			Utils.RegisterFunc(L, -4, "CompleteAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_CompleteAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Complete", new lua_CSFunction(DGTweeningDOTweenWrap._m_Complete_xlua_st_));
			Utils.RegisterFunc(L, -4, "FlipAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_FlipAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Flip", new lua_CSFunction(DGTweeningDOTweenWrap._m_Flip_xlua_st_));
			Utils.RegisterFunc(L, -4, "GotoAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_GotoAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Goto", new lua_CSFunction(DGTweeningDOTweenWrap._m_Goto_xlua_st_));
			Utils.RegisterFunc(L, -4, "KillAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_KillAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Kill", new lua_CSFunction(DGTweeningDOTweenWrap._m_Kill_xlua_st_));
			Utils.RegisterFunc(L, -4, "PauseAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_PauseAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Pause", new lua_CSFunction(DGTweeningDOTweenWrap._m_Pause_xlua_st_));
			Utils.RegisterFunc(L, -4, "PlayAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_PlayAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Play", new lua_CSFunction(DGTweeningDOTweenWrap._m_Play_xlua_st_));
			Utils.RegisterFunc(L, -4, "PlayBackwardsAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_PlayBackwardsAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "PlayBackwards", new lua_CSFunction(DGTweeningDOTweenWrap._m_PlayBackwards_xlua_st_));
			Utils.RegisterFunc(L, -4, "PlayForwardAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_PlayForwardAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "PlayForward", new lua_CSFunction(DGTweeningDOTweenWrap._m_PlayForward_xlua_st_));
			Utils.RegisterFunc(L, -4, "RestartAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_RestartAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Restart", new lua_CSFunction(DGTweeningDOTweenWrap._m_Restart_xlua_st_));
			Utils.RegisterFunc(L, -4, "RewindAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_RewindAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Rewind", new lua_CSFunction(DGTweeningDOTweenWrap._m_Rewind_xlua_st_));
			Utils.RegisterFunc(L, -4, "SmoothRewindAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_SmoothRewindAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "SmoothRewind", new lua_CSFunction(DGTweeningDOTweenWrap._m_SmoothRewind_xlua_st_));
			Utils.RegisterFunc(L, -4, "TogglePauseAll", new lua_CSFunction(DGTweeningDOTweenWrap._m_TogglePauseAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "TogglePause", new lua_CSFunction(DGTweeningDOTweenWrap._m_TogglePause_xlua_st_));
			Utils.RegisterFunc(L, -4, "IsTweening", new lua_CSFunction(DGTweeningDOTweenWrap._m_IsTweening_xlua_st_));
			Utils.RegisterFunc(L, -4, "TotalPlayingTweens", new lua_CSFunction(DGTweeningDOTweenWrap._m_TotalPlayingTweens_xlua_st_));
			Utils.RegisterFunc(L, -4, "PlayingTweens", new lua_CSFunction(DGTweeningDOTweenWrap._m_PlayingTweens_xlua_st_));
			Utils.RegisterFunc(L, -4, "PausedTweens", new lua_CSFunction(DGTweeningDOTweenWrap._m_PausedTweens_xlua_st_));
			Utils.RegisterFunc(L, -4, "TweensById", new lua_CSFunction(DGTweeningDOTweenWrap._m_TweensById_xlua_st_));
			Utils.RegisterFunc(L, -4, "TweensByTarget", new lua_CSFunction(DGTweeningDOTweenWrap._m_TweensByTarget_xlua_st_));
			Utils.RegisterObject(L, translator, -4, "Version", DOTween.Version);
			Utils.RegisterFunc(L, -2, "logBehaviour", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_logBehaviour));
			Utils.RegisterFunc(L, -2, "debugStoreTargetId", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_debugStoreTargetId));
			Utils.RegisterFunc(L, -2, "useSafeMode", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_useSafeMode));
			Utils.RegisterFunc(L, -2, "nestedTweenFailureBehaviour", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_nestedTweenFailureBehaviour));
			Utils.RegisterFunc(L, -2, "showUnityEditorReport", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_showUnityEditorReport));
			Utils.RegisterFunc(L, -2, "timeScale", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_timeScale));
			Utils.RegisterFunc(L, -2, "useSmoothDeltaTime", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_useSmoothDeltaTime));
			Utils.RegisterFunc(L, -2, "maxSmoothUnscaledTime", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_maxSmoothUnscaledTime));
			Utils.RegisterFunc(L, -2, "onWillLog", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_onWillLog));
			Utils.RegisterFunc(L, -2, "drawGizmos", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_drawGizmos));
			Utils.RegisterFunc(L, -2, "debugMode", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_debugMode));
			Utils.RegisterFunc(L, -2, "defaultUpdateType", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultUpdateType));
			Utils.RegisterFunc(L, -2, "defaultTimeScaleIndependent", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultTimeScaleIndependent));
			Utils.RegisterFunc(L, -2, "defaultAutoPlay", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultAutoPlay));
			Utils.RegisterFunc(L, -2, "defaultAutoKill", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultAutoKill));
			Utils.RegisterFunc(L, -2, "defaultLoopType", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultLoopType));
			Utils.RegisterFunc(L, -2, "defaultRecyclable", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultRecyclable));
			Utils.RegisterFunc(L, -2, "defaultEaseType", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultEaseType));
			Utils.RegisterFunc(L, -2, "defaultEaseOvershootOrAmplitude", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultEaseOvershootOrAmplitude));
			Utils.RegisterFunc(L, -2, "defaultEasePeriod", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_defaultEasePeriod));
			Utils.RegisterFunc(L, -2, "instance", new lua_CSFunction(DGTweeningDOTweenWrap._g_get_instance));
			Utils.RegisterFunc(L, -1, "logBehaviour", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_logBehaviour));
			Utils.RegisterFunc(L, -1, "debugStoreTargetId", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_debugStoreTargetId));
			Utils.RegisterFunc(L, -1, "useSafeMode", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_useSafeMode));
			Utils.RegisterFunc(L, -1, "nestedTweenFailureBehaviour", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_nestedTweenFailureBehaviour));
			Utils.RegisterFunc(L, -1, "showUnityEditorReport", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_showUnityEditorReport));
			Utils.RegisterFunc(L, -1, "timeScale", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_timeScale));
			Utils.RegisterFunc(L, -1, "useSmoothDeltaTime", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_useSmoothDeltaTime));
			Utils.RegisterFunc(L, -1, "maxSmoothUnscaledTime", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_maxSmoothUnscaledTime));
			Utils.RegisterFunc(L, -1, "onWillLog", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_onWillLog));
			Utils.RegisterFunc(L, -1, "drawGizmos", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_drawGizmos));
			Utils.RegisterFunc(L, -1, "debugMode", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_debugMode));
			Utils.RegisterFunc(L, -1, "defaultUpdateType", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultUpdateType));
			Utils.RegisterFunc(L, -1, "defaultTimeScaleIndependent", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultTimeScaleIndependent));
			Utils.RegisterFunc(L, -1, "defaultAutoPlay", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultAutoPlay));
			Utils.RegisterFunc(L, -1, "defaultAutoKill", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultAutoKill));
			Utils.RegisterFunc(L, -1, "defaultLoopType", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultLoopType));
			Utils.RegisterFunc(L, -1, "defaultRecyclable", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultRecyclable));
			Utils.RegisterFunc(L, -1, "defaultEaseType", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultEaseType));
			Utils.RegisterFunc(L, -1, "defaultEaseOvershootOrAmplitude", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultEaseOvershootOrAmplitude));
			Utils.RegisterFunc(L, -1, "defaultEasePeriod", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_defaultEasePeriod));
			Utils.RegisterFunc(L, -1, "instance", new lua_CSFunction(DGTweeningDOTweenWrap._s_set_instance));
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
					DOTween o = new DOTween();
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Init_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<bool?>(L, 1) && objectTranslator.Assignable<bool?>(L, 2) && objectTranslator.Assignable<LogBehaviour?>(L, 3))
				{
					bool? recycleAllByDefault;
					objectTranslator.Get<bool?>(L, 1, out recycleAllByDefault);
					bool? useSafeMode;
					objectTranslator.Get<bool?>(L, 2, out useSafeMode);
					LogBehaviour? logBehaviour;
					objectTranslator.Get<LogBehaviour?>(L, 3, out logBehaviour);
					IDOTweenInit o = DOTween.Init(recycleAllByDefault, useSafeMode, logBehaviour);
					objectTranslator.PushAny(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<bool?>(L, 1) && objectTranslator.Assignable<bool?>(L, 2))
				{
					bool? recycleAllByDefault2;
					objectTranslator.Get<bool?>(L, 1, out recycleAllByDefault2);
					bool? useSafeMode2;
					objectTranslator.Get<bool?>(L, 2, out useSafeMode2);
					IDOTweenInit o2 = DOTween.Init(recycleAllByDefault2, useSafeMode2, null);
					objectTranslator.PushAny(L, o2);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<bool?>(L, 1))
				{
					bool? recycleAllByDefault3;
					objectTranslator.Get<bool?>(L, 1, out recycleAllByDefault3);
					IDOTweenInit o3 = DOTween.Init(recycleAllByDefault3, null, null);
					objectTranslator.PushAny(L, o3);
					return 1;
				}
				if (num == 0)
				{
					IDOTweenInit o4 = DOTween.Init(null, null, null);
					objectTranslator.PushAny(L, o4);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Init!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetTweensCapacity_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int tweenersCapacity = Lua.xlua_tointeger(L, 1);
				int sequencesCapacity = Lua.xlua_tointeger(L, 2);
				DOTween.SetTweensCapacity(tweenersCapacity, sequencesCapacity);
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
		private static int _m_Clear_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1))
				{
					DOTween.Clear(Lua.lua_toboolean(L, 1));
					return 0;
				}
				if (num == 0)
				{
					DOTween.Clear(false);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Clear!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ClearCachedTweens_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				DOTween.ClearCachedTweens();
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
		private static int _m_Validate_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.Validate();
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
		private static int _m_ManualUpdate_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				float deltaTime = (float)Lua.lua_tonumber(L, 1);
				float unscaledDeltaTime = (float)Lua.lua_tonumber(L, 2);
				DOTween.ManualUpdate(deltaTime, unscaledDeltaTime);
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
		private static int _m_To_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<DOSetter<float>>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOSetter<float> @delegate = objectTranslator.GetDelegate<DOSetter<float>>(L, 1);
					float startValue = (float)Lua.lua_tonumber(L, 2);
					float endValue = (float)Lua.lua_tonumber(L, 3);
					float duration = (float)Lua.lua_tonumber(L, 4);
					Tweener o = DOTween.To(@delegate, startValue, endValue, duration);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<float>>(L, 1) && objectTranslator.Assignable<DOSetter<float>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<float> delegate2 = objectTranslator.GetDelegate<DOGetter<float>>(L, 1);
					DOSetter<float> delegate3 = objectTranslator.GetDelegate<DOSetter<float>>(L, 2);
					float endValue2 = (float)Lua.lua_tonumber(L, 3);
					float duration2 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<float, float, FloatOptions> o2 = DOTween.To(delegate2, delegate3, endValue2, duration2);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<double>>(L, 1) && objectTranslator.Assignable<DOSetter<double>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<double> delegate4 = objectTranslator.GetDelegate<DOGetter<double>>(L, 1);
					DOSetter<double> delegate5 = objectTranslator.GetDelegate<DOSetter<double>>(L, 2);
					double endValue3 = Lua.lua_tonumber(L, 3);
					float duration3 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<double, double, NoOptions> o3 = DOTween.To(delegate4, delegate5, endValue3, duration3);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<int>>(L, 1) && objectTranslator.Assignable<DOSetter<int>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<int> delegate6 = objectTranslator.GetDelegate<DOGetter<int>>(L, 1);
					DOSetter<int> delegate7 = objectTranslator.GetDelegate<DOSetter<int>>(L, 2);
					int endValue4 = Lua.xlua_tointeger(L, 3);
					float duration4 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<int, int, NoOptions> o4 = DOTween.To(delegate6, delegate7, endValue4, duration4);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<uint>>(L, 1) && objectTranslator.Assignable<DOSetter<uint>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<uint> delegate8 = objectTranslator.GetDelegate<DOGetter<uint>>(L, 1);
					DOSetter<uint> delegate9 = objectTranslator.GetDelegate<DOSetter<uint>>(L, 2);
					uint endValue5 = Lua.xlua_touint(L, 3);
					float duration5 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<uint, uint, UintOptions> o5 = DOTween.To(delegate8, delegate9, endValue5, duration5);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<long>>(L, 1) && objectTranslator.Assignable<DOSetter<long>>(L, 2) && (LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) || Lua.lua_isint64(L, 3)) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<long> delegate10 = objectTranslator.GetDelegate<DOGetter<long>>(L, 1);
					DOSetter<long> delegate11 = objectTranslator.GetDelegate<DOSetter<long>>(L, 2);
					long endValue6 = Lua.lua_toint64(L, 3);
					float duration6 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<long, long, NoOptions> o6 = DOTween.To(delegate10, delegate11, endValue6, duration6);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<ulong>>(L, 1) && objectTranslator.Assignable<DOSetter<ulong>>(L, 2) && (LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) || Lua.lua_isuint64(L, 3)) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<ulong> delegate12 = objectTranslator.GetDelegate<DOGetter<ulong>>(L, 1);
					DOSetter<ulong> delegate13 = objectTranslator.GetDelegate<DOSetter<ulong>>(L, 2);
					ulong endValue7 = Lua.lua_touint64(L, 3);
					float duration7 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<ulong, ulong, NoOptions> o7 = DOTween.To(delegate12, delegate13, endValue7, duration7);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<string>>(L, 1) && objectTranslator.Assignable<DOSetter<string>>(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<string> delegate14 = objectTranslator.GetDelegate<DOGetter<string>>(L, 1);
					DOSetter<string> delegate15 = objectTranslator.GetDelegate<DOSetter<string>>(L, 2);
					string endValue8 = Lua.lua_tostring(L, 3);
					float duration8 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<string, string, StringOptions> o8 = DOTween.To(delegate14, delegate15, endValue8, duration8);
					objectTranslator.Push(L, o8);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector2>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector2>>(L, 2) && objectTranslator.Assignable<Vector2>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Vector2> delegate16 = objectTranslator.GetDelegate<DOGetter<Vector2>>(L, 1);
					DOSetter<Vector2> delegate17 = objectTranslator.GetDelegate<DOSetter<Vector2>>(L, 2);
					Vector2 endValue9;
					objectTranslator.Get(L, 3, out endValue9);
					float duration9 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector2, Vector2, VectorOptions> o9 = DOTween.To(delegate16, delegate17, endValue9, duration9);
					objectTranslator.Push(L, o9);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Vector3> delegate18 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate19 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					Vector3 endValue10;
					objectTranslator.Get(L, 3, out endValue10);
					float duration10 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o10 = DOTween.To(delegate18, delegate19, endValue10, duration10);
					objectTranslator.Push(L, o10);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector4>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector4>>(L, 2) && objectTranslator.Assignable<Vector4>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Vector4> delegate20 = objectTranslator.GetDelegate<DOGetter<Vector4>>(L, 1);
					DOSetter<Vector4> delegate21 = objectTranslator.GetDelegate<DOSetter<Vector4>>(L, 2);
					Vector4 endValue11;
					objectTranslator.Get(L, 3, out endValue11);
					float duration11 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector4, Vector4, VectorOptions> o11 = DOTween.To(delegate20, delegate21, endValue11, duration11);
					objectTranslator.Push(L, o11);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Quaternion>>(L, 1) && objectTranslator.Assignable<DOSetter<Quaternion>>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Quaternion> delegate22 = objectTranslator.GetDelegate<DOGetter<Quaternion>>(L, 1);
					DOSetter<Quaternion> delegate23 = objectTranslator.GetDelegate<DOSetter<Quaternion>>(L, 2);
					Vector3 endValue12;
					objectTranslator.Get(L, 3, out endValue12);
					float duration12 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> o12 = DOTween.To(delegate22, delegate23, endValue12, duration12);
					objectTranslator.Push(L, o12);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Color>>(L, 1) && objectTranslator.Assignable<DOSetter<Color>>(L, 2) && objectTranslator.Assignable<Color>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Color> delegate24 = objectTranslator.GetDelegate<DOGetter<Color>>(L, 1);
					DOSetter<Color> delegate25 = objectTranslator.GetDelegate<DOSetter<Color>>(L, 2);
					Color endValue13;
					objectTranslator.Get(L, 3, out endValue13);
					float duration13 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Color, Color, ColorOptions> o13 = DOTween.To(delegate24, delegate25, endValue13, duration13);
					objectTranslator.Push(L, o13);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Rect>>(L, 1) && objectTranslator.Assignable<DOSetter<Rect>>(L, 2) && objectTranslator.Assignable<Rect>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Rect> delegate26 = objectTranslator.GetDelegate<DOGetter<Rect>>(L, 1);
					DOSetter<Rect> delegate27 = objectTranslator.GetDelegate<DOSetter<Rect>>(L, 2);
					Rect endValue14;
					objectTranslator.Get<Rect>(L, 3, out endValue14);
					float duration14 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Rect, Rect, RectOptions> o14 = DOTween.To(delegate26, delegate27, endValue14, duration14);
					objectTranslator.Push(L, o14);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<RectOffset>>(L, 1) && objectTranslator.Assignable<DOSetter<RectOffset>>(L, 2) && objectTranslator.Assignable<RectOffset>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<RectOffset> delegate28 = objectTranslator.GetDelegate<DOGetter<RectOffset>>(L, 1);
					DOSetter<RectOffset> delegate29 = objectTranslator.GetDelegate<DOSetter<RectOffset>>(L, 2);
					RectOffset endValue15 = (RectOffset)objectTranslator.GetObject(L, 3, typeof(RectOffset));
					float duration15 = (float)Lua.lua_tonumber(L, 4);
					Tweener o15 = DOTween.To(delegate28, delegate29, endValue15, duration15);
					objectTranslator.Push(L, o15);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.To!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToAxis_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 5 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && objectTranslator.Assignable<AxisConstraint>(L, 5))
				{
					DOGetter<Vector3> @delegate = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate2 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float endValue = (float)Lua.lua_tonumber(L, 3);
					float duration = (float)Lua.lua_tonumber(L, 4);
					AxisConstraint axisConstraint;
					objectTranslator.Get(L, 5, out axisConstraint);
					TweenerCore<Vector3, Vector3, VectorOptions> o = DOTween.ToAxis(@delegate, delegate2, endValue, duration, axisConstraint);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Vector3> delegate3 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate4 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float endValue2 = (float)Lua.lua_tonumber(L, 3);
					float duration2 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector3, Vector3, VectorOptions> o2 = DOTween.ToAxis(delegate3, delegate4, endValue2, duration2, AxisConstraint.X);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.ToAxis!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToAlpha_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				DOGetter<Color> @delegate = objectTranslator.GetDelegate<DOGetter<Color>>(L, 1);
				DOSetter<Color> delegate2 = objectTranslator.GetDelegate<DOSetter<Color>>(L, 2);
				float endValue = (float)Lua.lua_tonumber(L, 3);
				float duration = (float)Lua.lua_tonumber(L, 4);
				TweenerCore<Color, Color, ColorOptions> o = DOTween.ToAlpha(@delegate, delegate2, endValue, duration);
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
		private static int _m_Punch_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 6 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					DOGetter<Vector3> @delegate = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate2 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					Vector3 direction;
					objectTranslator.Get(L, 3, out direction);
					float duration = (float)Lua.lua_tonumber(L, 4);
					int vibrato = Lua.xlua_tointeger(L, 5);
					float elasticity = (float)Lua.lua_tonumber(L, 6);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o = DOTween.Punch(@delegate, delegate2, direction, duration, vibrato, elasticity);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					DOGetter<Vector3> delegate3 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate4 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					Vector3 direction2;
					objectTranslator.Get(L, 3, out direction2);
					float duration2 = (float)Lua.lua_tonumber(L, 4);
					int vibrato2 = Lua.xlua_tointeger(L, 5);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o2 = DOTween.Punch(delegate3, delegate4, direction2, duration2, vibrato2, 1f);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Vector3> delegate5 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate6 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					Vector3 direction3;
					objectTranslator.Get(L, 3, out direction3);
					float duration3 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o3 = DOTween.Punch(delegate5, delegate6, direction3, duration3, 10, 1f);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Punch!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Shake_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 8 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 7) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 8))
				{
					DOGetter<Vector3> @delegate = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate2 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration = (float)Lua.lua_tonumber(L, 3);
					float strength = (float)Lua.lua_tonumber(L, 4);
					int vibrato = Lua.xlua_tointeger(L, 5);
					float randomness = (float)Lua.lua_tonumber(L, 6);
					bool ignoreZAxis = Lua.lua_toboolean(L, 7);
					bool fadeOut = Lua.lua_toboolean(L, 8);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o = DOTween.Shake(@delegate, delegate2, duration, strength, vibrato, randomness, ignoreZAxis, fadeOut);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 7 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 7))
				{
					DOGetter<Vector3> delegate3 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate4 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration2 = (float)Lua.lua_tonumber(L, 3);
					float strength2 = (float)Lua.lua_tonumber(L, 4);
					int vibrato2 = Lua.xlua_tointeger(L, 5);
					float randomness2 = (float)Lua.lua_tonumber(L, 6);
					bool ignoreZAxis2 = Lua.lua_toboolean(L, 7);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o2 = DOTween.Shake(delegate3, delegate4, duration2, strength2, vibrato2, randomness2, ignoreZAxis2, true);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 6 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					DOGetter<Vector3> delegate5 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate6 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration3 = (float)Lua.lua_tonumber(L, 3);
					float strength3 = (float)Lua.lua_tonumber(L, 4);
					int vibrato3 = Lua.xlua_tointeger(L, 5);
					float randomness3 = (float)Lua.lua_tonumber(L, 6);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o3 = DOTween.Shake(delegate5, delegate6, duration3, strength3, vibrato3, randomness3, true, true);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					DOGetter<Vector3> delegate7 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate8 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration4 = (float)Lua.lua_tonumber(L, 3);
					float strength4 = (float)Lua.lua_tonumber(L, 4);
					int vibrato4 = Lua.xlua_tointeger(L, 5);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o4 = DOTween.Shake(delegate7, delegate8, duration4, strength4, vibrato4, 90f, true, true);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					DOGetter<Vector3> delegate9 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate10 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration5 = (float)Lua.lua_tonumber(L, 3);
					float strength5 = (float)Lua.lua_tonumber(L, 4);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o5 = DOTween.Shake(delegate9, delegate10, duration5, strength5, 10, 90f, true, true);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					DOGetter<Vector3> delegate11 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate12 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration6 = (float)Lua.lua_tonumber(L, 3);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o6 = DOTween.Shake(delegate11, delegate12, duration6, 3f, 10, 90f, true, true);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 7 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Vector3>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 7))
				{
					DOGetter<Vector3> delegate13 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate14 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration7 = (float)Lua.lua_tonumber(L, 3);
					Vector3 strength6;
					objectTranslator.Get(L, 4, out strength6);
					int vibrato5 = Lua.xlua_tointeger(L, 5);
					float randomness4 = (float)Lua.lua_tonumber(L, 6);
					bool fadeOut2 = Lua.lua_toboolean(L, 7);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o7 = DOTween.Shake(delegate13, delegate14, duration7, strength6, vibrato5, randomness4, fadeOut2);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 6 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Vector3>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					DOGetter<Vector3> delegate15 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate16 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration8 = (float)Lua.lua_tonumber(L, 3);
					Vector3 strength7;
					objectTranslator.Get(L, 4, out strength7);
					int vibrato6 = Lua.xlua_tointeger(L, 5);
					float randomness5 = (float)Lua.lua_tonumber(L, 6);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o8 = DOTween.Shake(delegate15, delegate16, duration8, strength7, vibrato6, randomness5, true);
					objectTranslator.Push(L, o8);
					return 1;
				}
				if (num == 5 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Vector3>(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					DOGetter<Vector3> delegate17 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate18 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration9 = (float)Lua.lua_tonumber(L, 3);
					Vector3 strength8;
					objectTranslator.Get(L, 4, out strength8);
					int vibrato7 = Lua.xlua_tointeger(L, 5);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o9 = DOTween.Shake(delegate17, delegate18, duration9, strength8, vibrato7, 90f, true);
					objectTranslator.Push(L, o9);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<DOGetter<Vector3>>(L, 1) && objectTranslator.Assignable<DOSetter<Vector3>>(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && objectTranslator.Assignable<Vector3>(L, 4))
				{
					DOGetter<Vector3> delegate19 = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
					DOSetter<Vector3> delegate20 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
					float duration10 = (float)Lua.lua_tonumber(L, 3);
					Vector3 strength9;
					objectTranslator.Get(L, 4, out strength9);
					TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o10 = DOTween.Shake(delegate19, delegate20, duration10, strength9, 10, 90f, true);
					objectTranslator.Push(L, o10);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Shake!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToArray_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				DOGetter<Vector3> @delegate = objectTranslator.GetDelegate<DOGetter<Vector3>>(L, 1);
				DOSetter<Vector3> delegate2 = objectTranslator.GetDelegate<DOSetter<Vector3>>(L, 2);
				Vector3[] endValues = (Vector3[])objectTranslator.GetObject(L, 3, typeof(Vector3[]));
				float[] durations = (float[])objectTranslator.GetObject(L, 4, typeof(float[]));
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o = DOTween.ToArray(@delegate, delegate2, endValues, durations);
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
		private static int _m_Sequence_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence o = DOTween.Sequence();
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
		private static int _m_CompleteAll_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1))
				{
					int value = DOTween.CompleteAll(Lua.lua_toboolean(L, 1));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 0)
				{
					int value2 = DOTween.CompleteAll(false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.CompleteAll!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Complete_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool withCallbacks = Lua.lua_toboolean(L, 2);
					int value = DOTween.Complete(@object, withCallbacks);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value2 = DOTween.Complete(objectTranslator.GetObject(L, 1, typeof(object)), false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Complete!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_FlipAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.FlipAll();
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
		private static int _m_Flip_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.Flip(ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(object)));
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
		private static int _m_GotoAll_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					float to = (float)Lua.lua_tonumber(L, 1);
					bool andPlay = Lua.lua_toboolean(L, 2);
					int value = DOTween.GotoAll(to, andPlay);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1))
				{
					int value2 = DOTween.GotoAll((float)Lua.lua_tonumber(L, 1), false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.GotoAll!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Goto_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					float to = (float)Lua.lua_tonumber(L, 2);
					bool andPlay = Lua.lua_toboolean(L, 3);
					int value = DOTween.Goto(@object, to, andPlay);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					object object2 = objectTranslator.GetObject(L, 1, typeof(object));
					float to2 = (float)Lua.lua_tonumber(L, 2);
					int value2 = DOTween.Goto(object2, to2, false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Goto!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_KillAll_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1))
				{
					int value = DOTween.KillAll(Lua.lua_toboolean(L, 1));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 0)
				{
					int value2 = DOTween.KillAll(false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num >= 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 2) || objectTranslator.Assignable<object>(L, 2)))
				{
					bool complete = Lua.lua_toboolean(L, 1);
					object[] @params = objectTranslator.GetParams<object>(L, 2);
					int value3 = DOTween.KillAll(complete, @params);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.KillAll!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Kill_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool complete = Lua.lua_toboolean(L, 2);
					int value = DOTween.Kill(@object, complete);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value2 = DOTween.Kill(objectTranslator.GetObject(L, 1, typeof(object)), false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Kill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PauseAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.PauseAll();
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
		private static int _m_Pause_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.Pause(ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(object)));
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
		private static int _m_PlayAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.PlayAll();
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
		private static int _m_Play_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value = DOTween.Play(objectTranslator.GetObject(L, 1, typeof(object)));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					object object2 = objectTranslator.GetObject(L, 2, typeof(object));
					int value2 = DOTween.Play(@object, object2);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Play!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PlayBackwardsAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.PlayBackwardsAll();
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
		private static int _m_PlayBackwards_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value = DOTween.PlayBackwards(objectTranslator.GetObject(L, 1, typeof(object)));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					object object2 = objectTranslator.GetObject(L, 2, typeof(object));
					int value2 = DOTween.PlayBackwards(@object, object2);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.PlayBackwards!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PlayForwardAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.PlayForwardAll();
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
		private static int _m_PlayForward_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value = DOTween.PlayForward(objectTranslator.GetObject(L, 1, typeof(object)));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					object object2 = objectTranslator.GetObject(L, 2, typeof(object));
					int value2 = DOTween.PlayForward(@object, object2);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.PlayForward!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_RestartAll_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1))
				{
					int value = DOTween.RestartAll(Lua.lua_toboolean(L, 1));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 0)
				{
					int value2 = DOTween.RestartAll(true);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.RestartAll!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Restart_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool includeDelay = Lua.lua_toboolean(L, 2);
					float changeDelayTo = (float)Lua.lua_tonumber(L, 3);
					int value = DOTween.Restart(@object, includeDelay, changeDelayTo);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object object2 = objectTranslator.GetObject(L, 1, typeof(object));
					bool includeDelay2 = Lua.lua_toboolean(L, 2);
					int value2 = DOTween.Restart(object2, includeDelay2, -1f);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value3 = DOTween.Restart(objectTranslator.GetObject(L, 1, typeof(object)), true, -1f);
					Lua.xlua_pushinteger(L, value3);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<object>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					object object3 = objectTranslator.GetObject(L, 1, typeof(object));
					object object4 = objectTranslator.GetObject(L, 2, typeof(object));
					bool includeDelay3 = Lua.lua_toboolean(L, 3);
					float changeDelayTo2 = (float)Lua.lua_tonumber(L, 4);
					int value4 = DOTween.Restart(object3, object4, includeDelay3, changeDelayTo2);
					Lua.xlua_pushinteger(L, value4);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<object>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					object object5 = objectTranslator.GetObject(L, 1, typeof(object));
					object object6 = objectTranslator.GetObject(L, 2, typeof(object));
					bool includeDelay4 = Lua.lua_toboolean(L, 3);
					int value5 = DOTween.Restart(object5, object6, includeDelay4, -1f);
					Lua.xlua_pushinteger(L, value5);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<object>(L, 2))
				{
					object object7 = objectTranslator.GetObject(L, 1, typeof(object));
					object object8 = objectTranslator.GetObject(L, 2, typeof(object));
					int value6 = DOTween.Restart(object7, object8, true, -1f);
					Lua.xlua_pushinteger(L, value6);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Restart!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_RewindAll_xlua_st_(IntPtr L)
		{
			try
			{
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1))
				{
					int value = DOTween.RewindAll(Lua.lua_toboolean(L, 1));
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 0)
				{
					int value2 = DOTween.RewindAll(true);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.RewindAll!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Rewind_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool includeDelay = Lua.lua_toboolean(L, 2);
					int value = DOTween.Rewind(@object, includeDelay);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					int value2 = DOTween.Rewind(objectTranslator.GetObject(L, 1, typeof(object)), true);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.Rewind!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SmoothRewindAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.SmoothRewindAll();
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
		private static int _m_SmoothRewind_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.SmoothRewind(ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(object)));
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
		private static int _m_TogglePauseAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.TogglePauseAll();
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
		private static int _m_TogglePause_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.TogglePause(ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(object)));
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
		private static int _m_IsTweening_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool alsoCheckIfIsPlaying = Lua.lua_toboolean(L, 2);
					bool value = DOTween.IsTweening(@object, alsoCheckIfIsPlaying);
					Lua.lua_pushboolean(L, value);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					bool value2 = DOTween.IsTweening(objectTranslator.GetObject(L, 1, typeof(object)), false);
					Lua.lua_pushboolean(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.IsTweening!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TotalPlayingTweens_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				int value = DOTween.TotalPlayingTweens();
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
		private static int _m_PlayingTweens_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<List<Tween>>(L, 1))
				{
					List<Tween> o = DOTween.PlayingTweens((List<Tween>)objectTranslator.GetObject(L, 1, typeof(List<Tween>)));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 0)
				{
					List<Tween> o2 = DOTween.PlayingTweens(null);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.PlayingTweens!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PausedTweens_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<List<Tween>>(L, 1))
				{
					List<Tween> o = DOTween.PausedTweens((List<Tween>)objectTranslator.GetObject(L, 1, typeof(List<Tween>)));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 0)
				{
					List<Tween> o2 = DOTween.PausedTweens(null);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.PausedTweens!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TweensById_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2) && objectTranslator.Assignable<List<Tween>>(L, 3))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool playingOnly = Lua.lua_toboolean(L, 2);
					List<Tween> fillableList = (List<Tween>)objectTranslator.GetObject(L, 3, typeof(List<Tween>));
					List<Tween> o = DOTween.TweensById(@object, playingOnly, fillableList);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object object2 = objectTranslator.GetObject(L, 1, typeof(object));
					bool playingOnly2 = Lua.lua_toboolean(L, 2);
					List<Tween> o2 = DOTween.TweensById(object2, playingOnly2, null);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					List<Tween> o3 = DOTween.TweensById(objectTranslator.GetObject(L, 1, typeof(object)), false, null);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.TweensById!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TweensByTarget_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2) && objectTranslator.Assignable<List<Tween>>(L, 3))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					bool playingOnly = Lua.lua_toboolean(L, 2);
					List<Tween> fillableList = (List<Tween>)objectTranslator.GetObject(L, 3, typeof(List<Tween>));
					List<Tween> o = DOTween.TweensByTarget(@object, playingOnly, fillableList);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					object object2 = objectTranslator.GetObject(L, 1, typeof(object));
					bool playingOnly2 = Lua.lua_toboolean(L, 2);
					List<Tween> o2 = DOTween.TweensByTarget(object2, playingOnly2, null);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					List<Tween> o3 = DOTween.TweensByTarget(objectTranslator.GetObject(L, 1, typeof(object)), false, null);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.DOTween.TweensByTarget!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_logBehaviour(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushDGTweeningLogBehaviour(L, DOTween.logBehaviour);
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
		private static int _g_get_debugStoreTargetId(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.debugStoreTargetId);
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
		private static int _g_get_useSafeMode(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.useSafeMode);
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
		private static int _g_get_nestedTweenFailureBehaviour(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).Push(L, DOTween.nestedTweenFailureBehaviour);
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
		private static int _g_get_showUnityEditorReport(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.showUnityEditorReport);
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
				Lua.lua_pushnumber(L, (double)DOTween.timeScale);
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
		private static int _g_get_useSmoothDeltaTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.useSmoothDeltaTime);
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
		private static int _g_get_maxSmoothUnscaledTime(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)DOTween.maxSmoothUnscaledTime);
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
		private static int _g_get_onWillLog(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).Push(L, DOTween.onWillLog);
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
		private static int _g_get_drawGizmos(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.drawGizmos);
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
		private static int _g_get_debugMode(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.debugMode);
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
		private static int _g_get_defaultUpdateType(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushDGTweeningUpdateType(L, DOTween.defaultUpdateType);
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
		private static int _g_get_defaultTimeScaleIndependent(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.defaultTimeScaleIndependent);
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
		private static int _g_get_defaultAutoPlay(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushDGTweeningAutoPlay(L, DOTween.defaultAutoPlay);
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
		private static int _g_get_defaultAutoKill(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.defaultAutoKill);
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
		private static int _g_get_defaultLoopType(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushDGTweeningLoopType(L, DOTween.defaultLoopType);
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
		private static int _g_get_defaultRecyclable(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, DOTween.defaultRecyclable);
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
		private static int _g_get_defaultEaseType(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushDGTweeningEase(L, DOTween.defaultEaseType);
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
		private static int _g_get_defaultEaseOvershootOrAmplitude(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)DOTween.defaultEaseOvershootOrAmplitude);
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
		private static int _g_get_defaultEasePeriod(IntPtr L)
		{
			try
			{
				Lua.lua_pushnumber(L, (double)DOTween.defaultEasePeriod);
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
		private static int _g_get_instance(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).Push(L, DOTween.instance);
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
		private static int _s_set_logBehaviour(IntPtr L)
		{
			try
			{
				LogBehaviour logBehaviour;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out logBehaviour);
				DOTween.logBehaviour = logBehaviour;
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
		private static int _s_set_debugStoreTargetId(IntPtr L)
		{
			try
			{
				DOTween.debugStoreTargetId = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_useSafeMode(IntPtr L)
		{
			try
			{
				DOTween.useSafeMode = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_nestedTweenFailureBehaviour(IntPtr L)
		{
			try
			{
				NestedTweenFailureBehaviour nestedTweenFailureBehaviour;
				ObjectTranslatorPool.Instance.Find(L).Get<NestedTweenFailureBehaviour>(L, 1, out nestedTweenFailureBehaviour);
				DOTween.nestedTweenFailureBehaviour = nestedTweenFailureBehaviour;
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
		private static int _s_set_showUnityEditorReport(IntPtr L)
		{
			try
			{
				DOTween.showUnityEditorReport = Lua.lua_toboolean(L, 1);
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
				DOTween.timeScale = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_useSmoothDeltaTime(IntPtr L)
		{
			try
			{
				DOTween.useSmoothDeltaTime = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_maxSmoothUnscaledTime(IntPtr L)
		{
			try
			{
				DOTween.maxSmoothUnscaledTime = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_onWillLog(IntPtr L)
		{
			try
			{
				DOTween.onWillLog = ObjectTranslatorPool.Instance.Find(L).GetDelegate<Func<UnityEngine.LogType, object, bool>>(L, 1);
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
		private static int _s_set_drawGizmos(IntPtr L)
		{
			try
			{
				DOTween.drawGizmos = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_debugMode(IntPtr L)
		{
			try
			{
				DOTween.debugMode = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_defaultUpdateType(IntPtr L)
		{
			try
			{
				UpdateType defaultUpdateType;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out defaultUpdateType);
				DOTween.defaultUpdateType = defaultUpdateType;
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
		private static int _s_set_defaultTimeScaleIndependent(IntPtr L)
		{
			try
			{
				DOTween.defaultTimeScaleIndependent = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_defaultAutoPlay(IntPtr L)
		{
			try
			{
				AutoPlay defaultAutoPlay;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out defaultAutoPlay);
				DOTween.defaultAutoPlay = defaultAutoPlay;
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
		private static int _s_set_defaultAutoKill(IntPtr L)
		{
			try
			{
				DOTween.defaultAutoKill = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_defaultLoopType(IntPtr L)
		{
			try
			{
				LoopType defaultLoopType;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out defaultLoopType);
				DOTween.defaultLoopType = defaultLoopType;
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
		private static int _s_set_defaultRecyclable(IntPtr L)
		{
			try
			{
				DOTween.defaultRecyclable = Lua.lua_toboolean(L, 1);
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
		private static int _s_set_defaultEaseType(IntPtr L)
		{
			try
			{
				Ease defaultEaseType;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out defaultEaseType);
				DOTween.defaultEaseType = defaultEaseType;
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
		private static int _s_set_defaultEaseOvershootOrAmplitude(IntPtr L)
		{
			try
			{
				DOTween.defaultEaseOvershootOrAmplitude = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_defaultEasePeriod(IntPtr L)
		{
			try
			{
				DOTween.defaultEasePeriod = (float)Lua.lua_tonumber(L, 1);
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
		private static int _s_set_instance(IntPtr L)
		{
			try
			{
				DOTween.instance = (DOTweenComponent)ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(DOTweenComponent));
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
