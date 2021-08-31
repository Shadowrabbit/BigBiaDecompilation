using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoYaoWoJueDeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_38");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_38");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_38");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_38");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		CardSlotData currentCardSlotData = base.GetDefaultTarget().CurrentCardSlotData;
		if (currentCardSlotData.ChildCardData == null || currentCardSlotData.ChildCardData.HasTag(TagMap.BOSS))
		{
			yield break;
		}
		List<string> list = new List<string>();
		foreach (CardSlotData cardSlotData in GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && !cardSlotData.ChildCardData.ModID.Equals(currentCardSlotData.ChildCardData.ModID) && cardSlotData.ChildCardData.HasTag(TagMap.怪物) && !list.Contains(cardSlotData.ChildCardData.ModID))
			{
				list.Add(cardSlotData.ChildCardData.ModID);
			}
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			string modId = list[SYNCRandom.Range(0, list.Count)];
			CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(modId), true);
			cardData._ATK = currentCardSlotData.ChildCardData.ATK;
			cardData._AttackTimes = currentCardSlotData.ChildCardData.AttackTimes;
			cardData.Armor = currentCardSlotData.ChildCardData.Armor;
			cardData.MaxArmor = currentCardSlotData.ChildCardData.MaxArmor;
			cardData.HP = currentCardSlotData.ChildCardData.HP;
			cardData.MaxHP = currentCardSlotData.ChildCardData.MaxHP;
			currentCardSlotData.ChildCardData.DeleteCardData();
			cardData.PutInSlotData(currentCardSlotData, true);
		}
		yield break;
	}
}
