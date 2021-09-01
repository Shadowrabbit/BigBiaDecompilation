using System;
using System.Collections;

public class SheYaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇3");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇3");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				attackMsg.Target.AddAffix(DungeonAffix.frail, 2);
				attackMsg.Target.AddAffix(DungeonAffix.bleeding, 2);
			}
		}
		yield break;
	}
}
