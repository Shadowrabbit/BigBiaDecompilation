using System;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
	private void Update()
	{
		float yAngle = Input.GetAxis("Mouse X") * this.speed;
		float num = Input.GetAxis("Mouse Y") * this.speed;
		base.transform.Rotate(0f, yAngle, 0f, Space.World);
		base.transform.Rotate(-num, 0f, 0f, Space.Self);
	}

	public float speed = 5f;
}
