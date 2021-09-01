using System;
using System.Collections.Generic;

public class OldStreetAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		GameController.getInstance().UIController.ShowBackToHomeButton();
		DungeonController.Instance.CurrentDungeonLogic = this;
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					if ((base.Data as SpaceAreaData).GridOpenState[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j] != 0)
					{
						CardSlotData cardSlotData = new CardSlotData();
						cardSlotData.SlotType = CardSlotData.Type.OnlyTake;
						cardSlotData.IconIndex = 0;
						cardSlotData.GridPositionX = j;
						cardSlotData.GridPositionY = i;
						cardSlotData.TagWhiteList = 0UL;
						cardSlotData.OnlyAcceptOneCard = true;
						cardSlotData.DisplayPositionX = (float)j - 9.7f;
						cardSlotData.DisplayPositionZ = (float)(-(float)i) - 3.2f;
						cardSlotData.CurrentAreaData = base.Data;
						base.Data.CardSlotDatas.Add(cardSlotData);
					}
				}
			}
		}
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		using (List<CardData>.Enumerator enumerator = cards.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cd = enumerator.Current;
				if (base.Data.Attrs.ContainsKey("Theme") && cd.Attrs.ContainsKey("Theme") && cd.HasTag(TagMap.随从) && !cd.HasTag(TagMap.衍生物) && !cd.HasTag(TagMap.特殊) && int.Parse(base.Data.Attrs["Theme"].ToString()) == int.Parse(cd.Attrs["Theme"].ToString()) && GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData().FindAll((CardSlotData item) => item.ChildCardData != null && item.ChildCardData.ModID == cd.ModID).Count <= 0)
				{
					list.Add(cd);
				}
			}
		}
		for (int k = 0; k < base.Data.CardSlotDatas.Count; k++)
		{
			if (list.Count == 0)
			{
				return;
			}
			CardData cardData = list[SYNCRandom.Range(0, list.Count)];
			Card.InitCardDataByID(cardData.ModID).PutInSlotData(base.Data.CardSlotDatas[k], true);
			list.Remove(cardData);
		}
	}

	public override void OnExit()
	{
		base.OnExit();
		GameController.getInstance().UIController.HideBackToHomeButton();
	}

	public CardSlotData ChessmanCurrentSlot;

	private bool isBossCreate;
}
