using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangGuanLogic : CardLogic
{
	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_111");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_111");
	}

	public override IEnumerator OnTurnStart()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		CardData cardData = allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)];
		GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_5"), UnityEngine.Color.white, 0, false, false);
		cardData.IsAttacked = true;
		yield break;
	}
}
