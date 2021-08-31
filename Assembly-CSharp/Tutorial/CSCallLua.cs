﻿using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Tutorial
{
	public class CSCallLua : MonoBehaviour
	{
		private void Start()
		{
			this.luaenv = new LuaEnv();
			this.luaenv.DoString(this.script, "chunk", null);
			Debug.Log("_G.a = " + this.luaenv.Global.Get<int>("a").ToString());
			Debug.Log("_G.b = " + this.luaenv.Global.Get<string>("b"));
			Debug.Log("_G.c = " + this.luaenv.Global.Get<bool>("c").ToString());
			CSCallLua.DClass dclass = this.luaenv.Global.Get<CSCallLua.DClass>("d");
			Debug.Log(string.Concat(new string[]
			{
				"_G.d = {f1=",
				dclass.f1.ToString(),
				", f2=",
				dclass.f2.ToString(),
				"}"
			}));
			Dictionary<string, double> dictionary = this.luaenv.Global.Get<Dictionary<string, double>>("d");
			Debug.Log(string.Concat(new string[]
			{
				"_G.d = {f1=",
				dictionary["f1"].ToString(),
				", f2=",
				dictionary["f2"].ToString(),
				"}, d.Count=",
				dictionary.Count.ToString()
			}));
			List<double> list = this.luaenv.Global.Get<List<double>>("d");
			Debug.Log("_G.d.len = " + list.Count.ToString());
			CSCallLua.ItfD itfD = this.luaenv.Global.Get<CSCallLua.ItfD>("d");
			itfD.f2 = 1000;
			Debug.Log(string.Concat(new string[]
			{
				"_G.d = {f1=",
				itfD.f1.ToString(),
				", f2=",
				itfD.f2.ToString(),
				"}"
			}));
			Debug.Log("_G.d:add(1, 2)=" + itfD.add(1, 2).ToString());
			LuaTable luaTable = this.luaenv.Global.Get<LuaTable>("d");
			Debug.Log(string.Concat(new string[]
			{
				"_G.d = {f1=",
				luaTable.Get<int>("f1").ToString(),
				", f2=",
				luaTable.Get<int>("f2").ToString(),
				"}"
			}));
			this.luaenv.Global.Get<Action>("e")();
			CSCallLua.DClass dclass2;
			int num = this.luaenv.Global.Get<CSCallLua.FDelegate>("f")(100, "John", out dclass2);
			Debug.Log(string.Concat(new string[]
			{
				"ret.d = {f1=",
				dclass2.f1.ToString(),
				", f2=",
				dclass2.f2.ToString(),
				"}, ret=",
				num.ToString()
			}));
			this.luaenv.Global.Get<CSCallLua.GetE>("ret_e")()();
			this.luaenv.Global.Get<LuaFunction>("e").Call(Array.Empty<object>());
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

		private string script = "\r\n        a = 1\r\n        b = 'hello world'\r\n        c = true\r\n\r\n        d = {\r\n           f1 = 12, f2 = 34, \r\n           1, 2, 3,\r\n           add = function(self, a, b) \r\n              print('d.add called')\r\n              return a + b \r\n           end\r\n        }\r\n\r\n        function e()\r\n            print('i am e')\r\n        end\r\n\r\n        function f(a, b)\r\n            print('a', a, 'b', b)\r\n            return 1, {f1 = 1024}\r\n        end\r\n        \r\n        function ret_e()\r\n            print('ret_e called')\r\n            return e\r\n        end\r\n    ";

		public class DClass
		{
			public int f1;

			public int f2;
		}

		[CSharpCallLua]
		public interface ItfD
		{
			int f1 { get; set; }

			int f2 { get; set; }

			int add(int a, int b);
		}

		[CSharpCallLua]
		public delegate int FDelegate(int a, string b, out CSCallLua.DClass c);

		[CSharpCallLua]
		public delegate Action GetE();
	}
}
