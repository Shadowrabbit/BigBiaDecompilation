using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class XiaoHunHunSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.NeedEnergyCount = new Vector3Int(0, 3, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_129");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_129");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 3, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_129");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_129");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (CardSlotData cardSlotData in base.GetMyBattleArea())
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			CardSlotData slotData = list[SYNCRandom.Range(0, list.Count)];
			CardData cardData = Card.InitCardDataByID(LocalizationMgr.Instance.GetLocalizationWord("SC_N_68"));
			cardData._ATK = this.CardData.ATK;
			cardData.MaxHP = (cardData.HP = this.CardData.MaxHP);
			cardData.PutInSlotData(slotData, true);
		}
		yield break;
	}
}
