using System;
using System.Collections;
using System.Collections.Generic;

public class MeiDunBuBingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_137");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_137");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_137");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_137");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.mergeCards.Add(mergeBy);
	}

	public override IEnumerator OnBattleEnd()
	{
		CardData cardData = this.CardData.Attrs["OriginMinion"] as CardData;
		if (cardData != null)
		{
			CardSlotData currentCardSlotData = this.CardData.CurrentCardSlotData;
			foreach (CardData cardData2 in base.GetAllCurrentMinions())
			{
				if (cardData2 != this.CardData)
				{
					foreach (CardLogic cardLogic in cardData2.CardLogics)
					{
						if (cardLogic is TwoPeopleCardLogic)
						{
							TwoPeopleCardLogic twoPeopleCardLogic = (TwoPeopleCardLogic)cardLogic;
							if (twoPeopleCardLogic.TargetID == this.CardData.ID)
							{
								twoPeopleCardLogic.TargetID = cardData.ID;
							}
						}
					}
				}
			}
			this.CardData.DeleteCardData();
			cardData.PutInSlotData(currentCardSlotData, true);
			using (List<CardData>.Enumerator enumerator = this.mergeCards.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData3 = enumerator.Current;
					cardData.MergeBy(cardData3, true, false);
				}
				yield break;
			}
		}
		yield break;
	}

	public List<CardData> mergeCards = new List<CardData>();

	public List<CardData> Targets = new List<CardData>();
}
