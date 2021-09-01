using System;
using System.Collections;
using UnityEngine;

public class DaGongZaiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_73");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_73");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_73");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_73");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		base.ShowMe();
		this.CardData._ATK = Mathf.CeilToInt((float)this.CardData.MaxHP * this.buff);
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.ShowMe();
		this.CardData._ATK = Mathf.CeilToInt((float)this.CardData.MaxHP * this.buff);
		yield break;
	}

	private float buff = 0.2f;
}
