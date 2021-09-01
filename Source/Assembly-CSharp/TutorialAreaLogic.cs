using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		GameController.ins.GameData.DungeonTheme = DungeonTheme.Tutorial;
		GameController.ins.GameData.CurrentDungeonType = GameData.DungeonType.Scene;
		GameController.getInstance().CreatePlayer("血条");
		DungeonController.Instance.StartNewDungeon();
		DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
		if (base.Data.CardSlotDatas != null && base.Data.CardSlotDatas.Count != 0)
		{
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					CardSlotData cardSlotData = base.Data.CardSlotDatas[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j];
					if (j >= 4 && j <= 6 && i > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData);
						cardSlotData.IconIndex = 3;
						if (!cardSlotData.Attrs.ContainsKey("Col"))
						{
							cardSlotData.Attrs.Add("Col", j - 4);
						}
					}
				}
			}
			return;
		}
		GameController.ins.GameData.StepInDungeon = 0;
		DungeonController.Instance.CurrentDungeonLogic = this;
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		int num = 0;
		int[] gridOpenState = (base.Data as SpaceAreaData).GridOpenState;
		for (int k = 0; k < gridOpenState.Length; k++)
		{
			if (gridOpenState[k] > 0)
			{
				num++;
			}
		}
		CardData item = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("指引之门"), true);
		list.Add(item);
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("引导酒馆1");
		list.Add(CardData.CopyCardData(cardDataByModID, true));
		CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID("教程怪物");
		list.Add(CardData.CopyCardData(cardDataByModID2, true));
		list.Add(CardData.CopyCardData(cardDataByModID2, true));
		list.Add(CardData.CopyCardData(cardDataByModID2, true));
		CardData cardDataByModID3 = GameController.getInstance().CardDataModMap.getCardDataByModID("引导出口");
		if (cardDataByModID3 != null)
		{
			list.Add(CardData.CopyCardData(cardDataByModID3, true));
		}
		for (int l = 0; l < list.Count; l++)
		{
			if (list[l] != null && (list[l].ModID == "指引之门" || list[l].ModID == "地下城结界"))
			{
				CardData cardData = list[l];
				list2.Add(CardData.CopyCardData(cardData, true));
			}
			else
			{
				CardData cardData2;
				if (list[l] != null && list[l].ModID == "Boss")
				{
					cardData2 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
				}
				else if (list[l] != null && list[l].HasAttr("CardBack"))
				{
					cardData2 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Data.CardBack), true);
					cardData2.Model = list[l].GetAttr("CardBack");
				}
				else
				{
					cardData2 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Data.CardBack), true);
				}
				if (list[l] != null)
				{
					if (!cardData2.Attrs.ContainsKey("CardModId"))
					{
						cardData2.Attrs.Add("CardModId", list[l].ModID);
					}
					else
					{
						cardData2.Attrs["CardModId"] = list[l].ModID;
					}
					if (!cardData2.Attrs.ContainsKey("CardLevel"))
					{
						cardData2.Attrs.Add("CardLevel", list[l].Level);
					}
					else
					{
						cardData2.Attrs["CardLevel"] = list[l].Level;
					}
					if (!cardData2.Attrs.ContainsKey("Distance"))
					{
						cardData2.Attrs.Add("Distance", l);
					}
					else
					{
						cardData2.Attrs["Distance"] = list[l].Level;
					}
					if (!cardData2.Attrs.ContainsKey("Theme"))
					{
						string text = base.Data.Attrs["Theme"] as string;
						if (text != null)
						{
							if (!(text == "Normal"))
							{
								if (!(text == "Forest"))
								{
									if (!(text == "Desert"))
									{
										if (text == "Tutorial")
										{
											cardData2.Attrs.Add("Theme", DungeonTheme.Normal);
										}
									}
									else
									{
										cardData2.Attrs.Add("Theme", DungeonTheme.Desert);
									}
								}
								else
								{
									cardData2.Attrs.Add("Theme", DungeonTheme.Forest);
								}
							}
							else
							{
								cardData2.Attrs.Add("Theme", DungeonTheme.Normal);
							}
						}
					}
					else
					{
						string text = base.Data.Attrs["Theme"] as string;
						if (text != null)
						{
							if (!(text == "Normal"))
							{
								if (!(text == "Forest"))
								{
									if (text == "Desert")
									{
										cardData2.Attrs["Theme"] = DungeonTheme.Desert;
									}
								}
								else
								{
									cardData2.Attrs["Theme"] = DungeonTheme.Forest;
								}
							}
							else
							{
								cardData2.Attrs["Theme"] = DungeonTheme.Normal;
							}
						}
					}
					if (!cardData2.Attrs.ContainsKey("EncounterType"))
					{
						cardData2.Attrs.Add("EncounterType", EncounterType.CUSTOM);
					}
					if (GameController.ins.GameData.level == 1 && GameController.ins.GameData.StepInDungeon < 8)
					{
						if (!cardData2.Attrs.ContainsKey("EnemyCount"))
						{
							cardData2.Attrs.Add("EnemyCount", UnityEngine.Random.Range(2, 4));
						}
						else
						{
							cardData2.Attrs["EnemyCount"] = UnityEngine.Random.Range(2, 4);
						}
					}
					else if (!cardData2.Attrs.ContainsKey("EnemyCount"))
					{
						cardData2.Attrs.Add("EnemyCount", UnityEngine.Random.Range(3, 10));
					}
					else
					{
						cardData2.Attrs["EnemyCount"] = UnityEngine.Random.Range(3, 10);
					}
					if (list[l].Attrs.ContainsKey("Elite"))
					{
						cardData2.Attrs.Add("Elite", "true");
					}
				}
				list2.Add(cardData2);
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int m = 0; m < (base.Data as SpaceAreaData).CardSlotGridHeight; m++)
			{
				for (int n = 0; n < (base.Data as SpaceAreaData).CardSlotGridWidth; n++)
				{
					CardSlotData cardSlotData2 = new CardSlotData();
					cardSlotData2.SlotType = CardSlotData.Type.Freeze;
					cardSlotData2.IconIndex = 0;
					cardSlotData2.GridPositionX = n;
					cardSlotData2.GridPositionY = m;
					cardSlotData2.TagWhiteList = 0UL;
					cardSlotData2.OnlyAcceptOneCard = true;
					cardSlotData2.DisplayPositionX = (float)n - 9.7f;
					cardSlotData2.DisplayPositionZ = (float)(-(float)m) - 3.2f;
					cardSlotData2.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData2);
					if (n >= 4 && n <= 6 && m > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
						cardSlotData2.IconIndex = 3;
						cardSlotData2.Attrs.Add("Col", n - 4);
					}
				}
			}
			List<int> list3 = new List<int>();
			Dictionary<CardSlotData, int> dictionary = new Dictionary<CardSlotData, int>();
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num2 = 0;
			for (int num3 = 0; num3 < base.Data.CardSlotDatas.Count; num3++)
			{
				CardSlotData cardSlotData3 = base.Data.CardSlotDatas[num3];
				if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 2)
				{
					queue.Enqueue(cardSlotData3);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					dictionary.Add(cardSlotData3, 0);
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 0)
				{
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
			}
			while (queue.Count > 0 && num2 < list2.Count)
			{
				CardSlotData cardSlotData4 = queue.Dequeue();
				int num4 = dictionary[cardSlotData4];
				list3.Add(num4);
				cardSlotData4.SlotType = CardSlotData.Type.Freeze;
				cardSlotData4.IconIndex = 3;
				if (list2[num2] != null)
				{
					list2[num2].PutInSlotData(cardSlotData4, true);
					cardSlotData4.Attrs.Add("EnemyDifficult", num4);
					if (list2[num2].ModID == "指引之门")
					{
						list2[num2].CurrentCardSlotData.MarkFlipState(true);
						DungeonOperationMgr.Instance.CurrentPositionInMap = list2[num2].CurrentCardSlotData;
					}
					cardSlotData4.SlotType = CardSlotData.Type.Freeze;
					num2++;
				}
				if (cardSlotData4.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] == 0)
					{
						CardSlotData ralitiveCardSlotData = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 1, 0, false);
						queue.Enqueue(ralitiveCardSlotData);
						dictionary.Add(ralitiveCardSlotData, num4 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] = 1;
				}
				if (cardSlotData4.GridPositionX > 0)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] == 0)
					{
						CardSlotData ralitiveCardSlotData2 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, -1, 0, false);
						queue.Enqueue(ralitiveCardSlotData2);
						dictionary.Add(ralitiveCardSlotData2, num4 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] = 1;
				}
				if (cardSlotData4.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					if (array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData3 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, 1, false);
						queue.Enqueue(ralitiveCardSlotData3);
						dictionary.Add(ralitiveCardSlotData3, num4 + 1);
					}
					array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] = 1;
				}
				if (cardSlotData4.GridPositionY > 0)
				{
					if (array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData4 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, -1, false);
						queue.Enqueue(ralitiveCardSlotData4);
						dictionary.Add(ralitiveCardSlotData4, num4 + 1);
					}
					array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] = 1;
				}
			}
		}
		foreach (CardSlotData cardSlotData5 in GameController.getInstance().PlayerSlotSets)
		{
			if (cardSlotData5.ChildCardData != null && cardSlotData5.ChildCardData.HasTag(TagMap.英雄))
			{
				cardSlotData5.ChildCardData.HP -= 43;
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
		for (int i = 0; i < base.Data.CardSlotDatas.Count; i++)
		{
			CardSlotData cardSlotData = base.Data.CardSlotDatas[i];
			if (cardSlotData.ChildCardData != null)
			{
				DungeonOperationMgr.Instance.AddChain(cardSlotData);
				cardSlotData.ChildCardData.ModID == "指引之门";
			}
		}
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().ShowGuideCanvas(0, 1);
		if (this.ChessmanCurrentSlot != null)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = this.ChessmanCurrentSlot;
		}
		yield return DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(false, false, null));
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		UIController.LockLevel = UIController.UILevel.None;
		yield return base.OnAlreadEnter();
		yield break;
	}

	public override void OnExit()
	{
		this.ChessmanCurrentSlot = DungeonOperationMgr.Instance.CurrentPositionInMap;
		GridIndicate.Instance.HideGird();
		DungeonController.Instance.Chessman.gameObject.transform.SetParent(GameController.ins.PlayerCardSlot.transform);
		DungeonController.Instance.Chessman.gameObject.SetActive(false);
		DungeonOperationMgr.Instance.CurrentPositionInMap = null;
		DungeonOperationMgr.Instance.BattleArea = null;
	}

	public CardSlotData ChessmanCurrentSlot;

	private bool isBossCreate;

	private static GameObject m_PotionIndicatorCardPrefab;
}
