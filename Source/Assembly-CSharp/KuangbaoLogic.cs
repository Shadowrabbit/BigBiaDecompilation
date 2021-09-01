using System;
using System.Collections;
using UnityEngine;

public class KuangbaoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_30");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_30"), Mathf.CeilToInt((0.5f + 0.5f * (float)(base.Layers - 1)) * (float)(this.CardData.MaxHP - this.CardData.HP)), 50 + 50 * (base.Layers - 1));
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_30");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_30"), Mathf.CeilToInt((0.5f + 0.5f * (float)(base.Layers - 1)) * (float)(this.CardData.MaxHP - this.CardData.HP)), 50 + 50 * (base.Layers - 1));
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && this.CardData.MaxHP > this.CardData.HP)
		{
			base.ShowMe();
			this.CardData.wATK += Mathf.CeilToInt((0.5f + 0.5f * (float)(base.Layers - 1)) * (float)(this.CardData.MaxHP - this.CardData.HP));
			yield break;
		}
		yield break;
	}
}
