using System;

namespace XLua
{
	public class MonoPInvokeCallbackAttribute : Attribute
	{
		public MonoPInvokeCallbackAttribute(Type t)
		{
			this.type = t;
		}

		private Type type;
	}
}
