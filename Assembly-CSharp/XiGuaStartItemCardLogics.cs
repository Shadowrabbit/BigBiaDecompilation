using System;
using System.Collections;
using UnityEngine;

public class XiGuaStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_西瓜的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_西瓜的味道");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player != null && player == this.CardData && changedValue > 0)
		{
			base.ShowMe();
			yield return new WaitForSeconds(0.2f);
			this.CardData.AddAffix(DungeonAffix.beatBack, 2);
		}
		yield break;
	}
}
