using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineVector4Wrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Vector4);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 6, 7, 7, 4, -1);
			Utils.RegisterFunc(L, -4, "__add", new lua_CSFunction(UnityEngineVector4Wrap.__AddMeta));
			Utils.RegisterFunc(L, -4, "__sub", new lua_CSFunction(UnityEngineVector4Wrap.__SubMeta));
			Utils.RegisterFunc(L, -4, "__unm", new lua_CSFunction(UnityEngineVector4Wrap.__UnmMeta));
			Utils.RegisterFunc(L, -4, "__mul", new lua_CSFunction(UnityEngineVector4Wrap.__MulMeta));
			Utils.RegisterFunc(L, -4, "__div", new lua_CSFunction(UnityEngineVector4Wrap.__DivMeta));
			Utils.RegisterFunc(L, -4, "__eq", new lua_CSFunction(UnityEngineVector4Wrap.__EqMeta));
			Utils.RegisterFunc(L, -3, "Set", new lua_CSFunction(UnityEngineVector4Wrap._m_Set));
			Utils.RegisterFunc(L, -3, "Scale", new lua_CSFunction(UnityEngineVector4Wrap._m_Scale));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineVector4Wrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineVector4Wrap._m_Equals));
			Utils.RegisterFunc(L, -3, "Normalize", new lua_CSFunction(UnityEngineVector4Wrap._m_Normalize));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineVector4Wrap._m_ToString));
			Utils.RegisterFunc(L, -3, "SqrMagnitude", new lua_CSFunction(UnityEngineVector4Wrap._m_SqrMagnitude));
			Utils.RegisterFunc(L, -2, "normalized", new lua_CSFunction(UnityEngineVector4Wrap._g_get_normalized));
			Utils.RegisterFunc(L, -2, "magnitude", new lua_CSFunction(UnityEngineVector4Wrap._g_get_magnitude));
			Utils.RegisterFunc(L, -2, "sqrMagnitude", new lua_CSFunction(UnityEngineVector4Wrap._g_get_sqrMagnitude));
			Utils.RegisterFunc(L, -2, "x", new lua_CSFunction(UnityEngineVector4Wrap._g_get_x));
			Utils.RegisterFunc(L, -2, "y", new lua_CSFunction(UnityEngineVector4Wrap._g_get_y));
			Utils.RegisterFunc(L, -2, "z", new lua_CSFunction(UnityEngineVector4Wrap._g_get_z));
			Utils.RegisterFunc(L, -2, "w", new lua_CSFunction(UnityEngineVector4Wrap._g_get_w));
			Utils.RegisterFunc(L, -1, "x", new lua_CSFunction(UnityEngineVector4Wrap._s_set_x));
			Utils.RegisterFunc(L, -1, "y", new lua_CSFunction(UnityEngineVector4Wrap._s_set_y));
			Utils.RegisterFunc(L, -1, "z", new lua_CSFunction(UnityEngineVector4Wrap._s_set_z));
			Utils.RegisterFunc(L, -1, "w", new lua_CSFunction(UnityEngineVector4Wrap._s_set_w));
			Utils.EndObjectRegister(typeFromHandle, L, translator, new lua_CSFunction(UnityEngineVector4Wrap.__CSIndexer), new lua_CSFunction(UnityEngineVector4Wrap.__NewIndexer), null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineVector4Wrap.__CreateInstance), 14, 4, 0);
			Utils.RegisterFunc(L, -4, "Lerp", new lua_CSFunction(UnityEngineVector4Wrap._m_Lerp_xlua_st_));
			Utils.RegisterFunc(L, -4, "LerpUnclamped", new lua_CSFunction(UnityEngineVector4Wrap._m_LerpUnclamped_xlua_st_));
			Utils.RegisterFunc(L, -4, "MoveTowards", new lua_CSFunction(UnityEngineVector4Wrap._m_MoveTowards_xlua_st_));
			Utils.RegisterFunc(L, -4, "Scale", new lua_CSFunction(UnityEngineVector4Wrap._m_Scale_xlua_st_));
			Utils.RegisterFunc(L, -4, "Normalize", new lua_CSFunction(UnityEngineVector4Wrap._m_Normalize_xlua_st_));
			Utils.RegisterFunc(L, -4, "Dot", new lua_CSFunction(UnityEngineVector4Wrap._m_Dot_xlua_st_));
			Utils.RegisterFunc(L, -4, "Project", new lua_CSFunction(UnityEngineVector4Wrap._m_Project_xlua_st_));
			Utils.RegisterFunc(L, -4, "Distance", new lua_CSFunction(UnityEngineVector4Wrap._m_Distance_xlua_st_));
			Utils.RegisterFunc(L, -4, "Magnitude", new lua_CSFunction(UnityEngineVector4Wrap._m_Magnitude_xlua_st_));
			Utils.RegisterFunc(L, -4, "Min", new lua_CSFunction(UnityEngineVector4Wrap._m_Min_xlua_st_));
			Utils.RegisterFunc(L, -4, "Max", new lua_CSFunction(UnityEngineVector4Wrap._m_Max_xlua_st_));
			Utils.RegisterFunc(L, -4, "SqrMagnitude", new lua_CSFunction(UnityEngineVector4Wrap._m_SqrMagnitude_xlua_st_));
			Utils.RegisterObject(L, translator, -4, "kEpsilon", 1E-05f);
			Utils.RegisterFunc(L, -2, "zero", new lua_CSFunction(UnityEngineVector4Wrap._g_get_zero));
			Utils.RegisterFunc(L, -2, "one", new lua_CSFunction(UnityEngineVector4Wrap._g_get_one));
			Utils.RegisterFunc(L, -2, "positiveInfinity", new lua_CSFunction(UnityEngineVector4Wrap._g_get_positiveInfinity));
			Utils.RegisterFunc(L, -2, "negativeInfinity", new lua_CSFunction(UnityEngineVector4Wrap._g_get_negativeInfinity));
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
					Vector4 val = new Vector4(x, y, z, w);
					objectTranslator.PushUnityEngineVector4(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					float x2 = (float)Lua.lua_tonumber(L, 2);
					float y2 = (float)Lua.lua_tonumber(L, 3);
					float z2 = (float)Lua.lua_tonumber(L, 4);
					Vector4 val2 = new Vector4(x2, y2, z2);
					objectTranslator.PushUnityEngineVector4(L, val2);
					return 1;
				}
				if (Lua.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					float x3 = (float)Lua.lua_tonumber(L, 2);
					float y3 = (float)Lua.lua_tonumber(L, 3);
					Vector4 val3 = new Vector4(x3, y3);
					objectTranslator.PushUnityEngineVector4(L, val3);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushUnityEngineVector4(L, default(Vector4));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector4 constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		public static int __CSIndexer(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector4>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Vector4 vector;
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
				if (objectTranslator.Assignable<Vector4>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 3))
				{
					Vector4 vector;
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
				if (objectTranslator.Assignable<Vector4>(L, 1) && objectTranslator.Assignable<Vector4>(L, 2))
				{
					Vector4 a;
					objectTranslator.Get(L, 1, out a);
					Vector4 b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineVector4(L, a + b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of + operator, need UnityEngine.Vector4!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __SubMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector4>(L, 1) && objectTranslator.Assignable<Vector4>(L, 2))
				{
					Vector4 a;
					objectTranslator.Get(L, 1, out a);
					Vector4 b;
					objectTranslator.Get(L, 2, out b);
					objectTranslator.PushUnityEngineVector4(L, a - b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of - operator, need UnityEngine.Vector4!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __UnmMeta(IntPtr L)
		{
			ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
			try
			{
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				objectTranslator.PushUnityEngineVector4(L, -a);
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
				if (objectTranslator.Assignable<Vector4>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Vector4 a;
					objectTranslator.Get(L, 1, out a);
					float d = (float)Lua.lua_tonumber(L, 2);
					objectTranslator.PushUnityEngineVector4(L, a * d);
					return 1;
				}
				if (LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 1) && objectTranslator.Assignable<Vector4>(L, 2))
				{
					float d2 = (float)Lua.lua_tonumber(L, 1);
					Vector4 a2;
					objectTranslator.Get(L, 2, out a2);
					objectTranslator.PushUnityEngineVector4(L, d2 * a2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of * operator, need UnityEngine.Vector4!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __DivMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector4>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					Vector4 a;
					objectTranslator.Get(L, 1, out a);
					float d = (float)Lua.lua_tonumber(L, 2);
					objectTranslator.PushUnityEngineVector4(L, a / d);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of / operator, need UnityEngine.Vector4!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __EqMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Vector4>(L, 1) && objectTranslator.Assignable<Vector4>(L, 2))
				{
					Vector4 lhs;
					objectTranslator.Get(L, 1, out lhs);
					Vector4 rhs;
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
			return Lua.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Vector4!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Set(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				float newX = (float)Lua.lua_tonumber(L, 2);
				float newY = (float)Lua.lua_tonumber(L, 3);
				float newZ = (float)Lua.lua_tonumber(L, 4);
				float newW = (float)Lua.lua_tonumber(L, 5);
				val.Set(newX, newY, newZ, newW);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
		private static int _m_Lerp_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Vector4 val = Vector4.Lerp(a, b, t);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 b;
				objectTranslator.Get(L, 2, out b);
				float t = (float)Lua.lua_tonumber(L, 3);
				Vector4 val = Vector4.LerpUnclamped(a, b, t);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 current;
				objectTranslator.Get(L, 1, out current);
				Vector4 target;
				objectTranslator.Get(L, 2, out target);
				float maxDistanceDelta = (float)Lua.lua_tonumber(L, 3);
				Vector4 val = Vector4.MoveTowards(current, target, maxDistanceDelta);
				objectTranslator.PushUnityEngineVector4(L, val);
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
		private static int _m_Scale_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 b;
				objectTranslator.Get(L, 2, out b);
				Vector4 val = Vector4.Scale(a, b);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				Vector4 scale;
				objectTranslator.Get(L, 2, out scale);
				val.Scale(scale);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				int hashCode = val.GetHashCode();
				Lua.xlua_pushinteger(L, hashCode);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool value = val.Equals(@object);
					Lua.lua_pushboolean(L, value);
					objectTranslator.UpdateUnityEngineVector4(L, 1, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Vector4>(L, 2))
				{
					Vector4 other;
					objectTranslator.Get(L, 2, out other);
					bool value2 = val.Equals(other);
					Lua.lua_pushboolean(L, value2);
					objectTranslator.UpdateUnityEngineVector4(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector4.Equals!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Normalize_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 val = Vector4.Normalize(a);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				val.Normalize();
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 b;
				objectTranslator.Get(L, 2, out b);
				float num = Vector4.Dot(a, b);
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
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 b;
				objectTranslator.Get(L, 2, out b);
				Vector4 val = Vector4.Project(a, b);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 a;
				objectTranslator.Get(L, 1, out a);
				Vector4 b;
				objectTranslator.Get(L, 2, out b);
				float num = Vector4.Distance(a, b);
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
		private static int _m_Magnitude_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Vector4 a;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out a);
				float num = Vector4.Magnitude(a);
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
				Vector4 lhs;
				objectTranslator.Get(L, 1, out lhs);
				Vector4 rhs;
				objectTranslator.Get(L, 2, out rhs);
				Vector4 val = Vector4.Min(lhs, rhs);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 lhs;
				objectTranslator.Get(L, 1, out lhs);
				Vector4 rhs;
				objectTranslator.Get(L, 2, out rhs);
				Vector4 val = Vector4.Max(lhs, rhs);
				objectTranslator.PushUnityEngineVector4(L, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					string str = val.ToString();
					Lua.lua_pushstring(L, str);
					objectTranslator.UpdateUnityEngineVector4(L, 1, val);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string format = Lua.lua_tostring(L, 2);
					string str2 = val.ToString(format);
					Lua.lua_pushstring(L, str2);
					objectTranslator.UpdateUnityEngineVector4(L, 1, val);
					return 1;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<IFormatProvider>(L, 3))
				{
					string format2 = Lua.lua_tostring(L, 2);
					IFormatProvider formatProvider = (IFormatProvider)objectTranslator.GetObject(L, 3, typeof(IFormatProvider));
					string str3 = val.ToString(format2, formatProvider);
					Lua.lua_pushstring(L, str3);
					objectTranslator.UpdateUnityEngineVector4(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str4 = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str4 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Vector4.ToString!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SqrMagnitude_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Vector4 a;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out a);
				float num = Vector4.SqrMagnitude(a);
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
		private static int _m_SqrMagnitude(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				float num = val.SqrMagnitude();
				Lua.lua_pushnumber(L, (double)num);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
		private static int _g_get_normalized(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Vector4 vector;
				objectTranslator.Get(L, 1, out vector);
				objectTranslator.PushUnityEngineVector4(L, vector.normalized);
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
				Vector4 vector;
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
				Vector4 vector;
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
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector4(L, Vector4.zero);
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
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector4(L, Vector4.one);
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
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector4(L, Vector4.positiveInfinity);
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
				ObjectTranslatorPool.Instance.Find(L).PushUnityEngineVector4(L, Vector4.negativeInfinity);
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
				Vector4 vector;
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
				Vector4 vector;
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
				Vector4 vector;
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
		private static int _g_get_w(IntPtr L)
		{
			try
			{
				Vector4 vector;
				ObjectTranslatorPool.Instance.Find(L).Get(L, 1, out vector);
				Lua.lua_pushnumber(L, (double)vector.w);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				val.x = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				val.y = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				val.z = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
				Vector4 val;
				objectTranslator.Get(L, 1, out val);
				val.w = (float)Lua.lua_tonumber(L, 2);
				objectTranslator.UpdateUnityEngineVector4(L, 1, val);
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
