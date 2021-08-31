using System;
using System.Collections;

public class QiShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_33");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_33"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_33");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_33"), base.Layers);
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
				attackMsg.reduceArmor += base.Layers;
			}
		}
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.ShotEffects.Add("");
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.HitEffects.Add("Effect/Damaged");
		yield break;
	}
}
