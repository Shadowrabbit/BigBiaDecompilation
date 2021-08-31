using System;
using System.Collections;
using UnityEngine;

public class ShaDaiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_反震");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_反震");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_反震");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_反震");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0 && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
			this.val += Mathf.CeilToInt(0.3f * (float)(-(float)changedValue));
			this.CardData._ATK += Mathf.CeilToInt(0.3f * (float)(-(float)changedValue));
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.CardData._ATK -= this.val;
			this.val = 0;
			yield break;
		}
		yield break;
	}

	private int val;
}
