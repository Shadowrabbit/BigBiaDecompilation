using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class RawObjectTest : MonoBehaviour
	{
		public static void PrintType(object o)
		{
			string str = "type:";
			Type type = o.GetType();
			Debug.Log(str + ((type != null) ? type.ToString() : null) + ", value:" + ((o != null) ? o.ToString() : null));
		}

		private void Start()
		{
			LuaEnv luaEnv = new LuaEnv();
			luaEnv.DoString("CS.XLuaTest.RawObjectTest.PrintType(1234)", "chunk", null);
			luaEnv.DoString("CS.XLuaTest.RawObjectTest.PrintType(CS.XLua.Cast.Int32(1234))", "chunk", null);
			luaEnv.Dispose();
		}

		private void Update()
		{
		}
	}
}
