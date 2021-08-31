using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class ChangGongShouSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 3, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_138");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_138"), Mathf.CeilToInt((float)this.CardData.ATK), 100);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 3, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_138");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_138"), Mathf.CeilToInt((float)this.CardData.ATK), 100);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allTargets = base.GetAllCurrentMonsters();
		if (allTargets.Count == 0)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < this.count; i = num + 1)
		{
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			foreach (CardData cardData in allTargets)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					dictionary.Add(cardData, -Mathf.CeilToInt((float)this.CardData.ATK));
				}
			}
			yield return base.AOE(dictionary, this.CardData, false, 0, true);
			num = i;
		}
		yield break;
	}

	private int count = 1;
}
