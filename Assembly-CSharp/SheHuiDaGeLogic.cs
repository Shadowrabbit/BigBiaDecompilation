using System;
using System.Collections;
using UnityEngine;

public class SheHuiDaGeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_108");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_108");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_108");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_108");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		if (value.value < 0 && from.CurrentCardSlotData.Color != (CardSlotData.LineColor)this.Color)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_3"), UnityEngine.Color.white, 0, false, false);
			value.value = 0;
		}
		else if (value.value < 0 && from.CurrentCardSlotData.Color == (CardSlotData.LineColor)this.Color)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_4"), UnityEngine.Color.white, 0, false, false);
		}
		yield break;
	}
}
