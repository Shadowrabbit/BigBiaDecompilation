using System;
using System.Collections;
using UnityEngine;

public class HuoKuLouLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_90");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_90"), (50 - this.m_Round * 25 > 0) ? (50 - this.m_Round * 25) : 0);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_90");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_90"), (50 - this.m_Round * 25 > 0) ? (50 - this.m_Round * 25) : 0);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.m_Round++;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData != this.CardData)
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, Mathf.CeilToInt((float)(player.ATK * ((50 - this.m_Round * 25 > 0) ? (50 - this.m_Round * 25) : 0)) / 100f), 0.2f, false, 0, null, null);
		yield break;
	}

	private int m_Round;
}
