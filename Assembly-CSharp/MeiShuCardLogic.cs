using System;
using System.Collections;
using System.Collections.Generic;

public class MeiShuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_换皮");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_换皮");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_换皮");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_换皮");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
			if (allEmptySlotsInMyBattleArea.Count == 0)
			{
				yield break;
			}
			CardData cardData = new CardData();
			switch (SYNCRandom.Range(0, 2))
			{
			case 0:
				cardData = Card.InitCardDataByID("黯月魔鹿");
				break;
			case 1:
				cardData = Card.InitCardDataByID("炽翼鬼蝠");
				break;
			case 2:
				cardData = Card.InitCardDataByID("烈阳神鸟");
				break;
			}
			if (GameData.CurrentGameType == GameData.GameType.Endless)
			{
				DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.step);
			}
			else
			{
				DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.level * 5);
			}
			cardData.PutInSlotData(allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)], true);
			cardData.DizzyLayer = 1;
		}
		yield break;
	}
}
