using System;
using System.Collections;
using System.Collections.Generic;

public class FengYiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_风衣");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_风衣"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_风衣");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_风衣"), base.Layers);
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player.HasTag(TagMap.随从) && value.value < 0)
		{
			List<CardSlotData> myBattleArea = base.GetMyBattleArea();
			List<CardData> list = new List<CardData>();
			if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) < myBattleArea.Count / 3 * 2)
			{
				CardSlotData cardSlotData = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + myBattleArea.Count / 3];
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != 0 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 * 2)
			{
				CardSlotData cardSlotData2 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 1];
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData2.ChildCardData);
				}
			}
			if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 - 1 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 * 2 - 1 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count - 1)
			{
				CardSlotData cardSlotData3 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 1];
				if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData3.ChildCardData);
				}
			}
			if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) >= myBattleArea.Count / 3)
			{
				CardSlotData cardSlotData4 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - myBattleArea.Count / 3];
				if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData4.ChildCardData);
				}
			}
			if (list.Count <= 0)
			{
				yield break;
			}
			if (list.Contains(player))
			{
				base.ShowMe();
				player.AddAffix(DungeonAffix.def, base.Layers);
			}
		}
		yield break;
	}
}
