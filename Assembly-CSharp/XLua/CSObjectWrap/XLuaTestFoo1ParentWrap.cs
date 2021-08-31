using System;
using UnityEngine;
using XLua.LuaDLL;
using XLuaTest;

namespace XLua.CSObjectWrap
{
	public class XLuaTestFoo1ParentWrap
	{
		public static void __Register(IntPtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Type typeFromHandle = typeof(Foo1Parent);
			Utils.BeginObjectRegister(typeFromHandle, L, translator, 0, 3, 0, 0, -1);
			Utils.RegisterFunc(L, -3, "PlainExtension", new lua_CSFunction(XLuaTestFoo1ParentWrap._m_PlainExtension));
			Utils.RegisterFunc(L, -3, "Extension1", new lua_CSFunction(XLuaTestFoo1ParentWrap._m_Extension1));
			Utils.RegisterFunc(L, -3, "Extension2", new lua_CSFunction(XLuaTestFoo1ParentWrap._m_Extension2));
			Utils.EndObjectRegister(typeFromHandle, L, translator, null, null, null, null, null);
			Utils.BeginClassRegister(typeFromHandle, L, new lua_CSFunction(XLuaTestFoo1ParentWrap.__CreateInstance), 1, 0, 0);
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
					Foo1Parent o = new Foo1Parent();
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
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.Foo1Parent constructor!");
		}

		[MonoPInvokeCallback(typeof(lua_CSFunction))]
		private static int _m_PlainExtension(IntPtr L)
		{
			int result;
			try
			{
				((Foo1Parent)ObjectTranslatorPool.Instance.Find(L).FastGetCSObj(L, 1)).PlainExtension();
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
		private static int _m_Extension1(IntPtr L)
		{
			int result;
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Foo1Parent o = ((Foo1Parent)objectTranslator.FastGetCSObj(L, 1)).Extension1<Foo1Parent>();
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
		private static int _m_Extension2(IntPtr L)
		{
			try
			{
				ObjectTranslator objectTranslator = ObjectTranslatorPool.Instance.Find(L);
				Foo1Parent a = (Foo1Parent)objectTranslator.FastGetCSObj(L, 1);
				int num = Lua.lua_gettop(L);
				if (num == 2 && objectTranslator.Assignable<GameObject>(L, 2))
				{
					GameObject b = (GameObject)objectTranslator.GetObject(L, 2, typeof(GameObject));
					Foo1Parent o = a.Extension2(b);
					objectTranslator.Push(L, o);
					return 1;
				}
				if (num == 2 && objectTranslator.Assignable<Foo2Parent>(L, 2))
				{
					Foo2Parent b2 = (Foo2Parent)objectTranslator.GetObject(L, 2, typeof(Foo2Parent));
					a.Extension2(b2);
					return 0;
				}
			}
			catch (Exception ex)
			{
				string str = "c# exception:";
				Exception ex2 = ex;
				return Lua.luaL_error(L, str + ((ex2 != null) ? ex2.ToString() : null));
			}
			return Lua.luaL_error(L, "invalid arguments to XLuaTest.Foo1Parent.Extension2!");
		}
	}
}
