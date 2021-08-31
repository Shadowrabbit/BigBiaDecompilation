using System;
using System.Collections;
using UnityEngine;

public class HaiYanStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_海盐的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_海盐的味道");
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (this.CardData.HasTag(TagMap.随从) && this.CardData != null && originCarddata == this.CardData)
		{
			bool flag = false;
			foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
			{
				if ((cardSlotData != null & cardSlotData.ChildCardData != null) && !DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData))
				{
					flag = true;
				}
			}
			if (!flag && this.CardData != null)
			{
				base.ShowMe();
				yield return new WaitForSeconds(0.2f);
				this.CardData._ATK++;
			}
		}
		yield break;
	}
}
