using System;
using System.Collections;
using System.Collections.Generic;

public class YanJiangWangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_93");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_93");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_93");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_93");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		base.ShowMe();
		using (List<CardData>.Enumerator enumerator = base.GetAllCurrentMonsters().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ModID.Equals("岩浆球"))
				{
					this.m_ATKCount++;
				}
			}
		}
		this.CardData.wAttackTimes += this.m_ATKCount;
		this.CardData._AttackTimes += this.m_ATKCount;
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		this.CardData._AttackTimes -= this.m_ATKCount;
		this.m_ATKCount = 0;
		yield break;
	}

	private int m_ATKCount;
}
