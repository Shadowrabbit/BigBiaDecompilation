using System;

namespace XLua
{
	public class LuaCallCSharpAttribute : Attribute
	{
		public GenFlag Flag
		{
			get
			{
				return this.flag;
			}
		}

		public LuaCallCSharpAttribute(GenFlag flag = GenFlag.No)
		{
			this.flag = flag;
		}

		private GenFlag flag;
	}
}
