using System;
using System.Collections;
using System.Collections.Generic;

public class EmptyTableAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		GameController.getInstance().UIController.HideBackToHomeButton();
	}

	public override void BeforeInit()
	{
		base.Data.CardSlotDatas = new List<CardSlotData>();
		for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
		{
			for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
			{
				CardSlotData cardSlotData = new CardSlotData();
				cardSlotData.SlotType = CardSlotData.Type.Grid;
				cardSlotData.GridPositionX = j;
				cardSlotData.GridPositionY = i;
				cardSlotData.TagWhiteList = 0UL;
				cardSlotData.OnlyAcceptOneCard = true;
				cardSlotData.DisplayPositionX = (float)j - 10.5f;
				cardSlotData.DisplayPositionZ = (float)(-(float)i) - 3.2f;
				cardSlotData.CurrentAreaData = base.Data;
				base.Data.CardSlotDatas.Add(cardSlotData);
				if (i == (base.Data as SpaceAreaData).CardSlotGridHeight / 2 - 1 && j == (base.Data as SpaceAreaData).CardSlotGridWidth / 2)
				{
					cardSlotData.SetChildCardData(CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("森林地下城"), true));
					cardSlotData.ChildCardData.CurrentCardSlotData = cardSlotData;
					cardSlotData.ChildCardData.CurrentAreaID = base.Data.ID;
					(base.Data as SpaceAreaData).InputToSlotData = cardSlotData;
				}
			}
		}
	}

	public override void OnGameLoaded()
	{
		base.OnGameLoaded();
	}

	public override void OnExit()
	{
	}

	public override IEnumerator OnAlreadEnter()
	{
		return base.OnAlreadEnter();
	}
}
