using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleATKTimesCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.Color = CardLogicColor.blue;
		this.displayName = "魔鬼辣椒";
		this.Desc = "使上方一格的随从下次攻击次数翻倍。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "魔鬼辣椒";
		this.Desc = "使上方一格的随从下次攻击频次翻倍。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
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
		if (list.Count <= 0)
		{
			yield break;
		}
		foreach (CardData cd in list)
		{
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, cd);
			base.AddLogic("ExATKTimesCardLogic", cd.AttackTimes, cd);
			cd = null;
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}
}
