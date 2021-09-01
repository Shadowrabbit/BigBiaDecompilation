using System;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private void Reset()
	{
		this.Speed = 5f;
		this.InputForward = PlayerMove.ForwardMode.Camera;
		this.RotatePlayer = true;
		this.VelocityDamping = 0.5f;
		this.m_currentVleocity = Vector3.zero;
		this.JumpTime = 1f;
		this.m_currentJumpSpeed = 0f;
	}

	private void OnEnable()
	{
		this.m_currentJumpSpeed = 0f;
		this.m_restY = base.transform.position.y;
		this.SpaceAction = (Action)Delegate.Remove(this.SpaceAction, new Action(this.Jump));
		this.SpaceAction = (Action)Delegate.Combine(this.SpaceAction, new Action(this.Jump));
	}

	private void Update()
	{
		Vector3 vector;
		switch (this.InputForward)
		{
		case PlayerMove.ForwardMode.Camera:
			vector = Camera.main.transform.forward;
			goto IL_43;
		case PlayerMove.ForwardMode.Player:
			vector = base.transform.forward;
			goto IL_43;
		}
		vector = Vector3.forward;
		IL_43:
		vector.y = 0f;
		vector = vector.normalized;
		if (vector.sqrMagnitude < 0.01f)
		{
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(vector, Vector3.up);
		Vector3 vector2 = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		vector2 = rotation * vector2;
		float deltaTime = Time.deltaTime;
		Vector3 initial = vector2 * this.Speed - this.m_currentVleocity;
		this.m_currentVleocity += Damper.Damp(initial, this.VelocityDamping, deltaTime);
		base.transform.position += this.m_currentVleocity * deltaTime;
		if (this.RotatePlayer && this.m_currentVleocity.sqrMagnitude > 0.01f)
		{
			Quaternion rotation2 = base.transform.rotation;
			Quaternion b = Quaternion.LookRotation((this.InputForward == PlayerMove.ForwardMode.Player && Vector3.Dot(vector, this.m_currentVleocity) < 0f) ? (-this.m_currentVleocity) : this.m_currentVleocity);
			base.transform.rotation = Quaternion.Slerp(rotation2, b, Damper.Damp(1f, this.VelocityDamping, deltaTime));
		}
		if (this.m_currentJumpSpeed != 0f)
		{
			this.m_currentJumpSpeed -= 10f * deltaTime;
		}
		Vector3 position = base.transform.position;
		position.y += this.m_currentJumpSpeed * deltaTime;
		if (position.y < this.m_restY)
		{
			position.y = this.m_restY;
			this.m_currentJumpSpeed = 0f;
		}
		base.transform.position = position;
		if (Input.GetKeyDown(KeyCode.Space) && this.SpaceAction != null)
		{
			this.SpaceAction();
		}
		if (Input.GetKeyDown(KeyCode.Return) && this.EnterAction != null)
		{
			this.EnterAction();
		}
	}

	public void Jump()
	{
		this.m_currentJumpSpeed += 10f * this.JumpTime * 0.5f;
	}

	public float Speed;

	public float VelocityDamping;

	public float JumpTime;

	public PlayerMove.ForwardMode InputForward;

	public bool RotatePlayer = true;

	public Action SpaceAction;

	public Action EnterAction;

	private Vector3 m_currentVleocity;

	private float m_currentJumpSpeed;

	private float m_restY;

	public enum ForwardMode
	{
		Camera,
		Player,
		World
	}
}
