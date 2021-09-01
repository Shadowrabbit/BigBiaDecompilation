using System;

namespace XLua
{
	public class HotfixAttribute : Attribute
	{
		public HotfixFlag Flag
		{
			get
			{
				return this.flag;
			}
		}

		public HotfixAttribute(HotfixFlag e = HotfixFlag.Stateless)
		{
			this.flag = e;
		}

		private HotfixFlag flag;
	}
}
