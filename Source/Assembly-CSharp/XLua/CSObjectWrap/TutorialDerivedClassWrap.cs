using System;
using Tutorial;
using XLua.LuaDLL;

namespace XLua.CSObjectWrap
{
	public class TutorialDerivedClassWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(DerivedClass);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 1, 12, 2, 2, -1);
			Utils.RegisterFunc(L, -4, "__add", new lua_CSFunction(TutorialDerivedClassWrap.__AddMeta));
			Utils.RegisterFunc(L, -3, "DMFunc", new lua_CSFunction(TutorialDerivedClassWrap._m_DMFunc));
			Utils.RegisterFunc(L, -3, "ComplexFunc", new lua_CSFunction(TutorialDerivedClassWrap._m_ComplexFunc));
			Utils.RegisterFunc(L, -3, "TestFunc", new lua_CSFunction(TutorialDerivedClassWrap._m_TestFunc));
			Utils.RegisterFunc(L, -3, "DefaultValueFunc", new lua_CSFunction(TutorialDerivedClassWrap._m_DefaultValueFunc));
			Utils.RegisterFunc(L, -3, "VariableParamsFunc", new lua_CSFunction(TutorialDerivedClassWrap._m_VariableParamsFunc));
			Utils.RegisterFunc(L, -3, "EnumTestFunc", new lua_CSFunction(TutorialDerivedClassWrap._m_EnumTestFunc));
			Utils.RegisterFunc(L, -3, "CallEvent", new lua_CSFunction(TutorialDerivedClassWrap._m_CallEvent));
			Utils.RegisterFunc(L, -3, "TestLong", new lua_CSFunction(TutorialDerivedClassWrap._m_TestLong));
			Utils.RegisterFunc(L, -3, "GetCalc", new lua_CSFunction(TutorialDerivedClassWrap._m_GetCalc));
			Utils.RegisterFunc(L, -3, "GetSomeData", new lua_CSFunction(TutorialDerivedClassWrap._m_GetSomeData));
			Utils.RegisterFunc(L, -3, "GenericMethodOfString", new lua_CSFunction(TutorialDerivedClassWrap._m_GenericMethodOfString));
			Utils.RegisterFunc(L, -3, "TestEvent", new lua_CSFunction(TutorialDerivedClassWrap._e_TestEvent));
			Utils.RegisterFunc(L, -2, "DMF", new lua_CSFunction(TutorialDerivedClassWrap._g_get_DMF));
			Utils.RegisterFunc(L, -2, "TestDelegate", new lua_CSFunction(TutorialDerivedClassWrap._g_get_TestDelegate));
			Utils.RegisterFunc(L, -1, "DMF", new lua_CSFunction(TutorialDerivedClassWrap._s_set_DMF));
			Utils.RegisterFunc(L, -1, "TestDelegate", new lua_CSFunction(TutorialDerivedClassWrap._s_set_TestDelegate));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(TutorialDerivedClassWrap.__CreateInstance), 1, 0, 0);
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
					DerivedClass o = new DerivedClass();
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
			return Lua.luaL_error(L, "invalid arguments to Tutorial.DerivedClass constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int __AddMeta(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				if (objectTranslator.Assignable<DerivedClass>(L, 1) && objectTranslator.Assignable<DerivedClass>(L, 2))
				{
					DerivedClass a = (DerivedClass)objectTranslator.GetObject(L, 1, typeof(DerivedClass));
					DerivedClass b = (DerivedClass)objectTranslator.GetObject(L, 2, typeof(DerivedClass));
					objectTranslator.Push(L, a + b);
					return 1;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to right hand of + operator, need Tutorial.DerivedClass!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DMFunc(IntPtr L)
		{
			int result;
			try
			{
				((DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DMFunc();
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
		private static int _m_ComplexFunc(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				DerivedClass derivedClass = (DerivedClass)objectTranslator.FastGetCSObj(L, 1);
				Param1 p;
				objectTranslator.Get<Param1>(L, 2, out p);
				int value = Lua.xlua_tointeger(L, 3);
				Action @delegate = objectTranslator.GetDelegate<Action>(L, 4);
				string str;
				Action o;
				double number = derivedClass.ComplexFunc(p, ref value, out str, @delegate, out o);
				Lua.lua_pushnumber(L, number);
				Lua.xlua_pushinteger(L, value);
				Lua.lua_pushstring(L, str);
				objectTranslator.Push(L, o);
				result = 4;
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
		private static int _m_TestFunc(IntPtr L)
		{
			try
			{
				DerivedClass derivedClass = (DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int i = Lua.xlua_tointeger(L, 2);
					derivedClass.TestFunc(i);
					return 0;
				}
				if (num == 2 && (Lua.lua_isnil(L, 2) || Lua.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string i2 = Lua.lua_tostring(L, 2);
					derivedClass.TestFunc(i2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to Tutorial.DerivedClass.TestFunc!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_DefaultValueFunc(IntPtr L)
		{
			try
			{
				DerivedClass derivedClass = (DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 4 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING) && (Lua.lua_isnil(L, 4) || Lua.lua_type(L, 4) == LuaTypes.LUA_TSTRING))
				{
					int a = Lua.xlua_tointeger(L, 2);
					string b = Lua.lua_tostring(L, 3);
					string c = Lua.lua_tostring(L, 4);
					derivedClass.DefaultValueFunc(a, b, c);
					return 0;
				}
				if (num == 3 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2) && (Lua.lua_isnil(L, 3) || Lua.lua_type(L, 3) == LuaTypes.LUA_TSTRING))
				{
					int a2 = Lua.xlua_tointeger(L, 2);
					string b2 = Lua.lua_tostring(L, 3);
					derivedClass.DefaultValueFunc(a2, b2, null);
					return 0;
				}
				if (num == 2 && LuaTypes.LUA_TNUMBER == Lua.lua_type(L, 2))
				{
					int a3 = Lua.xlua_tointeger(L, 2);
					derivedClass.DefaultValueFunc(a3, "cccc", null);
					return 0;
				}
				if (num == 1)
				{
					derivedClass.DefaultValueFunc(100, "cccc", null);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to Tutorial.DerivedClass.DefaultValueFunc!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_VariableParamsFunc(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				DerivedClass derivedClass = (DerivedClass)objectTranslator.FastGetCSObj(L, 1);
				int a = Lua.xlua_tointeger(L, 2);
				string[] @params = objectTranslator.GetParams<string>(L, 3);
				derivedClass.VariableParamsFunc(a, @params);
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
		private static int _m_EnumTestFunc(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				DerivedClass derivedClass = (DerivedClass)objectTranslator.FastGetCSObj(L, 1);
				TestEnum e;
				objectTranslator.Get(L, 2, out e);
				TestEnum val = derivedClass.EnumTestFunc(e);
				objectTranslator.PushTutorialTestEnum(L, val);
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
		private static int _m_CallEvent(IntPtr L)
		{
			int result;
			try
			{
				((DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).CallEvent();
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
		private static int _m_TestLong(IntPtr L)
		{
			int result;
			try
			{
				DerivedClass derivedClass = (DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				long n = Lua.lua_toint64(L, 2);
				ulong n2 = derivedClass.TestLong(n);
				Lua.lua_pushuint64(L, n2);
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
		private static int _m_GetCalc(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				ICalc calc = ((DerivedClass)objectTranslator.FastGetCSObj(L, 1)).GetCalc();
				objectTranslator.PushAny(L, calc);
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
		private static int _m_GetSomeData(IntPtr L)
		{
			int result;
			try
			{
				int someData = ((DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GetSomeData();
				Lua.xlua_pushinteger(L, someData);
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
		private static int _m_GenericMethodOfString(IntPtr L)
		{
			int result;
			try
			{
				((DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).GenericMethodOfString();
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
		private static int _g_get_DMF(IntPtr L)
		{
			try
			{
				DerivedClass derivedClass = (DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1);
				Lua.xlua_pushinteger(L, derivedClass.DMF);
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
		private static int _g_get_TestDelegate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				DerivedClass derivedClass = (DerivedClass)objectTranslator.FastGetCSObj(L, 1);
				objectTranslator.Push(L, derivedClass.TestDelegate);
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
		private static int _s_set_DMF(IntPtr L)
		{
			try
			{
				((DerivedClass)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).DMF = Lua.xlua_tointeger(L, 2);
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
		private static int _s_set_TestDelegate(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				((DerivedClass)objectTranslator.FastGetCSObj(L, 1)).TestDelegate = objectTranslator.GetDelegate<Action<string>>(L, 2);
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
		private static int _e_TestEvent(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				int num = Lua.lua_gettop(L);
				DerivedClass derivedClass = (DerivedClass)objectTranslator.FastGetCSObj(L, 1);
				Action @delegate = objectTranslator.GetDelegate<Action>(L, 3);
				if (@delegate == null)
				{
					return Lua.luaL_error(L, "#3 need System.Action!");
				}
				if (num == 3)
				{
					if (Lua.xlua_is_eq_str(L, 2, "+"))
					{
						derivedClass.TestEvent += @delegate;
						return 0;
					}
					if (Lua.xlua_is_eq_str(L, 2, "-"))
					{
						derivedClass.TestEvent -= @delegate;
						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			Lua.luaL_error(L, "invalid arguments to Tutorial.DerivedClass.TestEvent!");
			return 0;
		}
	}
}
