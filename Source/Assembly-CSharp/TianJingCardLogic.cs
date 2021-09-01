using System;
using System.Collections;
using UnityEngine;

public class TianJingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_44");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_44");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_44");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_44");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Yellow, this.CardData.CardGameObject.transform);
		yield return new WaitForSeconds(0.2f);
		yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Yellow, this.CardData.CardGameObject.transform);
		yield break;
	}
}
