using System;
using System.Collections;
using System.Collections.Generic;

public class ShuoYiGeJiuYiGe : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_说一个就一个");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_说一个就一个");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_说一个就一个");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_说一个就一个");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData)
		{
			if (from == null)
			{
				yield break;
			}
			if (!this.m_Attacker.Contains(from.ModID))
			{
				this.m_Attacker.Add(from.ModID);
			}
			else if (value.value < 0)
			{
				base.ShowMe();
				value.value = 0;
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.m_Attacker = new List<string>();
		}
		yield break;
	}

	private List<string> m_Attacker = new List<string>();
}
