using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class ShengNvSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 2);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_圣女2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_圣女2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_圣女2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_圣女2");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.GetMyBattleArea();
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData target = null;
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null)
		{
			yield break;
		}
		target = defaultTarget;
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, this.CardData.ATK, 0.2f, false, 0, null, null);
		this.CardData.IsAttacked = true;
		base.ShowMe();
		if (DungeonOperationMgr.Instance.CheckCardDead(target))
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
			using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					if (cardData != null)
					{
						cardData.wATK += Mathf.CeilToInt((float)cardData.ATK * 0.5f);
					}
				}
				yield break;
			}
		}
		yield break;
	}
}
