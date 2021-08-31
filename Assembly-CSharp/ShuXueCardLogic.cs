using System;
using System.Collections;
using UnityEngine;

public class ShuXueCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_32");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_32");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_32");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_32");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Red, this.CardData.CardGameObject.transform);
		yield return new WaitForSeconds(0.3f);
		yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Red, this.CardData.CardGameObject.transform);
		yield break;
	}
}
