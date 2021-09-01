using System;

namespace XLua.Cast
{
	public class Any<T> : RawObject
	{
		public Any(T i)
		{
			this.mTarget = i;
		}

		public object Target
		{
			get
			{
				return this.mTarget;
			}
		}

		private T mTarget;
	}
}
