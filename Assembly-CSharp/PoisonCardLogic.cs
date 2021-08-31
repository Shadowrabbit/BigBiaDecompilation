using System;
using System.Collections;
using UnityEngine;

public class PoisonCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "中毒";
		this.Desc = "回合结束时失去[" + Mathf.CeilToInt(this.debuff * 100f * (float)base.Layers).ToString() + "%最大生命值]。该效果可以叠加且永远持续。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn)
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, this.CardData, Mathf.CeilToInt((float)this.CardData.MaxHP * this.debuff * (float)base.Layers), 0.2f, false, 0, null, null);
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "中毒";
		this.Desc = "回合结束时失去[" + Mathf.CeilToInt(this.debuff * 100f * (float)base.Layers).ToString() + "%最大生命值]。该效果可以叠加且永远持续。";
	}

	private float debuff = 0.02f;
}
