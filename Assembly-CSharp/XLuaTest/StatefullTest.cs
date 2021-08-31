using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[Hotfix(HotfixFlag.Stateless)]
	public class StatefullTest
	{
		public StatefullTest()
		{
		}

		public StatefullTest(int a, int b)
		{
			if (a > 0)
			{
				return;
			}
			Debug.Log("a=" + a.ToString());
			if (b > 0)
			{
				return;
			}
			if (a + b > 0)
			{
				return;
			}
			Debug.Log("b=" + b.ToString());
		}

		public int AProp { get; set; }

		public event Action<int, double> AEvent;

		public int this[string field]
		{
			get
			{
				return 1;
			}
			set
			{
			}
		}

		public void Start()
		{
		}

		private void Update()
		{
		}

		public void GenericTest<T>(T a)
		{
		}

		public static void StaticFunc(int a, int b)
		{
		}

		public static void StaticFunc(string a, int b, int c)
		{
		}

		~StatefullTest()
		{
			Debug.Log("~StatefullTest");
		}
	}
}
