using System;
using System.Collections.Generic;

public class EmptyRoomAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Grid;
					cardSlotData.TagWhiteList = 32UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)j - 9.52f;
					cardSlotData.DisplayPositionZ = (float)(-(float)i) - 3.2f;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
		}
	}

	public override void OnExit()
	{
	}
}
