using System;
using System.Collections.Generic;
using UnityEngine;

public class BossCthulhuAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		base.Data.CardSlotDatas.Add(this.BossCSLArea.CardSlot.CardSlotData);
		this.BossCSLArea.CardSlot.CardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
	}

	public override void BeforeInit()
	{
		GameController.ins.GameData.PaiPaiBossModelPath = "Prefabs/克苏鲁_拍扁用";
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
					cardSlotData.IconIndex = 0;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
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
		this.BossCSLArea = UnityEngine.Object.FindObjectOfType<BossCSLArea>();
		this.BossCSLArea.CardSlot.CardSlotData.CurrentAreaData = base.Data;
	}

	public override void OnExit()
	{
	}

	public BossCSLArea BossCSLArea;
}
