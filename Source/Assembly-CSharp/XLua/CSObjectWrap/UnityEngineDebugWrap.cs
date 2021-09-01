using System;
using UnityEngine;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class UnityEngineDebugWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Debug);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 0, 0, 0, -1);
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(UnityEngineDebugWrap.__CreateInstance), 17, 3, 1);
			Utils.RegisterFunc(L, -4, "DrawLine", new lua_CSFunction(UnityEngineDebugWrap._m_DrawLine_xlua_st_));
			Utils.RegisterFunc(L, -4, "DrawRay", new lua_CSFunction(UnityEngineDebugWrap._m_DrawRay_xlua_st_));
			Utils.RegisterFunc(L, -4, "Break", new lua_CSFunction(UnityEngineDebugWrap._m_Break_xlua_st_));
			Utils.RegisterFunc(L, -4, "DebugBreak", new lua_CSFunction(UnityEngineDebugWrap._m_DebugBreak_xlua_st_));
			Utils.RegisterFunc(L, -4, "Log", new lua_CSFunction(UnityEngineDebugWrap._m_Log_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogFormat", new lua_CSFunction(UnityEngineDebugWrap._m_LogFormat_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogError", new lua_CSFunction(UnityEngineDebugWrap._m_LogError_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogErrorFormat", new lua_CSFunction(UnityEngineDebugWrap._m_LogErrorFormat_xlua_st_));
			Utils.RegisterFunc(L, -4, "ClearDeveloperConsole", new lua_CSFunction(UnityEngineDebugWrap._m_ClearDeveloperConsole_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogException", new lua_CSFunction(UnityEngineDebugWrap._m_LogException_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogWarning", new lua_CSFunction(UnityEngineDebugWrap._m_LogWarning_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogWarningFormat", new lua_CSFunction(UnityEngineDebugWrap._m_LogWarningFormat_xlua_st_));
			Utils.RegisterFunc(L, -4, "Assert", new lua_CSFunction(UnityEngineDebugWrap._m_Assert_xlua_st_));
			Utils.RegisterFunc(L, -4, "AssertFormat", new lua_CSFunction(UnityEngineDebugWrap._m_AssertFormat_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogAssertion", new lua_CSFunction(UnityEngineDebugWrap._m_LogAssertion_xlua_st_));
			Utils.RegisterFunc(L, -4, "LogAssertionFormat", new lua_CSFunction(UnityEngineDebugWrap._m_LogAssertionFormat_xlua_st_));
			Utils.RegisterFunc(L, -2, "unityLogger", new lua_CSFunction(UnityEngineDebugWrap._g_get_unityLogger));
			Utils.RegisterFunc(L, -2, "developerConsoleVisible", new lua_CSFunction(UnityEngineDebugWrap._g_get_developerConsoleVisible));
			Utils.RegisterFunc(L, -2, "isDebugBuild", new lua_CSFunction(UnityEngineDebugWrap._g_get_isDebugBuild));
			Utils.RegisterFunc(L, -1, "developerConsoleVisible", new lua_CSFunction(UnityEngineDebugWrap._s_set_developerConsoleVisible));
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
					Debug o = new Debug();
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
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DrawLine_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 start;
					objectTranslator.Get(L, 1, out start);
					Vector3 end;
					objectTranslator.Get(L, 2, out end);
					Debug.DrawLine(start, end);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Color>(L, 3))
				{
					Vector3 start2;
					objectTranslator.Get(L, 1, out start2);
					Vector3 end2;
					objectTranslator.Get(L, 2, out end2);
					Color color;
					objectTranslator.Get(L, 3, out color);
					Debug.DrawLine(start2, end2, color);
					return 0;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Color>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 start3;
					objectTranslator.Get(L, 1, out start3);
					Vector3 end3;
					objectTranslator.Get(L, 2, out end3);
					Color color2;
					objectTranslator.Get(L, 3, out color2);
					float duration = (float)Lua.lua_tonumber(L, 4);
					Debug.DrawLine(start3, end3, color2, duration);
					return 0;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Color>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 5))
				{
					Vector3 start4;
					objectTranslator.Get(L, 1, out start4);
					Vector3 end4;
					objectTranslator.Get(L, 2, out end4);
					Color color3;
					objectTranslator.Get(L, 3, out color3);
					float duration2 = (float)Lua.lua_tonumber(L, 4);
					bool depthTest = Lua.lua_toboolean(L, 5);
					Debug.DrawLine(start4, end4, color3, duration2, depthTest);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.DrawLine!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DrawRay_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2))
				{
					Vector3 start;
					objectTranslator.Get(L, 1, out start);
					Vector3 dir;
					objectTranslator.Get(L, 2, out dir);
					Debug.DrawRay(start, dir);
					return 0;
				}
				if (num == 3 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Color>(L, 3))
				{
					Vector3 start2;
					objectTranslator.Get(L, 1, out start2);
					Vector3 dir2;
					objectTranslator.Get(L, 2, out dir2);
					Color color;
					objectTranslator.Get(L, 3, out color);
					Debug.DrawRay(start2, dir2, color);
					return 0;
				}
				if (num == 4 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Color>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4))
				{
					Vector3 start3;
					objectTranslator.Get(L, 1, out start3);
					Vector3 dir3;
					objectTranslator.Get(L, 2, out dir3);
					Color color2;
					objectTranslator.Get(L, 3, out color2);
					float duration = (float)Lua.lua_tonumber(L, 4);
					Debug.DrawRay(start3, dir3, color2, duration);
					return 0;
				}
				if (num == 5 && objectTranslator.Assignable<Vector3>(L, 1) && objectTranslator.Assignable<Vector3>(L, 2) && objectTranslator.Assignable<Color>(L, 3) && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 4) && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 5))
				{
					Vector3 start4;
					objectTranslator.Get(L, 1, out start4);
					Vector3 dir4;
					objectTranslator.Get(L, 2, out dir4);
					Color color3;
					objectTranslator.Get(L, 3, out color3);
					float duration2 = (float)Lua.lua_tonumber(L, 4);
					bool depthTest = Lua.lua_toboolean(L, 5);
					Debug.DrawRay(start4, dir4, color3, duration2, depthTest);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.DrawRay!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Break_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Debug.Break();
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
		private static int _m_DebugBreak_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Debug.DebugBreak();
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
		private static int _m_Log_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					Debug.Log(objectTranslator.GetObject(L, 1, typeof(object)));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					Debug.Log(@object, context);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.Log!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogFormat_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num >= 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 2) || objectTranslator.Assignable<object>(L, 2)))
				{
					string format = Lua.lua_tostring(L, 1);
					object[] @params = objectTranslator.GetParams<object>(L, 2);
					Debug.LogFormat(format, @params);
					return 0;
				}
				if (num >= 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 3) || objectTranslator.Assignable<object>(L, 3)))
				{
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					string format2 = Lua.lua_tostring(L, 2);
					object[] params2 = objectTranslator.GetParams<object>(L, 3);
					Debug.LogFormat(context, format2, params2);
					return 0;
				}
				if (num >= 4 && objectTranslator.Assignable<UnityEngine.LogType>(L, 1) && objectTranslator.Assignable<LogOption>(L, 2) && objectTranslator.Assignable<UnityEngine.Object>(L, 3) && (Lua.lua_isnil(L, 4) || Lua.lua_type(L, 4) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 5) || objectTranslator.Assignable<object>(L, 5)))
				{
					UnityEngine.LogType logType;
					objectTranslator.Get<UnityEngine.LogType>(L, 1, out logType);
					LogOption logOptions;
					objectTranslator.Get<LogOption>(L, 2, out logOptions);
					UnityEngine.Object context2 = (UnityEngine.Object)objectTranslator.GetObject(L, 3, typeof(UnityEngine.Object));
					string format3 = Lua.lua_tostring(L, 4);
					object[] params3 = objectTranslator.GetParams<object>(L, 5);
					Debug.LogFormat(logType, logOptions, context2, format3, params3);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogFormat!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogError_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					Debug.LogError(objectTranslator.GetObject(L, 1, typeof(object)));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					Debug.LogError(@object, context);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogError!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogErrorFormat_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num >= 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 2) || objectTranslator.Assignable<object>(L, 2)))
				{
					string format = Lua.lua_tostring(L, 1);
					object[] @params = objectTranslator.GetParams<object>(L, 2);
					Debug.LogErrorFormat(format, @params);
					return 0;
				}
				if (num >= 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 3) || objectTranslator.Assignable<object>(L, 3)))
				{
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					string format2 = Lua.lua_tostring(L, 2);
					object[] params2 = objectTranslator.GetParams<object>(L, 3);
					Debug.LogErrorFormat(context, format2, params2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogErrorFormat!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_ClearDeveloperConsole_xlua_st_(IntPtr L)
		{
			int result;
			try
			{
				Debug.ClearDeveloperConsole();
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
		private static int _m_LogException_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<Exception>(L, 1))
				{
					Debug.LogException((Exception)objectTranslator.GetObject(L, 1, typeof(Exception)));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<Exception>(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					Exception exception = (Exception)objectTranslator.GetObject(L, 1, typeof(Exception));
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					Debug.LogException(exception, context);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogException!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogWarning_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					Debug.LogWarning(objectTranslator.GetObject(L, 1, typeof(object)));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					object @object = objectTranslator.GetObject(L, 1, typeof(object));
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					Debug.LogWarning(@object, context);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogWarning!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogWarningFormat_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num >= 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 2) || objectTranslator.Assignable<object>(L, 2)))
				{
					string format = Lua.lua_tostring(L, 1);
					object[] @params = objectTranslator.GetParams<object>(L, 2);
					Debug.LogWarningFormat(format, @params);
					return 0;
				}
				if (num >= 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 3) || objectTranslator.Assignable<object>(L, 3)))
				{
					UnityEngine.Object context = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					string format2 = Lua.lua_tostring(L, 2);
					object[] params2 = objectTranslator.GetParams<object>(L, 3);
					Debug.LogWarningFormat(context, format2, params2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogWarningFormat!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Assert_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1))
				{
					Lua.lua_toboolean(L, 1);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					Lua.lua_toboolean(L, 1);
					UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && objectTranslator.Assignable<object>(L, 2))
				{
					Lua.lua_toboolean(L, 1);
					objectTranslator.GetObject(L, 2, typeof(object));
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					Lua.lua_toboolean(L, 1);
					Lua.lua_tostring(L, 2);
					return 0;
				}
				if (num == 3 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && objectTranslator.Assignable<object>(L, 2) && objectTranslator.Assignable<UnityEngine.Object>(L, 3))
				{
					Lua.lua_toboolean(L, 1);
					objectTranslator.GetObject(L, 2, typeof(object));
					UnityEngine.Object object2 = (UnityEngine.Object)objectTranslator.GetObject(L, 3, typeof(UnityEngine.Object));
					return 0;
				}
				if (num == 3 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && objectTranslator.Assignable<UnityEngine.Object>(L, 3))
				{
					Lua.lua_toboolean(L, 1);
					Lua.lua_tostring(L, 2);
					UnityEngine.Object object3 = (UnityEngine.Object)objectTranslator.GetObject(L, 3, typeof(UnityEngine.Object));
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.Assert!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_AssertFormat_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num >= 2 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 3) || objectTranslator.Assignable<object>(L, 3)))
				{
					Lua.lua_toboolean(L, 1);
					Lua.lua_tostring(L, 2);
					objectTranslator.GetParams<object>(L, 3);
					return 0;
				}
				if (num >= 3 && LuaTypes.LUA_TBOOLEAN == Lua.lua_type(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 4) || objectTranslator.Assignable<object>(L, 4)))
				{
					Lua.lua_toboolean(L, 1);
					UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					Lua.lua_tostring(L, 3);
					objectTranslator.GetParams<object>(L, 4);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.AssertFormat!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogAssertion_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num == 1 && objectTranslator.Assignable<object>(L, 1))
				{
					objectTranslator.GetObject(L, 1, typeof(object));
					return 0;
				}
				if (num == 2 && objectTranslator.Assignable<object>(L, 1) && objectTranslator.Assignable<UnityEngine.Object>(L, 2))
				{
					objectTranslator.GetObject(L, 1, typeof(object));
					UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.GetObject(L, 2, typeof(UnityEngine.Object));
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogAssertion!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_LogAssertionFormat_xlua_st_(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				if (num >= 1 && (Lua.lua_isnil(L, 1) || Lua.lua_type(L, 1) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 2) || objectTranslator.Assignable<object>(L, 2)))
				{
					Lua.lua_tostring(L, 1);
					objectTranslator.GetParams<object>(L, 2);
					return 0;
				}
				if (num >= 2 && objectTranslator.Assignable<UnityEngine.Object>(L, 1) && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == Lua.lua_type(L, 3) || objectTranslator.Assignable<object>(L, 3)))
				{
					UnityEngine.Object @object = (UnityEngine.Object)objectTranslator.GetObject(L, 1, typeof(UnityEngine.Object));
					Lua.lua_tostring(L, 2);
					objectTranslator.GetParams<object>(L, 3);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to UnityEngine.Debug.LogAssertionFormat!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _g_get_unityLogger(IntPtr L)
		{
			try
			{
				ObjectTranslatorPool.Instance.Find(L).PushAny(L, Debug.unityLogger);
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
		private static int _g_get_developerConsoleVisible(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, Debug.developerConsoleVisible);
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
		private static int _g_get_isDebugBuild(IntPtr L)
		{
			try
			{
				Lua.lua_pushboolean(L, Debug.isDebugBuild);
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
		private static int _s_set_developerConsoleVisible(IntPtr L)
		{
			try
			{
				Debug.developerConsoleVisible = Lua.lua_toboolean(L, 1);
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
