using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class InnerDungeonAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		AreaData data = base.Data;
		CardData innerMinionCardData = GameController.ins.GameData.InnerMinionCardData;
		DialogueLua.SetVariable("TargetMinionName", innerMinionCardData.PersonName);
		DialogueLua.SetVariable("TargetMinionModID", innerMinionCardData.ModID);
		if (innerMinionCardData.Rare == 1)
		{
			(base.Data as SpaceAreaData).GridOpenState = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
		}
		else if (innerMinionCardData.Rare == 2)
		{
			(base.Data as SpaceAreaData).GridOpenState = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
		}
		else if (innerMinionCardData.Rare == 3)
		{
			(base.Data as SpaceAreaData).GridOpenState = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				1,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
		}
		else if (innerMinionCardData.Rare == 4)
		{
			(base.Data as SpaceAreaData).GridOpenState = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				1,
				1,
				1,
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
		}
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
		new List<CardData>();
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		List<CardData> list5 = new List<CardData>();
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
				if ((cardData.CardTags & 16777216UL) > 0UL && cardData.HasTag(TagMap.基本))
				{
					list.Add(cardData);
				}
			}
		}
		int num2 = GameController.ins.GameData.InnerMinionCardData.Rare + 2;
		int num3 = num - num2 - 2 - 1;
		UnityEngine.Random.Range(num3 / 2, num3);
		for (int l = 0; l < num3; l++)
		{
			CardData item = Card.InitCardDataByID("心中世界的怪物");
			list2.Add(item);
			list4.Add(item);
		}
		CardData cardData2 = GameController.getInstance().CardDataModMap.getCardDataByModID("下层入口");
		if (cardData2 != null)
		{
			list4.Add(CardData.CopyCardData(cardData2, true));
		}
		for (int m = 0; m < num2; m++)
		{
			CardData item2 = list[SYNCRandom.Range(0, list.Count)];
			list3.Add(item2);
			list4.Insert(SYNCRandom.Range(2, list4.Count), item2);
		}
		CardData item3 = Card.InitCardDataByID("心中圣坛1");
		list3.Add(item3);
		list4.Insert(SYNCRandom.Range(2, list4.Count), item3);
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口");
		list4.Insert(0, CardData.CopyCardData(cardDataByModID, true));
		for (int n = 0; n < list4.Count; n++)
		{
			if (list4[n] != null && (list4[n].ModID == "地下城入口" || list4[n].ModID == "地下城结界"))
			{
				CardData cardData3 = list4[n];
				list5.Add(CardData.CopyCardData(cardData3, true));
			}
			else
			{
				CardData cardData4;
				if (list4[n] != null && list4[n].ModID == "Boss")
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
				}
				else if (list4[n] != null && list4[n].ModID == "下层入口")
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Data.CardBack), true);
					cardData2 = cardData4;
				}
				else if (list4[n] != null && list4[n].ModID == "心中圣坛1")
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("篝火卡背"), true);
				}
				else
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Data.CardBack), true);
				}
				if (list4[n] != null && list4[n].HasAttr("CardBack"))
				{
					cardData4.Model = list4[n].GetAttr("CardBack");
				}
				if (list4[n] != null)
				{
					if (!cardData4.Attrs.ContainsKey("CardModId"))
					{
						cardData4.Attrs.Add("CardModId", list4[n].ModID);
					}
					else
					{
						cardData4.Attrs["CardModId"] = list4[n].ModID;
					}
					if (!cardData4.Attrs.ContainsKey("CardLevel"))
					{
						cardData4.Attrs.Add("CardLevel", list4[n].Level);
					}
					else
					{
						cardData4.Attrs["CardLevel"] = list4[n].Level;
					}
					if (!cardData4.Attrs.ContainsKey("Distance"))
					{
						cardData4.Attrs.Add("Distance", n);
					}
					else
					{
						cardData4.Attrs["Distance"] = list4[n].Level;
					}
					if (!cardData4.Attrs.ContainsKey("Theme"))
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
											cardData4.Attrs.Add("Theme", DungeonTheme.Tutorial);
										}
									}
									else
									{
										cardData4.Attrs.Add("Theme", DungeonTheme.Desert);
									}
								}
								else
								{
									cardData4.Attrs.Add("Theme", DungeonTheme.Forest);
								}
							}
							else
							{
								cardData4.Attrs.Add("Theme", DungeonTheme.Normal);
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
											cardData4.Attrs["Theme"] = DungeonTheme.Tutorial;
										}
									}
									else
									{
										cardData4.Attrs["Theme"] = DungeonTheme.Desert;
									}
								}
								else
								{
									cardData4.Attrs["Theme"] = DungeonTheme.Forest;
								}
							}
							else
							{
								cardData4.Attrs["Theme"] = DungeonTheme.Normal;
							}
						}
					}
					if (cardData4.ModID == "精英怪物")
					{
						cardData4.Attrs.Add("EncounterType", EncounterType.ELITE);
					}
					if (!cardData4.Attrs.ContainsKey("EncounterType"))
					{
						cardData4.Attrs.Add("EncounterType", EncounterType.CUSTOM);
					}
					if (GameController.ins.GameData.level == 1 && GameController.ins.GameData.StepInDungeon < 8)
					{
						if (!cardData4.Attrs.ContainsKey("EnemyCount"))
						{
							cardData4.Attrs.Add("EnemyCount", UnityEngine.Random.Range(2, 4));
						}
						else
						{
							cardData4.Attrs["EnemyCount"] = UnityEngine.Random.Range(2, 4);
						}
					}
					else if (!cardData4.Attrs.ContainsKey("EnemyCount"))
					{
						cardData4.Attrs.Add("EnemyCount", UnityEngine.Random.Range(3, 10));
					}
					else
					{
						cardData4.Attrs["EnemyCount"] = UnityEngine.Random.Range(3, 10);
					}
					if (list4[n].Attrs.ContainsKey("Elite"))
					{
						cardData4.Attrs.Add("Elite", "true");
					}
				}
				list5.Add(cardData4);
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int num4 = 0; num4 < (base.Data as SpaceAreaData).CardSlotGridHeight; num4++)
			{
				for (int num5 = 0; num5 < (base.Data as SpaceAreaData).CardSlotGridWidth; num5++)
				{
					CardSlotData cardSlotData2 = new CardSlotData();
					cardSlotData2.SlotType = CardSlotData.Type.Freeze;
					cardSlotData2.IconIndex = 0;
					cardSlotData2.GridPositionX = num5;
					cardSlotData2.GridPositionY = num4;
					cardSlotData2.TagWhiteList = 0UL;
					cardSlotData2.OnlyAcceptOneCard = true;
					cardSlotData2.DisplayPositionX = (float)num5 - 9.7f;
					cardSlotData2.DisplayPositionZ = (float)(-(float)num4) - 3.2f;
					cardSlotData2.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData2);
					if (num5 >= 4 && num5 <= 6 && num4 > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
						cardSlotData2.IconIndex = 3;
						cardSlotData2.Attrs.Add("Col", num5 - 4);
					}
				}
			}
			List<int> list6 = new List<int>();
			Dictionary<CardSlotData, int> dictionary2 = new Dictionary<CardSlotData, int>();
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num6 = 0;
			for (int num7 = 0; num7 < base.Data.CardSlotDatas.Count; num7++)
			{
				CardSlotData cardSlotData3 = base.Data.CardSlotDatas[num7];
				if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 2)
				{
					queue.Enqueue(cardSlotData3);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					dictionary2.Add(cardSlotData3, 0);
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 3)
				{
					cardData2.PutInSlotData(cardSlotData3, true);
					list5.Remove(cardData2);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 0)
				{
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
			}
			while (queue.Count > 0 && num6 < list5.Count)
			{
				CardSlotData cardSlotData4 = queue.Dequeue();
				int num8 = dictionary2[cardSlotData4];
				list6.Add(num8);
				cardSlotData4.SlotType = CardSlotData.Type.Freeze;
				cardSlotData4.IconIndex = 3;
				if (list5[num6] != null)
				{
					if ((num8 - 1) % 3 == 0 && list5[num6].GetAttr("CardModId") == "未知怪物")
					{
						for (int num9 = num6 + 1; num9 < list5.Count; num9++)
						{
							if (list5[num9].GetAttr("CardModId") != "未知怪物" && list5[num9].GetAttr("CardModId") != "下层入口")
							{
								CardData value = list5[num6];
								list5[num6] = list5[num9];
								list5[num9] = value;
								break;
							}
						}
					}
					if ((num8 - 1) % 2 == 0 && list5[num6].GetAttr("CardModId") != "未知怪物")
					{
						for (int num10 = num6 + 1; num10 < list5.Count; num10++)
						{
							if (list5[num10].GetAttr("CardModId") == "未知怪物")
							{
								CardData value2 = list5[num6];
								list5[num6] = list5[num10];
								list5[num10] = value2;
								break;
							}
						}
					}
					list5[num6].PutInSlotData(cardSlotData4, true);
					cardSlotData4.Attrs.Add("EnemyDifficult", num8);
					if (list5[num6].ModID == "地下城入口")
					{
						list5[num6].CurrentCardSlotData.MarkFlipState(true);
						DungeonOperationMgr.Instance.CurrentPositionInMap = list5[num6].CurrentCardSlotData;
					}
					cardSlotData4.SlotType = CardSlotData.Type.Freeze;
					num6++;
				}
				if (cardSlotData4.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] == 0)
					{
						CardSlotData ralitiveCardSlotData = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 1, 0, false);
						queue.Enqueue(ralitiveCardSlotData);
						dictionary2.Add(ralitiveCardSlotData, num8 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] = 1;
				}
				if (cardSlotData4.GridPositionX > 0)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] == 0)
					{
						CardSlotData ralitiveCardSlotData2 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, -1, 0, false);
						queue.Enqueue(ralitiveCardSlotData2);
						dictionary2.Add(ralitiveCardSlotData2, num8 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] = 1;
				}
				if (cardSlotData4.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					if (array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData3 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, 1, false);
						queue.Enqueue(ralitiveCardSlotData3);
						dictionary2.Add(ralitiveCardSlotData3, num8 + 1);
					}
					array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] = 1;
				}
				if (cardSlotData4.GridPositionY > 0)
				{
					if (array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData4 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, -1, false);
						queue.Enqueue(ralitiveCardSlotData4);
						dictionary2.Add(ralitiveCardSlotData4, num8 + 1);
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
		GameController.ins.UIController.HideCancelGameBtn();
		if (this.ChessmanCurrentSlot != null)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = this.ChessmanCurrentSlot;
		}
		yield return DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(false, false, null));
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

	private int InnerSlotCount = 7;

	public CardSlotData ChessmanCurrentSlot;

	private bool isBossCreate;

	private static GameObject m_PotionIndicatorCardPrefab;
}
