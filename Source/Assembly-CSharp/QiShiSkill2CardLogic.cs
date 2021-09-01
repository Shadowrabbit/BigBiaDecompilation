using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class QiShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.NeedEnergyCount = new Vector3Int(0, 0, 2);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_134");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_134");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 0, 2);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_134");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_134");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
		{
			if ((int)cardSlotData.Attrs["Col"] == (int)this.CardData.CurrentCardSlotData.Attrs["Col"])
			{
				list.Add(cardSlotData);
			}
		}
		base.ShowMe();
		foreach (CardSlotData cardSlotData2 in list)
		{
			if (cardSlotData2.ChildCardData != null)
			{
				yield return DungeonOperationMgr.Instance.AttackProcess(this.CardData, cardSlotData2.ChildCardData, GameController.getInstance().GetCurrentAreaData().ID);
			}
		}
		List<CardSlotData>.Enumerator enumerator2 = default(List<CardSlotData>.Enumerator);
		yield break;
		yield break;
	}
}
