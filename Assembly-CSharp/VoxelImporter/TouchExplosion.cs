using System;
using UnityEngine;

namespace VoxelImporter
{
	public class TouchExplosion : MonoBehaviour
	{
		private void Update()
		{
			bool flag = false;
			Vector3 pos = Vector3.zero;
			if (Input.GetMouseButtonDown(0))
			{
				flag = true;
				pos = Input.mousePosition;
			}
			if (Input.touchCount > 0)
			{
				flag = true;
				pos = Input.GetTouch(0).position;
			}
			RaycastHit raycastHit;
			if (flag && Physics.Raycast(Camera.main.ScreenPointToRay(pos), out raycastHit, 1000f))
			{
				Collider[] array = Physics.OverlapSphere(raycastHit.point, this.radius);
				for (int i = 0; i < array.Length; i++)
				{
					Rigidbody component = array[i].GetComponent<Rigidbody>();
					if (!(component == null))
					{
						component.isKinematic = false;
						component.AddExplosionForce(this.power, raycastHit.point, this.radius);
					}
				}
			}
		}

		public float radius = 10f;

		public float power = 500f;
	}
}
