using System;
using System.Collections;
using UnityEngine;

public class TenacityLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData == null || (this.CardData != null && this.CardData.HasTag(TagMap.随从)))
		{
			this.Color = CardLogicColor.yellow;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_47");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_47_1"),
			Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_47_2"),
			((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_47_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_47");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_47_1"),
			Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_47_2"),
			((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_47_3")
		});
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData) && changedValue < 0)
		{
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * (this.baseDmg + this.increaseDmg * (float)base.Layers)), this.CardData);
		}
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.01f;
}
