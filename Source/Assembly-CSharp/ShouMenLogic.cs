using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouMenLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "守门";
		this.Desc = "左右两列的随从被攻击前，试图移向该列。";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData == this.CardData || !target.ChildCardData.HasTag(TagMap.随从) || target.GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col"))
		{
			yield break;
		}
		base.GetMyBattleArea();
		if (this.CardData.CurrentCardSlotData.GetAttr("Col").Equals("0"))
		{
			if (target.GetAttr("Col").Equals("1"))
			{
				yield return this.TryJump(target, Vector3Int.left);
			}
		}
		else if (this.CardData.CurrentCardSlotData.GetAttr("Col").Equals("2"))
		{
			if (target.GetAttr("Col").Equals("1"))
			{
				yield return this.TryJump(target, Vector3Int.right);
			}
		}
		else
		{
			if (target.GetAttr("Col").Equals("0"))
			{
				yield return this.TryJump(target, Vector3Int.right);
			}
			if (target.GetAttr("Col").Equals("2"))
			{
				yield return this.TryJump(target, Vector3Int.left);
			}
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd, Vector3Int dir)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		CardSlotData cardSlotData = null;
		CardSlotData rightCSD = null;
		if (playerSlotSets.IndexOf(csd) != 0 && playerSlotSets.IndexOf(csd) != playerSlotSets.Count / 3 && playerSlotSets.IndexOf(csd) != playerSlotSets.Count / 3 * 2 && playerSlotSets[playerSlotSets.IndexOf(csd) - 1].ChildCardData == null)
		{
			cardSlotData = playerSlotSets[playerSlotSets.IndexOf(csd) - 1];
		}
		if (playerSlotSets.IndexOf(csd) != playerSlotSets.Count / 3 - 1 && playerSlotSets.IndexOf(csd) != playerSlotSets.Count / 3 * 2 - 1 && playerSlotSets.IndexOf(csd) != playerSlotSets.Count - 1 && playerSlotSets[playerSlotSets.IndexOf(csd) + 1].ChildCardData == null)
		{
			CardSlotData cardSlotData2 = playerSlotSets[playerSlotSets.IndexOf(csd) + 1];
			rightCSD = cardSlotData2;
		}
		if (dir == Vector3Int.left && cardSlotData != null)
		{
			base.ShowMe();
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(cardSlotData.CardSlotGameObject, 0.2f, true);
		}
		if (dir == Vector3Int.right && rightCSD != null)
		{
			base.ShowMe();
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(rightCSD.CardSlotGameObject, 0.2f, true);
		}
		yield break;
	}
}
