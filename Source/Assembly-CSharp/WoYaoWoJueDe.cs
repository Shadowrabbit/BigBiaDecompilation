using System;
using System.Collections;
using System.Collections.Generic;

public class WoYaoWoJueDe : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_我要我觉得");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_我要我觉得");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_我要我觉得");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_我要我觉得");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData || target.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) || target.ChildCardData.HasTag(TagMap.BOSS))
		{
			yield break;
		}
		List<string> list = new List<string>();
		foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
		{
			if (cardSlotData.ChildCardData != null && !cardSlotData.ChildCardData.HasTag(TagMap.BOSS) && !cardSlotData.ChildCardData.ModID.Equals(target.ChildCardData.ModID) && !list.Contains(cardSlotData.ChildCardData.ModID))
			{
				list.Add(cardSlotData.ChildCardData.ModID);
			}
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			string modId = list[SYNCRandom.Range(0, list.Count)];
			CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(modId), true);
			cardData.CardTags = target.ChildCardData.CardTags;
			cardData._ATK = target.ChildCardData._ATK;
			cardData._AttackTimes = target.ChildCardData.AttackTimes;
			cardData.Armor = target.ChildCardData.Armor;
			cardData.MaxArmor = target.ChildCardData.MaxArmor;
			cardData.HP = target.ChildCardData.HP;
			cardData.MaxHP = target.ChildCardData.MaxHP;
			target.ChildCardData.HP = 0;
			target.ChildCardData.DeleteCardData();
			cardData.PutInSlotData(target, true);
		}
		yield break;
	}
}
