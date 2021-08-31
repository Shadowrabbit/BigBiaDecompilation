using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKey("w"))
		{
			base.transform.position += base.transform.TransformDirection(Vector3.forward) * Time.deltaTime * this.movementSpeed;
		}
		else if (Input.GetKey("s"))
		{
			base.transform.position -= base.transform.TransformDirection(Vector3.forward) * Time.deltaTime * this.movementSpeed;
		}
		if (Input.GetKey("a") && !Input.GetKey("d"))
		{
			base.transform.position += base.transform.TransformDirection(Vector3.left) * Time.deltaTime * this.movementSpeed;
		}
		else if (Input.GetKey("d") && !Input.GetKey("a"))
		{
			base.transform.position -= base.transform.TransformDirection(Vector3.left) * Time.deltaTime * this.movementSpeed;
		}
		float yAngle = Input.GetAxis("Mouse X") * this.lookatspeed;
		Input.GetAxis("Mouse Y");
		float num = this.lookatspeed;
		base.transform.Rotate(0f, yAngle, 0f, Space.World);
	}

	public float movementSpeed = 10f;

	public float lookatspeed = 5f;
}
