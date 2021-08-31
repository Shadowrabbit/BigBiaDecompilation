using System;
using UnityEngine;

public class EventJudgeBean
{
	public EventJudgeBean(string missionTitleOrReward, Vector3 missionContent)
	{
		this.MissionTitleOrReward = missionTitleOrReward;
		this.MissionContent = missionContent;
	}

	public string MissionTitleOrReward;

	public Vector3 MissionContent;
}
