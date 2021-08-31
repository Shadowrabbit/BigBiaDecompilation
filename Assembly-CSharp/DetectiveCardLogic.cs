using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_10");
		this.NeedEnergyCount = new Vector3Int(0, 1, 0);
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_10_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (1.4f + 0.1f * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_10_2"),
			(140 + 10 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_10_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_10_1"),
			Mathf.CeilToInt((float)this.CardData.ATK * (1.4f + 0.1f * (float)base.Layers)).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_10_2"),
			(140 + 10 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_10_3")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters == null)
		{
			yield break;
		}
		this.CardData.IsAttacked = true;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (list.Count == 0)
			{
				list.Add(cardData);
			}
			else if (cardData.HP == list[0].HP)
			{
				list.Add(cardData);
			}
			else if (cardData.HP < list[0].HP)
			{
				list.Clear();
				list.Add(cardData);
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData targetCardData = list[SYNCRandom.Range(0, list.Count)];
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, Mathf.CeilToInt((float)this.CardData.ATK * (1.4f + 0.1f * (float)base.Layers)), 0.2f, false, 0, "Effect/追迹", "Effect/追迹命中");
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "追迹释放";
	}
}
