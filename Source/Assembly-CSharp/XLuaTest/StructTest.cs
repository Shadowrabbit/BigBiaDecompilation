using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[Hotfix(HotfixFlag.Stateless)]
	public struct StructTest
	{
		public StructTest(GameObject go)
		{
			this.go = go;
		}

		public GameObject GetGo(int a, object b)
		{
			return this.go;
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public string Proxy()
		{
			return base.ToString();
		}

		private GameObject go;
	}
}
