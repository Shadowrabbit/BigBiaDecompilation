using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData == null || (this.CardData != null && this.CardData.HasTag(TagMap.随从)))
		{
			this.Color = CardLogicColor.blue;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_64");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_64"), Mathf.CeilToInt(0.5f * (float)base.Layers * (float)this.CardData.ATK), 50 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_64");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_64"), Mathf.CeilToInt(0.5f * (float)base.Layers * (float)this.CardData.ATK), 50 * base.Layers);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (this.CardData.HasTag(TagMap.随从) && isPlayerTurn)
		{
			List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
			List<CardData> list = new List<CardData>();
			foreach (CardSlotData cardSlotData in playerSlotSets)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从) && cardSlotData.ChildCardData != this.CardData && cardSlotData.ChildCardData.HP < cardSlotData.ChildCardData.MaxHP)
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (list.Count > 0)
			{
				base.ShowMe();
				CardData target = list[UnityEngine.Random.Range(0, list.Count)];
				yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), target);
			}
		}
		if (this.CardData.HasTag(TagMap.怪物) && !isPlayerTurn && this.CardData.DizzyLayer <= 0)
		{
			List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			List<CardData> list2 = new List<CardData>();
			foreach (CardSlotData cardSlotData2 in cardSlotDatas)
			{
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.怪物) && cardSlotData2.ChildCardData != this.CardData && cardSlotData2.ChildCardData.HP < cardSlotData2.ChildCardData.MaxHP)
				{
					list2.Add(cardSlotData2.ChildCardData);
				}
			}
			if (list2.Count > 0)
			{
				CardData target2 = list2[UnityEngine.Random.Range(0, list2.Count)];
				yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), target2);
			}
		}
		yield break;
	}
}
