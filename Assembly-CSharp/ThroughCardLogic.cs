using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = "穿透";
		this.Desc = string.Concat(new string[]
		{
			"对前方第一个敌人及其身后1格的单位造成",
			Mathf.CeilToInt((float)this.CardData.ATK * (1f + 0.1f * (float)base.Layers)).ToString(),
			"[",
			(100 + 10 * base.Layers).ToString(),
			"%攻击力]伤害。"
		});
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
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (1f + 0.1f * (float)base.Layers)), 0.2f, false, 0, null, null);
				new List<Vector3Int>();
				Vector3Int down = Vector3Int.down;
				CardSlotData ralitiveCardSlotData = (GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData).GetRalitiveCardSlotData(CardSlots[i].GridPositionX, CardSlots[i].GridPositionY, down.x, down.y, false);
				if (ralitiveCardSlotData == null || ralitiveCardSlotData.ChildCardData == null || !ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
				{
					yield break;
				}
				base.ShowMe();
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, ralitiveCardSlotData.ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (1f + 0.1f * (float)base.Layers)), 0.2f, false, 0, null, null);
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
