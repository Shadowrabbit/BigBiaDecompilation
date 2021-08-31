using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class AsyncTest : MonoBehaviour
	{
		private void Start()
		{
			this.luaenv = new LuaEnv();
			this.luaenv.DoString("require 'async_test'", "chunk", null);
		}

		private void Update()
		{
			if (this.luaenv != null)
			{
				this.luaenv.Tick();
			}
		}

		private LuaEnv luaenv;
	}
}
