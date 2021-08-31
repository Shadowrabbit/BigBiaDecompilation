using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowlLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "偷袭";
		this.Desc = "对未行动过的敌人只造成50%伤害。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		using (List<List<AttackMsg>>.Enumerator enumerator = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				List<AttackMsg> list = enumerator.Current;
				if (list.Count == 0)
				{
					yield break;
				}
				foreach (AttackMsg attackMsg in list)
				{
					if (!attackMsg.Target.IsAttacked)
					{
						base.ShowMe();
						attackMsg.Dmg = Mathf.CeilToInt((float)attackMsg.Dmg * 0.5f);
					}
				}
			}
			yield break;
		}
		yield break;
	}
}
