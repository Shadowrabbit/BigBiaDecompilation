using System;
using System.Collections;

public class GuChongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蛊虫");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_蛊虫"), 3 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蛊虫");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_蛊虫"), 3 + base.Layers);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target.HasAffix(DungeonAffix.bleeding))
				{
					attackMsg.Target.AddAffix(DungeonAffix.poisoning, 3 + base.Layers);
				}
			}
		}
		yield break;
	}
}
