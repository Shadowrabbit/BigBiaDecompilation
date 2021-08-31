using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianJinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = "炼金";
		this.Desc = "偷取前方第一个敌人1护甲。对BOSS无效";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea == null)
		{
			yield break;
		}
		for (int i = enemiesBattleArea.Count - 1; i >= 0; i--)
		{
			if (enemiesBattleArea[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && enemiesBattleArea[i].ChildCardData != null && enemiesBattleArea[i].ChildCardData.HasTag(TagMap.怪物) && enemiesBattleArea[i].ChildCardData.Armor > 0)
			{
				base.ShowMe();
				enemiesBattleArea[i].ChildCardData.Armor--;
				this.CardData.MaxArmor++;
				this.CardData.Armor++;
			}
		}
		yield break;
	}
}
