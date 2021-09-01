using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianFengShanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_电风扇");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_电风扇"), 2 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_电风扇");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_电风扇"), 2 + base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		Dictionary<CardData, int> targets = new Dictionary<CardData, int>();
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData.CurrentCardSlotData.GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && cardData.HasTag(TagMap.怪物))
			{
				targets.Add(cardData, -1);
			}
		}
		if (targets.Count == 0)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < 2 + base.Layers; i = num + 1)
		{
			yield return base.AOE(targets, this.CardData, false, 0, true);
			num = i;
		}
		using (Dictionary<CardData, int>.Enumerator enumerator2 = targets.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				KeyValuePair<CardData, int> keyValuePair = enumerator2.Current;
				if (!DungeonOperationMgr.Instance.CheckCardDead(keyValuePair.Key))
				{
					keyValuePair.Key.AddAffix(DungeonAffix.bleeding, 2 + base.Layers);
					keyValuePair.Key.AddAffix(DungeonAffix.frozen, 2 + base.Layers);
				}
			}
			yield break;
		}
		yield break;
	}
}
