using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class WuYiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_医疗事故");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_医疗事故");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_医疗事故");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_医疗事故");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allMonsters = base.GetAllCurrentMonsters();
		if (allMonsters.Count == 0)
		{
			yield break;
		}
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_给你们治疗"));
		yield return base.ShowCustomEffect("毒药释放", this.CardData.CurrentCardSlotData, 0.5f);
		foreach (CardData cardData in allMonsters)
		{
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && cardData.HasAffix(DungeonAffix.bleeding))
			{
				DungeonOperationMgr.Instance.StartCoroutine(base.PlayCureEffect(this.CardData, cardData));
				int affixData = cardData.GetAffixData(DungeonAffix.bleeding);
				int num = 0;
				for (int i = 0; i <= affixData; i++)
				{
					num += i;
				}
				cardData.RemoveAffix(DungeonAffix.bleeding);
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, -num, this.CardData, true, 0, true, false);
			}
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}
}
