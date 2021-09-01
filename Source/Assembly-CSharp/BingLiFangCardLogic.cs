using System;
using System.Collections;
using UnityEngine;

public class BingLiFangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_凝结");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_凝结");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_凝结");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_凝结");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		base.ShowMe();
		yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.2f), this.CardData);
		yield break;
	}
}
