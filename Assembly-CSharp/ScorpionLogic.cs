using System;
using System.Collections;
using System.Collections.Generic;

public class ScorpionLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "尾刺";
		this.Desc = "总是会试图攻击同列最后面的敌人。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				base.ShowMe();
				List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
				for (int j = 0; j < enemiesBattleArea.Count; j++)
				{
					if (!(enemiesBattleArea[i].GetAttr("Col") != this.CardData.CurrentCardSlotData.GetAttr("Col")) && enemiesBattleArea[j].ChildCardData != null && enemiesBattleArea[j].ChildCardData.HasTag(TagMap.随从))
					{
						attackMsg.Target = enemiesBattleArea[j].ChildCardData;
					}
				}
			}
		}
		yield break;
	}
}
