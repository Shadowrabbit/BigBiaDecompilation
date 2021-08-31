using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSceneAreaLogic : BrookAreaLogic
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
		int num = 11;
		int num2 = 18;
		int num3 = 2;
		AreaData data = base.Data;
		int[] array = MapDataSet.MapData[SYNCRandom.Range(0, MapDataSet.MapData.Count)];
		int num4 = 0;
		for (int k = 0; k < (base.Data as SpaceAreaData).CardSlotGridHeight; k++)
		{
			for (int l = 0; l < (base.Data as SpaceAreaData).CardSlotGridWidth; l++)
			{
				if (l >= num && l <= num2 && k > num3)
				{
					(base.Data as SpaceAreaData).GridOpenState[k * (base.Data as SpaceAreaData).CardSlotGridWidth + l] = array[num4++];
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
		int num5 = 0;
		foreach (int num6 in (base.Data as SpaceAreaData).GridOpenState)
		{
			if ((num6 > 0 && num6 < 4) || num6 == 8)
			{
				num5++;
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
				if (cardData.HasTag(TagMap.玩具房间) && !cardData.HasTag(TagMap.奇遇))
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
		float num7 = 25f;
		int num8 = (list.Count > 0) ? 1 : 0;
		int num9 = (GameController.ins.GameData.level == 4) ? 2 : 3;
		int num10 = (Mathf.RoundToInt((float)num5 / num7 * 1f) > 1) ? Mathf.RoundToInt((float)num5 / num7 * 1f) : 1;
		int num11 = (Mathf.RoundToInt((float)num5 / num7 * 1f) > 1) ? Mathf.RoundToInt((float)num5 / num7 * 1f) : 1;
		int num12 = 1;
		int num13 = (Mathf.RoundToInt((float)num5 / num7 * 1f) > 1) ? Mathf.RoundToInt((float)num5 / num7 * 1f) : 1;
		int num14 = (Mathf.RoundToInt((float)num5 / num7 * 1f) > 1) ? Mathf.RoundToInt((float)num5 / num7 * 1f) : 1;
		int num15 = (Mathf.RoundToInt((float)num5 / num7 * 3f) > 1) ? Mathf.RoundToInt((float)num5 / num7 * 3f) : 1;
		int num16 = 0;
		num10 = 0;
		int num17 = (GameController.ins.GameData.level >= 2) ? 1 : 0;
		int num18 = num5 - num8 - num13 - num14 - num11 - num12 - num15 - num10 - num16 - num9 - num17;
		int num19;
		int num20;
		int num21;
		if (GameController.ins.GameData.Agreenment >= 5)
		{
			num19 = Mathf.RoundToInt((float)num18 * 2f / 5f);
			num20 = ((GameController.ins.GameData.level > 1) ? GameController.ins.GameData.level : 0);
			num21 = ((GameController.ins.GameData.level - 1 > 0) ? (GameController.ins.GameData.level - 1) : 0);
		}
		else
		{
			num19 = num18 / 3;
			num20 = GameController.ins.GameData.level - 1;
			num21 = ((GameController.ins.GameData.level - 2 > 0) ? (GameController.ins.GameData.level - 2) : 0);
		}
		while (num19 + num20 + num21 > num18)
		{
			if (num19 > 0)
			{
				num19--;
			}
			else if (num20 > 0)
			{
				num20--;
			}
			else if (num21 > 0)
			{
				num21--;
			}
		}
		int num22 = (num18 - (num19 + num20 + num21)) / 2;
		if (num22 < 0)
		{
			num22 = 0;
		}
		for (int n = 0; n < num18 - (num19 + num20 + num21 + num22); n++)
		{
			CardData item = Card.InitCardDataByID("未知怪物");
			list5.Add(item);
			list7.Add(item);
		}
		for (int num23 = 0; num23 < num19; num23++)
		{
			CardData item2 = Card.InitCardDataByID("中级怪物");
			list5.Add(item2);
			list7.Add(item2);
		}
		for (int num24 = 0; num24 < num20; num24++)
		{
			CardData item3 = Card.InitCardDataByID("高级怪物");
			list5.Add(item3);
			list7.Add(item3);
		}
		for (int num25 = 0; num25 < num21; num25++)
		{
			CardData item4 = Card.InitCardDataByID("超级怪物");
			list5.Add(item4);
			list7.Add(item4);
		}
		for (int num26 = 0; num26 < num22; num26++)
		{
			CardData item5 = Card.InitCardDataByID("未知怪物");
			list5.Add(item5);
			list7.Add(item5);
		}
		List<CardData> list9 = new List<CardData>();
		CardData cardData2 = null;
		CardData cardData3 = null;
		CardData cardData4 = null;
		if (GameController.ins.GameData.level < 4)
		{
			foreach (CardData cardData5 in GameController.getInstance().CardDataModMap.Cards)
			{
				if (cardData5.HasTag(TagMap.地下城入口) && cardData5.HasTag(TagMap.地点) && !cardData5.HasTag(TagMap.特殊) && !cardData5.HasTag(TagMap.BOSS) && cardData5.Attrs.ContainsKey("Theme") && cardData5.Level == GameController.ins.GameData.level + 1)
				{
					list9.Add(CardData.CopyCardData(cardData5, true));
				}
			}
			if (list9.Count > 0)
			{
				cardData2 = list9[SYNCRandom.Range(0, list9.Count)];
				list7.Add(cardData2);
				list9.Remove(cardData2);
			}
			if (list9.Count > 0)
			{
				CardData item6 = list9[SYNCRandom.Range(0, list9.Count)];
				list7.Add(item6);
				list9.Remove(item6);
			}
		}
		else
		{
			list9 = new List<CardData>();
			foreach (CardData cardData6 in GameController.getInstance().CardDataModMap.Cards)
			{
				if (cardData6.HasTag(TagMap.地点) && cardData6.HasTag(TagMap.BOSS))
				{
					list9.Add(cardData6);
				}
			}
			if (list9.Count > 0)
			{
				if (this.m_Data.Attrs.ContainsKey("Boss"))
				{
					foreach (CardData cardData7 in list9)
					{
						if (cardData7.ModID == this.m_Data.Attrs["Boss"].ToString())
						{
							cardData2 = cardData7;
						}
					}
				}
				if (cardData2 == null)
				{
					cardData2 = list9[SYNCRandom.Range(0, list9.Count)];
				}
				list7.Add(cardData2);
				list9.Remove(cardData2);
			}
		}
		if (list.Count > 0)
		{
			for (int num27 = 0; num27 < num8; num27++)
			{
				if (list.Count > 0)
				{
					list7.Insert(SYNCRandom.Range(0, list7.Count), list[SYNCRandom.Range(0, list.Count)]);
				}
			}
		}
		if (list3.Count > 0)
		{
			for (int num28 = 0; num28 < num16; num28++)
			{
				CardData cardData8 = list3[SYNCRandom.Range(0, list3.Count)];
				list7.Insert(SYNCRandom.Range(0, list7.Count), CardData.CopyCardData(cardData8, true));
			}
		}
		if (num17 > 0)
		{
			for (int num29 = 0; num29 < num17; num29++)
			{
				CardData cardData9 = Card.InitCardDataByID("复活点");
				list7.Insert(SYNCRandom.Range(0, list7.Count), CardData.CopyCardData(cardData9, true));
			}
		}
		if (num12 > 0)
		{
			for (int num30 = 0; num30 < num12; num30++)
			{
				CardData cardData10 = Card.InitCardDataByID("祈祷房");
				list7.Insert(SYNCRandom.Range(0, list7.Count), CardData.CopyCardData(cardData10, true));
			}
		}
		if (cardDataByModID2 != null && num11 > 0)
		{
			int num31 = SYNCRandom.Range(5, list7.Count / num11);
			for (int num32 = 0; num32 < num11; num32++)
			{
				int index = num31 + num32 * list7.Count / num11;
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
		if (cardDataByModID3 != null && num13 > 0)
		{
			for (int num33 = 0; num33 < num13; num33++)
			{
				list7.Insert(SYNCRandom.Range(list7.Count / 3, list7.Count), CardData.CopyCardData(cardDataByModID3, true));
			}
		}
		CardData cardDataByModID4 = GameController.getInstance().CardDataModMap.getCardDataByModID("帐篷");
		if (cardDataByModID4 != null && num14 > 0)
		{
			for (int num34 = 0; num34 < num14; num34++)
			{
				list7.Insert(SYNCRandom.Range(list7.Count / 3, list7.Count), CardData.CopyCardData(cardDataByModID4, true));
			}
		}
		if (list2.Count > 0)
		{
			for (int num35 = 0; num35 < num15; num35++)
			{
				CardData item7 = list2[SYNCRandom.Range(0, list2.Count)];
				list6.Add(item7);
				list7.Insert(SYNCRandom.Range(2, list7.Count), item7);
			}
		}
		if (cardDataByModID != null)
		{
			int num36 = SYNCRandom.Range(list7.Count / (num10 + 1) - 3, list7.Count / (num10 + 1));
			for (int num37 = 0; num37 < num10; num37++)
			{
				int index2 = num36 + num37 * list7.Count / (num10 + 1);
				list7.Insert(index2, CardData.CopyCardData(cardDataByModID, true));
			}
		}
		CardData cardData11 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口"), true);
		if (this.m_Data.GetAttr("JieJieName") != "")
		{
			CardLogic cardLogic = Activator.CreateInstance(Type.GetType(this.m_Data.GetAttr("JieJieName"))) as CardLogic;
			cardLogic.CardData = cardData11;
			cardData11.CardLogicClassNames.Add(this.m_Data.GetAttr("JieJieName"));
			cardData11.CardLogics.Add(cardLogic);
			cardLogic.Init();
		}
		list7.Insert(0, cardData11);
		for (int num38 = 0; num38 < list7.Count; num38++)
		{
			if (list7[num38] != null && (list7[num38].ModID == "地下城入口" || list7[num38].ModID == "地下城结界" || list7[num38].ModID == "门" || list7[num38].ModID == "墙" || list7[num38].ModID == "宝箱"))
			{
				CardData cardData12 = list7[num38];
				list8.Add(CardData.CopyCardData(cardData12, true));
			}
			else
			{
				CardData cardData13;
				if (list7[num38] != null && list7[num38].HasTag(TagMap.BOSS))
				{
					cardData13 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData13.desc = list7[num38].desc;
					if (cardData3 == null)
					{
						cardData3 = cardData13;
					}
				}
				else if (list7[num38] != null && list7[num38].HasTag(TagMap.地下城入口))
				{
					cardData13 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData13.desc = list7[num38].desc;
					if (cardData3 == null)
					{
						cardData3 = cardData13;
					}
					else if (cardData4 == null)
					{
						cardData4 = cardData13;
					}
				}
				else
				{
					cardData13 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData13.desc = list7[num38].desc;
				}
				if (list7[num38] != null && list7[num38].HasAttr("CardBack"))
				{
					cardData13.Model = list7[num38].GetAttr("CardBack");
					cardData13.desc = LocalizationMgr.Instance.GetLocalizationWord(list7[num38].desc);
					cardData13.Name = list7[num38].Name;
					if (list7[num38].Level == 4 && list7[num38].Attrs.ContainsKey("Boss"))
					{
						CardData cardData14 = cardData13;
						cardData14.desc = cardData14.desc + "(Boss:" + LocalizationMgr.Instance.GetLocalizationWord(list7[num38].Attrs["Boss"].ToString()) + ")";
					}
				}
				else if (list7[num38] != null && list7[num38].HasTag(TagMap.地下城入口))
				{
					cardData13.Model = list7[num38].Model;
					cardData13.desc = list7[num38].desc;
					cardData13.Name = list7[num38].Name;
				}
				if (list7[num38] != null)
				{
					if (!cardData13.Attrs.ContainsKey("CardModId"))
					{
						cardData13.Attrs.Add("CardModId", list7[num38].ModID);
					}
					else
					{
						cardData13.Attrs["CardModId"] = list7[num38].ModID;
					}
					if (!cardData13.Attrs.ContainsKey("CardLevel"))
					{
						cardData13.Attrs.Add("CardLevel", list7[num38].Level);
					}
					else
					{
						cardData13.Attrs["CardLevel"] = list7[num38].Level;
					}
					if (!cardData13.Attrs.ContainsKey("Distance"))
					{
						cardData13.Attrs.Add("Distance", num38);
					}
					else
					{
						cardData13.Attrs["Distance"] = list7[num38].Level;
					}
					if (!cardData13.Attrs.ContainsKey("Theme"))
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
											cardData13.Attrs.Add("Theme", DungeonTheme.Tutorial);
										}
									}
									else
									{
										cardData13.Attrs.Add("Theme", DungeonTheme.Desert);
									}
								}
								else
								{
									cardData13.Attrs.Add("Theme", DungeonTheme.Forest);
								}
							}
							else
							{
								cardData13.Attrs.Add("Theme", DungeonTheme.Normal);
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
											cardData13.Attrs["Theme"] = DungeonTheme.Tutorial;
										}
									}
									else
									{
										cardData13.Attrs["Theme"] = DungeonTheme.Desert;
									}
								}
								else
								{
									cardData13.Attrs["Theme"] = DungeonTheme.Forest;
								}
							}
							else
							{
								cardData13.Attrs["Theme"] = DungeonTheme.Normal;
							}
						}
					}
					if (!cardData13.Attrs.ContainsKey("EncounterType"))
					{
						cardData13.Attrs.Add("EncounterType", EncounterType.CUSTOM);
					}
					if (list7[num38].Attrs.ContainsKey("BattleLevel"))
					{
						cardData13.Attrs.Add("BattleLevel", list7[num38].Attrs["BattleLevel"]);
					}
				}
				list8.Add(cardData13);
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			int num39 = SYNCRandom.Range(0, 5);
			if (num39 == 0)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志19"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num39 == 1)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志20"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num39 == 2)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志21"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num39 == 3)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志22"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num39 == 4)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志23"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int num40 = 0; num40 < (base.Data as SpaceAreaData).CardSlotGridHeight; num40++)
			{
				for (int num41 = 0; num41 < (base.Data as SpaceAreaData).CardSlotGridWidth; num41++)
				{
					CardSlotData cardSlotData2 = new CardSlotData();
					cardSlotData2.SlotType = CardSlotData.Type.Freeze;
					cardSlotData2.IconIndex = 0;
					cardSlotData2.GridPositionX = num41;
					cardSlotData2.GridPositionY = num40;
					cardSlotData2.TagWhiteList = 0UL;
					cardSlotData2.OnlyAcceptOneCard = true;
					cardSlotData2.DisplayPositionX = (float)num41 * 1f - 9.7f;
					cardSlotData2.DisplayPositionZ = (float)(-(float)num40) * 1f - 3.2f;
					cardSlotData2.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData2);
					if (num41 >= 4 && num41 <= 6 && num40 > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
						cardSlotData2.OnlyAcceptOneCard = true;
						cardSlotData2.IconIndex = 3;
						cardSlotData2.TagWhiteList = 8589967360UL;
						cardSlotData2.Attrs.Add("Col", num41 - 4);
					}
				}
			}
			List<int> list10 = new List<int>();
			Dictionary<CardSlotData, int> dictionary2 = new Dictionary<CardSlotData, int>();
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array2 = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num42 = 0;
			for (int num43 = 0; num43 < base.Data.CardSlotDatas.Count; num43++)
			{
				CardSlotData cardSlotData3 = base.Data.CardSlotDatas[num43];
				if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 2)
				{
					queue.Enqueue(cardSlotData3);
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					dictionary2.Add(cardSlotData3, 0);
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 3)
				{
					cardData3.PutInSlotData(cardSlotData3, true);
					list8.Remove(cardData3);
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 8 && GameController.ins.GameData.level != 4)
				{
					cardData4.PutInSlotData(cardSlotData3, true);
					list8.Remove(cardData4);
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 4)
				{
					Card.InitCardDataByID("墙").PutInSlotData(cardSlotData3, true);
					cardSlotData3.IconIndex = 3;
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 5)
				{
					Card.InitCardDataByID("门").PutInSlotData(cardSlotData3, true);
					cardSlotData3.IconIndex = 3;
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 6)
				{
					Card.InitCardDataByID("锁住的宝箱").PutInSlotData(cardSlotData3, true);
					cardSlotData3.IconIndex = 3;
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 7)
				{
					Card.InitCardDataByID("宝箱").PutInSlotData(cardSlotData3, true);
					cardSlotData3.IconIndex = 3;
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 0)
				{
					array2[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					if (DungeonOperationMgr.Instance.BattleArea.Contains(cardSlotData3))
					{
						cardSlotData3.IconIndex = 3;
					}
					else
					{
						cardSlotData3.IconIndex = 0;
					}
				}
			}
			while (queue.Count > 0 && num42 < list8.Count)
			{
				CardSlotData cardSlotData4 = queue.Dequeue();
				int num44 = dictionary2[cardSlotData4];
				list10.Add(num44);
				cardSlotData4.SlotType = CardSlotData.Type.Freeze;
				cardSlotData4.IconIndex = 3;
				if (list8[num42] != null)
				{
					if ((num44 - 1) % 3 == 0 && list8[num42].GetAttr("CardModId") == "未知怪物")
					{
						for (int num45 = num42 + 1; num45 < list8.Count; num45++)
						{
							if (list8[num45].GetAttr("CardModId") != "未知怪物" && list8[num45].GetAttr("CardModId") != "下层入口" && list8[num45].GetAttr("CardModId") != "门" && list8[num45].GetAttr("CardModId") != "墙" && list8[num45].GetAttr("CardModId") != "宝箱" && this.m_Data.Attrs.ContainsKey("Boss") && list8[num45].GetAttr("CardModId") != this.m_Data.Attrs["Boss"].ToString())
							{
								CardData value = list8[num42];
								list8[num42] = list8[num45];
								list8[num45] = value;
								break;
							}
						}
					}
					if ((num44 - 1) % 2 == 0 && list8[num42].GetAttr("CardModId") != "未知怪物" && list8[num42].GetAttr("CardModId") != "下层入口" && list8[num42].GetAttr("CardModId") != "门" && list8[num42].GetAttr("CardModId") != "墙" && list8[num42].GetAttr("CardModId") != "宝箱" && this.m_Data.Attrs.ContainsKey("Boss") && list8[num42].GetAttr("CardModId") != this.m_Data.Attrs["Boss"].ToString())
					{
						for (int num46 = num42 + 1; num46 < list8.Count; num46++)
						{
							if (list8[num46].GetAttr("CardModId") == "未知怪物")
							{
								CardData value2 = list8[num42];
								list8[num42] = list8[num46];
								list8[num46] = value2;
								break;
							}
						}
					}
					list8[num42].PutInSlotData(cardSlotData4, true);
					int m = GameController.ins.GameData.level;
					int num47;
					if (m != 1)
					{
						if (m != 2)
						{
							num47 = (GameController.ins.GameData.level - 1) * 8;
						}
						else
						{
							num47 = 5;
						}
					}
					else
					{
						num47 = 0;
					}
					cardSlotData4.Attrs.Add("EnemyDifficult", num47 + num44);
					if (list8[num42].ModID == "地下城入口")
					{
						list8[num42].CurrentCardSlotData.MarkFlipState(true);
						DungeonOperationMgr.Instance.CurrentPositionInMap = list8[num42].CurrentCardSlotData;
					}
					cardSlotData4.SlotType = CardSlotData.Type.Freeze;
					num42++;
				}
				if (cardSlotData4.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
				{
					if (array2[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] == 0)
					{
						CardSlotData ralitiveCardSlotData = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 1, 0, false);
						queue.Enqueue(ralitiveCardSlotData);
						dictionary2.Add(ralitiveCardSlotData, num44 + 1);
					}
					array2[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] = 1;
				}
				if (cardSlotData4.GridPositionX > 0)
				{
					if (array2[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] == 0)
					{
						CardSlotData ralitiveCardSlotData2 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, -1, 0, false);
						queue.Enqueue(ralitiveCardSlotData2);
						dictionary2.Add(ralitiveCardSlotData2, num44 + 1);
					}
					array2[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] = 1;
				}
				if (cardSlotData4.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					if (array2[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData3 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, 1, false);
						queue.Enqueue(ralitiveCardSlotData3);
						dictionary2.Add(ralitiveCardSlotData3, num44 + 1);
					}
					array2[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] = 1;
				}
				if (cardSlotData4.GridPositionY > 0)
				{
					if (array2[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData4 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, -1, false);
						queue.Enqueue(ralitiveCardSlotData4);
						dictionary2.Add(ralitiveCardSlotData4, num44 + 1);
					}
					array2[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] = 1;
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
		if (GameController.ins.GameData.level == 1 && this.IsFirstEnter)
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

	private bool isBossCreate;

	private static GameObject m_PotionIndicatorCardPrefab;
}
