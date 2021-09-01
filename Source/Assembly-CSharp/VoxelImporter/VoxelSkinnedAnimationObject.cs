using System;
using UnityEngine;

namespace VoxelImporter
{
	[AddComponentMenu("Voxel Importer/Voxel Skinned Animation Object"), RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(SkinnedMeshRenderer))]
	public class VoxelSkinnedAnimationObject : VoxelBase
	{
		private void Awake()
		{
			UnityEngine.Object.Destroy(this);
		}
	}
}
