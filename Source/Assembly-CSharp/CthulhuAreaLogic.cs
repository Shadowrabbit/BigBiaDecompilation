using System;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		base.Data.CardSlotDatas.Add(this.BossCSLArea.CardSlot.CardSlotData);
		this.BossCSLArea.CardSlot.CardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
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
					cardSlotData.SlotType = CardSlotData.Type.Freeze;
					cardSlotData.IconIndex = 0;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)j - 6.5f;
					cardSlotData.DisplayPositionZ = -9.2f + (float)i;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
		}
		this.BossCSLArea = UnityEngine.Object.FindObjectOfType<BossCSLArea>();
		this.BossCSLArea.CardSlot.CardSlotData.CurrentAreaData = base.Data;
	}

	public override void OnExit()
	{
	}

	public BossCSLArea BossCSLArea;
}
