using System;
using System.Collections;

public class KouHongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_口红");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_口红"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_口红");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_口红"), base.Layers * this.weight);
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
					attackMsg.Target.AddAffix(DungeonAffix.frail, base.Layers * this.weight);
				}
			}
		}
		yield break;
	}

	private int weight = 1;
}
