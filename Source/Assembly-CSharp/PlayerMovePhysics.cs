using System;
using UnityEngine;

public class PlayerMovePhysics : MonoBehaviour
{
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		base.transform.position += new Vector3(10f, 0f, 0f);
	}

	private void FixedUpdate()
	{
		Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		if (vector.magnitude > 0f)
		{
			Vector3 forward = this.worldDirection ? Vector3.forward : (base.transform.position - Camera.main.transform.position);
			forward.y = 0f;
			forward = forward.normalized;
			if (forward.magnitude > 0.001f)
			{
				vector = Quaternion.LookRotation(forward, Vector3.up) * vector;
				if (vector.magnitude > 0.001f)
				{
					this.rb.AddForce(this.speed * vector);
					if (this.rotatePlayer)
					{
						base.transform.rotation = Quaternion.LookRotation(vector.normalized, Vector3.up);
					}
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) && this.spaceAction != null)
		{
			this.spaceAction();
		}
		if (Input.GetKeyDown(KeyCode.Return) && this.enterAction != null)
		{
			this.enterAction();
		}
	}

	public float speed = 5f;

	public bool worldDirection = true;

	public bool rotatePlayer = true;

	public Action spaceAction;

	public Action enterAction;

	private Rigidbody rb;
}
