using System;
using UnityEngine;

namespace Cinemachine.Examples
{
	[AddComponentMenu("")]
	public class MixingCameraBlend : MonoBehaviour
	{
		private void Start()
		{
			if (this.followTarget)
			{
				this.vcam = base.GetComponent<CinemachineMixingCamera>();
				this.vcam.m_Weight0 = this.initialBottomWeight;
			}
		}

		private void Update()
		{
			if (this.followTarget)
			{
				switch (this.axisToTrack)
				{
				case MixingCameraBlend.AxisEnum.X:
					this.vcam.m_Weight1 = Mathf.Abs(this.followTarget.transform.position.x);
					return;
				case MixingCameraBlend.AxisEnum.Z:
					this.vcam.m_Weight1 = Mathf.Abs(this.followTarget.transform.position.z);
					return;
				case MixingCameraBlend.AxisEnum.XZ:
					this.vcam.m_Weight1 = Mathf.Abs(Mathf.Abs(this.followTarget.transform.position.x) + Mathf.Abs(this.followTarget.transform.position.z));
					break;
				default:
					return;
				}
			}
		}

		public Transform followTarget;

		public float initialBottomWeight = 20f;

		public MixingCameraBlend.AxisEnum axisToTrack;

		private CinemachineMixingCamera vcam;

		public enum AxisEnum
		{
			X,
			Z,
			XZ
		}
	}
}
