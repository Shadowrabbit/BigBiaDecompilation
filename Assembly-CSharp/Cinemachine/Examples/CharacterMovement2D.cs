using System;
using UnityEngine;

namespace Cinemachine.Examples
{
	[AddComponentMenu("")]
	public class CharacterMovement2D : MonoBehaviour
	{
		private void Start()
		{
			this.anim = base.GetComponent<Animator>();
			this.rigbody = base.GetComponent<Rigidbody>();
			this.targetrot = base.transform.rotation;
		}

		private void FixedUpdate()
		{
			this.input.x = Input.GetAxis("Horizontal");
			if ((this.input.x < 0f && !this.headingleft) || (this.input.x > 0f && this.headingleft))
			{
				if (this.input.x < 0f)
				{
					this.targetrot = Quaternion.Euler(0f, 270f, 0f);
				}
				if (this.input.x > 0f)
				{
					this.targetrot = Quaternion.Euler(0f, 90f, 0f);
				}
				this.headingleft = !this.headingleft;
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, this.targetrot, Time.deltaTime * 20f);
			this.speed = Mathf.Abs(this.input.x);
			this.speed = Mathf.SmoothDamp(this.anim.GetFloat("Speed"), this.speed, ref this.velocity, 0.1f);
			this.anim.SetFloat("Speed", this.speed);
			if ((Input.GetKeyDown(this.sprintJoystick) || Input.GetKeyDown(this.sprintKeyboard)) && this.input != Vector2.zero)
			{
				this.isSprinting = true;
			}
			if (Input.GetKeyUp(this.sprintJoystick) || Input.GetKeyUp(this.sprintKeyboard) || this.input == Vector2.zero)
			{
				this.isSprinting = false;
			}
			this.anim.SetBool("isSprinting", this.isSprinting);
			if ((Input.GetKeyDown(this.jumpJoystick) || Input.GetKeyDown(this.jumpKeyboard)) && this.isGrounded())
			{
				this.rigbody.velocity = new Vector3(this.input.x, this.jumpVelocity, 0f);
			}
		}

		public bool isGrounded()
		{
			return !this.checkGroundForJump || Physics.Raycast(base.transform.position, Vector3.down, this.groundTolerance);
		}

		public KeyCode sprintJoystick = KeyCode.JoystickButton2;

		public KeyCode jumpJoystick = KeyCode.JoystickButton0;

		public KeyCode sprintKeyboard = KeyCode.LeftShift;

		public KeyCode jumpKeyboard = KeyCode.Space;

		public float jumpVelocity = 7f;

		public float groundTolerance = 0.2f;

		public bool checkGroundForJump = true;

		private float speed;

		private bool isSprinting;

		private Animator anim;

		private Vector2 input;

		private float velocity;

		private bool headingleft;

		private Quaternion targetrot;

		private Rigidbody rigbody;
	}
}
