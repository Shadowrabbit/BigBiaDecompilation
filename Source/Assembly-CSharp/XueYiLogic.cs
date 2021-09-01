using System;
using System.Collections;
using UnityEngine;

public class XueYiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_血裔");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_血裔");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_血裔");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_血裔");
	}

	public override IEnumerator OnBattleStart()
	{
		this.CardData.AddAffix(DungeonAffix.strength, 2);
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		this.CardData.AddAffix(DungeonAffix.strength, 2);
		yield break;
	}

	public override IEnumerator OnMoveOnMap()
	{
		yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -Mathf.CeilToInt((float)this.CardData.MaxHP * 0.05f), this.CardData, true, 0, true, false);
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (from == this.CardData)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, "渴血", UnityEngine.Color.white, 0, false, false);
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.3f), this.CardData);
		}
		yield break;
	}
}
