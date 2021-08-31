using System;
using System.Collections;
using System.Collections.Generic;

public class ChengXuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_写外挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_写外挂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_写外挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_写外挂");
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
			switch (SYNCRandom.Range(0, 3))
			{
			case 0:
				cardData = Card.InitCardDataByID("锁头挂");
				break;
			case 1:
				cardData = Card.InitCardDataByID("锁血挂");
				break;
			case 2:
				cardData = Card.InitCardDataByID("加攻挂");
				break;
			}
			cardData.PutInSlotData(allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)], true);
		}
		yield break;
	}
}
