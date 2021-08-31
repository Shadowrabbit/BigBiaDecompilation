using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace XLua
{
	internal class ReferenceEqualsComparer : IEqualityComparer<object>
	{
		public bool Equals(object o1, object o2)
		{
			return o1 == o2;
		}

		public int GetHashCode(object obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}
}
