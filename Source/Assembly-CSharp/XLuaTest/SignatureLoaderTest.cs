using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	public class SignatureLoaderTest : MonoBehaviour
	{
		private void Start()
		{
			LuaEnv luaEnv = new LuaEnv();
			luaEnv.AddLoader(new SignatureLoader(SignatureLoaderTest.PUBLIC_KEY, delegate(ref string filepath)
			{
				filepath = filepath.Replace('.', '/') + ".lua";
				TextAsset textAsset = (TextAsset)Resources.Load(filepath);
				if (textAsset != null)
				{
					return textAsset.bytes;
				}
				return null;
			}));
			luaEnv.DoString("\r\n            require 'signatured1'\r\n            require 'signatured2'\r\n        ", "chunk", null);
			luaEnv.Dispose();
		}

		private void Update()
		{
		}

		public static string PUBLIC_KEY = "BgIAAACkAABSU0ExAAQAAAEAAQBVDDC5QJ+0uSCJA+EysIC9JBzIsd6wcXa+FuTGXcsJuwyUkabwIiT2+QEjP454RwfSQP8s4VZE1m4npeVD2aDnY4W6ZNJe+V+d9Drt9b+9fc/jushj/5vlEksGBIIC/plU4ZaR6/nDdMIs/JLvhN8lDQthwIYnSLVlPmY1Wgyatw==";
	}
}
