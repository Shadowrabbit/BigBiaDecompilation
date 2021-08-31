using System;
using System.Collections;
using UnityEngine;

public class ShiLaiMuNiangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_情感异质");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_情感异质"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_情感异质");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_情感异质"), base.Layers);
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData)
		{
			if (value.value > 0 && from == this.CardData)
			{
				base.ShowMe();
				value.value = 0;
			}
			if (from != this.CardData)
			{
				base.ShowMe();
				if (value.value < 0)
				{
					value.value = Mathf.FloorToInt((float)value.value * 1.5f);
				}
				else
				{
					value.value = Mathf.CeilToInt((float)value.value * 1.5f);
				}
			}
			if (value.value > 0)
			{
				base.ShowMe();
				this.CardData.MaxHP += base.Layers;
			}
		}
		yield break;
	}
}
