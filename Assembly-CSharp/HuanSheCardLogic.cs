using System;
using System.Collections;
using System.Collections.Generic;

public class HuanSheCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇5");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇5");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇5");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇5");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		base.ShowMe();
		for (int i = 0; i < 2; i++)
		{
			List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
			if (allEmptySlotsInMyBattleArea != null && allEmptySlotsInMyBattleArea.Count > 0)
			{
				CardSlotData slotData = allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)];
				CardData cardData = Card.InitCardDataByID("蛇");
				if (GameData.CurrentGameType == GameData.GameType.Endless)
				{
					DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.step);
				}
				else
				{
					DungeonOperationMgr.Instance.InitDungeonMonster(cardData, GameController.ins.GameData.level * 5);
				}
				cardData.PutInSlotData(slotData, true);
			}
		}
		yield break;
	}
}
