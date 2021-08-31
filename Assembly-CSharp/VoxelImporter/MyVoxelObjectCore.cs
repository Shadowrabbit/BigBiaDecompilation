using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelImporter
{
	public class MyVoxelObjectCore : MyVoxelBaseCore
	{
		public MyVoxelObjectCore(VoxelBase target) : base(target)
		{
			this.voxelObject = (target as VoxelObject);
		}

		public VoxelObject voxelObject { get; set; }

		public virtual Mesh mesh
		{
			get
			{
				return this.voxelObject.mesh;
			}
			set
			{
				this.voxelObject.mesh = value;
			}
		}

		public virtual List<Material> materials
		{
			get
			{
				return this.voxelObject.materials;
			}
			set
			{
				this.voxelObject.materials = value;
			}
		}

		public virtual Texture2D atlasTexture
		{
			get
			{
				return this.voxelObject.atlasTexture;
			}
			set
			{
				this.voxelObject.atlasTexture = value;
			}
		}

		public override string GetDefaultPath()
		{
			return base.GetDefaultPath();
		}

		protected override bool CreateMesh()
		{
			Action<string> action = delegate(string info)
			{
			};
			action("");
			if (base.voxelBase.materialData == null)
			{
				base.voxelBase.materialData = new List<MaterialData>();
			}
			if (base.voxelBase.materialData.Count == 0)
			{
				base.voxelBase.materialData.Add(null);
			}
			for (int i = 0; i < base.voxelBase.materialData.Count; i++)
			{
				if (base.voxelBase.materialData[i] == null)
				{
					base.voxelBase.materialData[i] = new MaterialData();
				}
			}
			if (this.materials == null)
			{
				this.materials = new List<Material>();
			}
			if (this.materials.Count < base.voxelBase.materialData.Count)
			{
				for (int j = this.materials.Count; j < base.voxelBase.materialData.Count; j++)
				{
					this.materials.Add(null);
				}
			}
			else if (this.materials.Count > base.voxelBase.materialData.Count)
			{
				this.materials.RemoveRange(base.voxelBase.materialData.Count, this.materials.Count - base.voxelBase.materialData.Count);
			}
			for (int k = 0; k < base.voxelBase.materialData.Count; k++)
			{
				List<IntVector3> removeList = new List<IntVector3>();
				base.voxelBase.materialData[k].AllAction(delegate(IntVector3 pos)
				{
					if (this.voxelBase.voxelData.VoxelTableContains(pos) < 0)
					{
						removeList.Add(pos);
					}
				});
				for (int l = 0; l < removeList.Count; l++)
				{
					base.voxelBase.materialData[k].RemoveMaterial(removeList[l]);
				}
			}
			base.CalcDataCreate(base.voxelBase.voxelData.voxels);
			this.faceAreaTable = base.CreateFaceArea(base.voxelBase.voxelData.voxels);
			action("");
			Texture2D atlasTexture = this.atlasTexture;
			if (!base.CreateTexture(this.faceAreaTable, base.voxelBase.voxelData.palettes, ref this.atlasRectTable, ref atlasTexture, ref this.atlasRects))
			{
				return false;
			}
			this.atlasTexture = atlasTexture;
			for (int m = 0; m < this.materials.Count; m++)
			{
				if (this.materials[m] == null)
				{
					this.materials[m] = new Material(Shader.Find("Standard"));
				}
				this.materials[m].mainTexture = this.atlasTexture;
			}
			action("");
			Mesh result = (this.mesh != null) ? this.mesh : null;
			this.mesh = base.CreateMeshOnly(result, this.faceAreaTable, this.atlasTexture, this.atlasRects, this.atlasRectTable, Vector3.zero, out base.voxelBase.materialIndexes);
			action("");
			if (base.voxelBase.generateLightmapUVs)
			{
				int num = this.mesh.uv.Length;
			}
			action("");
			this.SetRendererCompornent();
			this.CreateMeshAfterFree();
			base.RefreshCheckerSave();
			return true;
		}

		protected override void CreateMeshAfterFree()
		{
			base.CreateMeshAfterFree();
			this.atlasRects = null;
			this.atlasRectTable = null;
			this.faceAreaTable = null;
			GC.Collect();
		}

		public override void SetRendererCompornent()
		{
			base.voxelBase.GetComponent<MeshFilter>().sharedMesh = this.mesh;
			if (this.materials != null)
			{
				for (int i = 0; i < this.materials.Count; i++)
				{
					if (this.materials[i] != null)
					{
						this.materials[i].mainTexture = this.atlasTexture;
					}
				}
			}
			Renderer component = base.voxelBase.GetComponent<Renderer>();
			if (this.materials != null)
			{
				Material[] array = new Material[base.voxelBase.materialIndexes.Count];
				for (int j = 0; j < base.voxelBase.materialIndexes.Count; j++)
				{
					array[j] = this.materials[base.voxelBase.materialIndexes[j]];
				}
				component.sharedMaterials = array;
				return;
			}
			component.sharedMaterial = null;
		}

		public override Mesh[] Edit_CreateMesh(List<VoxelData.Voxel> voxels, List<MyVoxelBaseCore.Edit_VerticesInfo> dstList = null, bool combine = true)
		{
			return new Mesh[]
			{
				base.Edit_CreateMeshOnly(voxels, this.atlasRects, dstList, combine)
			};
		}

		protected Rect[] atlasRects;

		protected MyVoxelBaseCore.AtlasRectTable atlasRectTable;

		protected VoxelData.FaceAreaTable faceAreaTable;
	}
}
