using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "奥术";
		if (base.Layers < 1)
		{
			base.Layers = 1;
		}
		this.Desc = "友方单位攻击时，对随机目标造成" + base.Layers.ToString() + "伤害。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player.HasTag(TagMap.随从) && this.CardData.HasTag(TagMap.随从) && player != this.CardData)
		{
			List<CardData> list = new List<CardData>();
			foreach (CardSlotData cardSlotData in GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData.CardSlotDatas)
			{
				if (cardSlotData.IsFlipped && cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.怪物))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (list.Count > 0)
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, list[UnityEngine.Random.Range(0, list.Count)], base.Layers, 0.2f, false, 0, null, null);
			}
		}
		if (player.HasTag(TagMap.怪物) && this.CardData.HasTag(TagMap.怪物) && player != this.CardData)
		{
			List<CardData> list2 = new List<CardData>();
			foreach (CardSlotData cardSlotData2 in GameController.getInstance().PlayerSlotSets)
			{
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
				{
					list2.Add(cardSlotData2.ChildCardData);
				}
			}
			if (list2.Count > 0)
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, list2[UnityEngine.Random.Range(0, list2.Count)], base.Layers, 0.2f, false, 0, null, null);
			}
		}
		yield break;
	}
}
