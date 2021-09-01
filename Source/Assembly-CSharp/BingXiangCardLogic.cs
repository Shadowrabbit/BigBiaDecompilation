using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingXiangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_急速制冷");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_急速制冷"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_急速制冷");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_急速制冷"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
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
		Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
		base.ShowMe();
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				if (cardData.HasAffix(DungeonAffix.frozen))
				{
					cardData.RemoveAffix(DungeonAffix.frozen);
					cardData.DizzyLayer = 1;
				}
				dictionary.Add(cardData, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)));
			}
		}
		yield return base.AOE(dictionary, this.CardData, false, 0, true);
		yield break;
	}

	private float baseDmg = 0.25f;

	private float increaseDmg = 1f;
}
