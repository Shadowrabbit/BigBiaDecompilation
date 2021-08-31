using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_141");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_141"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_141");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_141"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		List<CardData> list = new List<CardData>();
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) < myBattleArea.Count / 3 * 2)
		{
			CardSlotData cardSlotData = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + myBattleArea.Count / 3];
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			yield break;
		}
		foreach (CardData target in list)
		{
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), target);
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}

	private float baseDmg = 0.2f;

	private float increaseDmg = 0.2f;

	private List<CardData> UselessTargets = new List<CardData>();
}
