using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineObjectWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(UnityEngine.Object);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 1, 4, 2, 2, -1);
			Utils.RegisterFunc(L, -4, "__eq", new lua_CSFunction(UnityEngineObjectWrap.__EqMeta));
			Utils.RegisterFunc(L, -3, "GetInstanceID", new lua_CSFunction(UnityEngineObjectWrap._m_GetInstanceID));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(UnityEngineObjectWrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(UnityEngineObjectWrap._m_Equals));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(UnityEngineObjectWrap._m_ToString));
			Utils.RegisterFunc(L, -2, "name", new lua_CSFunction(UnityEngineObjectWrap._g_get_name));
			Utils.RegisterFunc(L, -2, "hideFlags", new lua_CSFunction(UnityEngineObjectWrap._g_get_hideFlags));
			Utils.RegisterFunc(L, -1, "name", new lua_CSFunction(UnityEngineObjectWrap._s_set_name));
			Utils.RegisterFunc(L, -1, "hideFlags", new lua_CSFunction(UnityEngineObjectWrap._s_set_hideFlags));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineObjectWrap.__CreateInstance), 7, 0, 0);
			Utils.RegisterFunc(L, -4, "Instantiate", new lua_CSFunction(UnityEngineObjectWrap._m_Instantiate_xlua_st_));
			Utils.RegisterFunc(L, -4, "Destroy", new lua_CSFunction(UnityEngineObjectWrap._m_Destroy_xlua_st_));
			Utils.RegisterFunc(L, -4, "DestroyImmediate", new lua_CSFunction(UnityEngineObjectWrap._m_DestroyImmediate_xlua_st_));
			Utils.RegisterFunc(L, -4, "FindObjectsOfType", new lua_CSFunction(UnityEngineObjectWrap._m_FindObjectsOfType_xlua_st_));
			Utils.RegisterFunc(L, -4, "DontDestroyOnLoad", new lua_CSFunction(UnityEngineObjectWrap._m_DontDestroyOnLoad_xlua_st_));
			Utils.RegisterFunc(L, -4, "FindObjectOfType", new lua_CSFunction(UnityEngineObjectWrap._m_FindObjectOfType_xlua_st_));
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
					UnityEngine.Object o = new UnityEngine.Object();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Object constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __EqMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					UnityEngine.Object x = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					UnityEngine.Object y = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					Lua.lua_pushboolean(L, x == y);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Object!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetInstanceID(IntPtr L)
		{
			int result;
			try
			{
				int instanceID = ((UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetInstanceID();
				Lua.xlua_pushinteger(L, instanceID);
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
				int hashCode = ((UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetHashCode();
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
		private static int _m_Equals(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.FastGetCSObj(L, 1);
				object object2 = objectTranslator.GetObject(L, 2, typeof(object));
				bool value = @object.Equals(object2);
				Lua.lua_pushboolean(L, value);
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
		private static int _m_Instantiate_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<UnityEngine.Object>(L, 1))
				{
					UnityEngine.Object o = UnityEngine.Object.Instantiate((UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object)));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 1 && objectTranslator.Assignable<UnityEngine.Object>(L, 1))
				{
					UnityEngine.Object o2 = UnityEngine.Object.Instantiate((UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object)));
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Transform>(L, 2))
				{
					UnityEngine.Object original = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Transform parent = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					UnityEngine.Object o3 = UnityEngine.Object.Instantiate(original, parent);
					objectTranslator.Push(L, o3);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Transform>(L, 2))
				{
					UnityEngine.Object original2 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Transform parent2 = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					UnityEngine.Object o4 = UnityEngine.Object.Instantiate(original2, parent2);
					objectTranslator.Push(L, o4);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Transform>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					UnityEngine.Object original3 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Transform parent3 = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					bool instantiateInWorldSpace = Lua.lua_toboolean(L, 3);
					UnityEngine.Object o5 = UnityEngine.Object.Instantiate(original3, parent3, instantiateInWorldSpace);
					objectTranslator.Push(L, o5);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Transform>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					UnityEngine.Object original4 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Transform parent4 = (Transform)objectTranslator.GetObject(L, 2, typeof(Transform));
					bool instantiateInWorldSpace2 = Lua.lua_toboolean(L, 3);
					UnityEngine.Object o6 = UnityEngine.Object.Instantiate(original4, parent4, instantiateInWorldSpace2);
					objectTranslator.Push(L, o6);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Quaternion>(L, 3))
				{
					UnityEngine.Object original5 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Vector3 position;
					objectTranslator.Get(L, 2, out position);
					Quaternion rotation;
					objectTranslator.Get(L, 3, out rotation);
					UnityEngine.Object o7 = UnityEngine.Object.Instantiate(original5, position, rotation);
					objectTranslator.Push(L, o7);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Quaternion>(L, 3))
				{
					UnityEngine.Object original6 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Vector3 position2;
					objectTranslator.Get(L, 2, out position2);
					Quaternion rotation2;
					objectTranslator.Get(L, 3, out rotation2);
					UnityEngine.Object o8 = UnityEngine.Object.Instantiate(original6, position2, rotation2);
					objectTranslator.Push(L, o8);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Quaternion>(L, 3) && objectTranslator.Assignable<Transform>(L, 4))
				{
					UnityEngine.Object original7 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Vector3 position3;
					objectTranslator.Get(L, 2, out position3);
					Quaternion rotation3;
					objectTranslator.Get(L, 3, out rotation3);
					Transform parent5 = (Transform)objectTranslator.GetObject(L, 4, typeof(Transform));
					UnityEngine.Object o9 = UnityEngine.Object.Instantiate(original7, position3, rotation3, parent5);
					objectTranslator.Push(L, o9);
					return 1;
				}
				if (num == 4 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Quaternion>(L, 3) && objectTranslator.Assignable<Transform>(L, 4))
				{
					UnityEngine.Object original8 = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Vector3 position4;
					objectTranslator.Get(L, 2, out position4);
					Quaternion rotation4;
					objectTranslator.Get(L, 3, out rotation4);
					Transform parent6 = (Transform)objectTranslator.GetObject(L, 4, typeof(Transform));
					UnityEngine.Object o10 = UnityEngine.Object.Instantiate(original8, position4, rotation4, parent6);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Object.Instantiate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Destroy_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<UnityEngine.Object>(L, 1))
				{
					UnityEngine.Object.Destroy((UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object)));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					UnityEngine.Object obj = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					float t = (float)Lua.lua_tonumber(L, 2);
					UnityEngine.Object.Destroy(obj, t);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Object.Destroy!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DestroyImmediate_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<UnityEngine.Object>(L, 1))
				{
					UnityEngine.Object.DestroyImmediate((UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object)));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					UnityEngine.Object obj = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					bool allowDestroyingAssets = Lua.lua_toboolean(L, 2);
					UnityEngine.Object.DestroyImmediate(obj, allowDestroyingAssets);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Object.DestroyImmediate!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_FindObjectsOfType_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<Type>(L, 1))
				{
					UnityEngine.Object[] o = UnityEngine.Object.FindObjectsOfType((Type)objectTranslator.GetObject(L, 1, typeof(Type)));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Type>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 1, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 2);
					UnityEngine.Object[] o2 = UnityEngine.Object.FindObjectsOfType(type, includeInactive);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Object.FindObjectsOfType!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DontDestroyOnLoad_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(UnityEngine.Object)));
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
		private static int _m_FindObjectOfType_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<Type>(L, 1))
				{
					UnityEngine.Object o = UnityEngine.Object.FindObjectOfType((Type)objectTranslator.GetObject(L, 1, typeof(Type)));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Type>(L, 1) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 1, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 2);
					UnityEngine.Object o2 = UnityEngine.Object.FindObjectOfType(type, includeInactive);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Object.FindObjectOfType!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ToString(IntPtr L)
		{
			int result;
			try
			{
				string str = ((UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).ToString();
				Lua.lua_pushstring(L, str);
				result = 1;
			}
			catch (Exception ex)
			{
				string str2 = "c# exception:";
				Exception ex2 = ex;
				result = Lua.luaL_error(L, str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
			return result;
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_name(IntPtr L)
		{
			try
			{
				UnityEngine.Object @object = (UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, @object.name);
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
		private static int _g_get_hideFlags(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, @object.hideFlags);
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
		private static int _s_set_name(IntPtr L)
		{
			try
			{
				((UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).name = Lua.lua_tostring(L, 2);
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
		private static int _s_set_hideFlags(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.FastGetCSObj(L, 1);
				HideFlags hideFlags;
				objectTranslator.Get<HideFlags>(L, 2, out hideFlags);
				@object.hideFlags = hideFlags;
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
