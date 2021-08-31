using System;
using UnityEngine;

namespace VoxelImporter
{
	public class FlagTable3
	{
		public FlagTable3(int reserveX = 0, int reserveY = 0, int reserveZ = 0)
		{
			this.reserve = new IntVector3(reserveX, reserveY, reserveZ);
		}

		public void Set(int x, int y, int z, bool flag)
		{
			int num = Mathf.FloorToInt((float)z / 64f);
			int num2 = z % 64;
			if (!flag)
			{
				if (this.table == null || x >= this.table.Length)
				{
					return;
				}
				if (this.table[x] == null || y >= this.table[x].Length)
				{
					return;
				}
				if (this.table[x][y] == null || num >= this.table[x][y].Length)
				{
					return;
				}
			}
			this.reserve = IntVector3.Max(this.reserve, new IntVector3(x + 1, y + 1, z + 1));
			if (this.table == null)
			{
				this.table = new ulong[this.reserve.x][][];
			}
			if (x >= this.table.Length)
			{
				ulong[][][] array = new ulong[x + 1][][];
				this.table.CopyTo(array, 0);
				this.table = array;
			}
			if (this.table[x] == null)
			{
				this.table[x] = new ulong[this.reserve.y][];
			}
			if (y >= this.table[x].Length)
			{
				ulong[][] array2 = new ulong[y + 1][];
				this.table[x].CopyTo(array2, 0);
				this.table[x] = array2;
			}
			if (this.table[x][y] == null)
			{
				this.table[x][y] = new ulong[this.reserve.z];
			}
			if (num >= this.table[x][y].Length)
			{
				ulong[] array3 = new ulong[this.bufferSize];
				this.table[x][y].CopyTo(array3, 0);
				this.table[x][y] = array3;
			}
			if (flag)
			{
				this.table[x][y][num] |= 1UL << num2;
				return;
			}
			this.table[x][y][num] &= ~(1UL << num2);
		}

		public void Set(IntVector3 pos, bool flag)
		{
			this.Set(pos.x, pos.y, pos.z, flag);
		}

		public bool Get(int x, int y, int z)
		{
			int num = Mathf.FloorToInt((float)z / 64f);
			int num2 = z % 64;
			return this.table != null && x >= 0 && x < this.table.Length && this.table[x] != null && y >= 0 && y < this.table[x].Length && this.table[x][y] != null && num >= 0 && num < this.table[x][y].Length && (this.table[x][y][num] & 1UL << num2) > 0UL;
		}

		public bool Get(IntVector3 pos)
		{
			return this.Get(pos.x, pos.y, pos.z);
		}

		public void Clear()
		{
			this.table = null;
		}

		public void AllAction(Action<int, int, int> action)
		{
			if (this.table == null)
			{
				return;
			}
			for (int i = 0; i < this.table.Length; i++)
			{
				if (this.table[i] != null)
				{
					for (int j = 0; j < this.table[i].Length; j++)
					{
						if (this.table[i][j] != null)
						{
							for (int k = 0; k < this.table[i][j].Length; k++)
							{
								for (int l = 0; l < 64; l++)
								{
									int num = k * 64 + l;
									if (this.Get(i, j, num))
									{
										action(i, j, num);
									}
								}
							}
						}
					}
				}
			}
		}

		private int bufferSize
		{
			get
			{
				return Mathf.CeilToInt((float)this.reserve.z / 64f);
			}
		}

		private IntVector3 reserve;

		private ulong[][][] table;
	}
}
