using System;
using System.Collections.Generic;

public class WoLaiZuoGeFanYiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "我来做个翻译";
		this.Desc = "每使用一个食物，都会随机返回一个低一级的食物。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "我来做个翻译";
		this.Desc = "每使用一个食物，都会随机返回一个低一级的食物。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (mergeBy.Rare > 1)
		{
			base.ShowMe();
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
			{
				if (cardData.HasTag(TagMap.食物) && !cardData.HasTag(TagMap.特殊) && cardData.Rare == mergeBy.Rare - 1)
				{
					list.Add(cardData);
				}
			}
			CardData cardData2 = CardData.CopyCardData(list[SYNCRandom.Range(0, list.Count)], true);
			Card.InitCard(cardData2);
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(cardData2);
			if (emptySlotDataByCardData != null)
			{
				cardData2.PutInSlotData(emptySlotDataByCardData, true);
			}
		}
	}
}
