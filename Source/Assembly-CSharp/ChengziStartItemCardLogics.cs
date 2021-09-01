using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengziStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_橙子的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_橙子的味道");
	}

	public override IEnumerator OnBattleEnd()
	{
		if (this.CardData == null || this.CardData.CardGameObject == null)
		{
			yield break;
		}
		int i = 0;
		using (List<CardSlotData>.Enumerator enumerator = base.GetMyBattleArea().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ChildCardData != null)
				{
					int num = i;
					i = num + 1;
				}
			}
		}
		base.ShowMe();
		yield return new WaitForSeconds(0.2f);
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, i - 1, this.CardData, false, 0, true, false);
		yield break;
	}
}
