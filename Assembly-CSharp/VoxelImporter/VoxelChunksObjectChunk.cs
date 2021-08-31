using System;
using UnityEngine;

namespace VoxelImporter
{
	[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
	public class VoxelChunksObjectChunk : MonoBehaviour
	{
		private void Awake()
		{
			UnityEngine.Object.Destroy(this);
		}
	}
}
