using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiaoBoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = "吐槽";
		this.Desc = "使前方第一个敌人对其附近的一个随机单位造成等同于其攻击力的伤害。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		int i = CardSlots.Count - 1;
		while (i >= 0)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				base.ShowMe();
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, 0, 0.2f, false, 0, null, null);
				List<Vector3Int> list = new List<Vector3Int>();
				list.Add(Vector3Int.up);
				list.Add(Vector3Int.left);
				list.Add(Vector3Int.right);
				list.Add(Vector3Int.down);
				List<CardData> list2 = new List<CardData>();
				foreach (Vector3Int vector3Int in list)
				{
					CardSlotData ralitiveCardSlotData = (GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData).GetRalitiveCardSlotData(CardSlots[i].GridPositionX, CardSlots[i].GridPositionY, vector3Int.x, vector3Int.y, false);
					if (ralitiveCardSlotData == null || ralitiveCardSlotData.ChildCardData == null || !ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
					{
						yield break;
					}
					list2.Add(ralitiveCardSlotData.ChildCardData);
				}
				if (list2.Count <= 0)
				{
					yield break;
				}
				yield return DungeonOperationMgr.Instance.Hit(CardSlots[i].ChildCardData, list2[SYNCRandom.Range(0, list2.Count)], CardSlots[i].ChildCardData.ATK, 0.2f, false, 0, null, null);
				yield break;
			}
			else
			{
				int num = i;
				i = num - 1;
			}
		}
		yield break;
	}
}
