using System;
using System.Collections;
using System.Collections.Generic;

public class YanLiaoTongCardLogic : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_渲染");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_渲染");
	}

	public override IEnumerator OnTurnStart()
	{
		foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
				{
					if (cardLogic is ShiGaoCardLogic)
					{
						yield return (cardLogic as ShiGaoCardLogic).ChangeColor((CardLogicColor)SYNCRandom.Range(0, 3));
					}
				}
				List<CardLogic>.Enumerator enumerator2 = default(List<CardLogic>.Enumerator);
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield break;
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
		{
			if (cardSlotData.ChildCardData != null)
			{
				foreach (CardLogic cardLogic in cardSlotData.ChildCardData.CardLogics)
				{
					if (cardLogic is ShiGaoCardLogic)
					{
						yield return (cardLogic as ShiGaoCardLogic).ChangeColor((CardLogicColor)SYNCRandom.Range(0, 3));
					}
				}
				List<CardLogic>.Enumerator enumerator2 = default(List<CardLogic>.Enumerator);
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield break;
		yield break;
	}
}
