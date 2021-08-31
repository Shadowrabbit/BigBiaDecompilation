using System;
using XLua;

namespace Tutorial
{
	[LuaCallCSharp(GenFlag.No)]
	public enum TestEnum
	{
		E1,
		E2
	}
}
