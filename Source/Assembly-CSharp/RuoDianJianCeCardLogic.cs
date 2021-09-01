using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuoDianJianCeCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_弱点检测");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_弱点检测"), 4 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_弱点检测");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_弱点检测"), 4 + base.Layers);
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
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_检测敌方弱点"));
		using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				if (DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					yield break;
				}
				cardData.AddAffix(DungeonAffix.frail, 4 + base.Layers);
			}
			yield break;
		}
		yield break;
	}
}
