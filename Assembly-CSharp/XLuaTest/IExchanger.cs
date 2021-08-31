using System;
using XLua;

namespace XLuaTest
{
	[CSharpCallLua]
	public interface IExchanger
	{
		void exchange(Array arr);
	}
}
