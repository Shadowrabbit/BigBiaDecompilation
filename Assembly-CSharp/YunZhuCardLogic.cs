using System;
using System.Collections;
using System.Collections.Generic;

public class YunZhuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_173");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_173"), base.Layers * this.value);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_173");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_173"), base.Layers * this.value);
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		new List<CardData>();
		if (this.CardData.HasTag(TagMap.随从) && playerBattleArea.Contains(this.CardData.CurrentCardSlotData))
		{
			for (int i = -6; i <= 6; i += 3)
			{
				if (playerBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + i >= 0 && playerBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + i < playerBattleArea.Count && playerBattleArea[playerBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + i] != null && playerBattleArea[playerBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + i].ChildCardData != null)
				{
					DungeonOperationMgr.Instance.StartCoroutine(base.Cure(this.CardData, base.Layers * this.value, playerBattleArea[playerBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + i].ChildCardData));
				}
			}
		}
		yield break;
	}

	private int value = 2;
}
