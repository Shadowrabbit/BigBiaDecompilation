using System;
using XLua;

namespace XLuaTest
{
	[Hotfix(HotfixFlag.Stateless)]
	public struct GenericStruct<T>
	{
		public GenericStruct(T a)
		{
			this.a = a;
		}

		public T GetA(int p)
		{
			return this.a;
		}

		private T a;
	}
}
