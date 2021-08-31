using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpToRightLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "右跳";
		this.Desc = "每次被攻击后，向右横跳。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData == this.CardData)
		{
			base.ShowMe();
			yield return this.TryJump(target);
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.right);
		List<CardSlotData> targets = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && myBattleArea.Contains(ralitiveCardSlotData))
			{
				targets.Add(ralitiveCardSlotData);
			}
		}
		if (targets.Count == 0)
		{
			yield break;
		}
		CardData card = csd.ChildCardData;
		yield return card.CardGameObject.JumpToSlot(targets[0].CardSlotGameObject, 0.2f, true);
		if (card.Attrs.ContainsKey("Col"))
		{
			card.Attrs["Col"] = targets[0].Attrs["Col"];
		}
		yield break;
	}
}
