using System;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		base.Data.CardSlotDatas.Add(this.BossSnakeArea.CardSlot.CardSlotData);
		this.BossSnakeArea.CardSlot.CardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
	}

	public override void BeforeInit()
	{
		GameController.ins.GameData.PaiPaiBossModelPath = "Prefabs/蛇拍扁";
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Freeze;
					cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
					cardSlotData.TagWhiteList = 32768UL;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
					cardSlotData.IconIndex = 0;
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)j - 7.6f;
					cardSlotData.DisplayPositionZ = (float)(-(float)i - 4);
					cardSlotData.CurrentAreaData = base.Data;
					if ((base.Data as SpaceAreaData).GridOpenState[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j] >= 1)
					{
						cardSlotData.IconIndex = 3;
						if (!cardSlotData.Attrs.ContainsKey("Col"))
						{
							cardSlotData.Attrs.Add("Col", j % 5 - 2);
						}
						else
						{
							cardSlotData.Attrs["Col"] = j % 5 - 2;
						}
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData);
					}
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
		}
		this.BossSnakeArea = UnityEngine.Object.FindObjectOfType<BossSnakeArea>();
		this.BossSnakeArea.CardSlot.CardSlotData.CurrentAreaData = base.Data;
	}

	public override void OnExit()
	{
	}

	public BossSnakeArea BossSnakeArea;
}
