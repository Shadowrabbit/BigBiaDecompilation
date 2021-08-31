using System;

namespace XLua
{
	public class GCOptimizeAttribute : Attribute
	{
		public OptimizeFlag Flag
		{
			get
			{
				return this.flag;
			}
		}

		public GCOptimizeAttribute(OptimizeFlag flag = OptimizeFlag.Default)
		{
			this.flag = flag;
		}

		private OptimizeFlag flag;
	}
}
