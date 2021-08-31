using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "王者咆哮";
		this.Desc = "回合开始时发出一声咆哮，使自己和所有相邻的怪物+50%攻击力。";
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		base.ShowMe();
		List<List<AttackMsg>> targets = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets;
		new List<CardData>();
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		list.Add(Vector3Int.up);
		list.Add(Vector3Int.down);
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
			{
				ralitiveCardSlotData.ChildCardData._ATK = Mathf.CeilToInt((float)ralitiveCardSlotData.ChildCardData.ATK * 1.5f);
			}
		}
		this.CardData._ATK = Mathf.CeilToInt((float)this.CardData.ATK * 1.5f);
		yield break;
	}

	private CardData CurrentData;
}
