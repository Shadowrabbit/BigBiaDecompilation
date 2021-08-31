using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
	private void Start()
	{
		this.animator = base.GetComponent<Animator>();
	}

	private void OnAnimatorIK()
	{
		if (this.animator)
		{
			if (this.ikActive)
			{
				if (this.lookObj != null)
				{
					this.animator.SetLookAtWeight(1f);
					this.animator.SetLookAtPosition(this.lookObj.position);
				}
				if (this.leftHandObj != null)
				{
					this.animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
					this.animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
					this.animator.SetIKPosition(AvatarIKGoal.LeftHand, this.leftHandObj.position);
					this.animator.SetIKRotation(AvatarIKGoal.LeftHand, this.leftHandObj.rotation);
				}
				if (this.rightHandObj != null)
				{
					this.animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
					this.animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
					this.animator.SetIKPosition(AvatarIKGoal.RightHand, this.rightHandObj.position);
					this.animator.SetIKRotation(AvatarIKGoal.RightHand, this.rightHandObj.rotation);
				}
				if (this.leftFootObj != null)
				{
					this.animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
					this.animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1f);
					this.animator.SetIKPosition(AvatarIKGoal.LeftFoot, this.leftFootObj.position);
					this.animator.SetIKRotation(AvatarIKGoal.LeftFoot, this.leftFootObj.rotation);
				}
				if (this.rightFootObj != null)
				{
					this.animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
					this.animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1f);
					this.animator.SetIKPosition(AvatarIKGoal.RightFoot, this.rightFootObj.position);
					this.animator.SetIKRotation(AvatarIKGoal.RightFoot, this.rightFootObj.rotation);
					return;
				}
			}
			else
			{
				this.animator.SetLookAtWeight(0f);
				this.animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
				this.animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
				this.animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
				this.animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
				this.animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
				this.animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0f);
				this.animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
				this.animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0f);
			}
		}
	}

	protected Animator animator;

	public bool ikActive;

	public Transform leftHandObj;

	public Transform rightHandObj;

	public Transform leftFootObj;

	public Transform rightFootObj;

	public Transform lookObj;
}
