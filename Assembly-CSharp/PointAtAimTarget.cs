using System;
using UnityEngine;

public class PointAtAimTarget : MonoBehaviour
{
	private void Update()
	{
		if (this.AimTarget == null)
		{
			return;
		}
		Vector3 forward = this.AimTarget.position - base.transform.position;
		if (forward.sqrMagnitude > 0.01f)
		{
			base.transform.rotation = Quaternion.LookRotation(forward);
		}
	}

	[Tooltip("This object represents the aim target.  We always point toeards this")]
	public Transform AimTarget;
}
