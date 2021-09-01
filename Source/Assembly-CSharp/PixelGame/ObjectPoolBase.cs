using System;

namespace PixelGame
{
	public abstract class ObjectPoolBase
	{
		public string Name
		{
			get
			{
				return this.m_Name;
			}
		}

		public string FullName
		{
			get
			{
				return this.Name;
			}
		}

		public abstract Type ObjectType { get; }

		public abstract int Capacity { get; set; }

		public abstract int Count { get; }

		public abstract int CanReleaseCount { get; }

		public abstract float ExpireTime { get; }

		public abstract float AutoReleaseInterval { get; }

		public abstract bool AllowMultiSpawn { get; set; }

		public ObjectPoolBase()
		{
			this.m_Name = string.Empty;
		}

		public ObjectPoolBase(string name)
		{
			this.m_Name = name;
		}

		internal abstract void Update(float time);

		private readonly string m_Name;
	}
}
