using System;
using UnityEngine;

public class CharacterMovementNoCamera : MonoBehaviour
{
	private void OnEnable()
	{
		this.anim = base.GetComponent<Animator>();
		this.currentVelocity = Vector2.zero;
		this.currentStrafeSpeed = 0f;
		this.isSprinting = false;
	}

	private void FixedUpdate()
	{
		Vector2 vector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		float num = vector.y;
		num = Mathf.Clamp(num, -1f, 1f);
		num = Mathf.SmoothDamp(this.anim.GetFloat("Speed"), num, ref this.currentVelocity.y, this.Damping);
		this.anim.SetFloat("Speed", num);
		this.anim.SetFloat("Direction", num);
		this.isSprinting = ((Input.GetKey(this.sprintJoystick) || Input.GetKey(this.sprintKeyboard)) && num > 0f);
		this.anim.SetBool("isSprinting", this.isSprinting);
		this.currentStrafeSpeed = Mathf.SmoothDamp(this.currentStrafeSpeed, vector.x * this.StrafeSpeed, ref this.currentVelocity.x, this.Damping);
		base.transform.position += base.transform.TransformDirection(Vector3.right) * this.currentStrafeSpeed;
		Vector2 vector2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.y += vector2.x * this.TurnSpeed;
		base.transform.rotation = Quaternion.Euler(eulerAngles);
		if (this.InvisibleCameraOrigin != null)
		{
			eulerAngles = this.InvisibleCameraOrigin.localRotation.eulerAngles;
			eulerAngles.x -= vector2.y * this.TurnSpeed;
			if (eulerAngles.x > 180f)
			{
				eulerAngles.x -= 360f;
			}
			eulerAngles.x = Mathf.Clamp(eulerAngles.x, this.VerticalRotMin, this.VerticalRotMax);
			this.InvisibleCameraOrigin.localRotation = Quaternion.Euler(eulerAngles);
		}
	}

	public Transform InvisibleCameraOrigin;

	public float StrafeSpeed = 0.1f;

	public float TurnSpeed = 3f;

	public float Damping = 0.2f;

	public float VerticalRotMin = -80f;

	public float VerticalRotMax = 80f;

	public KeyCode sprintJoystick = KeyCode.JoystickButton2;

	public KeyCode sprintKeyboard = KeyCode.Space;

	private bool isSprinting;

	private Animator anim;

	private float currentStrafeSpeed;

	private Vector2 currentVelocity;
}
