using System;
using System.Collections;
using UnityEngine;

public class HongBaoShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_184");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_184"), base.Layers * 25);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_184");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_184"), base.Layers * 25);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		if (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Red) < this.needEnergy)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < this.needEnergy; i = num + 1)
		{
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Red, this.CardData.CardGameObject.transform);
			num = i;
		}
		base.ShowMe();
		for (int j = 0; j < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; j++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[j])
			{
				attackMsg.Dmg += Mathf.CeilToInt((float)attackMsg.Dmg * 0.25f * (float)base.Layers);
			}
		}
		yield break;
	}

	private int needEnergy = 1;
}
