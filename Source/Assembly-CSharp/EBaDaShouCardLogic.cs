using System;
using System.Collections;
using UnityEngine;

public class EBaDaShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_68");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_68");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_68");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_68");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData && target.ChildCardData.ATK < this.CardData.ATK)
		{
			this.flag = true;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData && this.flag)
		{
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f), this.CardData);
			this.flag = false;
		}
		yield break;
	}

	private bool flag;
}
