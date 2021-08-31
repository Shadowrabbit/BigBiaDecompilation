using System;
using System.Diagnostics;

namespace VoxelImporter
{
	[DebuggerDisplay("\"({x}, {y}, {z}, {w}\")"), Serializable]
	public struct IntVector4
	{
		public IntVector4(int x, int y, int z, int w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static IntVector4 operator -(IntVector4 value)
		{
			return new IntVector4(-value.x, -value.y, -value.z, -value.w);
		}

		public static IntVector4 operator -(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z, value1.w - value2.w);
		}

		public static IntVector4 operator *(int scaleFactor, IntVector4 value)
		{
			return new IntVector4(scaleFactor * value.x, scaleFactor * value.y, scaleFactor * value.z, scaleFactor * value.w);
		}

		public static IntVector4 operator *(IntVector4 value, int scaleFactor)
		{
			return new IntVector4(value.x * scaleFactor, value.y * scaleFactor, value.z * scaleFactor, value.w * scaleFactor);
		}

		public static IntVector4 operator *(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x * value2.x, value1.y * value2.y, value1.z * value2.z, value1.w * value2.w);
		}

		public static IntVector4 operator /(IntVector4 value, int divider)
		{
			return new IntVector4(value.x / divider, value.y / divider, value.z / divider, value.w / divider);
		}

		public static IntVector4 operator /(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x / value2.x, value1.y / value2.y, value1.z / value2.z, value1.w / value2.w);
		}

		public static IntVector4 operator +(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z, value1.w + value2.w);
		}

		public static bool operator ==(IntVector4 value1, IntVector4 value2)
		{
			return value1.x == value2.x && value1.y == value2.y && value1.z == value2.z && value1.w == value2.w;
		}

		public static bool operator !=(IntVector4 value1, IntVector4 value2)
		{
			return value1.x != value2.x || value1.y != value2.y || value1.z != value2.z || value1.w != value2.w;
		}

		public static IntVector4 Max(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(Math.Max(value1.x, value2.x), Math.Max(value1.y, value2.y), Math.Max(value1.z, value2.z), Math.Max(value1.w, value2.w));
		}

		public static IntVector4 Min(IntVector4 value1, IntVector4 value2)
		{
			return new IntVector4(Math.Min(value1.x, value2.x), Math.Min(value1.y, value2.y), Math.Min(value1.z, value2.z), Math.Min(value1.w, value2.w));
		}

		public static IntVector4 zero
		{
			get
			{
				return new IntVector4(0, 0, 0, 0);
			}
		}

		public static IntVector4 one
		{
			get
			{
				return new IntVector4(1, 1, 1, 1);
			}
		}

		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.y.GetHashCode() ^ this.z.GetHashCode() ^ this.w.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is IntVector4))
			{
				return false;
			}
			IntVector4 value = (IntVector4)obj;
			return this == value;
		}

		public int x;

		public int y;

		public int z;

		public int w;
	}
}
