using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuiShiBuDuiRenLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_43");
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_43_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (1.25f + this.dmg * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_43_2"),
			((1.25f + this.dmg * (float)base.Layers) * 100f).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_43_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_43_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (1.25f + this.dmg * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_43_2"),
			((1.25f + this.dmg * (float)base.Layers) * 100f).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_43_3")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null)
		{
			yield break;
		}
		base.ShowMe();
		List<CardData> list = new List<CardData>();
		list.Add(defaultTarget);
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (cardData.ModID == defaultTarget.ModID && !DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData != defaultTarget)
			{
				list.Add(cardData);
			}
		}
		if (list.Count > 0)
		{
			using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData targetCardData = enumerator.Current;
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, Mathf.CeilToInt((float)this.CardData.ATK * (1.25f + this.dmg * (float)base.Layers)), 0.2f, false, 0, null, null));
				}
				yield break;
			}
		}
		yield break;
	}

	private float dmg = 0.25f;
}
