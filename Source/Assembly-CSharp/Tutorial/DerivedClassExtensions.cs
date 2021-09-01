using System;
using UnityEngine;
using XLua;

namespace Tutorial
{
	[LuaCallCSharp(GenFlag.No)]
	public static class DerivedClassExtensions
	{
		public static int GetSomeData(this DerivedClass obj)
		{
			Debug.Log("GetSomeData ret = " + obj.DMF.ToString());
			return obj.DMF;
		}

		public static int GetSomeBaseData(this BaseClass obj)
		{
			Debug.Log("GetSomeBaseData ret = " + obj.BMF.ToString());
			return obj.BMF;
		}

		public static void GenericMethodOfString(this DerivedClass obj)
		{
			obj.GenericMethod<string>();
		}
	}
}
