using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiangMuJingLiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_77");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_77");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_77");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_77");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.m_Round++;
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			yield return this.Explode();
		}
		yield break;
	}

	private IEnumerator Explode()
	{
		base.ShowMe();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		new List<CardData>();
		if (allCurrentMinions.Count > 0)
		{
			foreach (CardData targetCardData in allCurrentMinions)
			{
				GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, Mathf.CeilToInt((float)this.CardData.MaxHP * this.dmg * (float)this.m_Round), 0.2f, false, 0, null, null));
			}
		}
		if (allCurrentMonsters.Count > 0)
		{
			using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData targetCardData2 = enumerator.Current;
					GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData2, Mathf.CeilToInt((float)this.CardData.MaxHP * this.dmg * (float)this.m_Round), 0.2f, false, 0, null, null));
				}
				yield break;
			}
		}
		yield break;
	}

	private float dmg = 0.03f;

	private int m_Round = 1;
}
