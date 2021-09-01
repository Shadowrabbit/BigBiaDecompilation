using System;
using DG.Tweening;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class DGTweeningSequenceWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Sequence);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 32, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "Pause", new lua_CSFunction(DGTweeningSequenceWrap._m_Pause));
			Utils.RegisterFunc(L, -3, "Play", new lua_CSFunction(DGTweeningSequenceWrap._m_Play));
			Utils.RegisterFunc(L, -3, "SetAutoKill", new lua_CSFunction(DGTweeningSequenceWrap._m_SetAutoKill));
			Utils.RegisterFunc(L, -3, "SetId", new lua_CSFunction(DGTweeningSequenceWrap._m_SetId));
			Utils.RegisterFunc(L, -3, "SetLink", new lua_CSFunction(DGTweeningSequenceWrap._m_SetLink));
			Utils.RegisterFunc(L, -3, "SetTarget", new lua_CSFunction(DGTweeningSequenceWrap._m_SetTarget));
			Utils.RegisterFunc(L, -3, "SetLoops", new lua_CSFunction(DGTweeningSequenceWrap._m_SetLoops));
			Utils.RegisterFunc(L, -3, "SetEase", new lua_CSFunction(DGTweeningSequenceWrap._m_SetEase));
			Utils.RegisterFunc(L, -3, "SetRecyclable", new lua_CSFunction(DGTweeningSequenceWrap._m_SetRecyclable));
			Utils.RegisterFunc(L, -3, "SetUpdate", new lua_CSFunction(DGTweeningSequenceWrap._m_SetUpdate));
			Utils.RegisterFunc(L, -3, "OnStart", new lua_CSFunction(DGTweeningSequenceWrap._m_OnStart));
			Utils.RegisterFunc(L, -3, "OnPlay", new lua_CSFunction(DGTweeningSequenceWrap._m_OnPlay));
			Utils.RegisterFunc(L, -3, "OnPause", new lua_CSFunction(DGTweeningSequenceWrap._m_OnPause));
			Utils.RegisterFunc(L, -3, "OnRewind", new lua_CSFunction(DGTweeningSequenceWrap._m_OnRewind));
			Utils.RegisterFunc(L, -3, "OnUpdate", new lua_CSFunction(DGTweeningSequenceWrap._m_OnUpdate));
			Utils.RegisterFunc(L, -3, "OnStepComplete", new lua_CSFunction(DGTweeningSequenceWrap._m_OnStepComplete));
			Utils.RegisterFunc(L, -3, "OnComplete", new lua_CSFunction(DGTweeningSequenceWrap._m_OnComplete));
			Utils.RegisterFunc(L, -3, "OnKill", new lua_CSFunction(DGTweeningSequenceWrap._m_OnKill));
			Utils.RegisterFunc(L, -3, "OnWaypointChange", new lua_CSFunction(DGTweeningSequenceWrap._m_OnWaypointChange));
			Utils.RegisterFunc(L, -3, "SetAs", new lua_CSFunction(DGTweeningSequenceWrap._m_SetAs));
			Utils.RegisterFunc(L, -3, "Append", new lua_CSFunction(DGTweeningSequenceWrap._m_Append));
			Utils.RegisterFunc(L, -3, "Prepend", new lua_CSFunction(DGTweeningSequenceWrap._m_Prepend));
			Utils.RegisterFunc(L, -3, "Join", new lua_CSFunction(DGTweeningSequenceWrap._m_Join));
			Utils.RegisterFunc(L, -3, "Insert", new lua_CSFunction(DGTweeningSequenceWrap._m_Insert));
			Utils.RegisterFunc(L, -3, "AppendInterval", new lua_CSFunction(DGTweeningSequenceWrap._m_AppendInterval));
			Utils.RegisterFunc(L, -3, "PrependInterval", new lua_CSFunction(DGTweeningSequenceWrap._m_PrependInterval));
			Utils.RegisterFunc(L, -3, "AppendCallback", new lua_CSFunction(DGTweeningSequenceWrap._m_AppendCallback));
			Utils.RegisterFunc(L, -3, "PrependCallback", new lua_CSFunction(DGTweeningSequenceWrap._m_PrependCallback));
			Utils.RegisterFunc(L, -3, "InsertCallback", new lua_CSFunction(DGTweeningSequenceWrap._m_InsertCallback));
			Utils.RegisterFunc(L, -3, "SetDelay", new lua_CSFunction(DGTweeningSequenceWrap._m_SetDelay));
			Utils.RegisterFunc(L, -3, "SetRelative", new lua_CSFunction(DGTweeningSequenceWrap._m_SetRelative));
			Utils.RegisterFunc(L, -3, "SetSpeedBased", new lua_CSFunction(DGTweeningSequenceWrap._m_SetSpeedBased));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(DGTweeningSequenceWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			return Lua.luaL_error(L, "DG.Tweening.Sequence does not have a constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Pause(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Tween o = ((Sequence)objectTranslator.FastGetCSObj(L, 1)).Pause<Sequence>();
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
				Tween o = ((Sequence)objectTranslator.FastGetCSObj(L, 1)).Play<Sequence>();
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
				Sequence sequence = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = sequence.SetAutoKill<Sequence>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool autoKillOnCompletion = Lua.lua_toboolean(L, 2);
					Tween o2 = sequence.SetAutoKill(autoKillOnCompletion);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetAutoKill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetId(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetId!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetLink(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetLink!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetTarget(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetLoops!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetEase(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetEase!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetRecyclable(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence sequence = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = sequence.SetRecyclable<Sequence>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool recyclable = Lua.lua_toboolean(L, 2);
					Tween o2 = sequence.SetRecyclable(recyclable);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetRecyclable!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetUpdate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetUpdate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_OnStart(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetAs!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Append(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				Tween t = (Tween)objectTranslator.GetObject(L, 2, typeof(Tween));
				Sequence o = s.Append(t);
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
		private static int _m_Prepend(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				Tween t = (Tween)objectTranslator.GetObject(L, 2, typeof(Tween));
				Sequence o = s.Prepend(t);
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
		private static int _m_Join(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				Tween t = (Tween)objectTranslator.GetObject(L, 2, typeof(Tween));
				Sequence o = s.Join(t);
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
		private static int _m_Insert(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				float atPosition = (float)Lua.lua_tonumber(L, 2);
				Tween t = (Tween)objectTranslator.GetObject(L, 3, typeof(Tween));
				Sequence o = s.Insert(atPosition, t);
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
		private static int _m_AppendInterval(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				float interval = (float)Lua.lua_tonumber(L, 2);
				Sequence o = s.AppendInterval(interval);
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
		private static int _m_PrependInterval(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				float interval = (float)Lua.lua_tonumber(L, 2);
				Sequence o = s.PrependInterval(interval);
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
		private static int _m_AppendCallback(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Sequence o = s.AppendCallback(@delegate);
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
		private static int _m_PrependCallback(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 2);
				Sequence o = s.PrependCallback(@delegate);
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
		private static int _m_InsertCallback(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence s = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				float atPosition = (float)Lua.lua_tonumber(L, 2);
				TweenCallback @delegate = objectTranslator.GetDelegate<TweenCallback>(L, 3);
				Sequence o = s.InsertCallback(atPosition, @delegate);
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
				Sequence t = (Sequence)objectTranslator.FastGetCSObj(L, 1);
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
				Sequence sequence = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = sequence.SetRelative<Sequence>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isRelative = Lua.lua_toboolean(L, 2);
					Tween o2 = sequence.SetRelative(isRelative);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetRelative!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetSpeedBased(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Sequence sequence = (Sequence)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					Tween o = sequence.SetSpeedBased<Sequence>();
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool isSpeedBased = Lua.lua_toboolean(L, 2);
					Tween o2 = sequence.SetSpeedBased(isSpeedBased);
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
			return Lua.luaL_error(L, "invalid arguments to DG.Tweening.Sequence.SetSpeedBased!");
		}
	}
}
