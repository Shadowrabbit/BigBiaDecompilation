using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class GenericMethodExample : MonoBehaviour
	{
		private void Start()
		{
			this.env = new LuaEnv();
			this.env.DoString("\r\n        local foo1 = CS.XLuaTest.Foo1Child()\r\n        local foo2 = CS.XLuaTest.Foo2Child()\r\n\r\n        local obj = CS.UnityEngine.GameObject()\r\n        foo1:PlainExtension()\r\n        foo1:Extension1()\r\n        foo1:Extension2(obj) -- overload1\r\n        foo1:Extension2(foo2) -- overload2\r\n        \r\n        local foo = CS.XLuaTest.Foo()\r\n        foo:Test1(foo1)\r\n        foo:Test2(foo1,foo2,obj)\r\n", "chunk", null);
		}

		private void Update()
		{
			if (this.env != null)
			{
				this.env.Tick();
			}
		}

		private void OnDestroy()
		{
			this.env.Dispose();
		}

		private const string script = "\r\n        local foo1 = CS.XLuaTest.Foo1Child()\r\n        local foo2 = CS.XLuaTest.Foo2Child()\r\n\r\n        local obj = CS.UnityEngine.GameObject()\r\n        foo1:PlainExtension()\r\n        foo1:Extension1()\r\n        foo1:Extension2(obj) -- overload1\r\n        foo1:Extension2(foo2) -- overload2\r\n        \r\n        local foo = CS.XLuaTest.Foo()\r\n        foo:Test1(foo1)\r\n        foo:Test2(foo1,foo2,obj)\r\n";

		private LuaEnv env;
	}
}
