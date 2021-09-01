using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaZhiJiSiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_22");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_22");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_22");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_22");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		base.ShowMe();
		yield return new WaitForSeconds(1f);
		int num;
		for (int i = 0; i < 3; i = num + 1)
		{
			for (int j = CardSlots.Count - 1; j >= 0; j = num - 1)
			{
				if (CardSlots[j].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[j].ChildCardData != null && CardSlots[j].ChildCardData.HasTag(TagMap.怪物))
				{
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[j].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * this.dmg), 0.2f, false, 0, null, null));
					yield return new WaitForSeconds(0.1f);
				}
				num = j;
			}
			num = i;
		}
		this.CardData.IsAttacked = true;
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "沙之祭祀释放";
	}

	private float dmg = 0.3f;
}
