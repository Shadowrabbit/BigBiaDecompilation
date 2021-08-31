using System;
using System.Collections;
using System.Collections.Generic;

public class MaXiTuanZhangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_103");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_103");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_103");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_103");
	}

	public override IEnumerator OnTurnStart()
	{
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea.Count == 0)
		{
			yield break;
		}
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS) && cardData.Attrs.ContainsKey("Theme") && this.CardData.Attrs.ContainsKey("Theme") && cardData.Attrs["Theme"] == this.CardData.Attrs["Theme"] && cardData.ModID != this.CardData.ModID)
			{
				list.Add(cardData);
			}
		}
		if (list.Count > 0)
		{
			yield break;
		}
		ItemData itemData = list[SYNCRandom.Range(0, list.Count)];
		base.ShowMe();
		Card.InitCardDataByID(itemData.ModID).PutInSlotData(allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)], true);
		yield break;
	}

	private int m_ATKGain;
}
