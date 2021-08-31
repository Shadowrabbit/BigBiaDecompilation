using System;
using UnityEngine;

namespace XLuaTest
{
	public class BaseTestBase<T> : BaseTestHelper
	{
		public virtual void Foo(int p)
		{
			Debug.Log("BaseTestBase<>.Foo, p = " + p.ToString());
		}
	}
}
