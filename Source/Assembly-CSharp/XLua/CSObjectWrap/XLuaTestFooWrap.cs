using System;
using UnityEngine;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestFooWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Foo);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 2, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "Test1", new lua_CSFunction(XLuaTestFooWrap._m_Test1));
			Utils.RegisterFunc(L, -3, "Test2", new lua_CSFunction(XLuaTestFooWrap._m_Test2));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestFooWrap.__CreateInstance), 1, 0, 0);
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
					Foo o = new Foo();
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
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.Foo constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_Test1(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Foo foo = (Foo)objectTranslator.FastGetCSObj(L, 1);
				Foo1Parent a = (Foo1Parent)objectTranslator.GetObject(L, 2, typeof(Foo1Parent));
				foo.Test1<Foo1Parent>(a);
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
		private static int _m_Test2(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Foo foo = (Foo)objectTranslator.FastGetCSObj(L, 1);
				Foo1Parent a = (Foo1Parent)objectTranslator.GetObject(L, 2, typeof(Foo1Parent));
				Foo2Parent b = (Foo2Parent)objectTranslator.GetObject(L, 3, typeof(Foo2Parent));
				GameObject c = (GameObject)objectTranslator.GetObject(L, 4, typeof(GameObject));
				Foo1Parent o = foo.Test2<Foo1Parent, Foo2Parent>(a, b, c);
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
	}
}
