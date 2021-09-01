using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[Hotfix(HotfixFlag.Stateless)]
	public class GenericClass<T>
	{
		public GenericClass(T a)
		{
			this.a = a;
		}

		public void Func1()
		{
			string str = "a=";
			T t = this.a;
			Debug.Log(str + ((t != null) ? t.ToString() : null));
		}

		public T Func2()
		{
			return default(T);
		}

		private T a;
	}
}
