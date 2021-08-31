using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "狙击";
		this.Desc = "己方回合结束时，消灭一个血量最少的非BOSS敌人。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			List<CardData> list = new List<CardData>();
			foreach (CardSlotData cardSlotData in cardSlotDatas)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.怪物) && !cardSlotData.ChildCardData.HasTag(TagMap.BOSS))
				{
					if (list.Count > 0 && list[0].HP > cardSlotData.ChildCardData.HP)
					{
						list.Clear();
					}
					if (list.Count == 0)
					{
						list.Add(cardSlotData.ChildCardData);
					}
					else if (list[0].HP == cardSlotData.ChildCardData.HP)
					{
						list.Add(cardSlotData.ChildCardData);
					}
				}
			}
			if (list.Count > 0)
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, list[UnityEngine.Random.Range(0, list.Count)], 999, 0.1f, true, 0, null, null);
			}
		}
		yield break;
	}
}
