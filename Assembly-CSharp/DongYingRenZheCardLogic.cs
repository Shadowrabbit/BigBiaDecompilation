using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongYingRenZheCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "迅捷";
		this.Desc = "受到攻击后随机移动一格。攻击时身边每有一个其他友军，额外攻击一次。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "迅捷";
		this.Desc = "受到攻击后随机移动一格。攻击时身边每有一个其他友军，额外攻击一次。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && target.ChildCardData == this.CardData && this.HaveJumped)
		{
			this.HaveJumped = false;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		this.HaveJumped = true;
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			List<CardData> monstersNearBy = base.GetMonstersNearBy(this.CardData.CurrentCardSlotData, new List<Vector3Int>
			{
				Vector3Int.left,
				Vector3Int.right,
				Vector3Int.up,
				Vector3Int.down
			});
			if (monstersNearBy.Count > 0)
			{
				base.ShowMe();
				this.CardData.NextAttackTimes += monstersNearBy.Count;
			}
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
		list.Add(Vector3Int.up);
		list.Add(Vector3Int.down);
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && myBattleArea.Contains(ralitiveCardSlotData))
			{
				list2.Add(ralitiveCardSlotData);
			}
		}
		if (list2.Count == 0)
		{
			yield break;
		}
		CardSlotData target = list2[SYNCRandom.Range(0, list2.Count)];
		if (csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		}
		if (csd.ChildCardData != null && csd.ChildCardData.Attrs.ContainsKey("Col"))
		{
			csd.ChildCardData.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	private bool HaveJumped = true;
}
