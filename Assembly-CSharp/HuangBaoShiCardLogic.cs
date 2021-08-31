using System;
using System.Collections;
using UnityEngine;

public class HuangBaoShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_183");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_183"), base.Layers * 25);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_183");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_183"), base.Layers * 25);
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData && value.value < 0 && this.CardData.Armor == 0)
		{
			if (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Yellow) < this.needEnergy)
			{
				yield break;
			}
			base.ShowMe();
			int num;
			for (int i = 0; i < this.needEnergy; i = num + 1)
			{
				yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Yellow, this.CardData.CardGameObject.transform);
				num = i;
			}
			value.value -= Mathf.CeilToInt((float)value.value * 0.25f * (float)base.Layers);
		}
		yield break;
	}

	private int needEnergy = 1;
}
