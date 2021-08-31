using System;
using System.Collections;
using UnityEngine;

public class ShuRouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_熟肉");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_熟肉"), 100f * (this.baseDmg + this.increaseDmg * (float)base.Layers));
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_熟肉");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_熟肉"), 100f * (this.baseDmg + this.increaseDmg * (float)base.Layers));
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (from == this.CardData && changedValue < 0)
		{
			base.ShowMe();
			yield return base.Cure(this.CardData, Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * (float)(-(float)changedValue)), this.CardData);
		}
		yield break;
	}

	private float baseDmg = 0.1f;

	private float increaseDmg = 0.1f;
}
