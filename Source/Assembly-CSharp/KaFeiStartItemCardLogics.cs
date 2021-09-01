using System;
using System.Collections;
using UnityEngine;

public class KaFeiStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_咖啡的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_咖啡的味道");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从) && isPlayerTurn && !this.CardData.IsAttacked)
		{
			base.ShowMe();
			yield return new WaitForSeconds(0.2f);
			this.CardData.NextAttackTimes++;
		}
		yield break;
	}
}
