using System;
using System.Collections.Generic;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineGameObjectWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(GameObject);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 13, 9, 3, -1);
			Utils.RegisterFunc(L, -3, "GetComponent", new lua_CSFunction(UnityEngineGameObjectWrap._m_GetComponent));
			Utils.RegisterFunc(L, -3, "GetComponentInChildren", new lua_CSFunction(UnityEngineGameObjectWrap._m_GetComponentInChildren));
			Utils.RegisterFunc(L, -3, "GetComponentInParent", new lua_CSFunction(UnityEngineGameObjectWrap._m_GetComponentInParent));
			Utils.RegisterFunc(L, -3, "GetComponents", new lua_CSFunction(UnityEngineGameObjectWrap._m_GetComponents));
			Utils.RegisterFunc(L, -3, "GetComponentsInChildren", new lua_CSFunction(UnityEngineGameObjectWrap._m_GetComponentsInChildren));
			Utils.RegisterFunc(L, -3, "GetComponentsInParent", new lua_CSFunction(UnityEngineGameObjectWrap._m_GetComponentsInParent));
			Utils.RegisterFunc(L, -3, "TryGetComponent", new lua_CSFunction(UnityEngineGameObjectWrap._m_TryGetComponent));
			Utils.RegisterFunc(L, -3, "SendMessageUpwards", new lua_CSFunction(UnityEngineGameObjectWrap._m_SendMessageUpwards));
			Utils.RegisterFunc(L, -3, "SendMessage", new lua_CSFunction(UnityEngineGameObjectWrap._m_SendMessage));
			Utils.RegisterFunc(L, -3, "BroadcastMessage", new lua_CSFunction(UnityEngineGameObjectWrap._m_BroadcastMessage));
			Utils.RegisterFunc(L, -3, "AddComponent", new lua_CSFunction(UnityEngineGameObjectWrap._m_AddComponent));
			Utils.RegisterFunc(L, -3, "SetActive", new lua_CSFunction(UnityEngineGameObjectWrap._m_SetActive));
			Utils.RegisterFunc(L, -3, "CompareTag", new lua_CSFunction(UnityEngineGameObjectWrap._m_CompareTag));
			Utils.RegisterFunc(L, -2, "transform", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_transform));
			Utils.RegisterFunc(L, -2, "layer", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_layer));
			Utils.RegisterFunc(L, -2, "activeSelf", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_activeSelf));
			Utils.RegisterFunc(L, -2, "activeInHierarchy", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_activeInHierarchy));
			Utils.RegisterFunc(L, -2, "isStatic", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_isStatic));
			Utils.RegisterFunc(L, -2, "tag", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_tag));
			Utils.RegisterFunc(L, -2, "scene", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_scene));
			Utils.RegisterFunc(L, -2, "sceneCullingMask", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_sceneCullingMask));
			Utils.RegisterFunc(L, -2, "gameObject", new lua_CSFunction(UnityEngineGameObjectWrap._g_get_gameObject));
			Utils.RegisterFunc(L, -1, "layer", new lua_CSFunction(UnityEngineGameObjectWrap._s_set_layer));
			Utils.RegisterFunc(L, -1, "isStatic", new lua_CSFunction(UnityEngineGameObjectWrap._s_set_isStatic));
			Utils.RegisterFunc(L, -1, "tag", new lua_CSFunction(UnityEngineGameObjectWrap._s_set_tag));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineGameObjectWrap.__CreateInstance), 6, 0, 0);
			Utils.RegisterFunc(L, -4, "CreatePrimitive", new lua_CSFunction(UnityEngineGameObjectWrap._m_CreatePrimitive_xlua_st_));
			Utils.RegisterFunc(L, -4, "FindWithTag", new lua_CSFunction(UnityEngineGameObjectWrap._m_FindWithTag_xlua_st_));
			Utils.RegisterFunc(L, -4, "FindGameObjectWithTag", new lua_CSFunction(UnityEngineGameObjectWrap._m_FindGameObjectWithTag_xlua_st_));
			Utils.RegisterFunc(L, -4, "FindGameObjectsWithTag", new lua_CSFunction(UnityEngineGameObjectWrap._m_FindGameObjectsWithTag_xlua_st_));
			Utils.RegisterFunc(L, -4, "Find", new lua_CSFunction(UnityEngineGameObjectWrap._m_Find_xlua_st_));
			Utils.EndClassRegister(typeFromHandle, L, translator);
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __CreateInstance(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (Lua.lua_gettop(L) == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					GameObject o = new GameObject(Lua.lua_tostring(L, 2));
					objectTranslator.Push(L, o);
					return 1;
				}
				if (Lua.lua_gettop(L) == 1)
				{
					GameObject o2 = new GameObject();
					objectTranslator.Push(L, o2);
					return 1;
				}
				if (Lua.lua_gettop(L) >= 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 3) || objectTranslator.Assignable<Type>(L, 3)))
				{
					string name = Lua.lua_tostring(L, 2);
					Type[] @params = objectTranslator.GetParams<Type>(L, 3);
					GameObject o3 = new GameObject(name, @params);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_CreatePrimitive_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				PrimitiveType type;
				objectTranslator.Get<PrimitiveType>(L, 1, out type);
				GameObject o = GameObject.CreatePrimitive(type);
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
		private static int _m_GetComponent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component component = gameObject.GetComponent(type);
					objectTranslator.Push(L, component);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string type2 = Lua.lua_tostring(L, 2);
					Component component2 = gameObject.GetComponent(type2);
					objectTranslator.Push(L, component2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponent!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponentInChildren(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component componentInChildren = gameObject.GetComponentInChildren(type);
					objectTranslator.Push(L, componentInChildren);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type type2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component componentInChildren2 = gameObject.GetComponentInChildren(type2, includeInactive);
					objectTranslator.Push(L, componentInChildren2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentInChildren!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponentInParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component componentInParent = gameObject.GetComponentInParent(type);
					objectTranslator.Push(L, componentInParent);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type type2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component componentInParent2 = gameObject.GetComponentInParent(type2, includeInactive);
					objectTranslator.Push(L, componentInParent2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentInParent!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponents(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component[] components = gameObject.GetComponents(type);
					objectTranslator.Push(L, components);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && objectTranslator.Assignable<List<Component>>(L, 3))
				{
					Type type2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					List<Component> results = (List<Component>)objectTranslator.GetObject(L, 3, typeof(List<Component>));
					gameObject.GetComponents(type2, results);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponents!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponentsInChildren(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component[] componentsInChildren = gameObject.GetComponentsInChildren(type);
					objectTranslator.Push(L, componentsInChildren);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type type2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component[] componentsInChildren2 = gameObject.GetComponentsInChildren(type2, includeInactive);
					objectTranslator.Push(L, componentsInChildren2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentsInChildren!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponentsInParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component[] componentsInParent = gameObject.GetComponentsInParent(type);
					objectTranslator.Push(L, componentsInParent);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type type2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component[] componentsInParent2 = gameObject.GetComponentsInParent(type2, includeInactive);
					objectTranslator.Push(L, componentsInParent2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentsInParent!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TryGetComponent(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
				Component o;
				bool value = gameObject.TryGetComponent(type, out o);
				Lua.lua_pushboolean(L, value);
				objectTranslator.Push(L, o);
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
		private static int _m_FindWithTag_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject o = GameObject.FindWithTag(Lua.lua_tostring(L, 1));
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
		private static int _m_SendMessageUpwards(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string methodName = Lua.lua_tostring(L, 2);
					gameObject.SendMessageUpwards(methodName);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<SendMessageOptions>(L, 3))
				{
					string methodName2 = Lua.lua_tostring(L, 2);
					SendMessageOptions options;
					objectTranslator.Get<SendMessageOptions>(L, 3, out options);
					gameObject.SendMessageUpwards(methodName2, options);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3))
				{
					string methodName3 = Lua.lua_tostring(L, 2);
					object @object = objectTranslator.GetObject(L, 3, typeof(object));
					gameObject.SendMessageUpwards(methodName3, @object);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3) && objectTranslator.Assignable<SendMessageOptions>(L, 4))
				{
					string methodName4 = Lua.lua_tostring(L, 2);
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					SendMessageOptions options2;
					objectTranslator.Get<SendMessageOptions>(L, 4, out options2);
					gameObject.SendMessageUpwards(methodName4, object2, options2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.SendMessageUpwards!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SendMessage(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string methodName = Lua.lua_tostring(L, 2);
					gameObject.SendMessage(methodName);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<SendMessageOptions>(L, 3))
				{
					string methodName2 = Lua.lua_tostring(L, 2);
					SendMessageOptions options;
					objectTranslator.Get<SendMessageOptions>(L, 3, out options);
					gameObject.SendMessage(methodName2, options);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3))
				{
					string methodName3 = Lua.lua_tostring(L, 2);
					object @object = objectTranslator.GetObject(L, 3, typeof(object));
					gameObject.SendMessage(methodName3, @object);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3) && objectTranslator.Assignable<SendMessageOptions>(L, 4))
				{
					string methodName4 = Lua.lua_tostring(L, 2);
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					SendMessageOptions options2;
					objectTranslator.Get<SendMessageOptions>(L, 4, out options2);
					gameObject.SendMessage(methodName4, object2, options2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.SendMessage!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_BroadcastMessage(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string methodName = Lua.lua_tostring(L, 2);
					gameObject.BroadcastMessage(methodName);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<SendMessageOptions>(L, 3))
				{
					string methodName2 = Lua.lua_tostring(L, 2);
					SendMessageOptions options;
					objectTranslator.Get<SendMessageOptions>(L, 3, out options);
					gameObject.BroadcastMessage(methodName2, options);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3))
				{
					string methodName3 = Lua.lua_tostring(L, 2);
					object @object = objectTranslator.GetObject(L, 3, typeof(object));
					gameObject.BroadcastMessage(methodName3, @object);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3) && objectTranslator.Assignable<SendMessageOptions>(L, 4))
				{
					string methodName4 = Lua.lua_tostring(L, 2);
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					SendMessageOptions options2;
					objectTranslator.Get<SendMessageOptions>(L, 4, out options2);
					gameObject.BroadcastMessage(methodName4, object2, options2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.GameObject.BroadcastMessage!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_AddComponent(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				Type componentType = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
				Component o = gameObject.AddComponent(componentType);
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
		private static int _m_SetActive(IntPtr L)
		{
			int result;
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				bool active = Lua.lua_toboolean(L, 2);
				gameObject.SetActive(active);
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
		private static int _m_CompareTag(IntPtr L)
		{
			int result;
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string tag = Lua.lua_tostring(L, 2);
				bool value = gameObject.CompareTag(tag);
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
		private static int _m_FindGameObjectWithTag_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject o = GameObject.FindGameObjectWithTag(Lua.lua_tostring(L, 1));
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
		private static int _m_FindGameObjectsWithTag_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject[] o = GameObject.FindGameObjectsWithTag(Lua.lua_tostring(L, 1));
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
		private static int _m_Find_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject o = GameObject.Find(Lua.lua_tostring(L, 1));
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
		private static int _g_get_transform(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameObject.transform);
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
		private static int _g_get_layer(IntPtr L)
		{
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, gameObject.layer);
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
		private static int _g_get_activeSelf(IntPtr L)
		{
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, gameObject.activeSelf);
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
		private static int _g_get_activeInHierarchy(IntPtr L)
		{
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, gameObject.activeInHierarchy);
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
		private static int _g_get_isStatic(IntPtr L)
		{
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushboolean(L, gameObject.isStatic);
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
		private static int _g_get_tag(IntPtr L)
		{
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, gameObject.tag);
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
		private static int _g_get_scene(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameObject.scene);
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
		private static int _g_get_sceneCullingMask(IntPtr L)
		{
			try
			{
				GameObject gameObject = (GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushuint64(L, gameObject.sceneCullingMask);
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
		private static int _g_get_gameObject(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				GameObject gameObject = (GameObject)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, gameObject.gameObject);
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
		private static int _s_set_layer(IntPtr L)
		{
			try
			{
				((GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).layer = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_isStatic(IntPtr L)
		{
			try
			{
				((GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).isStatic = Lua.lua_toboolean(L, 2);
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
		private static int _s_set_tag(IntPtr L)
		{
			try
			{
				((GameObject)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).tag = Lua.lua_tostring(L, 2);
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
