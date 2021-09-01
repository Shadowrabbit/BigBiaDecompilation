using System;
using UnityEngine;
using XLua;

namespace XLuaTest
{
	[Hotfix(HotfixFlag.Stateless)]
	public class InnerTypeTest
	{
		public void Foo()
		{
			InnerTypeTest._InnerStruct innerStruct = this.Bar();
			Debug.Log(string.Concat(new string[]
			{
				"{x=",
				innerStruct.x.ToString(),
				",y= ",
				innerStruct.y.ToString(),
				"}"
			}));
		}

		private InnerTypeTest._InnerStruct Bar()
		{
			return new InnerTypeTest._InnerStruct
			{
				x = 1,
				y = 2
			};
		}

		private struct _InnerStruct
		{
			public int x;

			public int y;
		}
	}
}
