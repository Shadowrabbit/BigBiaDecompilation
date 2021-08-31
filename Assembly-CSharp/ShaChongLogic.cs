using System;
using System.Collections;
using System.Collections.Generic;

public class ShaChongLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_80");
		this.Desc = "攻击后，若自身有护甲，则在地方区域创造一个[沙坑]";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_80");
		this.Desc = "攻击后，若自身有护甲，则在地方区域创造一个[沙坑]";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && this.CardData.Armor > 0)
		{
			List<CardSlotData> list = new List<CardSlotData>();
			foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
			{
				if (cardSlotData.ChildCardData == null)
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count > 0)
			{
				base.ShowMe();
				CardSlotData cardSlotData2 = list[SYNCRandom.Range(0, list.Count)];
				cardSlotData2.SlotType = CardSlotData.Type.Freeze;
				Card.InitCardDataByID("沙坑").PutInSlotData(cardSlotData2, true);
				this.m_Targets.Add(cardSlotData2, 0);
			}
		}
		yield break;
	}

	private Dictionary<CardSlotData, int> m_Targets = new Dictionary<CardSlotData, int>();
}
