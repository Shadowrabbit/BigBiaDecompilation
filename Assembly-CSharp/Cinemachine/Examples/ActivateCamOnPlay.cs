using System;
using UnityEngine;

namespace Cinemachine.Examples
{
	[AddComponentMenu("")]
	public class ActivateCamOnPlay : MonoBehaviour
	{
		private void Start()
		{
			if (this.vcam)
			{
				this.vcam.MoveToTopOfPrioritySubqueue();
			}
		}

		public CinemachineVirtualCameraBase vcam;
	}
}
