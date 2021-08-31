using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TiaoZhanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 1, 2);
		this.displayName = "挑战";
		this.Desc = "对生命值最多的敌人造成125%伤害并使其眩晕1回合。";
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea == null)
		{
			yield break;
		}
		CardData target = null;
		int num = int.MinValue;
		for (int i = enemiesBattleArea.Count - 1; i >= 0; i--)
		{
			if (enemiesBattleArea[i].ChildCardData != null && enemiesBattleArea[i].ChildCardData.HasTag(TagMap.怪物) && num < enemiesBattleArea[i].ChildCardData.HP)
			{
				target = enemiesBattleArea[i].ChildCardData;
				num = enemiesBattleArea[i].ChildCardData.HP;
			}
		}
		if (target != null)
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, Mathf.CeilToInt(1.25f * (float)this.CardData.ATK), 0.2f, false, 0, null, null);
			target.DizzyLayer++;
			this.CardData.IsAttacked = true;
			GameController.ins.UIController.AreaAdvocateDesc.transform.parent.DOPunchPosition(Vector3.right * 30f, 0.4f, 10, 1f, false);
		}
		yield break;
	}
}
