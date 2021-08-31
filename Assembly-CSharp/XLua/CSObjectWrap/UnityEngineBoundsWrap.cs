using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineBoundsWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Bounds);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 1, 11, 5, 5, -1);
			Utils.RegisterFunc(L, -4, "__eq", new lua_CSFunction(UnityEngineBoundsWrap.__EqMeta));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineBoundsWrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineBoundsWrap._m_Equals));
			Utils.RegisterFunc(L, -3, "SetMinMax", new lua_CSFunction(UnityEngineBoundsWrap._m_SetMinMax));
			Utils.RegisterFunc(L, -3, "Encapsulate", new lua_CSFunction(UnityEngineBoundsWrap._m_Encapsulate));
			Utils.RegisterFunc(L, -3, "Expand", new lua_CSFunction(UnityEngineBoundsWrap._m_Expand));
			Utils.RegisterFunc(L, -3, "Intersects", new lua_CSFunction(UnityEngineBoundsWrap._m_Intersects));
			Utils.RegisterFunc(L, -3, "IntersectRay", new lua_CSFunction(UnityEngineBoundsWrap._m_IntersectRay));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineBoundsWrap._m_ToString));
			Utils.RegisterFunc(L, -3, "Contains", new lua_CSFunction(UnityEngineBoundsWrap._m_Contains));
			Utils.RegisterFunc(L, -3, "SqrDistance", new lua_CSFunction(UnityEngineBoundsWrap._m_SqrDistance));
			Utils.RegisterFunc(L, -3, "ClosestPoint", new lua_CSFunction(UnityEngineBoundsWrap._m_ClosestPoint));
			Utils.RegisterFunc(L, -2, "center", new lua_CSFunction(UnityEngineBoundsWrap._g_get_center));
			Utils.RegisterFunc(L, -2, "size", new lua_CSFunction(UnityEngineBoundsWrap._g_get_size));
			Utils.RegisterFunc(L, -2, "extents", new lua_CSFunction(UnityEngineBoundsWrap._g_get_extents));
			Utils.RegisterFunc(L, -2, "min", new lua_CSFunction(UnityEngineBoundsWrap._g_get_min));
			Utils.RegisterFunc(L, -2, "max", new lua_CSFunction(UnityEngineBoundsWrap._g_get_max));
			Utils.RegisterFunc(L, -1, "center", new lua_CSFunction(UnityEngineBoundsWrap._s_set_center));
			Utils.RegisterFunc(L, -1, "size", new lua_CSFunction(UnityEngineBoundsWrap._s_set_size));
			Utils.RegisterFunc(L, -1, "extents", new lua_CSFunction(UnityEngineBoundsWrap._s_set_extents));
			Utils.RegisterFunc(L, -1, "min", new lua_CSFunction(UnityEngineBoundsWrap._s_set_min));
			Utils.RegisterFunc(L, -1, "max", new lua_CSFunction(UnityEngineBoundsWrap._s_set_max));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineBoundsWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 3 && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Vector3>(L, 3))
				{
					Vector3 center;
					objectTranslator.Get(L, 2, out center);
					Vector3 size;
					objectTranslator.Get(L, 3, out size);
					Bounds val = new Bounds(center, size);
					objectTranslator.PushUnityEngineBounds(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushUnityEngineBounds(L, default(Bounds));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Bounds constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __EqMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<Bounds>(L, 1) && objectTranslator.Assignable<Bounds>(L, 2))
				{
					Bounds lhs;
					objectTranslator.Get(L, 1, out lhs);
					Bounds rhs;
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
			return Lua.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Bounds!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetHashCode(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				int hashCode = val.GetHashCode();
				Lua.xlua_pushinteger(L, hashCode);
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 2, typeof(object));
					bool value = val.Equals(@object);
					Lua.lua_pushboolean(L, value);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Bounds>(L, 2))
				{
					Bounds other;
					objectTranslator.Get(L, 2, out other);
					bool value2 = val.Equals(other);
					Lua.lua_pushboolean(L, value2);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Bounds.Equals!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SetMinMax(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 min;
				objectTranslator.Get(L, 2, out min);
				Vector3 max;
				objectTranslator.Get(L, 3, out max);
				val.SetMinMax(min, max);
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _m_Encapsulate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 point;
					objectTranslator.Get(L, 2, out point);
					val.Encapsulate(point);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Bounds>(L, 2))
				{
					Bounds bounds;
					objectTranslator.Get(L, 2, out bounds);
					val.Encapsulate(bounds);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Bounds.Encapsulate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Expand(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float amount = (float)Lua.lua_tonumber(L, 2);
					val.Expand(amount);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 amount2;
					objectTranslator.Get(L, 2, out amount2);
					val.Expand(amount2);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Bounds.Expand!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Intersects(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Bounds bounds;
				objectTranslator.Get(L, 2, out bounds);
				bool value = val.Intersects(bounds);
				Lua.lua_pushboolean(L, value);
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _m_IntersectRay(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Ray>(L, 2))
				{
					Ray ray;
					objectTranslator.Get(L, 2, out ray);
					bool value = val.IntersectRay(ray);
					Lua.lua_pushboolean(L, value);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Ray>(L, 2))
				{
					Ray ray2;
					objectTranslator.Get(L, 2, out ray2);
					float num2;
					bool value2 = val.IntersectRay(ray2, out num2);
					Lua.lua_pushboolean(L, value2);
					Lua.lua_pushnumber(L, (double)num2);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 2;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Bounds.IntersectRay!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToString(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					string str = val.ToString();
					Lua.lua_pushstring(L, str);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string format = Lua.lua_tostring(L, 2);
					string str2 = val.ToString(format);
					Lua.lua_pushstring(L, str2);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 1;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<IFormatProvider>(L, 3))
				{
					string format2 = Lua.lua_tostring(L, 2);
					IFormatProvider formatProvider = (IFormatProvider)objectTranslator.GetObject(L, 3, typeof(IFormatProvider));
					string str3 = val.ToString(format2, formatProvider);
					Lua.lua_pushstring(L, str3);
					objectTranslator.UpdateUnityEngineBounds(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str4 = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str4 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Bounds.ToString!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Contains(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 point;
				objectTranslator.Get(L, 2, out point);
				bool value = val.Contains(point);
				Lua.lua_pushboolean(L, value);
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _m_SqrDistance(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 point;
				objectTranslator.Get(L, 2, out point);
				float num = val.SqrDistance(point);
				Lua.lua_pushnumber(L, (double)num);
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _m_ClosestPoint(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 point;
				objectTranslator.Get(L, 2, out point);
				Vector3 val2 = val.ClosestPoint(point);
				objectTranslator.PushUnityEngineVector3(L, val2);
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _g_get_center(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds bounds;
				objectTranslator.Get(L, 1, out bounds);
				objectTranslator.PushUnityEngineVector3(L, bounds.center);
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
		private static int _g_get_size(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds bounds;
				objectTranslator.Get(L, 1, out bounds);
				objectTranslator.PushUnityEngineVector3(L, bounds.size);
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
		private static int _g_get_extents(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds bounds;
				objectTranslator.Get(L, 1, out bounds);
				objectTranslator.PushUnityEngineVector3(L, bounds.extents);
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
		private static int _g_get_min(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds bounds;
				objectTranslator.Get(L, 1, out bounds);
				objectTranslator.PushUnityEngineVector3(L, bounds.min);
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
		private static int _g_get_max(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds bounds;
				objectTranslator.Get(L, 1, out bounds);
				objectTranslator.PushUnityEngineVector3(L, bounds.max);
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
		private static int _s_set_center(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 center;
				objectTranslator.Get(L, 2, out center);
				val.center = center;
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _s_set_size(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 size;
				objectTranslator.Get(L, 2, out size);
				val.size = size;
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _s_set_extents(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 extents;
				objectTranslator.Get(L, 2, out extents);
				val.extents = extents;
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _s_set_min(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 min;
				objectTranslator.Get(L, 2, out min);
				val.min = min;
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
		private static int _s_set_max(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Bounds val;
				objectTranslator.Get(L, 1, out val);
				Vector3 max;
				objectTranslator.Get(L, 2, out max);
				val.max = max;
				objectTranslator.UpdateUnityEngineBounds(L, 1, val);
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
