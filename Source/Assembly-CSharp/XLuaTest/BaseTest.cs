using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[Hotfix(HotfixFlag.Stateless), LuaCallCSharp(GenFlag.No)]
	public class BaseTest : BaseTestBase<InnerTypeTest>
	{
		public override void Foo(int p)
		{
			Debug.Log("BaseTest<>.Foo, p = " + p.ToString());
		}

		public void Proxy(int p)
		{
			base.Foo(p);
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
