using System;
using XLua;

namespace XLuaTest
{
	[CSharpCallLua]
	public delegate MyEnum EnumParam(MyEnum p);
}
