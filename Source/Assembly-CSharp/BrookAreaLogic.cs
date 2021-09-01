using System;
using System.Collections.Generic;
using UnityEngine;

public class BrookAreaLogic : AreaLogic
{
	public override void BeforeInit()
	{
		DungeonController.Instance.CurrentDungeonLogic = this;
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		new List<CardData>();
		List<CardData> list5 = new List<CardData>();
		List<CardData> list6 = new List<CardData>();
		List<CardData> list7 = new List<CardData>();
		List<CardData> list8 = new List<CardData>();
		List<CardData> list9 = new List<CardData>();
		new List<CardData>();
		List<CardData> list10 = new List<CardData>();
		List<CardData> list11 = new List<CardData>();
		List<CardData> list12 = new List<CardData>();
		int num = 0;
		foreach (CardData cardData in cards)
		{
			if ((cardData.CardTags & 32768UL) > 0UL && (cardData.CardTags & 524288UL) <= 0UL)
			{
				list.Add(cardData);
			}
			if ((cardData.CardTags & 65536UL) > 0UL)
			{
				list2.Add(cardData);
			}
			if ((cardData.CardTags & 16384UL) > 0UL)
			{
				list3.Add(cardData);
			}
			if ((cardData.CardTags & 131072UL) > 0UL)
			{
				list4.Add(cardData);
			}
			if ((cardData.CardTags & 262144UL) > 0UL)
			{
				list5.Add(cardData);
			}
		}
		int[] array = new int[]
		{
			10,
			5,
			4,
			4,
			4,
			3,
			3,
			3,
			2,
			1
		};
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < array[i]; j++)
			{
				CardData cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
				int num2 = i + (GameController.ins.GameData.level - 1) * 10 + 1;
				cardData2.Level = num2;
				cardData2.MaxHP = (cardData2.HP = (int)Math.Ceiling((double)((float)cardData2.wHP * ((float)(num2 * num2) + (float)(num2 * 12) * cardData2.wDHP - 1f) / 2f)));
				if ((float)cardData2.wATK > 1.34f && (float)cardData2.wATK < 1.36f)
				{
					Debug.Log(1);
				}
				cardData2._ATK = (int)Math.Ceiling((double)((float)cardData2.wATK * (Mathf.Pow((float)(num2 - 1), 2f) + (float)(num2 * 5) * cardData2.wDATK) / 3f));
				list6.Add(cardData2);
				list11.Add(CardData.CopyCardData(cardData2, true));
			}
		}
		if (list2.Count > 0)
		{
			for (int k = 0; k < 2; k++)
			{
				CardData cardData3 = list2[UnityEngine.Random.Range(0, list2.Count)];
				list7.Add(cardData3);
				list7.Add(cardData3);
				list7.Add(cardData3);
				list2.Remove(cardData3);
				list11.Insert(UnityEngine.Random.Range(0, list11.Count), CardData.CopyCardData(cardData3, true));
				list11.Insert(UnityEngine.Random.Range(0, list11.Count), CardData.CopyCardData(cardData3, true));
				list11.Insert(UnityEngine.Random.Range(0, list11.Count), CardData.CopyCardData(cardData3, true));
			}
		}
		if (list3.Count > 0)
		{
			for (int l = 0; l < 3; l++)
			{
				CardData cardData4 = list3[UnityEngine.Random.Range(0, list3.Count)];
				list8.Add(cardData4);
				list8.Add(cardData4);
				list8.Add(cardData4);
				list3.Remove(cardData4);
				list11.Insert(UnityEngine.Random.Range(0, list11.Count / 2), CardData.CopyCardData(cardData4, true));
				list11.Insert(UnityEngine.Random.Range(0, list11.Count / 2), CardData.CopyCardData(cardData4, true));
				list11.Insert(UnityEngine.Random.Range(0, list11.Count / 2), CardData.CopyCardData(cardData4, true));
			}
		}
		if (list4.Count > 0)
		{
			for (int m = 0; m < 6; m++)
			{
				CardData cardData5 = list4[UnityEngine.Random.Range(0, list4.Count)];
				list9.Add(cardData5);
				list4.Remove(cardData5);
				list11.Insert(UnityEngine.Random.Range(0, list11.Count / 2), CardData.CopyCardData(cardData5, true));
			}
		}
		if (list5.Count > 0)
		{
			for (int n = 0; n < 3; n++)
			{
				CardData cardData6 = list5[UnityEngine.Random.Range(0, list5.Count)];
				list10.Add(cardData6);
				list11.Insert(0, CardData.CopyCardData(cardData6, true));
			}
		}
		int[] gridOpenState = (base.Data as SpaceAreaData).GridOpenState;
		for (int num3 = 0; num3 < gridOpenState.Length; num3++)
		{
			if (gridOpenState[num3] == 1)
			{
				num++;
			}
		}
		list11.Insert(0, CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("鲨鱼牙玩具"), true));
		list11.Insert(0, CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("投篮玩具"), true));
		int count = list11.Count;
		for (int num4 = 1; num4 < num - count; num4++)
		{
			CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("空区域");
			int index = UnityEngine.Random.Range(0, list11.Count);
			list11.Insert(index, CardData.CopyCardData(cardDataByModID, true));
		}
		CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口");
		list11.Insert(0, CardData.CopyCardData(cardDataByModID2, true));
		for (int num5 = 0; num5 < 0; num5++)
		{
			int index2 = UnityEngine.Random.Range(0, list11.Count);
			int index3 = UnityEngine.Random.Range(0, list11.Count);
			CardData value = list11[index2];
			list11[index2] = list11[index3];
			list11[index3] = value;
		}
		for (int num6 = 0; num6 < list11.Count; num6++)
		{
			if (list11[num6].ModID != "地下城入口")
			{
				CardData cardDataByModID3 = GameController.getInstance().CardDataModMap.getCardDataByModID("地下城卡背");
				if (!cardDataByModID3.Attrs.ContainsKey("CardModId"))
				{
					cardDataByModID3.Attrs.Add("CardModId", list11[num6].ModID);
				}
				else
				{
					cardDataByModID3.Attrs["CardModId"] = list11[num6].ModID;
				}
				if (!cardDataByModID3.Attrs.ContainsKey("CardLevel"))
				{
					cardDataByModID3.Attrs.Add("CardLevel", list11[num6].Level);
				}
				else
				{
					cardDataByModID3.Attrs["CardLevel"] = list11[num6].Level;
				}
				list12.Add(CardData.CopyCardData(cardDataByModID3, true));
			}
			else
			{
				CardData cardData7 = list11[num6];
				list12.Add(CardData.CopyCardData(cardData7, true));
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int num7 = 0; num7 < (base.Data as SpaceAreaData).CardSlotGridHeight; num7++)
			{
				for (int num8 = 0; num8 < (base.Data as SpaceAreaData).CardSlotGridWidth; num8++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Grid;
					cardSlotData.GridPositionX = num8;
					cardSlotData.GridPositionY = num7;
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)num8 - 9.5f;
					cardSlotData.DisplayPositionZ = (float)(-(float)num7) - 3.2f;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
			int num9 = 0;
			int num10 = UnityEngine.Random.Range(0, base.Data.CardSlotDatas.Count);
			while ((base.Data as SpaceAreaData).GridOpenState[num10] == 0)
			{
				num10 = UnityEngine.Random.Range(0, base.Data.CardSlotDatas.Count);
			}
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array2 = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			queue.Enqueue(base.Data.CardSlotDatas[num10]);
			for (int num11 = 0; num11 < base.Data.CardSlotDatas.Count; num11++)
			{
				CardSlotData cardSlotData2 = queue.Dequeue();
				if (array2[cardSlotData2.GridPositionY, cardSlotData2.GridPositionX] != 0)
				{
					num11--;
				}
				else
				{
					array2[cardSlotData2.GridPositionY, cardSlotData2.GridPositionX] = 1;
					if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData2.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData2.GridPositionX] >= 1)
					{
						if (list12[num9] != null)
						{
							list12[num9].PutInSlotData(cardSlotData2, true);
							if (list12[num9].ModID == "地下城入口")
							{
								list12[num9].CurrentCardSlotData.MarkFlipState(true);
							}
							if (list11[num9].HasTag(TagMap.怪物))
							{
								cardSlotData2.SlotType = CardSlotData.Type.Freeze;
							}
						}
						num9++;
					}
					if (cardSlotData2.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
					{
						queue.Enqueue((base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData2.GridPositionX, cardSlotData2.GridPositionY, 1, 0, false));
					}
					if (cardSlotData2.GridPositionX > 0)
					{
						queue.Enqueue((base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData2.GridPositionX, cardSlotData2.GridPositionY, -1, 0, false));
					}
					if (cardSlotData2.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
					{
						queue.Enqueue((base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData2.GridPositionX, cardSlotData2.GridPositionY, 0, 1, false));
					}
					if (cardSlotData2.GridPositionY > 0)
					{
						queue.Enqueue((base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData2.GridPositionX, cardSlotData2.GridPositionY, 0, -1, false));
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
	}

	public override void OnExit()
	{
	}

	private static GameObject m_PotionIndicatorCardPrefab;
}
