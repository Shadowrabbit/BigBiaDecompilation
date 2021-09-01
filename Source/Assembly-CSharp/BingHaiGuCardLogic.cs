using System;
using System.Collections;
using System.Collections.Generic;

public class BingHaiGuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_来块冰");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_来块冰");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_来块冰");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_来块冰");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn || this.used)
		{
			yield break;
		}
		base.ShowMe();
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea.Count == 0)
		{
			yield break;
		}
		CardData cardData = Card.InitCardDataByID("冰立方");
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
		this.used = true;
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.used = false;
		yield break;
	}

	public bool used;
}
