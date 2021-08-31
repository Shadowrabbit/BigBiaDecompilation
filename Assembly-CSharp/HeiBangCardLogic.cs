using System;
using System.Collections;
using UnityEngine;

public class HeiBangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_69");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_69");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_69");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_69");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && this.CardData.HP < this.CardData.MaxHP && this.flag)
		{
			this.CardData._ATK = Mathf.CeilToInt((float)(this.CardData.ATK / 2));
			this.flag = false;
		}
		else if (player == this.CardData && this.CardData.HP == this.CardData.MaxHP && !this.flag)
		{
			this.CardData._ATK = Mathf.CeilToInt((float)(this.CardData.ATK * 2));
			this.flag = true;
		}
		yield break;
	}

	private bool flag = true;
}
