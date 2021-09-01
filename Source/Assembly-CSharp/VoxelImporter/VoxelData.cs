using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace VoxelImporter
{
	public class VoxelData
	{
		public void CreateVoxelTable()
		{
			this.voxelTable = new DataTable3<int>(this.voxelSize.x, this.voxelSize.y, this.voxelSize.z);
			if (this.voxels != null)
			{
				for (int i = 0; i < this.voxels.Length; i++)
				{
					this.voxelTable.Set(this.voxels[i].position, i);
				}
			}
			this.vertexList = new List<IntVector3>();
			bool[,,] doneTable = new bool[this.voxelSize.x + 1, this.voxelSize.y + 1, this.voxelSize.z + 1];
			Action<IntVector3> action = delegate(IntVector3 pos)
			{
				if (pos.x < 0 || pos.y < 0 || pos.z < 0)
				{
					return;
				}
				if (!doneTable[pos.x, pos.y, pos.z])
				{
					doneTable[pos.x, pos.y, pos.z] = true;
					this.vertexList.Add(pos);
				}
			};
			if (this.voxels != null)
			{
				for (int j = 0; j < this.voxels.Length; j++)
				{
					action(new IntVector3(this.voxels[j].x, this.voxels[j].y, this.voxels[j].z));
					action(new IntVector3(this.voxels[j].x + 1, this.voxels[j].y, this.voxels[j].z));
					action(new IntVector3(this.voxels[j].x, this.voxels[j].y + 1, this.voxels[j].z));
					action(new IntVector3(this.voxels[j].x, this.voxels[j].y, this.voxels[j].z + 1));
					action(new IntVector3(this.voxels[j].x + 1, this.voxels[j].y + 1, this.voxels[j].z));
					action(new IntVector3(this.voxels[j].x + 1, this.voxels[j].y, this.voxels[j].z + 1));
					action(new IntVector3(this.voxels[j].x, this.voxels[j].y + 1, this.voxels[j].z + 1));
					action(new IntVector3(this.voxels[j].x + 1, this.voxels[j].y + 1, this.voxels[j].z + 1));
				}
			}
		}

		public int VoxelTableContains(IntVector3 pos)
		{
			if (!this.voxelTable.Contains(pos))
			{
				return -1;
			}
			return this.voxelTable.Get(pos);
		}

		public int VoxelTableContains(int x, int y, int z)
		{
			if (!this.voxelTable.Contains(x, y, z))
			{
				return -1;
			}
			return this.voxelTable.Get(x, y, z);
		}

		protected void SetVoxelTable(IntVector3 pos, int index)
		{
			this.voxelTable.Set(pos, index);
		}

		protected void SetVoxelTable(int x, int y, int z, int index)
		{
			this.voxelTable.Set(x, y, z, index);
		}

		private DataTable3<int> voxelTable;

		public List<IntVector3> vertexList;

		public VoxelData.Voxel[] voxels;

		public Color[] palettes;

		public IntVector3 voxelSize;

		[DebuggerDisplay("\"Position({x}, {y}, {z}\"), Palette({palette})")]
		public struct Voxel
		{
			public Voxel(int x, int y, int z, int palette)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				this.palette = palette;
				this.visible = (VoxelBase.Face.forward | VoxelBase.Face.up | VoxelBase.Face.right | VoxelBase.Face.left | VoxelBase.Face.down | VoxelBase.Face.back);
			}

			public IntVector3 position
			{
				get
				{
					return new IntVector3(this.x, this.y, this.z);
				}
				set
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}

			public int x;

			public int y;

			public int z;

			public int palette;

			public VoxelBase.Face visible;
		}

		public struct FaceArea
		{
			public IntVector3 size
			{
				get
				{
					return this.max - this.min + IntVector3.one;
				}
			}

			public Vector3 minf
			{
				get
				{
					return new Vector3((float)this.min.x, (float)this.min.y, (float)this.min.z);
				}
			}

			public Vector3 maxf
			{
				get
				{
					return new Vector3((float)this.max.x, (float)this.max.y, (float)this.max.z);
				}
			}

			public IntVector3 Get(VoxelBase.VoxelVertexIndex index)
			{
				switch (index)
				{
				case VoxelBase.VoxelVertexIndex.XYZ:
					return new IntVector3(this.max.x, this.max.y, this.max.z);
				case VoxelBase.VoxelVertexIndex._XYZ:
					return new IntVector3(this.min.x, this.max.y, this.max.z);
				case VoxelBase.VoxelVertexIndex.X_YZ:
					return new IntVector3(this.max.x, this.min.y, this.max.z);
				case VoxelBase.VoxelVertexIndex.XY_Z:
					return new IntVector3(this.max.x, this.max.y, this.min.z);
				case VoxelBase.VoxelVertexIndex._X_YZ:
					return new IntVector3(this.min.x, this.min.y, this.max.z);
				case VoxelBase.VoxelVertexIndex._XY_Z:
					return new IntVector3(this.min.x, this.max.y, this.min.z);
				case VoxelBase.VoxelVertexIndex.X_Y_Z:
					return new IntVector3(this.max.x, this.min.y, this.min.z);
				case VoxelBase.VoxelVertexIndex._X_Y_Z:
					return new IntVector3(this.min.x, this.min.y, this.min.z);
				default:
					return IntVector3.zero;
				}
			}

			public IntVector3 min;

			public IntVector3 max;

			public int palette;

			public int material;
		}

		public class FaceAreaTable
		{
			public void Merge(VoxelData.FaceAreaTable src)
			{
				this.forward.AddRange(src.forward);
				this.up.AddRange(src.up);
				this.right.AddRange(src.right);
				this.left.AddRange(src.left);
				this.down.AddRange(src.down);
				this.back.AddRange(src.back);
			}

			public void ReplacePalette(int[] paletteTable)
			{
				for (int i = 0; i < this.forward.Count; i++)
				{
					VoxelData.FaceArea faceArea = this.forward[i];
					faceArea.palette = paletteTable[faceArea.palette];
					this.forward[i] = faceArea;
				}
				for (int j = 0; j < this.up.Count; j++)
				{
					VoxelData.FaceArea faceArea2 = this.up[j];
					faceArea2.palette = paletteTable[faceArea2.palette];
					this.up[j] = faceArea2;
				}
				for (int k = 0; k < this.right.Count; k++)
				{
					VoxelData.FaceArea faceArea3 = this.right[k];
					faceArea3.palette = paletteTable[faceArea3.palette];
					this.right[k] = faceArea3;
				}
				for (int l = 0; l < this.left.Count; l++)
				{
					VoxelData.FaceArea faceArea4 = this.left[l];
					faceArea4.palette = paletteTable[faceArea4.palette];
					this.left[l] = faceArea4;
				}
				for (int m = 0; m < this.down.Count; m++)
				{
					VoxelData.FaceArea faceArea5 = this.down[m];
					faceArea5.palette = paletteTable[faceArea5.palette];
					this.down[m] = faceArea5;
				}
				for (int n = 0; n < this.back.Count; n++)
				{
					VoxelData.FaceArea faceArea6 = this.back[n];
					faceArea6.palette = paletteTable[faceArea6.palette];
					this.back[n] = faceArea6;
				}
			}

			public List<VoxelData.FaceArea> forward = new List<VoxelData.FaceArea>();

			public List<VoxelData.FaceArea> up = new List<VoxelData.FaceArea>();

			public List<VoxelData.FaceArea> right = new List<VoxelData.FaceArea>();

			public List<VoxelData.FaceArea> left = new List<VoxelData.FaceArea>();

			public List<VoxelData.FaceArea> down = new List<VoxelData.FaceArea>();

			public List<VoxelData.FaceArea> back = new List<VoxelData.FaceArea>();
		}
	}
}
