using System;
using DG.Tweening;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningTweenParamsWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(TweenParams);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 19, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "Clear", new lua_CSFunction(DGTweeningTweenParamsWrap._m_Clear));
			Utils.RegisterFunc(L, -3, "SetAutoKill", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetAutoKill));
			Utils.RegisterFunc(L, -3, "SetId", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetId));
			Utils.RegisterFunc(L, -3, "SetTarget", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetTarget));
			Utils.RegisterFunc(L, -3, "SetLoops", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetLoops));
			Utils.RegisterFunc(L, -3, "SetEase", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetEase));
			Utils.RegisterFunc(L, -3, "SetRecyclable", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetRecyclable));
			Utils.RegisterFunc(L, -3, "SetUpdate", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetUpdate));
			Utils.RegisterFunc(L, -3, "OnStart", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnStart));
			Utils.RegisterFunc(L, -3, "OnPlay", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnPlay));
			Utils.RegisterFunc(L, -3, "OnRewind", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnRewind));
			Utils.RegisterFunc(L, -3, "OnUpdate", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnUpdate));
			Utils.RegisterFunc(L, -3, "OnStepComplete", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnStepComplete));
			Utils.RegisterFunc(L, -3, "OnComplete", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnComplete));
			Utils.RegisterFunc(L, -3, "OnKill", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnKill));
			Utils.RegisterFunc(L, -3, "OnWaypointChange", new lua_CSFunction(DGTweeningTweenParamsWrap._m_OnWaypointChange));
			Utils.RegisterFunc(L, -3, "SetDelay", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetDelay));
			Utils.RegisterFunc(L, -3, "SetRelative", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetRelative));
			Utils.RegisterFunc(L, -3, "SetSpeedBased", new lua_CSFunction(DGTweeningTweenParamsWrap._m_SetSpeedBased));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningTweenParamsWrap.__CreateInstance), 2, 0, 0);
			Utils.RegisterObject(L, translator, -4, "Params", TweenParams.Params);
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
					TweenParams o = new TweenParams();
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Clear(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams o = ((TweenParams)objectTranslator.FastGetCSObj(L, 1)).Clear();
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
		private static int _m_SetAutoKill(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool autoKill = Lua.lua_toboolean(L, 2);
					TweenParams o = tweenParams.SetAutoKill(autoKill);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1)
				{
					TweenParams o2 = tweenParams.SetAutoKill(true);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetAutoKill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetId(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				object @object = objectTranslator.GetObject(L, 2, typeof(object));
				TweenParams o = tweenParams.SetId(@object);
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
		private static int _m_SetTarget(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				object @object = objectTranslator.GetObject(L, 2, typeof(object));
				TweenParams o = tweenParams.SetTarget(@object);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && objectTranslator.Assignable<LoopType?>(L, 3))
				{
					int loops = Lua.xlua_tointeger(L, 2);
					LoopType? loopType;
					objectTranslator.Get<LoopType?>(L, 3, out loopType);
					TweenParams o = tweenParams.SetLoops(loops, loopType);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int loops2 = Lua.xlua_tointeger(L, 2);
					TweenParams o2 = tweenParams.SetLoops(loops2, null);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetLoops!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetEase(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<AnimationCurve>(L, 2))
				{
					AnimationCurve ease = (AnimationCurve)objectTranslator.GetObject(L, 2, typeof(AnimationCurve));
					TweenParams o = tweenParams.SetEase(ease);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<EaseFunction>(L, 2))
				{
					EaseFunction @delegate = objectTranslator.GetDelegate<EaseFunction>(L, 2);
					TweenParams o2 = tweenParams.SetEase(@delegate);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<Ease>(L, 2) && objectTranslator.Assignable<float?>(L, 3) && objectTranslator.Assignable<float?>(L, 4))
				{
					Ease ease2;
					objectTranslator.Get(L, 2, out ease2);
					float? overshootOrAmplitude;
					objectTranslator.Get<float?>(L, 3, out overshootOrAmplitude);
					float? period;
					objectTranslator.Get<float?>(L, 4, out period);
					TweenParams o3 = tweenParams.SetEase(ease2, overshootOrAmplitude, period);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Ease>(L, 2) && objectTranslator.Assignable<float?>(L, 3))
				{
					Ease ease3;
					objectTranslator.Get(L, 2, out ease3);
					float? overshootOrAmplitude2;
					objectTranslator.Get<float?>(L, 3, out overshootOrAmplitude2);
					TweenParams o4 = tweenParams.SetEase(ease3, overshootOrAmplitude2, null);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Ease>(L, 2))
				{
					Ease ease4;
					objectTranslator.Get(L, 2, out ease4);
					TweenParams o5 = tweenParams.SetEase(ease4, null, null);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetEase!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetRecyclable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool recyclable = Lua.lua_toboolean(L, 2);
					TweenParams o = tweenParams.SetRecyclable(recyclable);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1)
				{
					TweenParams o2 = tweenParams.SetRecyclable(true);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetRecyclable!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetUpdate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool update = Lua.lua_toboolean(L, 2);
					TweenParams o = tweenParams.SetUpdate(update);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UpdateType>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					UpdateType updateType;
					objectTranslator.Get(L, 2, out updateType);
					bool isIndependentUpdate = Lua.lua_toboolean(L, 3);
					TweenParams o2 = tweenParams.SetUpdate(updateType, isIndependentUpdate);
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<UpdateType>(L, 2))
				{
					UpdateType updateType2;
					objectTranslator.Get(L, 2, out updateType2);
					TweenParams o3 = tweenParams.SetUpdate(updateType2, false);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetUpdate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnStart(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnStart(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnPlay(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnRewind(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnUpdate(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnStepComplete(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnComplete(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				TweenParams o = tweenParams.OnKill(@delegate);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback<int> @delegate = objectTranslator.GetDelegate<TweenCallback<int>>(L, 2);
				TweenParams o = tweenParams.OnWaypointChange(@delegate);
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
		private static int _m_SetDelay(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				float delay = (float)Lua.lua_tonumber(L, 2);
				TweenParams o = tweenParams.SetDelay(delay);
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
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool relative = Lua.lua_toboolean(L, 2);
					TweenParams o = tweenParams.SetRelative(relative);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1)
				{
					TweenParams o2 = tweenParams.SetRelative(true);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetRelative!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetSpeedBased(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				TweenParams tweenParams = (TweenParams)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool speedBased = Lua.lua_toboolean(L, 2);
					TweenParams o = tweenParams.SetSpeedBased(speedBased);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1)
				{
					TweenParams o2 = tweenParams.SetSpeedBased(true);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.TweenParams.SetSpeedBased!");
		}
	}
}
