using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineVector3Wrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Vector3);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 6, 6, 6, 3, -1);
			Utils.RegisterFunc(L, -4, "__add", new lua_CSFunction(UnityEngineVector3Wrap.__AddMeta));
			Utils.RegisterFunc(L, -4, "__sub", new lua_CSFunction(UnityEngineVector3Wrap.__SubMeta));
			Utils.RegisterFunc(L, -4, "__unm", new lua_CSFunction(UnityEngineVector3Wrap.__UnmMeta));
			Utils.RegisterFunc(L, -4, "__mul", new lua_CSFunction(UnityEngineVector3Wrap.__MulMeta));
			Utils.RegisterFunc(L, -4, "__div", new lua_CSFunction(UnityEngineVector3Wrap.__DivMeta));
			Utils.RegisterFunc(L, -4, "__eq", new lua_CSFunction(UnityEngineVector3Wrap.__EqMeta));
			Utils.RegisterFunc(L, -3, "Set", new lua_CSFunction(UnityEngineVector3Wrap._m_Set));
			Utils.RegisterFunc(L, -3, "Scale", new lua_CSFunction(UnityEngineVector3Wrap._m_Scale));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineVector3Wrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineVector3Wrap._m_Equals));
			Utils.RegisterFunc(L, -3, "Normalize", new lua_CSFunction(UnityEngineVector3Wrap._m_Normalize));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineVector3Wrap._m_ToString));
			Utils.RegisterFunc(L, -2, "normalized", new lua_CSFunction(UnityEngineVector3Wrap._g_get_normalized));
			Utils.RegisterFunc(L, -2, "magnitude", new lua_CSFunction(UnityEngineVector3Wrap._g_get_magnitude));
			Utils.RegisterFunc(L, -2, "sqrMagnitude", new lua_CSFunction(UnityEngineVector3Wrap._g_get_sqrMagnitude));
			Utils.RegisterFunc(L, -2, "x", new lua_CSFunction(UnityEngineVector3Wrap._g_get_x));
			Utils.RegisterFunc(L, -2, "y", new lua_CSFunction(UnityEngineVector3Wrap._g_get_y));
			Utils.RegisterFunc(L, -2, "z", new lua_CSFunction(UnityEngineVector3Wrap._g_get_z));
			Utils.RegisterFunc(L, -1, "x", new lua_CSFunction(UnityEngineVector3Wrap._s_set_x));
			Utils.RegisterFunc(L, -1, "y", new lua_CSFunction(UnityEngineVector3Wrap._s_set_y));
			Utils.RegisterFunc(L, -1, "z", new lua_CSFunction(UnityEngineVector3Wrap._s_set_z));
			Utils.EndObjectRegister(typeFromHandle, L, translator, new lua_CSFunction(UnityEngineVector3Wrap.__CSIndexer), new lua_CSFunction(UnityEngineVector3Wrap.__NewIndexer), null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineVector3Wrap.__CreateInstance), 26, 10, 0);
			Utils.RegisterFunc(L, -4, "Slerp", new lua_CSFunction(UnityEngineVector3Wrap._m_Slerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "SlerpUnclamped", new lua_CSFunction(UnityEngineVector3Wrap._m_SlerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "OrthoNormalize", new lua_CSFunction(UnityEngineVector3Wrap._m_OrthoNormalize_xlua_st_));
			Utils.RegisterFunc(L, -4, "RotateTowards", new lua_CSFunction(UnityEngineVector3Wrap._m_RotateTowards_xlua_st_));
			Utils.RegisterFunc(L, -4, "Lerp", new lua_CSFunction(UnityEngineVector3Wrap._m_Lerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "LerpUnclamped", new lua_CSFunction(UnityEngineVector3Wrap._m_LerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "MoveTowards", new lua_CSFunction(UnityEngineVector3Wrap._m_MoveTowards_xlua_st_));
			Utils.RegisterFunc(L, -4, "SmoothDamp", new lua_CSFunction(UnityEngineVector3Wrap._m_SmoothDamp_xlua_st_));
			Utils.RegisterFunc(L, -4, "Scale", new lua_CSFunction(UnityEngineVector3Wrap._m_Scale_xlua_st_));
			Utils.RegisterFunc(L, -4, "Cross", new lua_CSFunction(UnityEngineVector3Wrap._m_Cross_xlua_st_));
			Utils.RegisterFunc(L, -4, "Reflect", new lua_CSFunction(UnityEngineVector3Wrap._m_Reflect_xlua_st_));
			Utils.RegisterFunc(L, -4, "Normalize", new lua_CSFunction(UnityEngineVector3Wrap._m_Normalize_xlua_st_));
			Utils.RegisterFunc(L, -4, "Dot", new lua_CSFunction(UnityEngineVector3Wrap._m_Dot_xlua_st_));
			Utils.RegisterFunc(L, -4, "Project", new lua_CSFunction(UnityEngineVector3Wrap._m_Project_xlua_st_));
			Utils.RegisterFunc(L, -4, "ProjectOnPlane", new lua_CSFunction(UnityEngineVector3Wrap._m_ProjectOnPlane_xlua_st_));
			Utils.RegisterFunc(L, -4, "Angle", new lua_CSFunction(UnityEngineVector3Wrap._m_Angle_xlua_st_));
			Utils.RegisterFunc(L, -4, "SignedAngle", new lua_CSFunction(UnityEngineVector3Wrap._m_SignedAngle_xlua_st_));
			Utils.RegisterFunc(L, -4, "Distance", new lua_CSFunction(UnityEngineVector3Wrap._m_Distance_xlua_st_));
			Utils.RegisterFunc(L, -4, "ClampMagnitude", new lua_CSFunction(UnityEngineVector3Wrap._m_ClampMagnitude_xlua_st_));
			Utils.RegisterFunc(L, -4, "Magnitude", new lua_CSFunction(UnityEngineVector3Wrap._m_Magnitude_xlua_st_));
			Utils.RegisterFunc(L, -4, "SqrMagnitude", new lua_CSFunction(UnityEngineVector3Wrap._m_SqrMagnitude_xlua_st_));
			Utils.RegisterFunc(L, -4, "Min", new lua_CSFunction(UnityEngineVector3Wrap._m_Min_xlua_st_));
			Utils.RegisterFunc(L, -4, "Max", new lua_CSFunction(UnityEngineVector3Wrap._m_Max_xlua_st_));
			Utils.RegisterObject(L, translator, -4, "kEpsilon", 1E-05f);
			Utils.RegisterObject(L, translator, -4, "kEpsilonNormalSqrt", 1E-15f);
			Utils.RegisterFunc(L, -2, "zero", new lua_CSFunction(UnityEngineVector3Wrap._g_get_zero));
			Utils.RegisterFunc(L, -2, "one", new lua_CSFunction(UnityEngineVector3Wrap._g_get_one));
			Utils.RegisterFunc(L, -2, "forward", new lua_CSFunction(UnityEngineVector3Wrap._g_get_forward));
			Utils.RegisterFunc(L, -2, "back", new lua_CSFunction(UnityEngineVector3Wrap._g_get_back));
			Utils.RegisterFunc(L, -2, "up", new lua_CSFunction(UnityEngineVector3Wrap._g_get_up));
			Utils.RegisterFunc(L, -2, "down", new lua_CSFunction(UnityEngineVector3Wrap._g_get_down));
			Utils.RegisterFunc(L, -2, "left", new lua_CSFunction(UnityEngineVector3Wrap._g_get_left));
			Utils.RegisterFunc(L, -2, "right", new lua_CSFunction(UnityEngineVector3Wrap._g_get_right));
			Utils.RegisterFunc(L, -2, "positiveInfinity", new lua_CSFunction(UnityEngineVector3Wrap._g_get_positiveInfinity));
			Utils.RegisterFunc(L, -2, "negativeInfinity", new lua_CSFunction(UnityEngineVector3Wrap._g_get_negativeInfinity));
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					Vector3 val = new Vector3(x, y, z);
					objectTranslator.PushUnityEngineVector3(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float x2 = (float)Lua.lua_tonumber(L, 2);
					float y2 = (float)Lua.lua_tonumber(L, 3);
					Vector3 val2 = new Vector3(x2, y2);
					objectTranslator.PushUnityEngineVector3(L, val2);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushUnityEngineVector3(L, default(Vector3));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector3 constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __CSIndexer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector3>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Vector3 vector;
					objectTranslator.Get(L, 1, out vector);
					int index = Lua.xlua_tointeger(L, 2);
					Lua.lua_pushboolean(L, true);
					Lua.lua_pushnumber(L, (double)vector[index]);
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
		public static int __NewIndexer(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			try
			{
				if (objectTranslator.Assignable<Vector3>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector3 vector;
					objectTranslator.Get(L, 1, out vector);
					int index = Lua.xlua_tointeger(L, 2);
					vector[index] = (float)Lua.lua_tonumber(L, 3);
					Lua.lua_pushboolean(L, true);
					return 1;
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
		private static int __AddMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 a;
					objectTranslator.Get(L, 1, out a);
					Vector3 b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineVector3(L, a + b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of + operator, need UnityEngine.Vector3!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __SubMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 a;
					objectTranslator.Get(L, 1, out a);
					Vector3 b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineVector3(L, a - b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of - operator, need UnityEngine.Vector3!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __UnmMeta(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			try
			{
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				objectTranslator.PushUnityEngineVector3(L, -a);
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
		private static int __MulMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector3>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Vector3 a;
					objectTranslator.Get(L, 1, out a);
					float d = (float)Lua.lua_tonumber(L, 2);
					objectTranslator.PushUnityEngineVector3(L, a * d);
					return 1;
				}
				if (LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					float d2 = (float)Lua.lua_tonumber(L, 1);
					Vector3 a2;
					objectTranslator.Get(L, 2, out a2);
					objectTranslator.PushUnityEngineVector3(L, d2 * a2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of * operator, need UnityEngine.Vector3!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __DivMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector3>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Vector3 a;
					objectTranslator.Get(L, 1, out a);
					float d = (float)Lua.lua_tonumber(L, 2);
					objectTranslator.PushUnityEngineVector3(L, a / d);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of / operator, need UnityEngine.Vector3!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __EqMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 lhs;
					objectTranslator.Get(L, 1, out lhs);
					Vector3 rhs;
					objectTranslator.Get(L, 2, out rhs);
					Lua.lua_pushboolean(L, lhs == rhs);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Vector3!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Slerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				Vector3 b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Vector3 val = Vector3.Slerp(a, b, t);
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
		private static int _m_SlerpUnclamped_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				Vector3 b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Vector3 val = Vector3.SlerpUnclamped(a, b, t);
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
		private static int _m_OrthoNormalize_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 val;
					objectTranslator.Get(L, 1, out val);
					Vector3 val2;
					objectTranslator.Get(L, 2, out val2);
					Vector3.OrthoNormalize(ref val, ref val2);
					objectTranslator.PushUnityEngineVector3(L, val);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val);
					objectTranslator.PushUnityEngineVector3(L, val2);
					objectTranslator.UpdateUnityEngineVector3(L, 2, val2);
					return 2;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					Vector3 val3;
					objectTranslator.Get(L, 1, out val3);
					Vector3 val4;
					objectTranslator.Get(L, 2, out val4);
					Vector3 val5;
					objectTranslator.Get(L, 3, out val5);
					Vector3.OrthoNormalize(ref val3, ref val4, ref val5);
					objectTranslator.PushUnityEngineVector3(L, val3);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val3);
					objectTranslator.PushUnityEngineVector3(L, val4);
					objectTranslator.UpdateUnityEngineVector3(L, 2, val4);
					objectTranslator.PushUnityEngineVector3(L, val5);
					objectTranslator.UpdateUnityEngineVector3(L, 3, val5);
					return 3;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector3.OrthoNormalize!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_RotateTowards_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 current;
				objectTranslator.Get(L, 1, out current);
				Vector3 target;
				objectTranslator.Get(L, 2, out target);
				float maxRadiansDelta = (float)Lua.lua_tonumber(L, 3);
				float maxMagnitudeDelta = (float)Lua.lua_tonumber(L, 4);
				Vector3 val = Vector3.RotateTowards(current, target, maxRadiansDelta, maxMagnitudeDelta);
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
		private static int _m_Lerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				Vector3 b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Vector3 val = Vector3.Lerp(a, b, t);
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
		private static int _m_LerpUnclamped_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				Vector3 b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Vector3 val = Vector3.LerpUnclamped(a, b, t);
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
		private static int _m_MoveTowards_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 current;
				objectTranslator.Get(L, 1, out current);
				Vector3 target;
				objectTranslator.Get(L, 2, out target);
				float maxDistanceDelta = (float)Lua.lua_tonumber(L, 3);
				Vector3 val = Vector3.MoveTowards(current, target, maxDistanceDelta);
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
		private static int _m_SmoothDamp_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 current;
					objectTranslator.Get(L, 1, out current);
					Vector3 target;
					objectTranslator.Get(L, 2, out target);
					Vector3 val;
					objectTranslator.Get(L, 3, out val);
					float smoothTime = (float)Lua.lua_tonumber(L, 4);
					Vector3 val2 = Vector3.SmoothDamp(current, target, ref val, smoothTime);
					objectTranslator.PushUnityEngineVector3(L, val2);
					objectTranslator.PushUnityEngineVector3(L, val);
					objectTranslator.UpdateUnityEngineVector3(L, 3, val);
					return 2;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					Vector3 current2;
					objectTranslator.Get(L, 1, out current2);
					Vector3 target2;
					objectTranslator.Get(L, 2, out target2);
					Vector3 val3;
					objectTranslator.Get(L, 3, out val3);
					float smoothTime2 = (float)Lua.lua_tonumber(L, 4);
					float maxSpeed = (float)Lua.lua_tonumber(L, 5);
					Vector3 val4 = Vector3.SmoothDamp(current2, target2, ref val3, smoothTime2, maxSpeed);
					objectTranslator.PushUnityEngineVector3(L, val4);
					objectTranslator.PushUnityEngineVector3(L, val3);
					objectTranslator.UpdateUnityEngineVector3(L, 3, val3);
					return 2;
				}
				if (num == 6 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 6))
				{
					Vector3 current3;
					objectTranslator.Get(L, 1, out current3);
					Vector3 target3;
					objectTranslator.Get(L, 2, out target3);
					Vector3 val5;
					objectTranslator.Get(L, 3, out val5);
					float smoothTime3 = (float)Lua.lua_tonumber(L, 4);
					float maxSpeed2 = (float)Lua.lua_tonumber(L, 5);
					float deltaTime = (float)Lua.lua_tonumber(L, 6);
					Vector3 val6 = Vector3.SmoothDamp(current3, target3, ref val5, smoothTime3, maxSpeed2, deltaTime);
					objectTranslator.PushUnityEngineVector3(L, val6);
					objectTranslator.PushUnityEngineVector3(L, val5);
					objectTranslator.UpdateUnityEngineVector3(L, 3, val5);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector3.SmoothDamp!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Set(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				float newX = (float)Lua.lua_tonumber(L, 2);
				float newY = (float)Lua.lua_tonumber(L, 3);
				float newZ = (float)Lua.lua_tonumber(L, 4);
				val.Set(newX, newY, newZ);
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
		private static int _m_Scale_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				Vector3 b;
				objectTranslator.Get(L, 2, out b);
				Vector3 val = Vector3.Scale(a, b);
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
		private static int _m_Scale(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				Vector3 scale;
				objectTranslator.Get(L, 2, out scale);
				val.Scale(scale);
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
		private static int _m_Cross_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 lhs;
				objectTranslator.Get(L, 1, out lhs);
				Vector3 rhs;
				objectTranslator.Get(L, 2, out rhs);
				Vector3 val = Vector3.Cross(lhs, rhs);
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
		private static int _m_GetHashCode(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				int hashCode = val.GetHashCode();
				Lua.xlua_pushinteger(L, hashCode);
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool value = val.Equals(@object);
					Lua.lua_pushboolean(L, value);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 other;
					objectTranslator.Get(L, 2, out other);
					bool value2 = val.Equals(other);
					Lua.lua_pushboolean(L, value2);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector3.Equals!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Reflect_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 inDirection;
				objectTranslator.Get(L, 1, out inDirection);
				Vector3 inNormal;
				objectTranslator.Get(L, 2, out inNormal);
				Vector3 val = Vector3.Reflect(inDirection, inNormal);
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
		private static int _m_Normalize_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 value;
				objectTranslator.Get(L, 1, out value);
				Vector3 val = Vector3.Normalize(value);
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
		private static int _m_Normalize(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				val.Normalize();
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
		private static int _m_Dot_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 lhs;
				objectTranslator.Get(L, 1, out lhs);
				Vector3 rhs;
				objectTranslator.Get(L, 2, out rhs);
				float num = Vector3.Dot(lhs, rhs);
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
		private static int _m_Project_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 vector;
				objectTranslator.Get(L, 1, out vector);
				Vector3 onNormal;
				objectTranslator.Get(L, 2, out onNormal);
				Vector3 val = Vector3.Project(vector, onNormal);
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
		private static int _m_ProjectOnPlane_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 vector;
				objectTranslator.Get(L, 1, out vector);
				Vector3 planeNormal;
				objectTranslator.Get(L, 2, out planeNormal);
				Vector3 val = Vector3.ProjectOnPlane(vector, planeNormal);
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
		private static int _m_Angle_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 from;
				objectTranslator.Get(L, 1, out from);
				Vector3 to;
				objectTranslator.Get(L, 2, out to);
				float num = Vector3.Angle(from, to);
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
		private static int _m_SignedAngle_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 from;
				objectTranslator.Get(L, 1, out from);
				Vector3 to;
				objectTranslator.Get(L, 2, out to);
				Vector3 axis;
				objectTranslator.Get(L, 3, out axis);
				float num = Vector3.SignedAngle(from, to, axis);
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
		private static int _m_Distance_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 a;
				objectTranslator.Get(L, 1, out a);
				Vector3 b;
				objectTranslator.Get(L, 2, out b);
				float num = Vector3.Distance(a, b);
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
		private static int _m_ClampMagnitude_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 vector;
				objectTranslator.Get(L, 1, out vector);
				float maxLength = (float)Lua.lua_tonumber(L, 2);
				Vector3 val = Vector3.ClampMagnitude(vector, maxLength);
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
		private static int _m_Magnitude_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				float num = Vector3.Magnitude(vector);
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
		private static int _m_SqrMagnitude_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				float num = Vector3.SqrMagnitude(vector);
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
		private static int _m_Min_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 lhs;
				objectTranslator.Get(L, 1, out lhs);
				Vector3 rhs;
				objectTranslator.Get(L, 2, out rhs);
				Vector3 val = Vector3.Min(lhs, rhs);
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
		private static int _m_Max_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 lhs;
				objectTranslator.Get(L, 1, out lhs);
				Vector3 rhs;
				objectTranslator.Get(L, 2, out rhs);
				Vector3 val = Vector3.Max(lhs, rhs);
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
		private static int _m_ToString(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					string str = val.ToString();
					Lua.lua_pushstring(L, str);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string format = Lua.lua_tostring(L, 2);
					string str2 = val.ToString(format);
					Lua.lua_pushstring(L, str2);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val);
					return 1;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<IFormatProvider>(L, 3))
				{
					string format2 = Lua.lua_tostring(L, 2);
					IFormatProvider formatProvider = (IFormatProvider)objectTranslator.GetObject(L, 3, typeof(IFormatProvider));
					string str3 = val.ToString(format2, formatProvider);
					Lua.lua_pushstring(L, str3);
					objectTranslator.UpdateUnityEngineVector3(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str4 = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str4 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector3.ToString!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_normalized(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 vector;
				objectTranslator.Get(L, 1, out vector);
				objectTranslator.PushUnityEngineVector3(L, vector.normalized);
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
		private static int _g_get_magnitude(IntPtr L)
		{
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				Lua.lua_pushnumber(L, (double)vector.magnitude);
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
		private static int _g_get_sqrMagnitude(IntPtr L)
		{
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				Lua.lua_pushnumber(L, (double)vector.sqrMagnitude);
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
		private static int _g_get_zero(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.zero);
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
		private static int _g_get_one(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.one);
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
		private static int _g_get_forward(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.forward);
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
		private static int _g_get_back(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.back);
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
		private static int _g_get_up(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.up);
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
		private static int _g_get_down(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.down);
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
		private static int _g_get_left(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.left);
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
		private static int _g_get_right(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.right);
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
		private static int _g_get_positiveInfinity(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.positiveInfinity);
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
		private static int _g_get_negativeInfinity(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector3(L, Vector3.negativeInfinity);
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
		private static int _g_get_x(IntPtr L)
		{
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				Lua.lua_pushnumber(L, (double)vector.x);
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
		private static int _g_get_y(IntPtr L)
		{
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				Lua.lua_pushnumber(L, (double)vector.y);
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
		private static int _g_get_z(IntPtr L)
		{
			try
			{
				Vector3 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				Lua.lua_pushnumber(L, (double)vector.z);
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
		private static int _s_set_x(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				val.x = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
		private static int _s_set_y(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				val.y = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
		private static int _s_set_z(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 val;
				objectTranslator.Get(L, 1, out val);
				val.z = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector3(L, 1, val);
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
