using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_51");
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_51_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (0.6f + 0.1f * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_51_2"),
			(60 + 10 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_51_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_51");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_51_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (0.6f + 0.1f * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_51_2"),
			(60 + 10 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_51_3")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		int i = CardSlots.Count - 1;
		while (i >= 0)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (0.6f + 0.1f * (float)base.Layers)), 0.2f, false, 0, null, null);
				if (DungeonOperationMgr.Instance.CheckCardDead(CardSlots[i].ChildCardData))
				{
					yield break;
				}
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (0.6f + 0.1f * (float)base.Layers)), 0.2f, false, 0, null, null);
				yield break;
			}
			else
			{
				int num = i;
				i = num - 1;
			}
		}
		yield break;
	}
}
