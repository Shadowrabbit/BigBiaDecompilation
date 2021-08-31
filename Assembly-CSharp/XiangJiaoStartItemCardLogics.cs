using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangJiaoStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_香蕉的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_香蕉的味道");
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (base.GetMyBattleArea().Contains(cardSlot))
		{
			foreach (CardSlotData cs in base.GetMyBattleArea())
			{
				if (cs.ChildCardData != null)
				{
					base.ShowMe();
					yield return new WaitForSeconds(0.2f);
					cs.ChildCardData.EXATK += 10;
				}
				cs = null;
			}
			List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		}
		yield return null;
		yield break;
		yield break;
	}
}
