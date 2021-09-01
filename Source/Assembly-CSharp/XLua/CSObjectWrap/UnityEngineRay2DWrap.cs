using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineRay2DWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Ray2D);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 2, 2, 2, -1);
			Utils.RegisterFunc(L, -3, "GetPoint", new lua_CSFunction(UnityEngineRay2DWrap._m_GetPoint));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineRay2DWrap._m_ToString));
			Utils.RegisterFunc(L, -2, "origin", new lua_CSFunction(UnityEngineRay2DWrap._g_get_origin));
			Utils.RegisterFunc(L, -2, "direction", new lua_CSFunction(UnityEngineRay2DWrap._g_get_direction));
			Utils.RegisterFunc(L, -1, "origin", new lua_CSFunction(UnityEngineRay2DWrap._s_set_origin));
			Utils.RegisterFunc(L, -1, "direction", new lua_CSFunction(UnityEngineRay2DWrap._s_set_direction));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineRay2DWrap.__CreateInstance), 1, 0, 0);
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 3 && objectTranslator.Assignable<Vector2>(L, 2) && objectTranslator.Assignable<Vector2>(L, 3))
				{
					Vector2 origin;
					objectTranslator.Get(L, 2, out origin);
					Vector2 direction;
					objectTranslator.Get(L, 3, out direction);
					Ray2D val = new Ray2D(origin, direction);
					objectTranslator.PushUnityEngineRay2D(L, val);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					objectTranslator.PushUnityEngineRay2D(L, default(Ray2D));
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Ray2D constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetPoint(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Ray2D val;
				objectTranslator.Get(L, 1, out val);
				float distance = (float)Lua.lua_tonumber(L, 2);
				Vector2 point = val.GetPoint(distance);
				objectTranslator.PushUnityEngineVector2(L, point);
				objectTranslator.UpdateUnityEngineRay2D(L, 1, val);
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
				Ray2D val;
				objectTranslator.Get(L, 1, out val);
				int num = Lua.lua_gettop(L);
				if (num == 1)
				{
					string str = val.ToString();
					Lua.lua_pushstring(L, str);
					objectTranslator.UpdateUnityEngineRay2D(L, 1, val);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string format = Lua.lua_tostring(L, 2);
					string str2 = val.ToString(format);
					Lua.lua_pushstring(L, str2);
					objectTranslator.UpdateUnityEngineRay2D(L, 1, val);
					return 1;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<IFormatProvider>(L, 3))
				{
					string format2 = Lua.lua_tostring(L, 2);
					IFormatProvider formatProvider = (IFormatProvider)objectTranslator.GetObject(L, 3, typeof(IFormatProvider));
					string str3 = val.ToString(format2, formatProvider);
					Lua.lua_pushstring(L, str3);
					objectTranslator.UpdateUnityEngineRay2D(L, 1, val);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str4 = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str4 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Ray2D.ToString!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_origin(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Ray2D ray2D;
				objectTranslator.Get(L, 1, out ray2D);
				objectTranslator.PushUnityEngineVector2(L, ray2D.origin);
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
		private static int _g_get_direction(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Ray2D ray2D;
				objectTranslator.Get(L, 1, out ray2D);
				objectTranslator.PushUnityEngineVector2(L, ray2D.direction);
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
		private static int _s_set_origin(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Ray2D val;
				objectTranslator.Get(L, 1, out val);
				Vector2 origin;
				objectTranslator.Get(L, 2, out origin);
				val.origin = origin;
				objectTranslator.UpdateUnityEngineRay2D(L, 1, val);
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
		private static int _s_set_direction(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Ray2D val;
				objectTranslator.Get(L, 1, out val);
				Vector2 direction;
				objectTranslator.Get(L, 2, out direction);
				val.direction = direction;
				objectTranslator.UpdateUnityEngineRay2D(L, 1, val);
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
