using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class CoroutineTest : MonoBehaviour
	{
		private void Start()
		{
			this.luaenv = new LuaEnv();
			this.luaenv.DoString("require 'coruntine_test'", "chunk", null);
		}

		private void Update()
		{
			if (this.luaenv != null)
			{
				this.luaenv.Tick();
			}
		}

		private void OnDestroy()
		{
			this.luaenv.Dispose();
		}

		private LuaEnv luaenv;
	}
}
