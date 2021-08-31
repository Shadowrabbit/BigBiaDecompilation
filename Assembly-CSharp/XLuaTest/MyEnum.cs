using System;
using XLua;

namespace XLuaTest
{
	[LuaCallCSharp(GenFlag.No)]
	public enum MyEnum
	{
		E1,
		E2
	}
}
