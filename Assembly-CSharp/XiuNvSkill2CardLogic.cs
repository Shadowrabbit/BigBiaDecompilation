using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class XiuNvSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_142");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_142");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_142");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_142");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		if (base.GetLogic(this.CardData, typeof(PrayerLogic)) != null)
		{
			int layers = base.GetLogic(this.CardData, typeof(PrayerLogic)).Layers;
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			if (allCurrentMinions.Count <= 0)
			{
				yield break;
			}
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			foreach (CardData key in allCurrentMinions)
			{
				dictionary.Add(key, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)layers)));
			}
			yield return base.AOE(dictionary, this.CardData, false, 0, true);
		}
		yield break;
	}

	private float baseDmg = 0.2f;

	private float increaseDmg = 0.2f;
}
