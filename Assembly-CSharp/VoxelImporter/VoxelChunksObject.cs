using System;
using UnityEngine;

namespace VoxelImporter
{
	[AddComponentMenu("Voxel Importer/Voxel Chunks Object")]
	public class VoxelChunksObject : VoxelBase
	{
		private void Awake()
		{
			UnityEngine.Object.Destroy(this);
		}
	}
}
