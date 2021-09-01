using System;
using System.Collections;
using System.Collections.Generic;

public class VSPlayAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
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
		DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
		base.Data.CardSlotDatas = new List<CardSlotData>();
		for (int j = 1; j < (base.Data as SpaceAreaData).CardSlotGridHeight; j++)
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
					if (cardSlotData.SlotType != CardSlotData.Type.OnlyTake)
					{
						cardSlotData.SlotType = CardSlotData.Type.Freeze;
					}
					cardSlotData.IconIndex = 3;
					cardSlotData.SlotType = CardSlotData.Type.OnlyTake;
					VSPlayController.Instance.P1AreaSlots.Add(cardSlotData);
				}
				if (k < 12 && k > 8 && j > 3)
				{
					if (cardSlotData.SlotType != CardSlotData.Type.OnlyTake)
					{
						cardSlotData.SlotType = CardSlotData.Type.Freeze;
					}
					cardSlotData.IconIndex = 3;
					cardSlotData.GridPositionX = k - 9;
					cardSlotData.GridPositionY = j - 4;
					if (!cardSlotData.Attrs.ContainsKey("Col"))
					{
						cardSlotData.Attrs.Add("Col", k % 9);
					}
					DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData);
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
		CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("战斗核心"), true);
		cardData.PutInSlotData(DungeonOperationMgr.Instance.BattleArea[1], true);
		VSModeController.Instance.OPBattleCore = cardData;
	}

	public override IEnumerator OnAlreadEnter()
	{
		VSModeController.Instance.StateChange(VSModeController.GameStateType.NotStart);
		DungeonOperationMgr.Instance.IsVSMode = true;
		return base.OnAlreadEnter();
	}

	public override void OnExit()
	{
	}
}
