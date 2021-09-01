using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "保险装置";
		this.Desc = "3回合后爆炸,对所有随从造成本单位剩余生命值伤害。";
		if (this.CardData == null)
		{
			return;
		}
		if (this.CardData.Armor <= 0)
		{
			this.CardData.Armor++;
		}
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			base.ShowMe();
			this.m_Round++;
			if (this.m_Round > 3)
			{
				this.displayName = "爆炸！";
				base.ShowMe();
				yield return this.EnemyExplode();
			}
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "保险装置";
		this.Desc = (3 - this.m_Round).ToString() + "回合后爆炸,对所有随从造成本单位剩余生命值伤害。";
	}

	private IEnumerator EnemyExplode()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		new List<CardData>();
		if (allCurrentMinions.Count > 0)
		{
			foreach (CardData targetCardData in allCurrentMinions)
			{
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.2f), 0.2f, false, 0, null, null));
			}
		}
		yield return new WaitForSeconds(0.5f);
		this.CardData.DeleteCardData();
		yield break;
	}

	private int m_Round;
}
