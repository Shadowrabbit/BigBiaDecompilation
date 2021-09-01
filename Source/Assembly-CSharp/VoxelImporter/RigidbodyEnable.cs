using System;
using UnityEngine;

namespace VoxelImporter
{
	public class RigidbodyEnable : MonoBehaviour
	{
		private void Awake()
		{
			this.rb = base.GetComponent<Rigidbody>();
			if (this.rb == null)
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		private void OnCollisionEnter()
		{
			this.rb.isKinematic = false;
		}

		protected Rigidbody rb;
	}
}
