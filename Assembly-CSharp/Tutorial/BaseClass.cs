using System;
using UnityEngine;
using XLua;

namespace Tutorial
{
	[LuaCallCSharp(GenFlag.No)]
	public class BaseClass
	{
		public static void BSFunc()
		{
			Debug.Log("Derived Static Func, BSF = " + BaseClass.BSF.ToString());
		}

		public void BMFunc()
		{
			Debug.Log("Derived Member Func, BMF = " + this.BMF.ToString());
		}

		public int BMF { get; set; }

		public static int BSF = 1;
	}
}
