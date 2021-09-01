using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelImporter
{
	[AddComponentMenu("Voxel Importer/Voxel Object"), RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
	public class VoxelObject : VoxelBase
	{
		public override bool EditorInitialize()
		{
			bool result = base.EditorInitialize();
			if (this.material != null)
			{
				this.materials = new List<Material>();
				this.materials.Add(this.material);
				this.materialData = new List<MaterialData>();
				this.materialData.Add(new MaterialData());
				this.materialIndexes = new List<int>();
				this.materialIndexes.Add(0);
				this.material = null;
				result = true;
			}
			return result;
		}

		private void Update()
		{
			Input.GetKeyDown(KeyCode.Space);
		}

		public Mesh mesh;

		[SerializeField]
		protected Material material;

		public List<Material> materials;

		public Texture2D atlasTexture;
	}
}
