using System;
using System.Collections;
using UnityEngine;

public class JiaFangBaBaLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = (CardLogicColor)(this.m_Color % 3);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_78");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_78");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = (CardLogicColor)(this.m_Color % 3);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_78");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_78");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player != this.CardData || from == null)
		{
			yield break;
		}
		if (value.value < 0 && from.CurrentCardSlotData.Color != (CardSlotData.LineColor)this.Color)
		{
			base.ShowMe();
			value.value = Mathf.CeilToInt((float)(value.value / 2));
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.m_Round++;
			if (this.m_Round % 2 == 0)
			{
				base.ShowMe();
				this.m_Color++;
				this.Color = (CardLogicColor)this.m_Color;
				yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.1f), this.CardData);
			}
		}
		yield break;
	}

	private int m_Round;

	private int m_Color;
}
