using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMasterCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_13");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_13");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_13");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_13");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData)
		{
			int num = 0;
			using (List<CardLogic>.Enumerator enumerator = this.CardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Color == CardLogicColor.blue)
					{
						num++;
					}
					this.Atk = Mathf.CeilToInt((float)(this.CardData.ATK * num) * 0.15f);
					this.CardData._ATK += this.Atk;
				}
			}
			if (num > 0)
			{
				base.ShowMe();
				this.m_HitEffect = this.CardData.HitEffect;
				this.CardData.HitEffect = "Effect/心中之剑命中";
			}
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			int num = 0;
			using (List<CardLogic>.Enumerator enumerator = this.CardData.CardLogics.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Color == CardLogicColor.blue)
					{
						num++;
					}
					this.Atk = Mathf.CeilToInt((float)(this.CardData.ATK * num) * 0.15f);
					this.CardData._ATK -= this.Atk;
				}
			}
			if (!string.IsNullOrEmpty(this.m_HitEffect))
			{
				this.CardData.HitEffect = this.m_HitEffect;
			}
		}
		yield break;
	}

	private int Atk;

	private string m_HitEffect = "";
}
