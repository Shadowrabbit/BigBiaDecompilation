using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class FuZiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_夫子");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_夫子");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_夫子");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_夫子");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		List<CardData> neighboors = this.GetNeighboors();
		if (value.value < 0 && neighboors.Count > 0 && neighboors.Contains(player))
		{
			int num = -Mathf.CeilToInt((float)Mathf.Abs(value.value) * 0.25f);
			if (-value.value > 1)
			{
				base.ShowMe();
				value.value -= num;
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, num, from, false, 0, true, false);
			}
		}
		yield break;
	}

	private List<CardData> GetNeighboors()
	{
		List<CardData> list = new List<CardData>();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData != this.CardData && (myBattleArea.IndexOf(cardData.CurrentCardSlotData) == myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 3 || myBattleArea.IndexOf(cardData.CurrentCardSlotData) == myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 3 || (myBattleArea.IndexOf(cardData.CurrentCardSlotData) / 3 == myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) / 3 && (myBattleArea.IndexOf(cardData.CurrentCardSlotData) == myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 1 || myBattleArea.IndexOf(cardData.CurrentCardSlotData) == myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 1))))
			{
				list.Add(cardData);
			}
		}
		return list;
	}
}
