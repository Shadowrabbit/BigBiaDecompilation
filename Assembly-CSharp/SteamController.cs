using System;
using UnityEngine;

public class SteamController : MonoBehaviour
{
	private void Awake()
	{
		SteamController.Instance = this;
		QualitySettings.SetQualityLevel(4, true);
	}

	public void Init()
	{
		this.SteamAchievementsController.InitSteamAchievementStatus();
	}

	public void End()
	{
	}

	public static SteamController Instance;

	public MySteamUGC SteamUGC;

	public OpenDialogFile1 OpenDialogFile;

	public SteamEvent SteamEvent = new SteamEvent();

	public SteamAchievementsController SteamAchievementsController;
}
