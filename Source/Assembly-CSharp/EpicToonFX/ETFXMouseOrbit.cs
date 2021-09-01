using System;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXMouseOrbit : MonoBehaviour
	{
		private void Start()
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			this.rotationYAxis = eulerAngles.y;
			this.rotationXAxis = eulerAngles.x;
			if (base.GetComponent<Rigidbody>())
			{
				base.GetComponent<Rigidbody>().freezeRotation = true;
			}
		}

		private void LateUpdate()
		{
			if (this.target)
			{
				if (Input.GetMouseButton(1))
				{
					this.velocityX += this.xSpeed * Input.GetAxis("Mouse X") * this.distance * 0.02f;
					this.velocityY += this.ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
				}
				this.rotationYAxis += this.velocityX;
				this.rotationXAxis -= this.velocityY;
				this.rotationXAxis = ETFXMouseOrbit.ClampAngle(this.rotationXAxis, this.yMinLimit, this.yMaxLimit);
				Quaternion rotation = Quaternion.Euler(this.rotationXAxis, this.rotationYAxis, 0f);
				this.distance = Mathf.Clamp(this.distance - Input.GetAxis("Mouse ScrollWheel") * 5f, this.distanceMin, this.distanceMax);
				RaycastHit raycastHit;
				if (Physics.Linecast(this.target.position, base.transform.position, out raycastHit))
				{
					this.distance -= raycastHit.distance;
				}
				Vector3 point = new Vector3(0f, 0f, -this.distance);
				Vector3 position = rotation * point + this.target.position;
				base.transform.rotation = rotation;
				base.transform.position = position;
				this.velocityX = Mathf.Lerp(this.velocityX, 0f, Time.deltaTime * this.smoothTime);
				this.velocityY = Mathf.Lerp(this.velocityY, 0f, Time.deltaTime * this.smoothTime);
			}
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
			return Mathf.Clamp(angle, min, max);
		}

		public Transform target;

		public float distance = 5f;

		public float xSpeed = 120f;

		public float ySpeed = 120f;

		public float yMinLimit = -20f;

		public float yMaxLimit = 80f;

		public float distanceMin = 0.5f;

		public float distanceMax = 15f;

		public float smoothTime = 2f;

		private float rotationYAxis;

		private float rotationXAxis;

		private float velocityX;

		private float velocityY;
	}
}
