using System;
using System.Collections.Generic;

public class ToyRoomAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		base.Data.CardSlotDatas = new List<CardSlotData>();
		for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
		{
			for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
			{
				CardSlotData cardSlotData = new CardSlotData();
				cardSlotData.SlotType = CardSlotData.Type.Normal;
				cardSlotData.GridPositionX = j;
				cardSlotData.GridPositionY = i;
				cardSlotData.TagWhiteList = 0UL;
				cardSlotData.OnlyAcceptOneCard = true;
				cardSlotData.DisplayPositionX = (float)j - 9.5f;
				cardSlotData.DisplayPositionZ = (float)i - 3.2f - (float)(base.Data as SpaceAreaData).CardSlotGridHeight + 1f;
				cardSlotData.CurrentAreaData = base.Data;
				base.Data.CardSlotDatas.Add(cardSlotData);
			}
		}
		List<CardData> cards = GameController.ins.CardDataModMap.Cards;
		int k = 0;
		int num = 0;
		while (k < cards.Count)
		{
			if (cards[k].HasTag(TagMap.玩具房间))
			{
				Card.InitCardDataByID(cards[k].ModID).PutInSlotData(base.Data.CardSlotDatas[num++], true);
			}
			k++;
		}
	}

	public override void OnGameLoaded()
	{
		base.OnGameLoaded();
	}

	public override void OnExit()
	{
	}
}
