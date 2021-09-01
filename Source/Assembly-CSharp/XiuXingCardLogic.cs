using System;
using System.Collections;
using UnityEngine;

public class XiuXingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_苦修");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_苦修"), Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_苦修");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_苦修"), Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), this.CardData);
		yield break;
	}

	private float baseDmg = 0.05f;

	private float increaseDmg = 0.05f;
}
