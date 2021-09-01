using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiXiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_西席");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_西席"), (6 - base.Layers > 1) ? (6 - base.Layers) : 1);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_西席");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_西席"), (6 - base.Layers > 1) ? (6 - base.Layers) : 1);
	}

	public override IEnumerator OnUseSkill()
	{
		this.m_IsSkill = true;
		this.CardData.IsAttacked = true;
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			if (this.m_Strength < 0)
			{
				base.ShowMe();
				int num = (6 - base.Layers > 1) ? (6 - base.Layers) : 1;
				List<CardSlotData> myBattleArea = base.GetMyBattleArea();
				if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 3 >= 0 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 3].ChildCardData != null && Mathf.Abs(this.m_Strength) / num > 0)
				{
					myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 3].ChildCardData.AddAffix(DungeonAffix.strength, Mathf.Abs(this.m_Strength) / num);
				}
				this.m_Strength = 0;
			}
			this.m_IsSkill = false;
		}
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && this.m_IsSkill && changedValue < 0)
		{
			this.m_Strength += changedValue;
		}
		yield break;
	}

	private bool m_IsSkill;

	private int m_Strength;
}
