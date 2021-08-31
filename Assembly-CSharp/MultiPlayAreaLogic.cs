using System;
using System.Collections;
using System.Collections.Generic;

public class MultiPlayAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas != null && base.Data.CardSlotDatas.Count != 0)
		{
			return;
		}
		DungeonController.Instance.CurrentDungeonLogic = this;
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		int num = 0;
		int[] gridOpenState = (base.Data as SpaceAreaData).GridOpenState;
		for (int i = 0; i < gridOpenState.Length; i++)
		{
			if (gridOpenState[i] == 1)
			{
				num++;
			}
		}
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口");
		DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridHeight; j++)
			{
				for (int k = 0; k < (base.Data as SpaceAreaData).CardSlotGridWidth; k++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Freeze;
					cardSlotData.IconIndex = 0;
					cardSlotData.GridPositionX = k;
					cardSlotData.GridPositionY = j;
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)k * 1.05f - 9.9f;
					cardSlotData.DisplayPositionZ = (float)(-(float)j) - 3.2f;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
					if (k < 7 && k > 3 && j > 4)
					{
						cardSlotData.SlotType = CardSlotData.Type.OnlyTake;
						MultiPlayArea.Instance.P1AreaSlots.Add(cardSlotData);
					}
					if (k < 17 && k > 13 && j > 4)
					{
						MultiPlayArea.Instance.P2AreaSlots.Add(cardSlotData);
					}
					if (k < 12 && k > 8 && j > 2)
					{
						if (!cardSlotData.Attrs.ContainsKey("Col"))
						{
							cardSlotData.Attrs.Add("Col", k % 9);
						}
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData);
					}
				}
			}
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			for (int l = 0; l < base.Data.CardSlotDatas.Count; l++)
			{
				CardSlotData cardSlotData2 = base.Data.CardSlotDatas[l];
				if (array[cardSlotData2.GridPositionY, cardSlotData2.GridPositionX] != 0)
				{
					l--;
				}
				else
				{
					array[cardSlotData2.GridPositionY, cardSlotData2.GridPositionX] = 1;
					if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData2.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData2.GridPositionX] >= 1)
					{
						if (cardSlotData2.SlotType != CardSlotData.Type.OnlyTake)
						{
							cardSlotData2.SlotType = CardSlotData.Type.Freeze;
						}
						cardSlotData2.IconIndex = 3;
					}
					if (cardSlotData2.GridPositionX == 12 && cardSlotData2.GridPositionY == 6)
					{
						cardDataByModID.PutInSlotData(cardSlotData2, true);
					}
				}
			}
		}
	}

	public override void BeforeEnter()
	{
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				DungeonOperationMgr.Instance.AddChain(cardSlotData);
				cardSlotData.ChildCardData.ModID == "地下城入口";
			}
		}
	}

	public override IEnumerator OnAlreadEnter()
	{
		MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.NotStart);
		DungeonOperationMgr.Instance.IsCoopMode = true;
		return base.OnAlreadEnter();
	}

	public override void OnExit()
	{
	}
}
