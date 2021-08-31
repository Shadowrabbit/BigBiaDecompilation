using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class MaoShanDaoShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_五雷轰顶");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_五雷轰顶"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f), this.baseChance + this.increaseChance * (float)base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_五雷轰顶");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_五雷轰顶"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), Mathf.CeilToInt((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f), this.baseChance + this.increaseChance * (float)base.Layers);
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
		base.ShowMe();
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				base.GetChainLighting(cardData.CardGameObject.transform.position + new Vector3(0f, 3f, 0f), cardData.CardGameObject.transform.position, 1);
			}
		}
		foreach (CardData target in allCurrentMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(target))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), this.CardData, false, 0, true, false);
				if (!DungeonOperationMgr.Instance.CheckCardDead(target) && !target.HasTag(TagMap.BOSS))
				{
					if ((float)SYNCRandom.Range(0, 101) < this.baseChance + this.increaseChance * (float)base.Layers)
					{
						target.DizzyLayer = 1;
					}
					target = null;
				}
			}
		}
		List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}

	private float baseDmg = 0.75f;

	private float increaseDmg = 0.25f;

	private float baseChance = 50f;

	private float increaseChance = 10f;
}
