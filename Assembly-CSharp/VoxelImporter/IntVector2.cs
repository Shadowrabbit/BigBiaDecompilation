using System;
using System.Diagnostics;

namespace VoxelImporter
{
	[DebuggerDisplay("\"({x}, {y}\")"), Serializable]
	public struct IntVector2
	{
		public IntVector2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static IntVector2 operator -(IntVector2 value)
		{
			return new IntVector2(-value.x, -value.y);
		}

		public static IntVector2 operator -(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x - value2.x, value1.y - value2.y);
		}

		public static IntVector2 operator *(int scaleFactor, IntVector2 value)
		{
			return new IntVector2(scaleFactor * value.x, scaleFactor * value.y);
		}

		public static IntVector2 operator *(IntVector2 value, int scaleFactor)
		{
			return new IntVector2(value.x * scaleFactor, value.y * scaleFactor);
		}

		public static IntVector2 operator *(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x * value2.x, value1.y * value2.y);
		}

		public static IntVector2 operator /(IntVector2 value, int divider)
		{
			return new IntVector2(value.x / divider, value.y / divider);
		}

		public static IntVector2 operator /(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x / value2.x, value1.y / value2.y);
		}

		public static IntVector2 operator +(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x + value2.x, value1.y + value2.y);
		}

		public static bool operator ==(IntVector2 value1, IntVector2 value2)
		{
			return value1.x == value2.x && value1.y == value2.y;
		}

		public static bool operator !=(IntVector2 value1, IntVector2 value2)
		{
			return value1.x != value2.x || value1.y != value2.y;
		}

		public static IntVector2 Max(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(Math.Max(value1.x, value2.x), Math.Max(value1.y, value2.y));
		}

		public static IntVector2 Min(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(Math.Min(value1.x, value2.x), Math.Min(value1.y, value2.y));
		}

		public static IntVector2 zero
		{
			get
			{
				return new IntVector2(0, 0);
			}
		}

		public static IntVector2 one
		{
			get
			{
				return new IntVector2(1, 1);
			}
		}

		public override int GetHashCode()
		{
			return this.x.GetHashCode() ^ this.x.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is IntVector2))
			{
				return false;
			}
			IntVector2 value = (IntVector2)obj;
			return this == value;
		}

		public int x;

		public int y;
	}
}
