using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineAnimationClipWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(AnimationClip);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 5, 12, 5, -1);
			Utils.RegisterFunc(L, -3, "SampleAnimation", new lua_CSFunction(UnityEngineAnimationClipWrap._m_SampleAnimation));
			Utils.RegisterFunc(L, -3, "SetCurve", new lua_CSFunction(UnityEngineAnimationClipWrap._m_SetCurve));
			Utils.RegisterFunc(L, -3, "EnsureQuaternionContinuity", new lua_CSFunction(UnityEngineAnimationClipWrap._m_EnsureQuaternionContinuity));
			Utils.RegisterFunc(L, -3, "ClearCurves", new lua_CSFunction(UnityEngineAnimationClipWrap._m_ClearCurves));
			Utils.RegisterFunc(L, -3, "AddEvent", new lua_CSFunction(UnityEngineAnimationClipWrap._m_AddEvent));
			Utils.RegisterFunc(L, -2, "length", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_length));
			Utils.RegisterFunc(L, -2, "frameRate", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_frameRate));
			Utils.RegisterFunc(L, -2, "wrapMode", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_wrapMode));
			Utils.RegisterFunc(L, -2, "localBounds", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_localBounds));
			Utils.RegisterFunc(L, -2, "legacy", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_legacy));
			Utils.RegisterFunc(L, -2, "humanMotion", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_humanMotion));
			Utils.RegisterFunc(L, -2, "empty", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_empty));
			Utils.RegisterFunc(L, -2, "hasGenericRootTransform", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_hasGenericRootTransform));
			Utils.RegisterFunc(L, -2, "hasMotionFloatCurves", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_hasMotionFloatCurves));
			Utils.RegisterFunc(L, -2, "hasMotionCurves", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_hasMotionCurves));
			Utils.RegisterFunc(L, -2, "hasRootCurves", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_hasRootCurves));
			Utils.RegisterFunc(L, -2, "events", new lua_CSFunction(UnityEngineAnimationClipWrap._g_get_events));
			Utils.RegisterFunc(L, -1, "frameRate", new lua_CSFunction(UnityEngineAnimationClipWrap._s_set_frameRate));
			Utils.RegisterFunc(L, -1, "wrapMode", new lua_CSFunction(UnityEngineAnimationClipWrap._s_set_wrapMode));
			Utils.RegisterFunc(L, -1, "localBounds", new lua_CSFunction(UnityEngineAnimationClipWrap._s_set_localBounds));
			Utils.RegisterFunc(L, -1, "legacy", new lua_CSFunction(UnityEngineAnimationClipWrap._s_set_legacy));
			Utils.RegisterFunc(L, -1, "events", new lua_CSFunction(UnityEngineAnimationClipWrap._s_set_events));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineAnimationClipWrap.__CreateInstance), 1, 0, 0);
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
					AnimationClip o = new AnimationClip();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.AnimationClip constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SampleAnimation(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				GameObject go = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
				float time = (float)Lua.lua_tonumber(L, 3);
				animationClip.SampleAnimation(go, time);
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
		private static int _m_SetCurve(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				string relativePath = Lua.lua_tostring(L, 2);
				Type type = (Type)objectTranslator.GetObject(L, 3, typeof(Type));
				string propertyName = Lua.lua_tostring(L, 4);
				AnimationCurve curve = (AnimationCurve)objectTranslator.GetObject(L, 5, typeof(AnimationCurve));
				animationClip.SetCurve(relativePath, type, propertyName, curve);
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
		private static int _m_EnsureQuaternionContinuity(IntPtr L)
		{
			int result;
			try
			{
				((AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).EnsureQuaternionContinuity();
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
		private static int _m_ClearCurves(IntPtr L)
		{
			int result;
			try
			{
				((AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ClearCurves();
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
		private static int _m_AddEvent(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				AnimationEvent evt = (AnimationEvent)objectTranslator.GetObject(L, 2, typeof(AnimationEvent));
				animationClip.AddEvent(evt);
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
		private static int _g_get_length(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)animationClip.length);
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
		private static int _g_get_frameRate(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushnumber(L, (double)animationClip.frameRate);
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
		private static int _g_get_wrapMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, animationClip.wrapMode);
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
		private static int _g_get_localBounds(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.PushUnityEngineBounds(L, animationClip.localBounds);
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
		private static int _g_get_legacy(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.legacy);
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
		private static int _g_get_humanMotion(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.humanMotion);
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
		private static int _g_get_empty(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.empty);
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
		private static int _g_get_hasGenericRootTransform(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.hasGenericRootTransform);
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
		private static int _g_get_hasMotionFloatCurves(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.hasMotionFloatCurves);
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
		private static int _g_get_hasMotionCurves(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.hasMotionCurves);
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
		private static int _g_get_hasRootCurves(IntPtr L)
		{
			try
			{
				AnimationClip animationClip = (AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, animationClip.hasRootCurves);
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
		private static int _g_get_events(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, animationClip.events);
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
		private static int _s_set_frameRate(IntPtr L)
		{
			try
			{
				((AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).frameRate = (float)Lua.lua_tonumber(L, 2);
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
		private static int _s_set_wrapMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				WrapMode wrapMode;
				objectTranslator.Get<WrapMode>(L, 2, out wrapMode);
				animationClip.wrapMode = wrapMode;
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
		private static int _s_set_localBounds(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationClip animationClip = (AnimationClip)objectTranslator.FastGetCSObj(L, 1);
				Bounds localBounds;
				objectTranslator.Get(L, 2, out localBounds);
				animationClip.localBounds = localBounds;
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
		private static int _s_set_legacy(IntPtr L)
		{
			try
			{
				((AnimationClip)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).legacy = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_events(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((AnimationClip)objectTranslator.FastGetCSObj(L, 1)).events = (AnimationEvent[])objectTranslator.GetObject(L, 2, typeof(AnimationEvent[]));
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
