using System;
using UnityEngine;
using XLua;

namespace Tutorial
{
	[LuaCallCSharp(GenFlag.No)]
	public class DerivedClass : BaseClass
	{
		public void DMFunc()
		{
			Debug.Log("Derived Member Func, DMF = " + this.DMF.ToString());
		}

		public int DMF { get; set; }

		public double ComplexFunc(Param1 p1, ref int p2, out string p3, Action luafunc, out Action csfunc)
		{
			Debug.Log(string.Concat(new string[]
			{
				"P1 = {x=",
				p1.x.ToString(),
				",y=",
				p1.y,
				"},p2 = ",
				p2.ToString()
			}));
			luafunc();
			p2 *= p1.x;
			p3 = "hello " + p1.y;
			csfunc = delegate()
			{
				Debug.Log("csharp callback invoked!");
			};
			return 1.23;
		}

		public void TestFunc(int i)
		{
			Debug.Log("TestFunc(int i)");
		}

		public void TestFunc(string i)
		{
			Debug.Log("TestFunc(string i)");
		}

		public static DerivedClass operator +(DerivedClass a, DerivedClass b)
		{
			return new DerivedClass
			{
				DMF = a.DMF + b.DMF
			};
		}

		public void DefaultValueFunc(int a = 100, string b = "cccc", string c = null)
		{
			Debug.Log(string.Concat(new string[]
			{
				"DefaultValueFunc: a=",
				a.ToString(),
				",b=",
				b,
				",c=",
				c
			}));
		}

		public void VariableParamsFunc(int a, params string[] strs)
		{
			Debug.Log("VariableParamsFunc: a =" + a.ToString());
			foreach (string str in strs)
			{
				Debug.Log("str:" + str);
			}
		}

		public TestEnum EnumTestFunc(TestEnum e)
		{
			Debug.Log("EnumTestFunc: e=" + e.ToString());
			return TestEnum.E2;
		}

		public event Action TestEvent;

		public void CallEvent()
		{
			this.TestEvent();
		}

		public ulong TestLong(long n)
		{
			return (ulong)(n + 1L);
		}

		public ICalc GetCalc()
		{
			return new DerivedClass.InnerCalc();
		}

		public void GenericMethod<T>()
		{
			string str = "GenericMethod<";
			Type typeFromHandle = typeof(T);
			Debug.Log(str + ((typeFromHandle != null) ? typeFromHandle.ToString() : null) + ">");
		}

		public Action<string> TestDelegate = delegate(string param)
		{
			Debug.Log("TestDelegate in c#:" + param);
		};

		[LuaCallCSharp(GenFlag.No)]
		public enum TestEnumInner
		{
			E3,
			E4
		}

		private class InnerCalc : ICalc
		{
			public int add(int a, int b)
			{
				return a + b;
			}

			public int id = 100;
		}
	}
}
