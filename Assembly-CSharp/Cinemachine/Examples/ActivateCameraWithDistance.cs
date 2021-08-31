using System;
using UnityEngine;

namespace Cinemachine.Examples
{
	[AddComponentMenu("")]
	public class ActivateCameraWithDistance : MonoBehaviour
	{
		private void Start()
		{
			this.brain = Camera.main.GetComponent<CinemachineBrain>();
			this.SwitchCam(this.initialActiveCam);
		}

		private void Update()
		{
			if (this.objectToCheck && this.switchCameraTo)
			{
				if (Vector3.Distance(base.transform.position, this.objectToCheck.transform.position) < this.distanceToObject)
				{
					this.SwitchCam(this.switchCameraTo);
					return;
				}
				this.SwitchCam(this.initialActiveCam);
			}
		}

		public void SwitchCam(CinemachineVirtualCameraBase vcam)
		{
			if (this.brain == null || vcam == null)
			{
				return;
			}
			if (this.brain.ActiveVirtualCamera != vcam)
			{
				vcam.MoveToTopOfPrioritySubqueue();
			}
		}

		public GameObject objectToCheck;

		public float distanceToObject = 15f;

		public CinemachineVirtualCameraBase initialActiveCam;

		public CinemachineVirtualCameraBase switchCameraTo;

		private CinemachineBrain brain;
	}
}
