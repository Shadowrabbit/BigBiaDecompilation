using System;
using System.Diagnostics;

namespace VoxelImporter
{
	[DebuggerDisplay("\"({x}, {y}, {z}\")"), Serializable]
	public struct IntVector3
	{
		public IntVector3(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static IntVector3 operator -(IntVector3 value)
		{
			return new IntVector3(-value.x, -value.y, -value.z);
		}

		public static IntVector3 operator -(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z);
		}

		public static IntVector3 operator *(int scaleFactor, IntVector3 value)
		{
			return new IntVector3(scaleFactor * value.x, scaleFactor * value.y, scaleFactor * value.z);
		}

		public static IntVector3 operator *(IntVector3 value, int scaleFactor)
		{
			return new IntVector3(value.x * scaleFactor, value.y * scaleFactor, value.z * scaleFactor);
		}

		public static IntVector3 operator *(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x * value2.x, value1.y * value2.y, value1.z * value2.z);
		}

		public static IntVector3 operator /(IntVector3 value, int divider)
		{
			return new IntVector3(value.x / divider, value.y / divider, value.z / divider);
		}

		public static IntVector3 operator /(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x / value2.x, value1.y / value2.y, value1.z / value2.z);
		}

		public static IntVector3 operator +(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z);
		}

		public static bool operator ==(IntVector3 value1, IntVector3 value2)
		{
			return value1.x == value2.x && value1.y == value2.y && value1.z == value2.z;
		}

		public static bool operator !=(IntVector3 value1, IntVector3 value2)
		{
			return value1.x != value2.x || value1.y != value2.y || value1.z != value2.z;
		}

		public static IntVector3 Max(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(Math.Max(value1.x, value2.x), Math.Max(value1.y, value2.y), Math.Max(value1.z, value2.z));
		}

		public static IntVector3 Min(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(Math.Min(value1.x, value2.x), Math.Min(value1.y, value2.y), Math.Min(value1.z, value2.z));
		}

		public static IntVector3 zero
		{
			get
			{
				return new IntVector3(0, 0, 0);
			}
		}

		public static IntVector3 one
		{
			get
			{
				return new IntVector3(1, 1, 1);
			}
		}

		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.y.GetHashCode() ^ this.z.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is IntVector3))
			{
				return false;
			}
			IntVector3 value = (IntVector3)obj;
			return this == value;
		}

		public int x;

		public int y;

		public int z;
	}
}
