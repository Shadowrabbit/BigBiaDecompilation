﻿using System;
using System.Collections.Generic;

public class DefaultSpaceAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
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
					cardSlotData.DisplayPositionZ = (float)i - 3.2f - (float)(base.Data as SpaceAreaData).CardSlotGridHeight - 1f;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
			Card.InitCardDataByID("不华鱼屋").PutInSlotData(base.Data.CardSlotDatas[7], true);
			Card.InitCardDataByID("商会").PutInSlotData(base.Data.CardSlotDatas[9], true);
			Card.InitCardDataByID("典当行").PutInSlotData(base.Data.CardSlotDatas[11], true);
			Card.InitCardDataByID("农场").PutInSlotData(base.Data.CardSlotDatas[13], true);
			Card.InitCardDataByID("厨房").PutInSlotData(base.Data.CardSlotDatas[17], true);
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
