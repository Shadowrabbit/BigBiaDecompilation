using System;
using System.Collections;
using System.Collections.Generic;

public class RongYanFaShiCardLogic : VolcanoLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_熔岩召唤");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_熔岩召唤");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_熔岩召唤");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_熔岩召唤");
	}

	public override IEnumerator BeFireBallAttacked()
	{
		base.BeFireBallAttacked();
		base.ShowMe();
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea.Count == 0)
		{
			yield break;
		}
		CardData cardData = Card.InitCardDataByID("火骷髅");
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.step);
		}
		else
		{
			DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.level * 5);
		}
		cardData.PutInSlotData(allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)], true);
		yield break;
	}
}
