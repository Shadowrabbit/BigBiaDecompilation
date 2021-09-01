using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessDungeonAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas != null && base.Data.CardSlotDatas.Count != 0)
		{
			return;
		}
		DungeonController.Instance.CurrentDungeonLogic = this;
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		new Dictionary<int, List<CardData>>();
		new List<CardData>();
		new List<CardData>();
		int num = 0;
		int[] gridOpenState = (base.Data as SpaceAreaData).GridOpenState;
		for (int i = 0; i < gridOpenState.Length; i++)
		{
			if (gridOpenState[i] == 1)
			{
				num++;
			}
		}
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("无尽结界");
		CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID("酒馆");
		CardData cardDataByModID3 = GameController.getInstance().CardDataModMap.getCardDataByModID("商铺");
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
				}
			}
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num2 = 0;
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
						cardSlotData2.SlotType = CardSlotData.Type.Freeze;
						cardSlotData2.IconIndex = 3;
						num2++;
					}
					if (cardSlotData2.GridPositionX == 18 && cardSlotData2.GridPositionY == 6)
					{
						cardDataByModID.PutInSlotData(cardSlotData2, true);
					}
					if (cardSlotData2.GridPositionX == 12 && cardSlotData2.GridPositionY == 5)
					{
						cardDataByModID2.PutInSlotData(cardSlotData2, true);
					}
					if (cardSlotData2.GridPositionX == 14 && cardSlotData2.GridPositionY == 5)
					{
						cardDataByModID3.PutInSlotData(cardSlotData2, true);
					}
				}
			}
		}
	}

	private CardData m_PlayerCardData
	{
		get
		{
			return GameController.getInstance().GameData.PlayerCardData;
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
		if (GameController.ins.GameData.level == 1 && this.IsFirstEnter)
		{
			ActData actData = new ActData();
			actData.Type = "Act/RuneAct";
			actData.Model = "ActTable/加工";
			GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData);
		}
		UnityEngine.Object.Instantiate<GameObject>(ResourceManager.Instance.LoadResource("Newspaper/Endless/Newspaper"));
		return base.OnAlreadEnter();
	}

	public override void OnExit()
	{
	}

	private static GameObject m_PotionIndicatorCardPrefab;
}
