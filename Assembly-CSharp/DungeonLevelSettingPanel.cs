using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DungeonLevelSettingPanel : MonoBehaviour
{
	private void Start()
	{
		this.DungeonThemeData = GlobalController.Instance.GlobalData.DungeonThemeLockData[this.DungeonTheme];
		this.CurLevel = this.DungeonThemeData.CurrentLevel;
		this.LevelText.text = (this.CurLevel.ToString() ?? "");
		this.NextBtn.onClick.AddListener(new UnityAction(this.OnNexrBtn));
		this.PrevBtn.onClick.AddListener(new UnityAction(this.OnPrevBtn));
	}

	public void OnNexrBtn()
	{
		if (this.CurLevel < this.DungeonThemeData.UnlockLevel)
		{
			this.CurLevel++;
			this.DungeonThemeData.CurrentLevel = this.CurLevel;
			this.LevelText.text = (this.CurLevel.ToString() ?? "");
		}
	}

	public void OnPrevBtn()
	{
		if (this.CurLevel > 1)
		{
			this.CurLevel--;
			this.DungeonThemeData.CurrentLevel = this.CurLevel;
			this.LevelText.text = (this.CurLevel.ToString() ?? "");
		}
	}

	private void Update()
	{
	}

	public DungeonTheme DungeonTheme;

	public DungeonThemeData DungeonThemeData;

	public int CurLevel;

	public Button PrevBtn;

	public Button NextBtn;

	public TextMeshProUGUI LevelText;
}
