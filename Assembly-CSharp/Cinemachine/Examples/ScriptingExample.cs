using System;
using UnityEngine;

namespace Cinemachine.Examples
{
	public class ScriptingExample : MonoBehaviour
	{
		private void Start()
		{
			CinemachineBrain cinemachineBrain = GameObject.Find("Main Camera").AddComponent<CinemachineBrain>();
			cinemachineBrain.m_ShowDebugText = true;
			cinemachineBrain.m_DefaultBlend.m_Time = 1f;
			this.vcam = new GameObject("VirtualCamera").AddComponent<CinemachineVirtualCamera>();
			this.vcam.m_LookAt = GameObject.Find("Cube").transform;
			this.vcam.m_Priority = 10;
			this.vcam.gameObject.transform.position = new Vector3(0f, 1f, 0f);
			CinemachineComposer cinemachineComposer = this.vcam.AddCinemachineComponent<CinemachineComposer>();
			cinemachineComposer.m_ScreenX = 0.3f;
			cinemachineComposer.m_ScreenY = 0.35f;
			this.freelook = new GameObject("FreeLook").AddComponent<CinemachineFreeLook>();
			this.freelook.m_LookAt = GameObject.Find("Cylinder/Sphere").transform;
			this.freelook.m_Follow = GameObject.Find("Cylinder").transform;
			this.freelook.m_Priority = 11;
			CinemachineVirtualCamera rig = this.freelook.GetRig(0);
			CinemachineVirtualCamera rig2 = this.freelook.GetRig(1);
			CinemachineVirtualCamera rig3 = this.freelook.GetRig(2);
			rig.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = 0.35f;
			rig2.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = 0.25f;
			rig3.GetCinemachineComponent<CinemachineComposer>().m_ScreenY = 0.15f;
		}

		private void Update()
		{
			if (Time.realtimeSinceStartup - this.lastSwapTime > 5f)
			{
				this.freelook.enabled = !this.freelook.enabled;
				this.lastSwapTime = Time.realtimeSinceStartup;
			}
		}

		private CinemachineVirtualCamera vcam;

		private CinemachineFreeLook freelook;

		private float lastSwapTime;
	}
}
