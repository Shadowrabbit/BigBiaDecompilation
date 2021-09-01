using System;
using System.Collections;

public class AddBleedingByAttackCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_170");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_170"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_170");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_170"), base.Layers);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					attackMsg.Target.AddAffix(DungeonAffix.bleeding, base.Layers);
				}
			}
		}
		yield break;
	}
}
