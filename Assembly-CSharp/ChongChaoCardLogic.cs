using System;
using System.Collections;
using System.Collections.Generic;

public class ChongChaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_虫巢");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_虫巢");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_虫巢");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_虫巢");
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
			switch (SYNCRandom.Range(0, 4))
			{
			case 0:
				cardData = Card.InitCardDataByID("虫母");
				break;
			case 1:
				cardData = Card.InitCardDataByID("工兵虫");
				break;
			case 2:
				cardData = Card.InitCardDataByID("哨兵虫");
				break;
			case 3:
				cardData = Card.InitCardDataByID("幼虫");
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
			cardData.Price = 0;
			base.ShowMe();
			cardData.PutInSlotData(allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)], true);
		}
		yield break;
	}
}
