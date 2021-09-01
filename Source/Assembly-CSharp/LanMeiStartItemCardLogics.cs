using System;
using System.Collections;
using UnityEngine;

public class LanMeiStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蓝莓的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_蓝莓的味道");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从) && from == this.CardData)
		{
			base.ShowMe();
			yield return new WaitForSeconds(0.2f);
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, 3, this.CardData, false, 0, true, false);
		}
		yield break;
	}
}
