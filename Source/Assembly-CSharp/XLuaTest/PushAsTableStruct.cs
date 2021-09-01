using System;
using XLua;

namespace XLuaTest
{
	[GCOptimize(OptimizeFlag.PackAsTable)]
	public struct PushAsTableStruct
	{
		public int x;

		public int y;
	}
}
