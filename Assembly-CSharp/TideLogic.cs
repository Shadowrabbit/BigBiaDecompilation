using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TideLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(4, 0, 0);
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_37");
		if (this.CardData != null)
		{
			this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_37"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 100f * (this.baseDmg + this.increaseDmg * (float)base.Layers));
		}
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_37");
		if (this.CardData != null)
		{
			this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_37"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 100f * (this.baseDmg + this.increaseDmg * (float)base.Layers));
		}
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.GetEnemiesBattleArea();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		List<CardData> HurtMinions = base.GetAllHurtedMinions();
		this.CardData.IsAttacked = true;
		bool isUse = false;
		if (allCurrentMonsters.Count > 0)
		{
			isUse = true;
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			foreach (CardData cardData in allCurrentMonsters)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					dictionary.Add(cardData, -Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * (float)this.CardData.ATK));
				}
			}
			yield return base.AOE(dictionary, this.CardData, false, 0, true);
		}
		if (HurtMinions.Count > 0)
		{
			isUse = true;
			Dictionary<CardData, int> dictionary2 = new Dictionary<CardData, int>();
			foreach (CardData cardData2 in HurtMinions)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData2))
				{
					dictionary2.Add(cardData2, Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * (float)this.CardData.ATK / 2f));
				}
			}
			yield return base.AOE(dictionary2, this.CardData, false, 0, true);
		}
		if (isUse)
		{
			base.ShowMe();
		}
		yield break;
	}

	private float baseDmg = 0.2f;

	private float increaseDmg = 0.2f;
}
