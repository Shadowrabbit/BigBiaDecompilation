using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class Helloworld : MonoBehaviour
	{
		private void Start()
		{
			LuaEnv luaEnv = new LuaEnv();
			luaEnv.DoString("CS.UnityEngine.Debug.Log('hello world')", "chunk", null);
			luaEnv.Dispose();
		}

		private void Update()
		{
		}
	}
}
