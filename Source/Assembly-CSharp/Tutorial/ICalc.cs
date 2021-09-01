using System;
using XLua;

namespace Tutorial
{
	[LuaCallCSharp(GenFlag.No)]
	public interface ICalc
	{
		int add(int a, int b);
	}
}
