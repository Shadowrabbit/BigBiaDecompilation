using System;
using XLua;

namespace XLuaTest
{
	[CSharpCallLua]
	public delegate MyStruct CustomValueTypeParam(MyStruct p);
}
