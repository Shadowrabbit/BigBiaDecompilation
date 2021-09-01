using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineAnimationCurveWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(AnimationCurve);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 7, 4, 3, -1);
			Utils.RegisterFunc(L, -3, "Evaluate", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_Evaluate));
			Utils.RegisterFunc(L, -3, "AddKey", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_AddKey));
			Utils.RegisterFunc(L, -3, "MoveKey", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_MoveKey));
			Utils.RegisterFunc(L, -3, "RemoveKey", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_RemoveKey));
			Utils.RegisterFunc(L, -3, "SmoothTangents", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_SmoothTangents));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_Equals));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_GetHashCode));
			Utils.RegisterFunc(L, -2, "keys", new lua_CSFunction(UnityEngineAnimationCurveWrap._g_get_keys));
			Utils.RegisterFunc(L, -2, "length", new lua_CSFunction(UnityEngineAnimationCurveWrap._g_get_length));
			Utils.RegisterFunc(L, -2, "preWrapMode", new lua_CSFunction(UnityEngineAnimationCurveWrap._g_get_preWrapMode));
			Utils.RegisterFunc(L, -2, "postWrapMode", new lua_CSFunction(UnityEngineAnimationCurveWrap._g_get_postWrapMode));
			Utils.RegisterFunc(L, -1, "keys", new lua_CSFunction(UnityEngineAnimationCurveWrap._s_set_keys));
			Utils.RegisterFunc(L, -1, "preWrapMode", new lua_CSFunction(UnityEngineAnimationCurveWrap._s_set_preWrapMode));
			Utils.RegisterFunc(L, -1, "postWrapMode", new lua_CSFunction(UnityEngineAnimationCurveWrap._s_set_postWrapMode));
			Utils.EndObjectRegister(typeFromHandle, L, translator, new lua_CSFunction(UnityEngineAnimationCurveWrap.__CSIndexer), null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineAnimationCurveWrap.__CreateInstance), 4, 0, 0);
			Utils.RegisterFunc(L, -4, "Constant", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_Constant_xlua_st_));
			Utils.RegisterFunc(L, -4, "Linear", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_Linear_xlua_st_));
			Utils.RegisterFunc(L, -4, "EaseInOut", new lua_CSFunction(UnityEngineAnimationCurveWrap._m_EaseInOut_xlua_st_));
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) >= 1 && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 2) || objectTranslator.Assignable<Keyframe>(L, 2)))
				{
					AnimationCurve o = new AnimationCurve(objectTranslator.GetParams<Keyframe>(L, 2));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					AnimationCurve o2 = new AnimationCurve();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.AnimationCurve constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __CSIndexer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<AnimationCurve>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
					int index = Lua.xlua_tointeger(L, 2);
					Lua.lua_pushboolean(L, true);
					objectTranslator.Push(L, animationCurve[index]);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			Lua.lua_pushboolean(L, false);
			return 1;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Evaluate(IntPtr L)
		{
			int result;
			try
			{
				AnimationCurve animationCurve = (AnimationCurve)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				float time = (float)Lua.lua_tonumber(L, 2);
				float num = animationCurve.Evaluate(time);
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
		private static int _m_AddKey(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float time = (float)Lua.lua_tonumber(L, 2);
					float value = (float)Lua.lua_tonumber(L, 3);
					int value2 = animationCurve.AddKey(time, value);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Keyframe>(L, 2))
				{
					Keyframe key;
					objectTranslator.Get<Keyframe>(L, 2, out key);
					int value3 = animationCurve.AddKey(key);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.AnimationCurve.AddKey!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_MoveKey(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				Keyframe key;
				objectTranslator.Get<Keyframe>(L, 3, out key);
				int value = animationCurve.MoveKey(index, key);
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
		private static int _m_RemoveKey(IntPtr L)
		{
			int result;
			try
			{
				AnimationCurve animationCurve = (AnimationCurve)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				animationCurve.RemoveKey(index);
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
		private static int _m_SmoothTangents(IntPtr L)
		{
			int result;
			try
			{
				AnimationCurve animationCurve = (AnimationCurve)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int index = Lua.xlua_tointeger(L, 2);
				float weight = (float)Lua.lua_tonumber(L, 3);
				animationCurve.SmoothTangents(index, weight);
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
		private static int _m_Constant_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				float timeStart = (float)Lua.lua_tonumber(L, 1);
				float timeEnd = (float)Lua.lua_tonumber(L, 2);
				float value = (float)Lua.lua_tonumber(L, 3);
				AnimationCurve o = AnimationCurve.Constant(timeStart, timeEnd, value);
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
		private static int _m_Linear_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				float timeStart = (float)Lua.lua_tonumber(L, 1);
				float valueStart = (float)Lua.lua_tonumber(L, 2);
				float timeEnd = (float)Lua.lua_tonumber(L, 3);
				float valueEnd = (float)Lua.lua_tonumber(L, 4);
				AnimationCurve o = AnimationCurve.Linear(timeStart, valueStart, timeEnd, valueEnd);
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
		private static int _m_EaseInOut_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				float timeStart = (float)Lua.lua_tonumber(L, 1);
				float valueStart = (float)Lua.lua_tonumber(L, 2);
				float timeEnd = (float)Lua.lua_tonumber(L, 3);
				float valueEnd = (float)Lua.lua_tonumber(L, 4);
				AnimationCurve o = AnimationCurve.EaseInOut(timeStart, valueStart, timeEnd, valueEnd);
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
		private static int _m_Equals(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool value = animationCurve.Equals(@object);
					Lua.lua_pushboolean(L, value);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<AnimationCurve>(L, 2))
				{
					AnimationCurve other = (AnimationCurve)objectTranslator.GetObject(L, 2, typeof(AnimationCurve));
					bool value2 = animationCurve.Equals(other);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.AnimationCurve.Equals!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetHashCode(IntPtr L)
		{
			int result;
			try
			{
				int hashCode = ((AnimationCurve)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetHashCode();
				Lua.xlua_pushinteger(L, hashCode);
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
		private static int _g_get_keys(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, animationCurve.keys);
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
		private static int _g_get_length(IntPtr L)
		{
			try
			{
				AnimationCurve animationCurve = (AnimationCurve)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, animationCurve.length);
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
		private static int _g_get_preWrapMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, animationCurve.preWrapMode);
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
		private static int _g_get_postWrapMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, animationCurve.postWrapMode);
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
		private static int _s_set_keys(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((AnimationCurve)objectTranslator.FastGetCSObj(L, 1)).keys = (Keyframe[])objectTranslator.GetObject(L, 2, typeof(Keyframe[]));
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
		private static int _s_set_preWrapMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				WrapMode preWrapMode;
				objectTranslator.Get<WrapMode>(L, 2, out preWrapMode);
				animationCurve.preWrapMode = preWrapMode;
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
		private static int _s_set_postWrapMode(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AnimationCurve animationCurve = (AnimationCurve)objectTranslator.FastGetCSObj(L, 1);
				WrapMode postWrapMode;
				objectTranslator.Get<WrapMode>(L, 2, out postWrapMode);
				animationCurve.postWrapMode = postWrapMode;
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
