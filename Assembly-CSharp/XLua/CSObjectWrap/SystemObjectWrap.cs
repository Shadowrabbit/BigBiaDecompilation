using System;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class SystemObjectWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(object);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 4, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "Equals", new lua_CSFunction(SystemObjectWrap._m_Equals));
			Utils.RegisterFunc(L, -3, "GetHashCode", new lua_CSFunction(SystemObjectWrap._m_GetHashCode));
			Utils.RegisterFunc(L, -3, "GetType", new lua_CSFunction(SystemObjectWrap._m_GetType));
			Utils.RegisterFunc(L, -3, "ToString", new lua_CSFunction(SystemObjectWrap._m_ToString));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(SystemObjectWrap.__CreateInstance), 3, 0, 0);
			Utils.RegisterFunc(L, -4, "Equals", new lua_CSFunction(SystemObjectWrap._m_Equals_xlua_st_));
			Utils.RegisterFunc(L, -4, "ReferenceEquals", new lua_CSFunction(SystemObjectWrap._m_ReferenceEquals_xlua_st_));
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
					object o = new object();
					objectTranslator.PushAny(L, o);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to object constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Equals(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object obj = objectTranslator.FastGetCSObj(L, 1);
				object @object = objectTranslator.GetObject(L, 2, typeof(object));
				bool value = obj.Equals(@object);
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
		private static int _m_Equals_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object @object = objectTranslator.GetObject(L, 1, typeof(object));
				object object2 = objectTranslator.GetObject(L, 2, typeof(object));
				bool value = object.Equals(@object, object2);
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
		private static int _m_GetHashCode(IntPtr L)
		{
			int result;
			try
			{
				int hashCode = ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1).GetHashCode();
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
		private static int _m_GetType(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Type type = objectTranslator.FastGetCSObj(L, 1).GetType();
				objectTranslator.Push(L, type);
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
			int result;
			try
			{
				string str = ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1).ToString();
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
		private static int _m_ReferenceEquals_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				object @object = objectTranslator.GetObject(L, 1, typeof(object));
				object object2 = objectTranslator.GetObject(L, 2, typeof(object));
				bool value = @object == object2;
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
	}
}
