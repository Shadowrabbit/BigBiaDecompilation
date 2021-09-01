using System;
using System.Collections;
using UnityEngine;

public class ZhenTouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_181");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_181"), (this.dmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_181");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_181"), (this.dmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * (this.dmg + this.increaseDmg * (float)base.Layers)), this.CardData);
		yield break;
	}

	private float dmg = 0.05f;

	private float increaseDmg = 0.05f;
}
