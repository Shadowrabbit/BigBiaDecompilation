using System;
using System.Collections;
using UnityEngine;

public class JueDouLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "角斗";
		this.Desc = "对最下一行的敌人伤害增加30%。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (target.ChildCardData == null)
		{
			yield break;
		}
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target != null && !DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					for (int j = 0; j < base.GetEnemiesBattleArea().Count; j++)
					{
						if (attackMsg.Target.CurrentCardSlotData == base.GetEnemiesBattleArea()[j] && j / 3 == 2)
						{
							base.ShowMe();
							attackMsg.Dmg += Mathf.CeilToInt(0.3f * (float)this.CardData.ATK);
						}
					}
				}
			}
		}
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.ShotEffects.Add("");
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.HitEffects.Add("Effect/Damaged");
		yield break;
	}
}
