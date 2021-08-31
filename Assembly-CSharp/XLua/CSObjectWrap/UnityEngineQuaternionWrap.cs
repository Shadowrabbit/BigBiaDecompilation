using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineQuaternionWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Quaternion);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 2, 8, 6, 5, -1);
			Utils.RegisterFunc(L, -4, "__mul", new lua_CSFunction(UnityEngineQuaternionWrap.__MulMeta));
			Utils.RegisterFunc(L, -4, "__eq", new lua_CSFunction(UnityEngineQuaternionWrap.__EqMeta));
			Utils.RegisterFunc(L, -3, "Set", new lua_CSFunction(UnityEngineQuaternionWrap._m_Set));
			Utils.RegisterFunc(L, -3, "SetLookRotation", new lua_CSFunction(UnityEngineQuaternionWrap._m_SetLookRotation));
			Utils.RegisterFunc(L, -3, "ToAngleAxis", new lua_CSFunction(UnityEngineQuaternionWrap._m_ToAngleAxis));
			Utils.RegisterFunc(L, -3, "SetFromToRotation", new lua_CSFunction(UnityEngineQuaternionWrap._m_SetFromToRotation));
			Utils.RegisterFunc(L, -3, "Normalize", new lua_CSFunction(UnityEngineQuaternionWrap._m_Normalize));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineQuaternionWrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineQuaternionWrap._m_Equals));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineQuaternionWrap._m_ToString));
			Utils.RegisterFunc(L, -2, "eulerAngles", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_eulerAngles));
			Utils.RegisterFunc(L, -2, "normalized", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_normalized));
			Utils.RegisterFunc(L, -2, "x", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_x));
			Utils.RegisterFunc(L, -2, "y", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_y));
			Utils.RegisterFunc(L, -2, "z", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_z));
			Utils.RegisterFunc(L, -2, "w", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_w));
			Utils.RegisterFunc(L, -1, "eulerAngles", new lua_CSFunction(UnityEngineQuaternionWrap._s_set_eulerAngles));
			Utils.RegisterFunc(L, -1, "x", new lua_CSFunction(UnityEngineQuaternionWrap._s_set_x));
			Utils.RegisterFunc(L, -1, "y", new lua_CSFunction(UnityEngineQuaternionWrap._s_set_y));
			Utils.RegisterFunc(L, -1, "z", new lua_CSFunction(UnityEngineQuaternionWrap._s_set_z));
			Utils.RegisterFunc(L, -1, "w", new lua_CSFunction(UnityEngineQuaternionWrap._s_set_w));
			Utils.EndObjectRegister(typeFromHandle, L, translator, new lua_CSFunction(UnityEngineQuaternionWrap.__CSIndexer), new lua_CSFunction(UnityEngineQuaternionWrap.__NewIndexer), null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineQuaternionWrap.__CreateInstance), 15, 1, 0);
			Utils.RegisterFunc(L, -4, "FromToRotation", new lua_CSFunction(UnityEngineQuaternionWrap._m_FromToRotation_xlua_st_));
			Utils.RegisterFunc(L, -4, "Inverse", new lua_CSFunction(UnityEngineQuaternionWrap._m_Inverse_xlua_st_));
			Utils.RegisterFunc(L, -4, "Slerp", new lua_CSFunction(UnityEngineQuaternionWrap._m_Slerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "SlerpUnclamped", new lua_CSFunction(UnityEngineQuaternionWrap._m_SlerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "Lerp", new lua_CSFunction(UnityEngineQuaternionWrap._m_Lerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "LerpUnclamped", new lua_CSFunction(UnityEngineQuaternionWrap._m_LerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "AngleAxis", new lua_CSFunction(UnityEngineQuaternionWrap._m_AngleAxis_xlua_st_));
			Utils.RegisterFunc(L, -4, "LookRotation", new lua_CSFunction(UnityEngineQuaternionWrap._m_LookRotation_xlua_st_));
			Utils.RegisterFunc(L, -4, "Dot", new lua_CSFunction(UnityEngineQuaternionWrap._m_Dot_xlua_st_));
			Utils.RegisterFunc(L, -4, "Angle", new lua_CSFunction(UnityEngineQuaternionWrap._m_Angle_xlua_st_));
			Utils.RegisterFunc(L, -4, "Euler", new lua_CSFunction(UnityEngineQuaternionWrap._m_Euler_xlua_st_));
			Utils.RegisterFunc(L, -4, "RotateTowards", new lua_CSFunction(UnityEngineQuaternionWrap._m_RotateTowards_xlua_st_));
			Utils.RegisterFunc(L, -4, "Normalize", new lua_CSFunction(UnityEngineQuaternionWrap._m_Normalize_xlua_st_));
			Utils.RegisterObject(L, translator, -4, "kEpsilon", 1E-06f);
			Utils.RegisterFunc(L, -2, "identity", new lua_CSFunction(UnityEngineQuaternionWrap._g_get_identity));
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 5))
				{
					float x = (float)Lua.lua_tonumber(L, 2);
					float y = (float)Lua.lua_tonumber(L, 3);
					float z = (float)Lua.lua_tonumber(L, 4);
					float w = (float)Lua.lua_tonumber(L, 5);
					Quaternion val = new Quaternion(x, y, z, w);
					objectTranslator.PushUnityEngineQuaternion(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushUnityEngineQuaternion(L, default(Quaternion));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Quaternion constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __CSIndexer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Quaternion>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Quaternion quaternion;
					objectTranslator.Get(L, 1, out quaternion);
					int index = Lua.xlua_tointeger(L, 2);
					Lua.lua_pushboolean(L, true);
					Lua.lua_pushnumber(L, (double)quaternion[index]);
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
				if (objectTranslator.Assignable<Quaternion>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Quaternion quaternion;
					objectTranslator.Get(L, 1, out quaternion);
					int index = Lua.xlua_tointeger(L, 2);
					quaternion[index] = (float)Lua.lua_tonumber(L, 3);
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
		private static int __MulMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Quaternion>(L, 1) && objectTranslator.Assignable<Quaternion>(L, 2))
				{
					Quaternion lhs;
					objectTranslator.Get(L, 1, out lhs);
					Quaternion rhs;
					objectTranslator.Get(L, 2, out rhs);
					objectTranslator.PushUnityEngineQuaternion(L, lhs * rhs);
					return 1;
				}
				if (objectTranslator.Assignable<Quaternion>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Quaternion rotation;
					objectTranslator.Get(L, 1, out rotation);
					Vector3 point;
					objectTranslator.Get(L, 2, out point);
					objectTranslator.PushUnityEngineVector3(L, rotation * point);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of * operator, need UnityEngine.Quaternion!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __EqMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Quaternion>(L, 1) && objectTranslator.Assignable<Quaternion>(L, 2))
				{
					Quaternion lhs;
					objectTranslator.Get(L, 1, out lhs);
					Quaternion rhs;
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
			return Lua.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Quaternion!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_FromToRotation_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector3 fromDirection;
				objectTranslator.Get(L, 1, out fromDirection);
				Vector3 toDirection;
				objectTranslator.Get(L, 2, out toDirection);
				Quaternion val = Quaternion.FromToRotation(fromDirection, toDirection);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
		private static int _m_Inverse_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion rotation;
				objectTranslator.Get(L, 1, out rotation);
				Quaternion val = Quaternion.Inverse(rotation);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
		private static int _m_Slerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion a;
				objectTranslator.Get(L, 1, out a);
				Quaternion b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Quaternion val = Quaternion.Slerp(a, b, t);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
				Quaternion a;
				objectTranslator.Get(L, 1, out a);
				Quaternion b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Quaternion val = Quaternion.SlerpUnclamped(a, b, t);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
				Quaternion a;
				objectTranslator.Get(L, 1, out a);
				Quaternion b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Quaternion val = Quaternion.Lerp(a, b, t);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
				Quaternion a;
				objectTranslator.Get(L, 1, out a);
				Quaternion b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Quaternion val = Quaternion.LerpUnclamped(a, b, t);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
		private static int _m_AngleAxis_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				float angle = (float)Lua.lua_tonumber(L, 1);
				Vector3 axis;
				objectTranslator.Get(L, 2, out axis);
				Quaternion val = Quaternion.AngleAxis(angle, axis);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
		private static int _m_LookRotation_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<Vector3>(L, 1))
				{
					Vector3 forward;
					objectTranslator.Get(L, 1, out forward);
					Quaternion val = Quaternion.LookRotation(forward);
					objectTranslator.PushUnityEngineQuaternion(L, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 forward2;
					objectTranslator.Get(L, 1, out forward2);
					Vector3 upwards;
					objectTranslator.Get(L, 2, out upwards);
					Quaternion val2 = Quaternion.LookRotation(forward2, upwards);
					objectTranslator.PushUnityEngineQuaternion(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Quaternion.LookRotation!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Set(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				float newX = (float)Lua.lua_tonumber(L, 2);
				float newY = (float)Lua.lua_tonumber(L, 3);
				float newZ = (float)Lua.lua_tonumber(L, 4);
				float newW = (float)Lua.lua_tonumber(L, 5);
				val.Set(newX, newY, newZ, newW);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
				Quaternion a;
				objectTranslator.Get(L, 1, out a);
				Quaternion b;
				objectTranslator.Get(L, 2, out b);
				float num = Quaternion.Dot(a, b);
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
		private static int _m_SetLookRotation(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 lookRotation;
					objectTranslator.Get(L, 2, out lookRotation);
					val.SetLookRotation(lookRotation);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					Vector3 view;
					objectTranslator.Get(L, 2, out view);
					Vector3 up;
					objectTranslator.Get(L, 3, out up);
					val.SetLookRotation(view, up);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Quaternion.SetLookRotation!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Angle_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion a;
				objectTranslator.Get(L, 1, out a);
				Quaternion b;
				objectTranslator.Get(L, 2, out b);
				float num = Quaternion.Angle(a, b);
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
		private static int _m_Euler_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float x = (float)Lua.lua_tonumber(L, 1);
					float y = (float)Lua.lua_tonumber(L, 2);
					float z = (float)Lua.lua_tonumber(L, 3);
					Quaternion val = Quaternion.Euler(x, y, z);
					objectTranslator.PushUnityEngineQuaternion(L, val);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<Vector3>(L, 1))
				{
					Vector3 euler;
					objectTranslator.Get(L, 1, out euler);
					Quaternion val2 = Quaternion.Euler(euler);
					objectTranslator.PushUnityEngineQuaternion(L, val2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Quaternion.Euler!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToAngleAxis(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				float num;
				Vector3 val2;
				val.ToAngleAxis(out num, out val2);
				Lua.lua_pushnumber(L, (double)num);
				objectTranslator.PushUnityEngineVector3(L, val2);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
				result = 2;
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
		private static int _m_SetFromToRotation(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				Vector3 fromDirection;
				objectTranslator.Get(L, 2, out fromDirection);
				Vector3 toDirection;
				objectTranslator.Get(L, 3, out toDirection);
				val.SetFromToRotation(fromDirection, toDirection);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
		private static int _m_RotateTowards_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion from;
				objectTranslator.Get(L, 1, out from);
				Quaternion to;
				objectTranslator.Get(L, 2, out to);
				float maxDegreesDelta = (float)Lua.lua_tonumber(L, 3);
				Quaternion val = Quaternion.RotateTowards(from, to, maxDegreesDelta);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
				Quaternion q;
				objectTranslator.Get(L, 1, out q);
				Quaternion val = Quaternion.Normalize(q);
				objectTranslator.PushUnityEngineQuaternion(L, val);
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
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				val.Normalize();
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
		private static int _m_GetHashCode(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				int hashCode = val.GetHashCode();
				Lua.xlua_pushinteger(L, hashCode);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool value = val.Equals(@object);
					Lua.lua_pushboolean(L, value);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Quaternion>(L, 2))
				{
					Quaternion other;
					objectTranslator.Get(L, 2, out other);
					bool value2 = val.Equals(other);
					Lua.lua_pushboolean(L, value2);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Quaternion.Equals!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToString(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					string str = val.ToString();
					Lua.lua_pushstring(L, str);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string format = Lua.lua_tostring(L, 2);
					string str2 = val.ToString(format);
					Lua.lua_pushstring(L, str2);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 1;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<IFormatProvider>(L, 3))
				{
					string format2 = Lua.lua_tostring(L, 2);
					IFormatProvider formatProvider = (IFormatProvider)objectTranslator.GetObject(L, 3, typeof(IFormatProvider));
					string str3 = val.ToString(format2, formatProvider);
					Lua.lua_pushstring(L, str3);
					objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str4 = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str4 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Quaternion.ToString!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_identity(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineQuaternion(L, Quaternion.identity);
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
		private static int _g_get_eulerAngles(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion quaternion;
				objectTranslator.Get(L, 1, out quaternion);
				objectTranslator.PushUnityEngineVector3(L, quaternion.eulerAngles);
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
		private static int _g_get_normalized(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion quaternion;
				objectTranslator.Get(L, 1, out quaternion);
				objectTranslator.PushUnityEngineQuaternion(L, quaternion.normalized);
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
				Quaternion quaternion;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out quaternion);
				Lua.lua_pushnumber(L, (double)quaternion.x);
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
				Quaternion quaternion;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out quaternion);
				Lua.lua_pushnumber(L, (double)quaternion.y);
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
				Quaternion quaternion;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out quaternion);
				Lua.lua_pushnumber(L, (double)quaternion.z);
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
		private static int _g_get_w(IntPtr L)
		{
			try
			{
				Quaternion quaternion;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out quaternion);
				Lua.lua_pushnumber(L, (double)quaternion.w);
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
		private static int _s_set_eulerAngles(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				Vector3 eulerAngles;
				objectTranslator.Get(L, 2, out eulerAngles);
				val.eulerAngles = eulerAngles;
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
		private static int _s_set_x(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				val.x = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				val.y = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				val.z = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
		private static int _s_set_w(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Quaternion val;
				objectTranslator.Get(L, 1, out val);
				val.w = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineQuaternion(L, 1, val);
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
