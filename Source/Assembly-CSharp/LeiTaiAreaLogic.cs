using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiTaiAreaLogic : BrookAreaLogic
{
	public override void BeforeInit()
	{
		if (this.m_Data.Attrs.ContainsKey("Theme"))
		{
			GameController.ins.GameData.DungeonTheme = (DungeonTheme)int.Parse(this.m_Data.Attrs["Theme"].ToString());
		}
		DungeonTheme dungeonTheme = GameController.ins.GameData.DungeonTheme;
		switch (dungeonTheme)
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
		default:
			if (dungeonTheme == DungeonTheme.Arena)
			{
				BGMusicManager.Instance.PlayBGMusic(12, 0, null);
			}
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
		CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城入口"), true);
		CardData cardDataByModID = GameController.getInstance().CardDataModMap.getCardDataByModID("挑战怪物");
		list.Add(CardData.CopyCardData(cardDataByModID, true));
		CardData item = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("投篮玩具"), true);
		list.Add(item);
		list.Add(CardData.CopyCardData(cardDataByModID, true));
		CardData cardData2 = GameController.getInstance().CardDataModMap.getCardDataByModID("挑战出口");
		if (cardData2 != null)
		{
			list.Add(CardData.CopyCardData(cardData2, true));
		}
		if (this.m_Data.GetAttr("JieJieName") != "")
		{
			CardLogic cardLogic = Activator.CreateInstance(Type.GetType(this.m_Data.GetAttr("JieJieName"))) as CardLogic;
			cardLogic.CardData = cardData;
			cardData.CardLogicClassNames.Add(this.m_Data.GetAttr("JieJieName"));
			cardData.CardLogics.Add(cardLogic);
			cardLogic.Init();
		}
		list.Insert(0, cardData);
		for (int l = 0; l < list.Count; l++)
		{
			if (list[l] != null && (list[l].ModID == "地下城入口" || list[l].ModID == "地下城结界"))
			{
				CardData cardData3 = list[l];
				list2.Add(CardData.CopyCardData(cardData3, true));
			}
			else
			{
				CardData cardData4;
				if (list[l] != null && list[l].HasTag(TagMap.BOSS))
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData4.desc = list[l].desc;
				}
				else if (list[l] != null && list[l].HasTag(TagMap.地下城入口))
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData4.desc = list[l].desc;
					cardData2 = cardData4;
				}
				else
				{
					cardData4 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("地下城Boss提示卡背"), true);
					cardData4.desc = list[l].desc;
				}
				if (list[l] != null && list[l].HasAttr("CardBack"))
				{
					cardData4.Model = list[l].GetAttr("CardBack");
					cardData4.desc = list[l].desc;
					cardData4.Name = list[l].Name;
					if (list[l].Level == 4 && list[l].Attrs.ContainsKey("Boss"))
					{
						CardData cardData5 = cardData4;
						cardData5.desc = cardData5.desc + "(即将面对Boss:" + list[l].Attrs["Boss"].ToString() + ")";
					}
				}
				else if (list[l] != null && list[l].HasTag(TagMap.地下城入口))
				{
					cardData4.Model = list[l].Model;
					cardData4.desc = list[l].desc;
					cardData4.Name = list[l].Name;
				}
				if (list[l] != null)
				{
					if (!cardData4.Attrs.ContainsKey("CardModId"))
					{
						cardData4.Attrs.Add("CardModId", list[l].ModID);
					}
					else
					{
						cardData4.Attrs["CardModId"] = list[l].ModID;
					}
					if (!cardData4.Attrs.ContainsKey("CardLevel"))
					{
						cardData4.Attrs.Add("CardLevel", list[l].Level);
					}
					else
					{
						cardData4.Attrs["CardLevel"] = list[l].Level;
					}
					if (!cardData4.Attrs.ContainsKey("Distance"))
					{
						cardData4.Attrs.Add("Distance", l);
					}
					else
					{
						cardData4.Attrs["Distance"] = list[l].Level;
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
					if (!cardData4.Attrs.ContainsKey("EncounterType"))
					{
						cardData4.Attrs.Add("EncounterType", EncounterType.CUSTOM);
					}
					if (list[l].Attrs.ContainsKey("BattleLevel"))
					{
						cardData4.Attrs.Add("BattleLevel", list[l].Attrs["BattleLevel"]);
					}
				}
				list2.Add(cardData4);
			}
		}
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			int num2 = SYNCRandom.Range(0, 5);
			if (num2 == 0)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志19"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num2 == 1)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志20"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num2 == 2)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志21"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num2 == 3)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志22"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
			else if (num2 == 4)
			{
				JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志23"), LocalizationMgr.Instance.GetLocalizationWord("KP_N_" + base.Data.Name)), null, null, null, null, null, null));
			}
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
					cardSlotData2.DisplayPositionX = (float)n * 1f - 9.7f;
					cardSlotData2.DisplayPositionZ = (float)(-(float)m) * 1f - 3.2f;
					cardSlotData2.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData2);
					if (n >= 4 && n <= 6 && m > 3)
					{
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
						cardSlotData2.OnlyAcceptOneCard = true;
						cardSlotData2.IconIndex = 3;
						cardSlotData2.TagWhiteList = 8589967360UL;
						cardSlotData2.Attrs.Add("Col", n - 4);
					}
				}
			}
			List<int> list3 = new List<int>();
			Dictionary<CardSlotData, int> dictionary = new Dictionary<CardSlotData, int>();
			Queue<CardSlotData> queue = new Queue<CardSlotData>();
			int[,] array = new int[(base.Data as SpaceAreaData).CardSlotGridHeight, (base.Data as SpaceAreaData).CardSlotGridWidth];
			int num3 = 0;
			for (int num4 = 0; num4 < base.Data.CardSlotDatas.Count; num4++)
			{
				CardSlotData cardSlotData3 = base.Data.CardSlotDatas[num4];
				if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 2)
				{
					queue.Enqueue(cardSlotData3);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
					dictionary.Add(cardSlotData3, 0);
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 3)
				{
					cardData2.PutInSlotData(cardSlotData3, true);
					list2.Remove(cardData2);
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
				else if ((base.Data as SpaceAreaData).GridOpenState[cardSlotData3.GridPositionY * (base.Data as SpaceAreaData).CardSlotGridWidth + cardSlotData3.GridPositionX] == 0)
				{
					array[cardSlotData3.GridPositionY, cardSlotData3.GridPositionX] = 1;
				}
			}
			while (queue.Count > 0 && num3 < list2.Count)
			{
				CardSlotData cardSlotData4 = queue.Dequeue();
				int num5 = dictionary[cardSlotData4];
				list3.Add(num5);
				cardSlotData4.SlotType = CardSlotData.Type.Freeze;
				cardSlotData4.IconIndex = 3;
				if (list2[num3] != null)
				{
					if ((num5 - 1) % 3 == 0 && list2[num3].GetAttr("CardModId") == "未知怪物")
					{
						for (int num6 = num3 + 1; num6 < list2.Count; num6++)
						{
							if (list2[num6].GetAttr("CardModId") != "未知怪物" && list2[num6].GetAttr("CardModId") != "下层入口")
							{
								CardData value = list2[num3];
								list2[num3] = list2[num6];
								list2[num6] = value;
								break;
							}
						}
					}
					if ((num5 - 1) % 2 == 0 && list2[num3].GetAttr("CardModId") != "未知怪物")
					{
						for (int num7 = num3 + 1; num7 < list2.Count; num7++)
						{
							if (list2[num7].GetAttr("CardModId") == "未知怪物")
							{
								CardData value2 = list2[num3];
								list2[num3] = list2[num7];
								list2[num7] = value2;
								break;
							}
						}
					}
					list2[num3].PutInSlotData(cardSlotData4, true);
					int k = GameController.ins.GameData.level;
					int num8;
					if (k != 1)
					{
						if (k != 2)
						{
							num8 = (GameController.ins.GameData.level - 1) * 8;
						}
						else
						{
							num8 = 5;
						}
					}
					else
					{
						num8 = 0;
					}
					cardSlotData4.Attrs.Add("EnemyDifficult", num8 + num5);
					if (list2[num3].ModID == "地下城入口")
					{
						list2[num3].CurrentCardSlotData.MarkFlipState(true);
						DungeonOperationMgr.Instance.CurrentPositionInMap = list2[num3].CurrentCardSlotData;
					}
					cardSlotData4.SlotType = CardSlotData.Type.Freeze;
					num3++;
				}
				if (cardSlotData4.GridPositionX < (base.Data as SpaceAreaData).CardSlotGridWidth - 1)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] == 0)
					{
						CardSlotData ralitiveCardSlotData = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 1, 0, false);
						queue.Enqueue(ralitiveCardSlotData);
						dictionary.Add(ralitiveCardSlotData, num5 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX + 1] = 1;
				}
				if (cardSlotData4.GridPositionX > 0)
				{
					if (array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] == 0)
					{
						CardSlotData ralitiveCardSlotData2 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, -1, 0, false);
						queue.Enqueue(ralitiveCardSlotData2);
						dictionary.Add(ralitiveCardSlotData2, num5 + 1);
					}
					array[cardSlotData4.GridPositionY, cardSlotData4.GridPositionX - 1] = 1;
				}
				if (cardSlotData4.GridPositionY < (base.Data as SpaceAreaData).CardSlotGridHeight - 1)
				{
					if (array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData3 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, 1, false);
						queue.Enqueue(ralitiveCardSlotData3);
						dictionary.Add(ralitiveCardSlotData3, num5 + 1);
					}
					array[cardSlotData4.GridPositionY + 1, cardSlotData4.GridPositionX] = 1;
				}
				if (cardSlotData4.GridPositionY > 0)
				{
					if (array[cardSlotData4.GridPositionY - 1, cardSlotData4.GridPositionX] == 0)
					{
						CardSlotData ralitiveCardSlotData4 = (base.Data as SpaceAreaData).GetRalitiveCardSlotData(cardSlotData4.GridPositionX, cardSlotData4.GridPositionY, 0, -1, false);
						queue.Enqueue(ralitiveCardSlotData4);
						dictionary.Add(ralitiveCardSlotData4, num5 + 1);
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
		if (base.Data.ChessmanPosition >= 0 && base.Data.ChessmanPosition < base.Data.CardSlotDatas.Count)
		{
			DungeonOperationMgr.Instance.CurrentPositionInMap = base.Data.CardSlotDatas[base.Data.ChessmanPosition];
		}
		yield return DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(false, false, null));
		UIController.LockLevel = UIController.UILevel.None;
		yield return base.OnAlreadEnter();
		if (DungeonOperationMgr.Instance.EnemyDifficult != 0)
		{
			YesPanel yesPanel = GameController.ins.UIController.YesPanel;
			yesPanel.MainText.text = "挑战成功！";
			if (GameController.ins.GameData.Money < 44)
			{
				yesPanel.MainText.text = "挑战失败！";
			}
			yield return yesPanel.StartChoosing();
			ActData actData = new ActData();
			actData.Type = "Act/Gift";
			actData.Model = "ActTable/Gift";
			GiftAct giftAct = GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct;
			giftAct.GiftNames.Add("电子琴");
			giftAct.GiftNames.Add("吉他");
			giftAct.GiftNames.Add("爵士鼓");
			giftAct.GiftNames.Add("麦克风");
			yield break;
		}
		CardData cardData = CardData.CopyCardData(Card.InitCardDataByID("长弓手"), true);
		CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(cardData);
		if (emptySlotDataByCardData != null)
		{
			cardData.PutInSlotData(emptySlotDataByCardData, true);
		}
		CardData cardData2 = CardData.CopyCardData(Card.InitCardDataByID("伐木工"), true);
		emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(cardData2);
		if (emptySlotDataByCardData != null)
		{
			cardData2.PutInSlotData(emptySlotDataByCardData, true);
		}
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
