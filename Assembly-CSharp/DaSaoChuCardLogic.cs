using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaSaoChuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(1, 1, 1);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大扫除");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_大扫除"), 2 + base.Layers, 1 + base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大扫除");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_大扫除"), 2 + base.Layers, 1 + base.Layers);
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count == 0)
		{
			yield break;
		}
		using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					cardData.AddAffix(DungeonAffix.heal, 2 + base.Layers);
					cardData.AddAffix(DungeonAffix.strength, 1 + base.Layers);
				}
			}
			yield break;
		}
		yield break;
	}
}
