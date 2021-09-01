using System;
using UnityEngine;
using XLua;

namespace Tutorial
{
	public class ByFile : MonoBehaviour
	{
		private void Start()
		{
			this.luaenv = new LuaEnv();
			this.luaenv.DoString("require 'byfile'", "chunk", null);
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
