using System;
using System.Text;
using UnityEngine;
using XLua;

namespace Tutorial
{
	public class CustomLoader : MonoBehaviour
	{
		private void Start()
		{
			this.luaenv = new LuaEnv();
			this.luaenv.AddLoader(delegate(ref string filename)
			{
				if (filename == "InMemory")
				{
					string s = "return {ccc = 9999}";
					return Encoding.UTF8.GetBytes(s);
				}
				return null;
			});
			this.luaenv.DoString("print('InMemory.ccc=', require('InMemory').ccc)", "chunk", null);
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
