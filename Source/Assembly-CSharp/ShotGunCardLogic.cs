using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "霰弹";
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.Desc = "对前方第一个敌人造成伤害。你与敌人离得越近，该伤害越高。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		bool allCurrentMonsters = base.GetAllCurrentMonsters() != null;
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (!allCurrentMonsters)
		{
			yield break;
		}
		this.CardData.IsAttacked = true;
		for (int i = enemiesBattleArea.Count - 1; i >= 0; i--)
		{
			if (enemiesBattleArea[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && enemiesBattleArea[i].ChildCardData != null && enemiesBattleArea[i].ChildCardData.HasTag(TagMap.怪物))
			{
				int num = base.GetMinionLine(this.CardData) + base.GetMonsterLine(enemiesBattleArea[i].ChildCardData);
				float num2 = 0f;
				switch (num)
				{
				case 0:
					num2 = 3f;
					break;
				case 1:
					num2 = 1.75f;
					break;
				case 2:
					num2 = 1.25f;
					break;
				case 3:
					num2 = 1f;
					break;
				case 4:
					num2 = 0.5f;
					break;
				}
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, enemiesBattleArea[i].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * num2), 0.2f, false, 0, null, null);
				yield break;
			}
		}
		base.GetMinionLine(this.CardData);
		new List<CardData>();
		yield break;
	}
}
