using System;
using System.Collections;
using System.Collections.Generic;

public class LangHaiZiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_孤狼");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_孤狼"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_孤狼");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_孤狼"), base.Layers);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		List<CardData> list = new List<CardData>();
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - 1];
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData2.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
		{
			CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + 1];
			if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData3.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
		{
			CardSlotData cardSlotData4 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
			if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData4.ChildCardData);
			}
		}
		if (list.Count > 0)
		{
			yield break;
		}
		base.ShowMe();
		yield return base.ShowXuLiEffect("居合释放", false);
		this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		List<CardData> list = new List<CardData>();
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - 1];
			if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData2.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
		{
			CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + 1];
			if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData3.ChildCardData);
			}
		}
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
		{
			CardSlotData cardSlotData4 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
			if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData4.ChildCardData);
			}
		}
		if (list.Count > 0)
		{
			yield break;
		}
		base.ShowMe();
		yield return base.ShowXuLiEffect("居合释放", false);
		this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
		yield break;
	}
}
