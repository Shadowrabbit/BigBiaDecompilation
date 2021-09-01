using System;
using UnityEngine;

namespace VoxelImporter
{
	public class RigidbodyDisable : MonoBehaviour
	{
		private void Awake()
		{
			Action<Rigidbody> action = delegate(Rigidbody rb)
			{
				rb.isKinematic = true;
				if (this.massSet)
				{
					MeshFilter component2 = rb.GetComponent<MeshFilter>();
					if (component2 != null && component2.mesh)
					{
						float num = component2.mesh.bounds.size.x * component2.mesh.bounds.size.y * component2.mesh.bounds.size.z;
						rb.mass = num * this.massRate;
					}
				}
			};
			Rigidbody component = base.GetComponent<Rigidbody>();
			if (component != null)
			{
				action(component);
			}
			Rigidbody[] componentsInChildren = base.GetComponentsInChildren<Rigidbody>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				action(componentsInChildren[i]);
			}
			UnityEngine.Object.Destroy(this);
		}

		public bool massSet = true;

		public float massRate = 0.1f;
	}
}
