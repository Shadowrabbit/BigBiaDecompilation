using System;
using UnityEngine;

namespace VoxelImporter
{
	public class PlayerController : MonoBehaviour
	{
		public Transform transformCache { get; protected set; }

		public CharacterController characterControllerCache { get; protected set; }

		public Animator animatorCache { get; protected set; }

		public Vector3 velocity { get; protected set; }

		private void Awake()
		{
			this.transformCache = base.transform;
			this.characterControllerCache = base.GetComponent<CharacterController>();
			this.animatorCache = base.GetComponent<Animator>();
			this.isWalkingID = Animator.StringToHash("IsWalking");
		}

		private void FixedUpdate()
		{
			Vector3 a = Vector3.zero;
			a += Vector3.forward * Input.GetAxis("Vertical");
			a += Vector3.right * Input.GetAxis("Horizontal");
			Vector3 vector = new Vector3(0f, this.velocity.y, 0f) + this.addVelocity;
			this.addVelocity = Vector3.zero;
			vector += a * this.moveSpeed;
			this.characterControllerCache.Move(vector * Time.fixedDeltaTime);
			this.velocity = vector;
			if (a.normalized.sqrMagnitude > 0f)
			{
				this.transformCache.rotation = Quaternion.Lerp(this.transformCache.rotation, Quaternion.LookRotation(a.normalized), 0.3f);
			}
			this.animatorCache.SetBool(this.isWalkingID, a.sqrMagnitude > 0.01f);
		}

		public float moveSpeed = 24f;

		public float rotateSpeed = 90f;

		protected int isWalkingID;

		protected Vector3 addVelocity;

		protected GameObject weaponColliderClone;
	}
}
