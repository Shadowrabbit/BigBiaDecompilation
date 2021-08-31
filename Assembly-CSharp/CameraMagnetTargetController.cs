using System;
using Cinemachine;
using UnityEngine;

public class CameraMagnetTargetController : MonoBehaviour
{
	private void Start()
	{
		this.cameraMagnets = base.GetComponentsInChildren<CameraMagnetProperty>();
		this.playerIndex = 0;
	}

	private void Update()
	{
		for (int i = 1; i < this.targetGroup.m_Targets.Length; i++)
		{
			float magnitude = (this.targetGroup.m_Targets[this.playerIndex].target.position - this.targetGroup.m_Targets[i].target.position).magnitude;
			if (magnitude < this.cameraMagnets[i - 1].Proximity)
			{
				this.targetGroup.m_Targets[i].weight = this.cameraMagnets[i - 1].MagnetStrength * (1f - magnitude / this.cameraMagnets[i - 1].Proximity);
			}
			else
			{
				this.targetGroup.m_Targets[i].weight = 0f;
			}
		}
	}

	public CinemachineTargetGroup targetGroup;

	private int playerIndex;

	private CameraMagnetProperty[] cameraMagnets;
}
