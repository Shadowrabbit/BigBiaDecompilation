using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WuYiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_毒药");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_毒药"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_毒药");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_毒药"), base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allMonsters = base.GetAllCurrentMonsters();
		base.ShowMe();
		yield return base.ShowCustomEffect("毒药释放", this.CardData.CurrentCardSlotData, 0.5f);
		for (int i = 0; i < base.Layers; i++)
		{
			if (allMonsters.Count == 0)
			{
				yield break;
			}
			CardData cardData = allMonsters[SYNCRandom.Range(0, allMonsters.Count)];
			ParticlePoolManager.Instance.Spawn("Effect/毒药命中", 0.5f).transform.position = cardData.CurrentCardSlotData.CardSlotGameObject.transform.position;
			cardData.AddAffix(DungeonAffix.poisoning, 4);
			int affixData = cardData.GetAffixData(DungeonAffix.poisoning);
			if (affixData > 0)
			{
				cardData.AddAffix(DungeonAffix.poisoning, Mathf.CeilToInt((float)affixData * 0.25f));
			}
			allMonsters.Remove(cardData);
		}
		yield return new WaitForSeconds(0.5f);
		yield break;
	}
}
