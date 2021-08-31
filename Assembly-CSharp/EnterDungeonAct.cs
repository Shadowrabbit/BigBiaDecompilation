using System;
using System.Collections.Generic;
using UnityEngine;

public class EnterDungeonAct : GameAct
{
	private void Start()
	{
		this.Init();
		GameController.ins.GameData.DungeonTheme = (DungeonTheme)int.Parse(this.Source.CardData.Attrs["Theme"].ToString());
		GameController.ins.GameData.Agreenment = GlobalController.Instance.GlobalData.DungeonThemeLockData[GameController.ins.GameData.DungeonTheme].CurrentLevel;
		DungeonTheme dungeonTheme = GameController.ins.GameData.DungeonTheme;
		GameController.ins.GameData.CurrentDungeonType = GameData.DungeonType.Dungeon;
		switch (dungeonTheme)
		{
		case DungeonTheme.Normal:
			GameController.getInstance().CreateSubtitle("这个地方过两天才能开呢 ^o^!!! ", 1f, 2f, 1f, 1f);
			UIController.LockLevel = UIController.UILevel.None;
			return;
		case DungeonTheme.Forest:
			BGMusicManager.Instance.PlayBGMusic(6, 0, null);
			break;
		case DungeonTheme.Desert:
			GameController.getInstance().CreateSubtitle("这个地方也还要过两天才能开呢 ^U^!!! ", 1f, 2f, 1f, 1f);
			UIController.LockLevel = UIController.UILevel.None;
			return;
		}
		GameController.getInstance().UIController.ShowBackToHomeButton();
		int agreenment = GameController.ins.GameData.Agreenment;
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		List<CardData> list2 = new List<CardData>();
		List<CardData> list3 = new List<CardData>();
		List<CardData> list4 = new List<CardData>();
		List<CardData> list5 = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.地下城入口) && cardData.Attrs.ContainsKey("Theme"))
			{
				if (cardData.Attrs["Theme"].ToString() == "Forest")
				{
					list.Add(cardData);
				}
				if (cardData.Attrs["Theme"].ToString() == "Desert")
				{
					list2.Add(cardData);
				}
				if (cardData.Attrs["Theme"].ToString() == "Void")
				{
					list3.Add(cardData);
				}
				if (cardData.Attrs["Theme"].ToString() == "Normal")
				{
					list4.Add(cardData);
				}
				if (cardData.Attrs["Theme"].ToString() == "Tutorial")
				{
					list5.Add(cardData);
				}
			}
		}
		CardData cardData2 = Card.InitCardDataByID("地下城营地");
		if (dungeonTheme == DungeonTheme.Forest)
		{
			for (int i = 0; i < 3; i++)
			{
				CardData cardData3 = list[UnityEngine.Random.Range(0, list.Count)];
				GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(cardData3, true));
				GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(cardData2, true));
				list.Remove(cardData3);
			}
			GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(Card.InitCardDataByID("BossTree"), true));
		}
		if (dungeonTheme == DungeonTheme.Desert)
		{
			for (int j = 0; j < 3; j++)
			{
				CardData cardData4 = list2[UnityEngine.Random.Range(0, list2.Count)];
				GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(cardData4, true));
				GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(cardData2, true));
				list2.Remove(cardData4);
			}
			GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(Card.InitCardDataByID("BossSnake"), true));
		}
		if (dungeonTheme == DungeonTheme.Normal)
		{
			GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(list4[0], true));
		}
		if (dungeonTheme == DungeonTheme.Tutorial)
		{
			GameController.ins.GameData.DungeonArea.Add(CardData.CopyCardData(list5[0], true));
		}
		if (this.Source.CardData.Attrs.ContainsKey("AreaDataID"))
		{
			AreaData areaData = GameController.getInstance().GameData.AreaMap["老虎机"];
			areaData.ParentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData;
			GameController.getInstance().GameEventManager.EnterArea(areaData.Name);
			GameController.getInstance().OnTableChange(areaData, true);
		}
		if (this.Source.CardData.Attrs.ContainsKey("DeleteAfterEnter") && this.Source.CardData.Attrs["DeleteAfterEnter"].ToString() == "true")
		{
			this.Source.CardData.DeleteCardData();
		}
		UIController.LockLevel = UIController.UILevel.None;
		this.ActEnd();
	}

	private void Update()
	{
	}
}
