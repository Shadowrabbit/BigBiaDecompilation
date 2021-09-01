using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomJumpLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "灵动";
		this.Desc = "每次被攻击后随机跳到随机位置。";
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
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea == null)
		{
			yield break;
		}
		CardSlotData target = enemiesBattleArea[UnityEngine.Random.Range(0, enemiesBattleArea.Count)];
		while (target.ChildCardData != null)
		{
			target = enemiesBattleArea[UnityEngine.Random.Range(0, enemiesBattleArea.Count)];
		}
		CardData card = csd.ChildCardData;
		yield return card.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (card.Attrs.ContainsKey("Col"))
		{
			card.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
