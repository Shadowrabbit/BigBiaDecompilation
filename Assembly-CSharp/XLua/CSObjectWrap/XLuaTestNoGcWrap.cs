using System;
using UnityEngine;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestNoGcWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(NoGc);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 5, 5, 5, -1);
			Utils.RegisterFunc(L, -3, "FloatParamMethod", new lua_CSFunction(XLuaTestNoGcWrap._m_FloatParamMethod));
			Utils.RegisterFunc(L, -3, "Vector3ParamMethod", new lua_CSFunction(XLuaTestNoGcWrap._m_Vector3ParamMethod));
			Utils.RegisterFunc(L, -3, "StructParamMethod", new lua_CSFunction(XLuaTestNoGcWrap._m_StructParamMethod));
			Utils.RegisterFunc(L, -3, "EnumParamMethod", new lua_CSFunction(XLuaTestNoGcWrap._m_EnumParamMethod));
			Utils.RegisterFunc(L, -3, "DecimalParamMethod", new lua_CSFunction(XLuaTestNoGcWrap._m_DecimalParamMethod));
			Utils.RegisterFunc(L, -2, "a1", new lua_CSFunction(XLuaTestNoGcWrap._g_get_a1));
			Utils.RegisterFunc(L, -2, "a2", new lua_CSFunction(XLuaTestNoGcWrap._g_get_a2));
			Utils.RegisterFunc(L, -2, "a3", new lua_CSFunction(XLuaTestNoGcWrap._g_get_a3));
			Utils.RegisterFunc(L, -2, "a4", new lua_CSFunction(XLuaTestNoGcWrap._g_get_a4));
			Utils.RegisterFunc(L, -2, "a5", new lua_CSFunction(XLuaTestNoGcWrap._g_get_a5));
			Utils.RegisterFunc(L, -1, "a1", new lua_CSFunction(XLuaTestNoGcWrap._s_set_a1));
			Utils.RegisterFunc(L, -1, "a2", new lua_CSFunction(XLuaTestNoGcWrap._s_set_a2));
			Utils.RegisterFunc(L, -1, "a3", new lua_CSFunction(XLuaTestNoGcWrap._s_set_a3));
			Utils.RegisterFunc(L, -1, "a4", new lua_CSFunction(XLuaTestNoGcWrap._s_set_a4));
			Utils.RegisterFunc(L, -1, "a5", new lua_CSFunction(XLuaTestNoGcWrap._s_set_a5));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestNoGcWrap.__CreateInstance), 1, 0, 0);
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
					NoGc o = new NoGc();
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
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.NoGc constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_FloatParamMethod(IntPtr L)
		{
			int result;
			try
			{
				NoGc noGc = (NoGc)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				float p = (float)Lua.lua_tonumber(L, 2);
				float num = noGc.FloatParamMethod(p);
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
		private static int _m_Vector3ParamMethod(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				Vector3 p;
				objectTranslator.Get(L, 2, out p);
				Vector3 val = noGc.Vector3ParamMethod(p);
				objectTranslator.PushUnityEngineVector3(L, val);
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
		private static int _m_StructParamMethod(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				MyStruct p;
				objectTranslator.Get(L, 2, out p);
				MyStruct val = noGc.StructParamMethod(p);
				objectTranslator.PushXLuaTestMyStruct(L, val);
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
		private static int _m_EnumParamMethod(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				MyEnum p;
				objectTranslator.Get(L, 2, out p);
				MyEnum val = noGc.EnumParamMethod(p);
				objectTranslator.PushXLuaTestMyEnum(L, val);
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
		private static int _m_DecimalParamMethod(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				decimal p;
				objectTranslator.Get(L, 2, out p);
				decimal val = noGc.DecimalParamMethod(p);
				objectTranslator.PushDecimal(L, val);
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
		private static int _g_get_a1(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, noGc.a1);
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
		private static int _g_get_a2(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, noGc.a2);
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
		private static int _g_get_a3(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, noGc.a3);
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
		private static int _g_get_a4(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, noGc.a4);
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
		private static int _g_get_a5(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				NoGc noGc = (NoGc)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, noGc.a5);
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
		private static int _s_set_a1(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((NoGc)objectTranslator.FastGetCSObj(L, 1)).a1 = (double[])objectTranslator.GetObject(L, 2, typeof(double[]));
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
		private static int _s_set_a2(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((NoGc)objectTranslator.FastGetCSObj(L, 1)).a2 = (Vector3[])objectTranslator.GetObject(L, 2, typeof(Vector3[]));
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
		private static int _s_set_a3(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((NoGc)objectTranslator.FastGetCSObj(L, 1)).a3 = (MyStruct[])objectTranslator.GetObject(L, 2, typeof(MyStruct[]));
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
		private static int _s_set_a4(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((NoGc)objectTranslator.FastGetCSObj(L, 1)).a4 = (MyEnum[])objectTranslator.GetObject(L, 2, typeof(MyEnum[]));
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
		private static int _s_set_a5(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((NoGc)objectTranslator.FastGetCSObj(L, 1)).a5 = (decimal[])objectTranslator.GetObject(L, 2, typeof(decimal[]));
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
