using System;
using UnityEngine;

namespace VoxelImporter
{
	public class CameraController : MonoBehaviour
	{
		public Transform transformCache { get; protected set; }

		private void Awake()
		{
			this.transformCache = base.transform;
			this.defaultPosition = this.transformCache.position - this.transformLookAt.position;
		}

		private void Update()
		{
			Vector3 vector = this.transformLookAt.position + this.defaultPosition;
			this.transformCache.position = new Vector3(vector.x, this.transformCache.position.y, vector.z);
		}

		public Transform transformLookAt;

		protected Vector3 defaultPosition;
	}
}
