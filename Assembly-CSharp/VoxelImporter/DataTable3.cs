using System;

namespace VoxelImporter
{
	public class DataTable3<Type>
	{
		public DataTable3(int reserveX = 0, int reserveY = 0, int reserveZ = 0)
		{
			this.reserve = new IntVector3(reserveX, reserveY, reserveZ);
			this.enable = new FlagTable3(reserveX, reserveY, reserveZ);
		}

		public void Set(int x, int y, int z, Type param)
		{
			this.reserve = IntVector3.Max(this.reserve, new IntVector3(x + 1, y + 1, z + 1));
			if (this.table == null)
			{
				this.table = new Type[this.reserve.x][][];
			}
			if (x >= this.table.Length)
			{
				Type[][][] array = new Type[this.reserve.x][][];
				this.table.CopyTo(array, 0);
				this.table = array;
			}
			if (this.table[x] == null)
			{
				this.table[x] = new Type[this.reserve.y][];
			}
			if (y >= this.table[x].Length)
			{
				Type[][] array2 = new Type[this.reserve.y][];
				this.table[x].CopyTo(array2, 0);
				this.table[x] = array2;
			}
			if (this.table[x][y] == null)
			{
				this.table[x][y] = new Type[this.reserve.z];
			}
			if (z >= this.table[x][y].Length)
			{
				Type[] array3 = new Type[this.reserve.z];
				this.table[x][y].CopyTo(array3, 0);
				this.table[x][y] = array3;
			}
			this.table[x][y][z] = param;
			this.enable.Set(x, y, z, true);
		}

		public void Set(IntVector3 pos, Type param)
		{
			this.Set(pos.x, pos.y, pos.z, param);
		}

		public Type Get(int x, int y, int z)
		{
			if (!this.enable.Get(x, y, z))
			{
				return default(Type);
			}
			return this.table[x][y][z];
		}

		public Type Get(IntVector3 pos)
		{
			return this.Get(pos.x, pos.y, pos.z);
		}

		public void Remove(int x, int y, int z)
		{
			if (!this.enable.Get(x, y, z))
			{
				return;
			}
			this.enable.Set(x, y, z, false);
		}

		public void Remove(IntVector3 pos)
		{
			this.Remove(pos.x, pos.y, pos.z);
		}

		public void Clear()
		{
			this.table = null;
			this.enable.Clear();
		}

		public bool Contains(int x, int y, int z)
		{
			return this.enable.Get(x, y, z);
		}

		public bool Contains(IntVector3 pos)
		{
			return this.enable.Get(pos);
		}

		public void AllAction(Action<int, int, int, Type> action)
		{
			if (this.table == null)
			{
				return;
			}
			this.enable.AllAction(delegate(int x, int y, int z)
			{
				action(x, y, z, this.table[x][y][z]);
			});
		}

		private IntVector3 reserve;

		private Type[][][] table;

		private FlagTable3 enable;
	}
}
