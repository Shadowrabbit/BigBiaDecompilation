using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_67");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_67");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_67");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_67");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (cardData != this.CardData)
			{
				if (list.Count == 0)
				{
					list.Add(cardData);
				}
				else if (cardData._ATK == list[0].ATK)
				{
					list.Add(cardData);
				}
				else if (cardData.ATK <= list[0].ATK)
				{
					list.Clear();
					list.Add(cardData);
				}
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData target = list[SYNCRandom.Range(0, list.Count)];
		base.ShowLogic("给我上！");
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, Mathf.CeilToInt((float)this.CardData.ATK * 0.1f), 0.2f, false, 0, null, null);
		target._ATK = Mathf.CeilToInt((float)target.ATK * 1.2f);
		yield break;
	}
}
