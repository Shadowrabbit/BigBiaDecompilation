using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaiWuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_74");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_74");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_74");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_74");
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
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count > 0)
		{
			using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, Mathf.CeilToInt((float)this.CardData.MaxHP * 0.2f), 0.2f, false, 0, null, null));
					if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
					{
						cardData._ATK += Mathf.CeilToInt((float)this.CardData.MaxHP * 0.2f);
					}
				}
				yield break;
			}
		}
		yield break;
	}
}
