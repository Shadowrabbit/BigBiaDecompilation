using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		if (this.m_Data.Attrs.ContainsKey("Theme"))
		{
			GameController.ins.GameData.DungeonTheme = (DungeonTheme)int.Parse(this.m_Data.Attrs["Theme"].ToString());
		}
		switch (GameController.ins.GameData.DungeonTheme)
		{
		case DungeonTheme.Forest:
			BGMusicManager.Instance.PlayBGMusic(9, 0, null);
			break;
		case DungeonTheme.Desert:
			BGMusicManager.Instance.PlayBGMusic(11, 0, null);
			break;
		case DungeonTheme.Hive:
			BGMusicManager.Instance.PlayBGMusic(16, 0, null);
			break;
		case DungeonTheme.RoninRoad:
			BGMusicManager.Instance.PlayBGMusic(14, 0, null);
			break;
		case DungeonTheme.Cell:
			BGMusicManager.Instance.PlayBGMusic(13, 0, null);
			break;
		case DungeonTheme.Office:
			BGMusicManager.Instance.PlayBGMusic(12, 0, null);
			break;
		case DungeonTheme.Volcano:
			BGMusicManager.Instance.PlayBGMusic(18, 0, null);
			break;
		case DungeonTheme.Circus:
			BGMusicManager.Instance.PlayBGMusic(17, 0, null);
			break;
		case DungeonTheme.InternetBar:
			BGMusicManager.Instance.PlayBGMusic(15, 0, null);
			break;
		case DungeonTheme.OldStreet:
			BGMusicManager.Instance.PlayBGMusic(9, 0, null);
			break;
		}
		DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
		DungeonOperationMgr.Instance.MapArea = new List<CardSlotData>();
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
						cardSlotData.TagWhiteList = 8589967360UL;
					}
					if (j >= 8 && j <= 19 && i > 2)
					{
						DungeonOperationMgr.Instance.MapArea.Add(cardSlotData);
					}
				}
			}
			return;
		}
		int level = GameController.ins.GameData.level;
		int num = 13;
		int num2 = 16;
		int num3 = 3;
		AreaData data = base.Data;
		for (int k = 0; k < (base.Data as SpaceAreaData).CardSlotGridHeight; k++)
		{
			for (int l = 0; l < (base.Data as SpaceAreaData).CardSlotGridWidth; l++)
			{
				if (l == num && k == num3 + 1)
				{
					(base.Data as SpaceAreaData).GridOpenState[k * (base.Data as SpaceAreaData).CardSlotGridWidth + l] = 2;
				}
				else if (l == num2 && k == (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					(base.Data as SpaceAreaData).GridOpenState[k * (base.Data as SpaceAreaData).CardSlotGridWidth + l] = 3;
				}
				else if (l >= num && l <= num2 && k > num3)
				{
					(base.Data as SpaceAreaData).GridOpenState[k * (base.Data as SpaceAreaData).CardSlotGridWidth + l] = 1;
				}
			}
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
		List<CardData> list8 = new List<CardData>();
		int num4 = 0;
		int[] gridOpenState = (base.Data as SpaceAreaData).GridOpenState;
		for (int m = 0; m < gridOpenState.Length; m++)
		{
			if (gridOpenState[m] > 0)
			{
				num4++;
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
				if (cardData.HasTag((TagMap)(-2147483648)))
				{
					list3.Add(cardData);
				}
				if (cardData.HasTag(TagMap.随从) && !cardData.HasTag(TagMap.特殊) && cardData.Attrs.ContainsKey("Theme") && int.Parse(cardData.Attrs["Theme"].ToString()) == (int)GameController.ins.GameData.DungeonTheme)
				{
					bool flag = false;
					using (List<string>.Enumerator enumerator2 = GlobalController.Instance.GetHadMinionsID().GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							if (enumerator2.Current == cardData.ModID)
							{
								flag = true;
							}
						}
					}
					if (!flag)
					{
						list4.Add(cardData);
					}
				}
			}
		}
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("事件酒馆");
		CardData cardDataByModID2 = GameController.getInstance().CardDataModMap.getCardDataByModID("商铺");
		float num5 = 25f;
		int num6 = 0;
		int num7 = 3;
		int num8 = 0;
		int num9 = 1;
		int num10 = 0;
		int num11 = 0;
		int num12 = (Mathf.RoundToInt((float)num4 / num5 * 3f) > 1) ? Mathf.RoundToInt((float)num4 / num5 * 3f) : 1;
		int num13 = 0;
		int num14 = 0;
		int num15 = (GameController.ins.GameData.level >= 2) ? 1 : 0;
		int num16 = num4 - num6 - num10 - num11 - num8 - num9 - num12 - num14 - num13 - num7 - num15;
		SYNCRandom.Range(num16 / 2, num16);
		int num17;
		int num18;
		int num19;
		if (GameController.ins.GameData.Agreenment >= 5)
		{
			num17 = Mathf.RoundToInt((float)num16 * 2f / 5f);
			num18 = ((GameController.ins.GameData.level > 1) ? GameController.ins.GameData.level : 0);
			num19 = ((GameController.ins.GameData.level - 1 > 0) ? (GameController.ins.GameData.level - 1) : 0);
		}
		else
		{
			num17 = num16 / 3;
			num18 = GameController.ins.GameData.level - 1;
			num19 = ((GameController.ins.GameData.level - 2 > 0) ? (GameController.ins.GameData.level - 2) : 0);
		}
		int num20 = (num16 - (num17 + num18 + num19)) / 2;
		if (num20 < 0)
		{
			num20 = 0;
		}
		for (int n = 0; n < num16 - (num17 + num18 + num19 + num20); n++)
		{
			CardData item = Card.InitCardDataByID("未知怪物");
			list5.Add(item);
			list7.Add(item);
		}
		for (int num21 = 0; num21 < num17; num21++)
		{
			CardData item2 = Card.InitCardDataByID("中级怪物");
			list5.Add(item2);
			list7.Add(item2);
		}
		for (int num22 = 0; num22 < num18; num22++)
		{
			CardData item3 = Card.InitCardDataByID("高级怪物");
			list5.Add(item3);
			list7.Add(item3);
		}
		for (int num23 = 0; num23 < num19; num23++)
		{
			CardData item4 = Card.InitCardDataByID("超级怪物");
			list5.Add(item4);
			list7.Add(item4);
		}
		for (int num24 = 0; num24 < num20; num24++)
		{
			CardData item5 = Card.InitCardDataByID("未知怪物");
			list5.Add(item5);
			list7.Add(item5);
		}
		if (list.Count > 0)
		{
			for (int num25 = 0; num25 < num6; num25++)
			{
				switch (GameController.ins.GameData.level)
				{
				case 1:
					list7.Insert(SYNCRandom.Range(0, list7.Count), Card.InitCardDataByID("鲨鱼牙玩具"));
					break;
				case 2:
					list7.Insert(SYNCRandom.Range(0, list7.Count), Card.InitCardDataByID("投篮玩具"));
					break;
				case 3:
					list7.Insert(SYNCRandom.Range(0, list7.Count), Card.InitCardDataByID("石头剪子布玩具"));
					break;
				default:
					list7.Insert(SYNCRandom.Range(0, list7.Count), Card.InitCardDataByID("鲨鱼牙玩具"));
					break;
				}
			}
		}
		if (list3.Count > 0)
		{
			for (int num26 = 0; num26 < num13; num26++)
			{
				CardData cardData2 = list3[SYNCRandom.Range(0, list3.Count)];
				list7.Insert(SYNCRandom.Range(0, list7.Count), CardData.CopyCardData(cardData2, true));
			}
		}
		if (num15 > 0)
		{
			for (int num27 = 0; num27 < num15; num27++)
			{
				CardData cardData3 = Card.InitCardDataByID("复活点");
				list7.Insert(SYNCRandom.Range(0, list7.Count), CardData.CopyCardData(cardData3, true));
			}
		}
		if (num9 > 0)
		{
			for (int num28 = 0; num28 < num9; num28++)
			{
				CardData cardData4 = Card.InitCardDataByID("祈祷房");
				list7.Insert(SYNCRandom.Range(0, list7.Count), CardData.CopyCardData(cardData4, true));
			}
		}
		if (cardDataByModID2 != null && num8 > 0)
		{
			int num29 = SYNCRandom.Range(5, list7.Count / num8);
			for (int num30 = 0; num30 < num8; num30++)
			{
				int index = num29 + num30 * list7.Count / num8;
				switch (SYNCRandom.Range(0, 4))
				{
				case 0:
					list7.Insert(index, Card.InitCardDataByID("银行"));
					break;
				case 1:
					list7.Insert(index, Card.InitCardDataByID("渔夫小屋"));
					break;
				case 2:
					list7.Insert(index, Card.InitCardDataByID("克隆室"));
					break;
				case 3:
					list7.Insert(index, Card.InitCardDataByID("医院"));
					break;
				}
			}
		}
		CardData cardDataByModID3 = GameController.getInstance().CardDataModMap.getCardDataByModID("事件篝火");
		if (cardDataByModID3 != null && num10 > 0)
		{
			for (int num31 = 0; num31 < num10; num31++)
			{
				list7.Insert(SYNCRandom.Range(list7.Count / 3, list7.Count), CardData.CopyCardData(cardDataByModID3, true));
			}
		}
		CardData cardDataByModID4 = GameController.getInstance().CardDataModMap.getCardDataByModID("帐篷");
		if (cardDataByModID4 != null && num11 > 0)
		{
			for (int num32 = 0; num32 < num11; num32++)
			{
				list7.Insert(SYNCRandom.Range(list7.Count / 3, list7.Count), CardData.CopyCardData(cardDataByModID4, true));
			}
		}
		if (list2.Count > 0)
		{
			for (int num33 = 0; num33 < num12; num33++)
			{
				CardData item6 = list2[SYNCRandom.Range(0, list2.Count)];
				list6.Add(item6);
				list7.Insert(SYNCRandom.Range(2, list7.Count), item6);
			}
		}
		if (cardDataByModID != null)
		{
			int num34 = SYNCRandom.Range(list7.Count / (num14 + 1) - 3, list7.Count / (num14 + 1));
			for (int num35 = 0; num35 < num14; num35++)
			{
				int index2 = num34 + num35 * list7.Count / (num14 + 1);
				list7.Insert(index2, CardData.CopyCardData(cardDataByModID, true));
			}
		}
		List<CardData> list9 = new List<CardData>();
		CardData cardData5 = null;
		if (GameController.ins.GameData.level < 4)
		{
			foreach (CardData cardData6 in GameController.getInstance().CardDataModMap.Cards)
			{
				if (cardData6.HasTag(TagMap.地下城入口) && cardData6.HasTag(TagMap.地点) && !cardData6.HasTag(TagMap.特殊) && !cardData6.HasTag(TagMap.BOSS) && cardData6.Attrs.ContainsKey("Theme") && cardData6.Level == GameController.ins.GameData.level + 1)
				{
					list9.Add(CardData.CopyCardData(cardData6, true));
				}
			}
			if (list9.Count > 0)
			{
				cardData5 = list9[SYNCRandom.Range(0, list9.Count)];
				list7.Add(cardData5);
				list9.Remove(cardData5);
			}
			if (list9.Count > 0)
			{
				cardData5 = list9[SYNCRandom.Range(0, list9.Count)];
				list7.Insert(SYNCRandom.Range(list7.Count / 3, list7.Count), cardData5);
				list9.Remove(cardData5);
			}
		}
		else
		{
			list9 = new List<CardData>();
			foreach (CardData cardData7 in GameController.getInstance().CardDataModMap.Cards)
			{
				if (cardData7.HasTag(TagMap.地点) && cardData7.HasTag(TagMap.BOSS))
				{
					list9.Add(cardData7);
				}
			}
			if (list9.Count > 0)
			{
				cardData5 = list9[SYNCRandom.Range(0, list9.Count)];
				list7.Add(cardData5);
				list9.Remove(cardData5);
			}
		}
		CardData cardData8 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口"), true);
		if (this.m_Data.GetAttr("JieJieName") != "")
		{
			CardLogic cardLogic = Activator.CreateInstance(Type.GetType(this.m_Data.GetAttr("JieJieName"))) as CardLogic;
			cardLogic.CardData = cardData8;
			cardData8.CardLogicClassNames.Add(this.m_Data.GetAttr("JieJieName"));
			cardData8.CardLogics.Add(cardLogic);
			cardLogic.Init();
		}
		list7.Insert(0, cardData8);
		for (int num36 = 0; num36 < list7.Count; num36++)
		{
			if (list7[num36] != null && (list7[num36].ModID == "地下城入口" || list7[num36].ModID == "地下城结界" || list7[num36].ModID == "门" || list7[num36].ModID == "墙" || list7[num36].ModID == "宝箱"))
			{
				CardData cardData9 = list7[num36];
				list8.Add(CardData.CopyCardData(cardData9, true));
			}
			else
			{
				CardData cardData10;
				if (list7[num36] != null && list7[num36].HasTag(TagMap.BOSS))
				{
					cardData10 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
				}
				else if (list7[num36] != null && list7[num36].HasTag(TagMap.地下城入口))
				{
					cardData10 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData5 = cardData10;
				}
				else
				{
					cardData10 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
				}
				if (list7[num36] != null && list7[num36].HasAttr("CardBack"))
				{
					cardData10.Model = list7[num36].GetAttr("CardBack");
					cardData10.desc = list7[num36].desc;
					cardData10.Name = list7[num36].Name;
				}
				else if (list7[num36] != null && list7[num36].HasTag(TagMap.地下城入口))
				{
					cardData10.Model = list7[num36].Model;
					cardData10.desc = list7[num36].desc;
					cardData10.Name = list7[num36].Name;
				}
				if (list7[num36] != null)
				{
					if (!cardData10.Attrs.ContainsKey("CardModId"))
					{
						cardData10.Attrs.Add("CardModId", list7[num36].ModID);
					}
					else
					{
						cardData10.Attrs["CardModId"] = list7[num36].ModID;
					}
					if (!cardData10.Attrs.ContainsKey("CardLevel"))
					{
						cardData10.Attrs.Add("CardLevel", list7[num36].Level);
					}
					else
					{
						cardData10.Attrs["CardLevel"] = list7[num36].Level;
					}
					if (!cardData10.Attrs.ContainsKey("Distance"))
					{
						cardData10.Attrs.Add("Distance", num36);
					}
					else
					{
						cardData10.Attrs["Distance"] = list7[num36].Level;
					}
					if (!cardData10.Attrs.ContainsKey("Theme"))
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
											cardData10.Attrs.Add("Theme", DungeonTheme.Tutorial);
										}
									}
									else
									{
										cardData10.Attrs.Add("Theme", DungeonTheme.Desert);
									}
								}
								else
								{
									cardData10.Attrs.Add("Theme", DungeonTheme.Forest);
								}
							}
							else
							{
								cardData10.Attrs.Add("Theme", DungeonTheme.Normal);
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
											cardData10.Attrs["Theme"] = DungeonTheme.Tutorial;
										}
									}
									else
									{
										cardData10.Attrs["Theme"] = DungeonTheme.Desert;
									}
								}
								else
								{
									cardData10.Attrs["Theme"] = DungeonTheme.Forest;
								}
							}
							else
							{
								cardData10.Attrs["Theme"] = DungeonTheme.Normal;
							}
						}
					}
					if (cardData10.ModID == "精英怪物")
					{
						cardData10.Attrs.Add("EncounterType", EncounterType.ELITE);
					}
					if (!cardData10.Attrs.ContainsKey("EncounterType"))
					{
						cardData10.Attrs.Add("EncounterType", EncounterType.CUSTOM);
					}
					if (GameController.ins.GameData.level == 1 && GameController.ins.GameData.StepInDungeon < 8)
					{
						if (!cardData10.Attrs.ContainsKey("EnemyCount"))
						{
							cardData10.Attrs.Add("EnemyCount", SYNCRandom.Range(2, 4));
						}
						else
						{
							cardData10.Attrs["EnemyCount"] = SYNCRandom.Range(2, 4);
						}
					}
					else if (!cardData10.Attrs.ContainsKey("EnemyCount"))
					{
						cardData10.Attrs.Add("EnemyCount", SYNCRandom.Range(3, 10));
					}
					else
					{
						cardData10.Attrs["EnemyCount"] = SYNCRandom.Range(3, 10);
					}
					if (list7[num36].Attrs.ContainsKey("BattleLevel"))
					{
						cardData10.Attrs.Add("BattleLevel", list7[num36].Attrs["BattleLevel"]);
					}
					if (list7[num36].Attrs.ContainsKey("Elite"))
					{
						cardData10.Attrs.Add("Elite", "true");
					}
				}
				list8.Add(cardData10);
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			int num37 = SYNCRandom.Range(0, 5);
			if (num37 == 0)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志19"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num37 == 1)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志20"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num37 == 2)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志21"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num37 == 3)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志22"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num37 == 4)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志23"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int num38 = 0; num38 < (base.Data as SpaceAreaData).CardSlotGridHeight; num38++)
			{
				for (int num39 = 0; num39 < (base.Data as SpaceAreaData).CardSlotGridWidth; num39++)
				{
					CardSlotData cardSlotData2 = new CardSlotData();
					cardSlotData2.SlotType = CardSlotData.Type.Freeze;
					cardSlotData2.IconIndex = 0;
					cardSlotData2.GridPositionX = num39;
					cardSlotData2.GridPositionY = num38;
					cardSlotData2.TagWhiteList = 0UL;
					cardSlotData2.OnlyAcceptOneCard = true;
					cardSlotData2.DisplayPositionX = (float)num39 * 1f - 9.7f;
					cardSlotData2.DisplayPositionZ = (float)(-(float)num38) * 1f - 3.2f;
					cardSlotData2.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData2);
					if (num39 >= 4 && num39 <= 6 && num38 > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
						cardSlotData2.OnlyAcceptOneCard = true;
						cardSlotData2.IconIndex = 3;
						cardSlotData2.TagWhiteList = 8589967360UL;
						cardSlotData2.Attrs.Add("Col", num39 - 4);
					}
				}
			}
			List<int> list10 = new List<int>();
			Dictionary<CardSlotData, int> dictionary2 = new Dictionary<CardSlotData, int>();
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num40 = 0;
			for (int num41 = 0; num41 < base.Data.CardSlotDatas.Count; num41++)
			{
				CardSlotData cardSlotData3 = base.Data.CardSlotDatas[num41];
				if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 2)
				{
					queue.Enqueue(cardSlotData3);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					dictionary2.Add(cardSlotData3, 0);
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 3)
				{
					cardData5.PutInSlotData(cardSlotData3, true);
					list8.Remove(cardData5);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 0)
				{
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
			}
			while (queue.Count > 0 && num40 < list8.Count)
			{
				CardSlotData cardSlotData4 = queue.Dequeue();
				int num42 = dictionary2[cardSlotData4];
				list10.Add(num42);
				cardSlotData4.SlotType = CardSlotData.Type.Freeze;
				cardSlotData4.IconIndex = 3;
				if (list8[num40] != null)
				{
					if ((num42 - 1) % 3 == 0 && list8[num40].GetAttr("CardModId") == "未知怪物")
					{
						for (int num43 = num40 + 1; num43 < list8.Count; num43++)
						{
							if (list8[num43].GetAttr("CardModId") != "未知怪物" && list8[num43].GetAttr("CardModId") != "下层入口")
							{
								CardData value = list8[num40];
								list8[num40] = list8[num43];
								list8[num43] = value;
								break;
							}
						}
					}
					if ((num42 - 1) % 2 == 0 && list8[num40].GetAttr("CardModId") != "未知怪物")
					{
						for (int num44 = num40 + 1; num44 < list8.Count; num44++)
						{
							if (list8[num44].GetAttr("CardModId") == "未知怪物")
							{
								CardData value2 = list8[num40];
								list8[num40] = list8[num44];
								list8[num44] = value2;
								break;
							}
						}
					}
					list8[num40].PutInSlotData(cardSlotData4, true);
					cardSlotData4.Attrs.Add("EnemyDifficult", (GameController.ins.GameData.level - 1) * 8 + num42);
					if (list8[num40].ModID == "地下城入口")
					{
						list8[num40].CurrentCardSlotData.MarkFlipState(true);
						DungeonOperationMgr.Instance.CurrentPositionInMap = list8[num40].CurrentCardSlotData;
					}
					cardSlotData4.SlotType = CardSlotData.Type.Freeze;
					num40++;
				}
				if (cardSlotData4.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] == 0)
					{
						CardSlotData ralitiveCardSlotData = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 1, 0, false);
						queue.Enqueue(ralitiveCardSlotData);
						dictionary2.Add(ralitiveCardSlotData, num42 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] = 1;
				}
				if (cardSlotData4.GridPositionX > 0)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] == 0)
					{
						CardSlotData ralitiveCardSlotData2 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, -1, 0, false);
						queue.Enqueue(ralitiveCardSlotData2);
						dictionary2.Add(ralitiveCardSlotData2, num42 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] = 1;
				}
				if (cardSlotData4.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					if (array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData3 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, 1, false);
						queue.Enqueue(ralitiveCardSlotData3);
						dictionary2.Add(ralitiveCardSlotData3, num42 + 1);
					}
					array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] = 1;
				}
				if (cardSlotData4.GridPositionY > 0)
				{
					if (array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData4 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, -1, false);
						queue.Enqueue(ralitiveCardSlotData4);
						dictionary2.Add(ralitiveCardSlotData4, num42 + 1);
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
		yield return this.freshHero();
		if (!PlayerPrefs.HasKey("FirstStart"))
		{
			GameController.ins.UIController.OnShuoMingShow();
			PlayerPrefs.SetInt("FirstStart", 1);
		}
		if (GameController.ins.GameData.level == 1 && this.IsFirstEnter && !GlobalController.Instance.IsLoadGame)
		{
			ActData actData = new ActData();
			actData.Type = "Act/BattleTavern";
			actData.Model = "ActTable/营地商店";
			(GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData) as BattleTavernAct).InitBattleAct("");
		}
		if (base.Data.ChessmanPosition >= 0 && base.Data.ChessmanPosition < base.Data.CardSlotDatas.Count)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = base.Data.CardSlotDatas[base.Data.ChessmanPosition];
		}
		yield return DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(false, false, null));
		UIController.LockLevel = UIController.UILevel.None;
		yield return base.OnAlreadEnter();
		yield break;
	}

	public override void OnExit()
	{
		base.Data.ChessmanPosition = base.Data.CardSlotDatas.FindIndex((CardSlotData a) => a == DungeonOperationMgr.Instance.CurrentPositionInMap);
		GridIndicate.Instance.HideGird();
		DungeonController.Instance.Chessman.gameObject.transform.SetParent(GameController.ins.PlayerCardSlot.transform);
		DungeonController.Instance.Chessman.gameObject.SetActive(false);
		DungeonOperationMgr.Instance.CurrentPositionInMap = null;
		DungeonOperationMgr.Instance.BattleArea = null;
	}

	private IEnumerator freshHero()
	{
		yield return null;
		yield return null;
		if (GameController.ins.PlayerToy == null)
		{
			GameController.ins.PlayerToy = GameController.ins.GameData.PlayerCardData.CardGameObject;
			GameController.ins.PlayerToy.gameObject.AddComponent<Hero>();
		}
		if (GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>() == null)
		{
			GameController.ins.PlayerToy.gameObject.AddComponent<Hero>();
		}
		DungeonController.Instance.m_Hero = GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
		for (int i = 0; i < GameController.ins.GameData.SlotsOnPlayerTable.Count; i++)
		{
			if (GameController.ins.GameData.SlotsOnPlayerTable[i].Attrs.ContainsKey("Col"))
			{
				GameController.ins.GameData.SlotsOnPlayerTable[i].Attrs["Col"] = int.Parse(GameController.ins.GameData.SlotsOnPlayerTable[i].Attrs["Col"].ToString());
			}
		}
		if (GlobalController.Instance.IsLoadGame)
		{
			GameController.ins.PlayerCardSlot = GameController.ins.GameData.PlayerCardData.CurrentCardSlotData.CardSlotGameObject;
			GameController.ins.UIController.EnergyUI.refreshEnery();
		}
		yield break;
	}

	public CardSlotData ChessmanCurrentSlot;

	private bool isBossCreate;

	private static GameObject m_PotionIndicatorCardPrefab;
}
