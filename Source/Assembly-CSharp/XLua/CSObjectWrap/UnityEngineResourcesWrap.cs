using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineResourcesWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Resources);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineResourcesWrap.__CreateInstance), 10, 0, 0);
			Utils.RegisterFunc(L, -4, "FindObjectsOfTypeAll", new lua_CSFunction(UnityEngineResourcesWrap._m_FindObjectsOfTypeAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "Load", new lua_CSFunction(UnityEngineResourcesWrap._m_Load_xlua_st_));
			Utils.RegisterFunc(L, -4, "LoadAsync", new lua_CSFunction(UnityEngineResourcesWrap._m_LoadAsync_xlua_st_));
			Utils.RegisterFunc(L, -4, "LoadAll", new lua_CSFunction(UnityEngineResourcesWrap._m_LoadAll_xlua_st_));
			Utils.RegisterFunc(L, -4, "GetBuiltinResource", new lua_CSFunction(UnityEngineResourcesWrap._m_GetBuiltinResource_xlua_st_));
			Utils.RegisterFunc(L, -4, "UnloadAsset", new lua_CSFunction(UnityEngineResourcesWrap._m_UnloadAsset_xlua_st_));
			Utils.RegisterFunc(L, -4, "UnloadUnusedAssets", new lua_CSFunction(UnityEngineResourcesWrap._m_UnloadUnusedAssets_xlua_st_));
			Utils.RegisterFunc(L, -4, "InstanceIDToObject", new lua_CSFunction(UnityEngineResourcesWrap._m_InstanceIDToObject_xlua_st_));
			Utils.RegisterFunc(L, -4, "InstanceIDToObjectList", new lua_CSFunction(UnityEngineResourcesWrap._m_InstanceIDToObjectList_xlua_st_));
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
					Resources o = new Resources();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Resources constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_FindObjectsOfTypeAll_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				UnityEngine.Object[] o = Resources.FindObjectsOfTypeAll((Type)objectTranslator.GetObject(L, 1, typeof(Type)));
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
		private static int _m_Load_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING))
				{
					UnityEngine.Object o = Resources.Load(Lua.lua_tostring(L, 1));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Type>(L, 2))
				{
					string path = Lua.lua_tostring(L, 1);
					Type systemTypeInstance = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					UnityEngine.Object o2 = Resources.Load(path, systemTypeInstance);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Resources.Load!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LoadAsync_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING))
				{
					ResourceRequest o = Resources.LoadAsync(Lua.lua_tostring(L, 1));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Type>(L, 2))
				{
					string path = Lua.lua_tostring(L, 1);
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					ResourceRequest o2 = Resources.LoadAsync(path, type);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Resources.LoadAsync!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LoadAll_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING))
				{
					UnityEngine.Object[] o = Resources.LoadAll(Lua.lua_tostring(L, 1));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<Type>(L, 2))
				{
					string path = Lua.lua_tostring(L, 1);
					Type systemTypeInstance = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					UnityEngine.Object[] o2 = Resources.LoadAll(path, systemTypeInstance);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Resources.LoadAll!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetBuiltinResource_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = (Type)objectTranslator.GetObject(L, 1, typeof(Type));
				string path = Lua.lua_tostring(L, 2);
				UnityEngine.Object builtinResource = Resources.GetBuiltinResource(type, path);
				objectTranslator.Push(L, builtinResource);
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
		private static int _m_UnloadAsset_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Resources.UnloadAsset((UnityEngine.Object)ObjectTranslatorPool.Instance.Find(L).GetObject(L, 1, typeof(UnityEngine.Object)));
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
		private static int _m_UnloadUnusedAssets_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				AsyncOperation o = Resources.UnloadUnusedAssets();
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
		private static int _m_InstanceIDToObject_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				UnityEngine.Object o = Resources.InstanceIDToObject(Lua.xlua_tointeger(L, 1));
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
		private static int _m_InstanceIDToObjectList_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NativeArray<int> instanceIDs;
				objectTranslator.Get<NativeArray<int>>(L, 1, out instanceIDs);
				List<UnityEngine.Object> objects = (List<UnityEngine.Object>)objectTranslator.GetObject(L, 2, typeof(List<UnityEngine.Object>));
				Resources.InstanceIDToObjectList(instanceIDs, objects);
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
	}
}
