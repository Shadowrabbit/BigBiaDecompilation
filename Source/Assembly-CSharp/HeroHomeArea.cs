using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroHomeArea : MonoBehaviour
{
	private void Start()
	{
		this.AllUnlockedPanel = new List<GameObject>();
		this.m_CurHeroModID = GameController.ins.HeroHomeCurrentHeroModID;
		Dictionary<string, List<int>> herosLevel = GlobalController.Instance.GlobalData.HerosLevel;
		if (herosLevel.ContainsKey(this.m_CurHeroModID))
		{
			for (int i = 0; i < herosLevel[this.m_CurHeroModID].Count; i++)
			{
				this.ShowContents[herosLevel[this.m_CurHeroModID][i]].transform.localScale = Vector3.zero;
				this.ShowContents[herosLevel[this.m_CurHeroModID][i]].ShowContent.transform.localScale = Vector3.one;
			}
			this.CheckAchievement();
		}
	}

	private void CheckAchievement()
	{
		using (List<HeroHomeLevelUpTipBox>.Enumerator enumerator = this.ShowContents.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.transform.localScale == Vector3.one)
				{
					return;
				}
			}
		}
		SteamController.Instance.SteamAchievementsController.UnlockAchievement(AchievementType.NEW_ACHIEVEMENT_zhuangxiudashi);
	}

	public void AddHeroLevel(int index)
	{
		Dictionary<string, List<int>> herosLevel = GlobalController.Instance.GlobalData.HerosLevel;
		GlobalController.Instance.SetHerosLevel(this.m_CurHeroModID, index);
		if (herosLevel.ContainsKey(this.m_CurHeroModID))
		{
			for (int i = 0; i < herosLevel[this.m_CurHeroModID].Count; i++)
			{
				this.ShowContents[herosLevel[this.m_CurHeroModID][i]].transform.localScale = Vector3.zero;
				this.ShowContents[herosLevel[this.m_CurHeroModID][i]].ShowContent.transform.localScale = Vector3.one;
			}
			this.CheckAchievement();
		}
	}

	public void CheckHaveUnlockedPanel()
	{
		if (this.AllUnlockedPanel.Count > 0)
		{
			for (int i = this.AllUnlockedPanel.Count - 1; i >= 0; i--)
			{
				UnityEngine.Object.Destroy(this.AllUnlockedPanel[i]);
			}
			this.AllUnlockedPanel = new List<GameObject>();
		}
	}

	public List<HeroHomeLevelUpTipBox> ShowContents;

	public Transform Canvas;

	private string m_CurHeroModID;

	[NonSerialized]
	public List<GameObject> AllUnlockedPanel;
}
