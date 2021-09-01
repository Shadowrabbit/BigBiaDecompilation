using System;

namespace PixelGame
{
	public abstract class ObjectBase
	{
		public abstract void Release();

		public string Name;

		public object target;

		public DateTime LastUseTime;
	}
}
