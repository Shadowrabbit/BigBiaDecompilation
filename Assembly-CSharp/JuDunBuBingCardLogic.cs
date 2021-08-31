using System;
using System.Collections;
using UnityEngine;

public class JuDunBuBingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_45");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_45"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_45");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_45"), base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (this.CardData.MaxArmor <= this.CardData.Armor)
		{
			this.CardData.MaxArmor += base.Layers;
		}
		this.CardData.wArmor += base.Layers;
		this.CardData.Armor += base.Layers;
		this.CardData.IsAttacked = true;
		yield break;
	}
}
