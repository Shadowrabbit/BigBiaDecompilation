using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenLinNvWuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(2, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_8");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_8");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_8");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_8");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		CardSlotData cardSlotData = null;
		foreach (CardSlotData cardSlotData2 in playerSlotSets)
		{
			if (cardSlotData2 != null && (cardSlotData2.TagWhiteList == 0UL || (cardSlotData2.TagWhiteList & 4294967296UL) != 0UL) && cardSlotData2.ChildCardData == null)
			{
				cardSlotData = cardSlotData2;
				break;
			}
		}
		if (cardSlotData == null)
		{
			yield break;
		}
		List<string> list = new List<string>();
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.药水) && cardData.Rare <= base.Layers)
			{
				list.Add(cardData.ModID);
			}
		}
		if (list.Count <= 0)
		{
			yield break;
		}
		Card.InitCardDataByID(list[SYNCRandom.Range(0, list.Count)]).PutInSlotData(cardSlotData, true);
		yield break;
	}
}
