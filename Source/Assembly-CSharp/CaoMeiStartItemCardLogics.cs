using System;
using System.Collections;
using UnityEngine;

public class CaoMeiStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_草莓的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_草莓的味道");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从) && from == this.CardData)
		{
			base.ShowMe();
			yield return new WaitForSeconds(0.2f);
			GameController.ins.GameData.Money += 5;
		}
		yield break;
	}
}
