using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeiDanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		if (this.CardData != null)
		{
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_34");
			this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_34"), 2 + base.Layers, Mathf.CeilToInt(0.5f * (float)this.CardData.ATK));
		}
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_34");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_34"), 2 + base.Layers, Mathf.CeilToInt(0.5f * (float)this.CardData.ATK));
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> AllMonsters = base.GetAllCurrentMonsters();
		if (AllMonsters == null || AllMonsters.Count == 0)
		{
			yield break;
		}
		base.ShowMe();
		int num;
		for (int i = 0; i < 2 + base.Layers; i = num + 1)
		{
			for (int j = 0; j < AllMonsters.Count; j++)
			{
				CardData cardData = AllMonsters[j];
				if (DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					AllMonsters.Remove(cardData);
				}
			}
			CardData cardData2 = AllMonsters[SYNCRandom.Range(0, AllMonsters.Count)];
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, cardData2, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f), 0.2f, false, 0, null, null);
			}
			num = i;
		}
		yield break;
	}
}
