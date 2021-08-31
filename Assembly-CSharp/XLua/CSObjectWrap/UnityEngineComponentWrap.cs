using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineComponentWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Component);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 23, 3, 1, -1);
			Utils.RegisterFunc(L, -3, "GetComponent", new lua_CSFunction(UnityEngineComponentWrap._m_GetComponent));
			Utils.RegisterFunc(L, -3, "TryGetComponent", new lua_CSFunction(UnityEngineComponentWrap._m_TryGetComponent));
			Utils.RegisterFunc(L, -3, "GetComponentInChildren", new lua_CSFunction(UnityEngineComponentWrap._m_GetComponentInChildren));
			Utils.RegisterFunc(L, -3, "GetComponentsInChildren", new lua_CSFunction(UnityEngineComponentWrap._m_GetComponentsInChildren));
			Utils.RegisterFunc(L, -3, "GetComponentInParent", new lua_CSFunction(UnityEngineComponentWrap._m_GetComponentInParent));
			Utils.RegisterFunc(L, -3, "GetComponentsInParent", new lua_CSFunction(UnityEngineComponentWrap._m_GetComponentsInParent));
			Utils.RegisterFunc(L, -3, "GetComponents", new lua_CSFunction(UnityEngineComponentWrap._m_GetComponents));
			Utils.RegisterFunc(L, -3, "CompareTag", new lua_CSFunction(UnityEngineComponentWrap._m_CompareTag));
			Utils.RegisterFunc(L, -3, "SendMessageUpwards", new lua_CSFunction(UnityEngineComponentWrap._m_SendMessageUpwards));
			Utils.RegisterFunc(L, -3, "SendMessage", new lua_CSFunction(UnityEngineComponentWrap._m_SendMessage));
			Utils.RegisterFunc(L, -3, "BroadcastMessage", new lua_CSFunction(UnityEngineComponentWrap._m_BroadcastMessage));
			Utils.RegisterFunc(L, -3, "DOComplete", new lua_CSFunction(UnityEngineComponentWrap._m_DOComplete));
			Utils.RegisterFunc(L, -3, "DOKill", new lua_CSFunction(UnityEngineComponentWrap._m_DOKill));
			Utils.RegisterFunc(L, -3, "DOFlip", new lua_CSFunction(UnityEngineComponentWrap._m_DOFlip));
			Utils.RegisterFunc(L, -3, "DOGoto", new lua_CSFunction(UnityEngineComponentWrap._m_DOGoto));
			Utils.RegisterFunc(L, -3, "DOPause", new lua_CSFunction(UnityEngineComponentWrap._m_DOPause));
			Utils.RegisterFunc(L, -3, "DOPlay", new lua_CSFunction(UnityEngineComponentWrap._m_DOPlay));
			Utils.RegisterFunc(L, -3, "DOPlayBackwards", new lua_CSFunction(UnityEngineComponentWrap._m_DOPlayBackwards));
			Utils.RegisterFunc(L, -3, "DOPlayForward", new lua_CSFunction(UnityEngineComponentWrap._m_DOPlayForward));
			Utils.RegisterFunc(L, -3, "DORestart", new lua_CSFunction(UnityEngineComponentWrap._m_DORestart));
			Utils.RegisterFunc(L, -3, "DORewind", new lua_CSFunction(UnityEngineComponentWrap._m_DORewind));
			Utils.RegisterFunc(L, -3, "DOSmoothRewind", new lua_CSFunction(UnityEngineComponentWrap._m_DOSmoothRewind));
			Utils.RegisterFunc(L, -3, "DOTogglePause", new lua_CSFunction(UnityEngineComponentWrap._m_DOTogglePause));
			Utils.RegisterFunc(L, -2, "transform", new lua_CSFunction(UnityEngineComponentWrap._g_get_transform));
			Utils.RegisterFunc(L, -2, "gameObject", new lua_CSFunction(UnityEngineComponentWrap._g_get_gameObject));
			Utils.RegisterFunc(L, -2, "tag", new lua_CSFunction(UnityEngineComponentWrap._g_get_tag));
			Utils.RegisterFunc(L, -1, "tag", new lua_CSFunction(UnityEngineComponentWrap._s_set_tag));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineComponentWrap.__CreateInstance), 1, 0, 0);
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
					Component o = new Component();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component component2 = component.GetComponent(type);
					objectTranslator.Push(L, component2);
					return 1;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string type2 = Lua.lua_tostring(L, 2);
					Component component3 = component.GetComponent(type2);
					objectTranslator.Push(L, component3);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.GetComponent!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_TryGetComponent(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
				Component o;
				bool value = component.TryGetComponent(type, out o);
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
		private static int _m_GetComponentInChildren(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type t = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component componentInChildren = component.GetComponentInChildren(t);
					objectTranslator.Push(L, componentInChildren);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type t2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component componentInChildren2 = component.GetComponentInChildren(t2, includeInactive);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.GetComponentInChildren!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponentsInChildren(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type t = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component[] componentsInChildren = component.GetComponentsInChildren(t);
					objectTranslator.Push(L, componentsInChildren);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type t2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component[] componentsInChildren2 = component.GetComponentsInChildren(t2, includeInactive);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.GetComponentsInChildren!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponentInParent(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				Type t = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
				Component componentInParent = component.GetComponentInParent(t);
				objectTranslator.Push(L, componentInParent);
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
		private static int _m_GetComponentsInParent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type t = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component[] componentsInParent = component.GetComponentsInParent(t);
					objectTranslator.Push(L, componentsInParent);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					Type t2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					bool includeInactive = Lua.lua_toboolean(L, 3);
					Component[] componentsInParent2 = component.GetComponentsInParent(t2, includeInactive);
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.GetComponentsInParent!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_GetComponents(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Type>(L, 2))
				{
					Type type = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					Component[] components = component.GetComponents(type);
					objectTranslator.Push(L, components);
					return 1;
				}
				if (num == 3 && objectTranslator.Assignable<Type>(L, 2) && objectTranslator.Assignable<List<Component>>(L, 3))
				{
					Type type2 = (Type)objectTranslator.GetObject(L, 2, typeof(Type));
					List<Component> results = (List<Component>)objectTranslator.GetObject(L, 3, typeof(List<Component>));
					component.GetComponents(type2, results);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.GetComponents!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_CompareTag(IntPtr L)
		{
			int result;
			try
			{
				Component component = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				string tag = Lua.lua_tostring(L, 2);
				bool value = component.CompareTag(tag);
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
		private static int _m_SendMessageUpwards(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string methodName = Lua.lua_tostring(L, 2);
					component.SendMessageUpwards(methodName);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3))
				{
					string methodName2 = Lua.lua_tostring(L, 2);
					object @object = objectTranslator.GetObject(L, 3, typeof(object));
					component.SendMessageUpwards(methodName2, @object);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<SendMessageOptions>(L, 3))
				{
					string methodName3 = Lua.lua_tostring(L, 2);
					SendMessageOptions options;
					objectTranslator.Get<SendMessageOptions>(L, 3, out options);
					component.SendMessageUpwards(methodName3, options);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3) && objectTranslator.Assignable<SendMessageOptions>(L, 4))
				{
					string methodName4 = Lua.lua_tostring(L, 2);
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					SendMessageOptions options2;
					objectTranslator.Get<SendMessageOptions>(L, 4, out options2);
					component.SendMessageUpwards(methodName4, object2, options2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.SendMessageUpwards!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_SendMessage(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string methodName = Lua.lua_tostring(L, 2);
					component.SendMessage(methodName);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3))
				{
					string methodName2 = Lua.lua_tostring(L, 2);
					object @object = objectTranslator.GetObject(L, 3, typeof(object));
					component.SendMessage(methodName2, @object);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<SendMessageOptions>(L, 3))
				{
					string methodName3 = Lua.lua_tostring(L, 2);
					SendMessageOptions options;
					objectTranslator.Get<SendMessageOptions>(L, 3, out options);
					component.SendMessage(methodName3, options);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3) && objectTranslator.Assignable<SendMessageOptions>(L, 4))
				{
					string methodName4 = Lua.lua_tostring(L, 2);
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					SendMessageOptions options2;
					objectTranslator.Get<SendMessageOptions>(L, 4, out options2);
					component.SendMessage(methodName4, object2, options2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.SendMessage!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_BroadcastMessage(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string methodName = Lua.lua_tostring(L, 2);
					component.BroadcastMessage(methodName);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3))
				{
					string methodName2 = Lua.lua_tostring(L, 2);
					object @object = objectTranslator.GetObject(L, 3, typeof(object));
					component.BroadcastMessage(methodName2, @object);
					return 0;
				}
				if (num == 3 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<SendMessageOptions>(L, 3))
				{
					string methodName3 = Lua.lua_tostring(L, 2);
					SendMessageOptions options;
					objectTranslator.Get<SendMessageOptions>(L, 3, out options);
					component.BroadcastMessage(methodName3, options);
					return 0;
				}
				if (num == 4 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<object>(L, 3) && objectTranslator.Assignable<SendMessageOptions>(L, 4))
				{
					string methodName4 = Lua.lua_tostring(L, 2);
					object object2 = objectTranslator.GetObject(L, 3, typeof(object));
					SendMessageOptions options2;
					objectTranslator.Get<SendMessageOptions>(L, 4, out options2);
					component.BroadcastMessage(methodName4, object2, options2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.BroadcastMessage!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOComplete(IntPtr L)
		{
			try
			{
				Component target = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool withCallbacks = Lua.lua_toboolean(L, 2);
					int value = target.DOComplete(withCallbacks);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1)
				{
					int value2 = target.DOComplete(false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.DOComplete!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOKill(IntPtr L)
		{
			try
			{
				Component target = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool complete = Lua.lua_toboolean(L, 2);
					int value = target.DOKill(complete);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1)
				{
					int value2 = target.DOKill(false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.DOKill!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOFlip(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOFlip();
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
		private static int _m_DOGoto(IntPtr L)
		{
			try
			{
				Component target = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 3))
				{
					float to = (float)Lua.lua_tonumber(L, 2);
					bool andPlay = Lua.lua_toboolean(L, 3);
					int value = target.DOGoto(to, andPlay);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					float to2 = (float)Lua.lua_tonumber(L, 2);
					int value2 = target.DOGoto(to2, false);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.DOGoto!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOPause(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOPause();
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
		private static int _m_DOPlay(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOPlay();
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
		private static int _m_DOPlayBackwards(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOPlayBackwards();
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
		private static int _m_DOPlayForward(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOPlayForward();
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
		private static int _m_DORestart(IntPtr L)
		{
			try
			{
				Component target = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeDelay = Lua.lua_toboolean(L, 2);
					int value = target.DORestart(includeDelay);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1)
				{
					int value2 = target.DORestart(true);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.DORestart!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DORewind(IntPtr L)
		{
			try
			{
				Component target = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 2))
				{
					bool includeDelay = Lua.lua_toboolean(L, 2);
					int value = target.DORewind(includeDelay);
					Lua.xlua_pushinteger(L, value);
					return 1;
				}
				if (num == 1)
				{
					int value2 = target.DORewind(true);
					Lua.xlua_pushinteger(L, value2);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Component.DORewind!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DOSmoothRewind(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOSmoothRewind();
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
		private static int _m_DOTogglePause(IntPtr L)
		{
			int result;
			try
			{
				int value = ((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DOTogglePause();
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
		private static int _g_get_transform(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, component.transform);
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
				Component component = (Component)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, component.gameObject);
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
				Component component = (Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.lua_pushstring(L, component.tag);
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
		private static int _s_set_tag(IntPtr L)
		{
			try
			{
				((Component)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).tag = Lua.lua_tostring(L, 2);
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
