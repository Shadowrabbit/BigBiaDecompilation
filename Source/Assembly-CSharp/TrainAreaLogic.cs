using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
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
						cardSlotData.SlotType = CardSlotData.Type.Normal;
						if (!cardSlotData.Attrs.ContainsKey("Col"))
						{
							cardSlotData.Attrs.Add("Col", j - 4);
						}
						cardSlotData.TagWhiteList = 32768UL;
					}
				}
			}
			return;
		}
		GameController.ins.GameData.StepInDungeon = 0;
		DungeonController.Instance.CurrentDungeonLogic = this;
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		Dictionary<int, List<CardData>> dictionary = new Dictionary<int, List<CardData>>();
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		List<CardData> list5 = new List<CardData>();
		List<CardData> list6 = new List<CardData>();
		List<CardData> list7 = new List<CardData>();
		int num = 0;
		int[] gridOpenState = (base.Data as SpaceAreaData).GridOpenState;
		for (int k = 0; k < gridOpenState.Length; k++)
		{
			if (gridOpenState[k] > 0)
			{
				num++;
			}
		}
		foreach (CardData cardData in cards)
		{
			if (!base.Data.Attrs.ContainsKey("Theme") || !cardData.Attrs.ContainsKey("Theme") || !(base.Data.Attrs["Theme"].ToString() != cardData.Attrs["Theme"].ToString()) || !(cardData.Attrs["Theme"].ToString() != "Normal"))
			{
				if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.BOSS))
				{
					if (cardData.Level <= 0)
					{
						cardData.Level = 1;
					}
					if (!dictionary.ContainsKey(cardData.Level))
					{
						dictionary.Add(cardData.Level, new List<CardData>());
					}
					dictionary[cardData.Level].Add(cardData);
				}
				if ((cardData.CardTags & 1048576UL) > 0UL)
				{
					list.Add(cardData);
				}
				if ((cardData.CardTags & 16777216UL) > 0UL && cardData.HasTag(TagMap.基本))
				{
					list2.Add(cardData);
				}
			}
		}
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("事件酒馆");
		CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID("商铺");
		float num2 = 25f;
		int num3 = (list.Count > 0) ? 1 : 0;
		int num4 = 2;
		if (GameController.ins.GameData.level == 1)
		{
			num4 = 2;
		}
		int num5 = 0;
		int num6 = (Mathf.RoundToInt((float)num / num2 * 1f) > 1) ? Mathf.RoundToInt((float)num / num2 * 1f) : 1;
		int num7 = (Mathf.RoundToInt((float)num / num2 * 1f) > 1) ? Mathf.RoundToInt((float)num / num2 * 1f) : 1;
		int num8 = (Mathf.RoundToInt((float)num / num2 * 2f) > 1) ? Mathf.RoundToInt((float)num / num2 * 2f) : 1;
		int num9 = 0;
		int num10 = 0;
		int num11 = num - num3 - num9 - num10 - num8 - num5 - num4 - 1;
		UnityEngine.Random.Range(num11 / 2, num11);
		for (int l = 0; l < num11; l++)
		{
			CardData item = Card.InitCardDataByID("未知怪物");
			list3.Add(item);
			list6.Add(item);
		}
		if (list.Count > 0)
		{
			for (int m = 0; m < num3; m++)
			{
				CardData cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
				list4.Add(cardData2);
				list6.Insert(UnityEngine.Random.Range(0, list6.Count), CardData.CopyCardData(cardData2, true));
			}
		}
		if (cardDataByModID2 != null && num10 > 0)
		{
			int num12 = UnityEngine.Random.Range(2, list6.Count / num10);
			for (int n = 0; n < num10; n++)
			{
				int index = num12 + n * list6.Count / num10;
				list6.Insert(index, CardData.CopyCardData(cardDataByModID2, true));
			}
		}
		CardData cardDataByModID3 = GameController.getInstance().CardDataModMap.getCardDataByModID("事件篝火");
		if (cardDataByModID3 != null && num9 > 0)
		{
			for (int num13 = 0; num13 < num9; num13++)
			{
				list6.Insert(UnityEngine.Random.Range(list6.Count / 3, list6.Count), CardData.CopyCardData(cardDataByModID3, true));
			}
		}
		if (cardDataByModID != null)
		{
			for (int num14 = 0; num14 < num8; num14++)
			{
				CardData item2 = list2[UnityEngine.Random.Range(0, list2.Count)];
				list5.Add(item2);
				list6.Insert(UnityEngine.Random.Range(2, list6.Count), item2);
			}
		}
		if (cardDataByModID != null)
		{
			int num15 = UnityEngine.Random.Range(list6.Count / (num5 + 1) - 3, list6.Count / (num5 + 1));
			for (int num16 = 0; num16 < num5; num16++)
			{
				int index2 = num15 + num16 * list6.Count / (num5 + 1);
				list6.Insert(index2, CardData.CopyCardData(cardDataByModID, true));
			}
		}
		CardData cardData3 = GameController.getInstance().CardDataModMap.getCardDataByModID("下层入口");
		if (cardData3 != null)
		{
			list6.Add(CardData.CopyCardData(cardData3, true));
		}
		CardData cardDataByModID4 = GameController.getInstance().CardDataModMap.getCardDataByModID("精英怪物");
		list6.Add(cardDataByModID4);
		CardData cardDataByModID5 = GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口");
		list6.Insert(0, CardData.CopyCardData(cardDataByModID5, true));
		for (int num17 = 0; num17 < list6.Count; num17++)
		{
			if (list6[num17] != null && (list6[num17].ModID == "地下城入口" || list6[num17].ModID == "地下城结界"))
			{
				CardData cardData4 = list6[num17];
				list7.Add(CardData.CopyCardData(cardData4, true));
			}
			else
			{
				CardData cardData5;
				if (list6[num17] != null && list6[num17].ModID == "Boss")
				{
					cardData5 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
				}
				else if (list6[num17] != null && list6[num17].ModID == "下层入口")
				{
					cardData5 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Data.CardBack), true);
					cardData3 = cardData5;
				}
				else
				{
					cardData5 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Data.CardBack), true);
				}
				if (list6[num17] != null && list6[num17].HasAttr("CardBack"))
				{
					cardData5.Model = list6[num17].GetAttr("CardBack");
				}
				if (list6[num17] != null)
				{
					if (!cardData5.Attrs.ContainsKey("CardModId"))
					{
						cardData5.Attrs.Add("CardModId", list6[num17].ModID);
					}
					else
					{
						cardData5.Attrs["CardModId"] = list6[num17].ModID;
					}
					if (!cardData5.Attrs.ContainsKey("CardLevel"))
					{
						cardData5.Attrs.Add("CardLevel", list6[num17].Level);
					}
					else
					{
						cardData5.Attrs["CardLevel"] = list6[num17].Level;
					}
					if (!cardData5.Attrs.ContainsKey("Distance"))
					{
						cardData5.Attrs.Add("Distance", num17);
					}
					else
					{
						cardData5.Attrs["Distance"] = list6[num17].Level;
					}
					if (!cardData5.Attrs.ContainsKey("Theme"))
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
											cardData5.Attrs.Add("Theme", DungeonTheme.Tutorial);
										}
									}
									else
									{
										cardData5.Attrs.Add("Theme", DungeonTheme.Desert);
									}
								}
								else
								{
									cardData5.Attrs.Add("Theme", DungeonTheme.Forest);
								}
							}
							else
							{
								cardData5.Attrs.Add("Theme", DungeonTheme.Normal);
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
									if (!(text == "Desert"))
									{
										if (text == "Tutorial")
										{
											cardData5.Attrs["Theme"] = DungeonTheme.Tutorial;
										}
									}
									else
									{
										cardData5.Attrs["Theme"] = DungeonTheme.Desert;
									}
								}
								else
								{
									cardData5.Attrs["Theme"] = DungeonTheme.Forest;
								}
							}
							else
							{
								cardData5.Attrs["Theme"] = DungeonTheme.Normal;
							}
						}
					}
					if (cardData5.ModID == "精英怪物")
					{
						cardData5.Attrs.Add("EncounterType", EncounterType.ELITE);
					}
					if (!cardData5.Attrs.ContainsKey("EncounterType"))
					{
						cardData5.Attrs.Add("EncounterType", EncounterType.CUSTOM);
					}
					if (GameController.ins.GameData.level == 1 && GameController.ins.GameData.StepInDungeon < 8)
					{
						if (!cardData5.Attrs.ContainsKey("EnemyCount"))
						{
							cardData5.Attrs.Add("EnemyCount", UnityEngine.Random.Range(2, 4));
						}
						else
						{
							cardData5.Attrs["EnemyCount"] = UnityEngine.Random.Range(2, 4);
						}
					}
					else if (!cardData5.Attrs.ContainsKey("EnemyCount"))
					{
						cardData5.Attrs.Add("EnemyCount", UnityEngine.Random.Range(3, 10));
					}
					else
					{
						cardData5.Attrs["EnemyCount"] = UnityEngine.Random.Range(3, 10);
					}
					if (list6[num17].Attrs.ContainsKey("Elite"))
					{
						cardData5.Attrs.Add("Elite", "true");
					}
				}
				list7.Add(cardData5);
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int num18 = 0; num18 < (base.Data as SpaceAreaData).CardSlotGridHeight; num18++)
			{
				for (int num19 = 0; num19 < (base.Data as SpaceAreaData).CardSlotGridWidth; num19++)
				{
					CardSlotData cardSlotData2 = new CardSlotData();
					cardSlotData2.SlotType = CardSlotData.Type.Freeze;
					cardSlotData2.IconIndex = 0;
					cardSlotData2.GridPositionX = num19;
					cardSlotData2.GridPositionY = num18;
					cardSlotData2.TagWhiteList = 0UL;
					cardSlotData2.OnlyAcceptOneCard = true;
					cardSlotData2.DisplayPositionX = (float)num19 - 9.7f;
					cardSlotData2.DisplayPositionZ = (float)(-(float)num18) - 3.2f;
					cardSlotData2.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData2);
					if (num19 >= 4 && num19 <= 6 && num18 > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
						cardSlotData2.IconIndex = 3;
						cardSlotData2.Attrs.Add("Col", num19 - 4);
					}
				}
			}
			List<int> list8 = new List<int>();
			Dictionary<CardSlotData, int> dictionary2 = new Dictionary<CardSlotData, int>();
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num20 = 0;
			for (int num21 = 0; num21 < base.Data.CardSlotDatas.Count; num21++)
			{
				CardSlotData cardSlotData3 = base.Data.CardSlotDatas[num21];
				if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 2)
				{
					queue.Enqueue(cardSlotData3);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					dictionary2.Add(cardSlotData3, 0);
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 3)
				{
					cardData3.PutInSlotData(cardSlotData3, true);
					list7.Remove(cardData3);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 0)
				{
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
			}
			while (queue.Count > 0 && num20 < list7.Count)
			{
				CardSlotData cardSlotData4 = queue.Dequeue();
				int num22 = dictionary2[cardSlotData4];
				list8.Add(num22);
				cardSlotData4.SlotType = CardSlotData.Type.Freeze;
				cardSlotData4.IconIndex = 3;
				if (list7[num20] != null)
				{
					if ((num22 - 1) % 3 == 0 && list7[num20].GetAttr("CardModId") == "未知怪物")
					{
						for (int num23 = num20 + 1; num23 < list7.Count; num23++)
						{
							if (list7[num23].GetAttr("CardModId") != "未知怪物" && list7[num23].GetAttr("CardModId") != "下层入口")
							{
								CardData value = list7[num20];
								list7[num20] = list7[num23];
								list7[num23] = value;
								break;
							}
						}
					}
					if ((num22 - 1) % 2 == 0 && list7[num20].GetAttr("CardModId") != "未知怪物")
					{
						for (int num24 = num20 + 1; num24 < list7.Count; num24++)
						{
							if (list7[num24].GetAttr("CardModId") == "未知怪物")
							{
								CardData value2 = list7[num20];
								list7[num20] = list7[num24];
								list7[num24] = value2;
								break;
							}
						}
					}
					list7[num20].PutInSlotData(cardSlotData4, true);
					cardSlotData4.Attrs.Add("EnemyDifficult", num22);
					if (list7[num20].ModID == "地下城入口")
					{
						list7[num20].CurrentCardSlotData.MarkFlipState(true);
						DungeonOperationMgr.Instance.CurrentPositionInMap = list7[num20].CurrentCardSlotData;
					}
					cardSlotData4.SlotType = CardSlotData.Type.Freeze;
					num20++;
				}
				if (cardSlotData4.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] == 0)
					{
						CardSlotData ralitiveCardSlotData = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 1, 0, false);
						queue.Enqueue(ralitiveCardSlotData);
						dictionary2.Add(ralitiveCardSlotData, num22 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] = 1;
				}
				if (cardSlotData4.GridPositionX > 0)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] == 0)
					{
						CardSlotData ralitiveCardSlotData2 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, -1, 0, false);
						queue.Enqueue(ralitiveCardSlotData2);
						dictionary2.Add(ralitiveCardSlotData2, num22 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] = 1;
				}
				if (cardSlotData4.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					if (array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData3 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, 1, false);
						queue.Enqueue(ralitiveCardSlotData3);
						dictionary2.Add(ralitiveCardSlotData3, num22 + 1);
					}
					array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] = 1;
				}
				if (cardSlotData4.GridPositionY > 0)
				{
					if (array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData4 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, -1, false);
						queue.Enqueue(ralitiveCardSlotData4);
						dictionary2.Add(ralitiveCardSlotData4, num22 + 1);
					}
					array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] = 1;
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
		for (int i = 0; i < base.Data.CardSlotDatas.Count; i++)
		{
			CardSlotData cardSlotData = base.Data.CardSlotDatas[i];
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
		if (this.ChessmanCurrentSlot != null)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = this.ChessmanCurrentSlot;
		}
		yield return DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(false, false, null));
		UIController.LockLevel = UIController.UILevel.None;
		foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.BattleArea)
		{
			cardSlotData.SlotType = CardSlotData.Type.Normal;
		}
		DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.StartBattle(false));
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
