using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class TrainArea : AreaLogic
{
	public override void BeforeInit()
	{
		base.Data.ChildrenAreaIDs = new List<string>();
		base.Data.ChildrenAreaIDs.Add(base.Data.ID);
		string path = Application.streamingAssetsPath + "/" + base.Data.DungeonPath + "/Monster";
		List<CardData> list = this.LoadToys(path);
		if (list.Count == 0)
		{
			return;
		}
		base.Data.CardSlotDatas = new List<CardSlotData>();
		base.Data.Toys = new List<CardData>();
		CardData cardData = JsonConvert.DeserializeObject<CardData>(JsonConvert.SerializeObject(list[0]));
		cardData.SetLevel(Convert.ToInt32(cardData.Attrs["Level"]));
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.DisplayPositionX = 0f;
		cardSlotData.DisplayPositionZ = -8f;
		cardSlotData.SetChildCardData(cardData);
		cardSlotData.SlotType = CardSlotData.Type.Normal;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
		cardData.IsToy = true;
		cardData.CurrentAreaID = base.Data.ID;
		base.Data.CardSlotDatas.Add(cardSlotData);
		this.monster = cardData;
		cardData = new CardData();
		cardData = Card.InitCardDataByID("恶魔");
		cardData.ActDatas = new List<ActData>();
		ActData actData = new ActData();
		actData.Name = "恢复初始状态";
		actData.Callback = delegate()
		{
			this.LoadGameData();
		};
		cardData.ActDatas.Add(actData);
		actData = new ActData();
		actData.Name = "加速";
		actData.Callback = delegate()
		{
			Time.timeScale = 20f;
		};
		cardData.ActDatas.Add(actData);
		actData = new ActData();
		actData.Name = "恢复";
		actData.Callback = delegate()
		{
			Time.timeScale = 1f;
		};
		cardData.ActDatas.Add(actData);
		actData = new ActData();
		actData.Name = "测试伤害";
		actData.Callback = delegate()
		{
			this.Test();
		};
		cardData.ActDatas.Add(actData);
		cardSlotData = new CardSlotData();
		cardSlotData.DisplayPositionX = -5f;
		cardSlotData.DisplayPositionZ = -8f;
		cardSlotData.SetChildCardData(cardData);
		cardSlotData.SlotType = CardSlotData.Type.Normal;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
		cardData.IsToy = true;
		cardData.CurrentAreaID = base.Data.ID;
		base.Data.CardSlotDatas.Add(cardSlotData);
	}

	public override void BeforeEnter()
	{
		this.LoadGameData();
	}

	public override void OnExit()
	{
	}

	private List<CardData> LoadToys(string path)
	{
		List<CardData> list = new List<CardData>();
		string fullPath = Path.GetFullPath(path);
		FileInfo[] files = new DirectoryInfo(fullPath).GetFiles("*.toy", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].Name.EndsWith(".toy"))
			{
				CardData item = JsonConvert.DeserializeObject(File.ReadAllText(fullPath + "/" + files[i].Name), typeof(CardData)) as CardData;
				list.Add(item);
			}
		}
		return list;
	}

	private List<CardData> LoadCards(string path)
	{
		List<CardData> list = new List<CardData>();
		string fullPath = Path.GetFullPath(path);
		FileInfo[] files = new DirectoryInfo(fullPath).GetFiles("*.json", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			if (files[i].Name.EndsWith(".json"))
			{
				CardData item = JsonConvert.DeserializeObject(File.ReadAllText(fullPath + "/" + files[i].Name), typeof(CardData)) as CardData;
				list.Add(item);
			}
		}
		return list;
	}

	private void LoadGameData()
	{
		CardData cardData = JsonConvert.DeserializeObject<CardData>(File.ReadAllText(Application.streamingAssetsPath + "/" + base.Data.DungeonPath + "/Player.json"));
		CardData playerCardData = GameController.getInstance().GameData.PlayerCardData;
		playerCardData.Attrs = cardData.Attrs;
		playerCardData.SetLevel(Convert.ToInt32(cardData.Attrs["Level"]));
		GameController.getInstance().PlayerToy.HPText.text = playerCardData.HP.ToString();
		GameController.getInstance().PlayerToy.ATKText.text = playerCardData.ATK.ToString();
		string path = Application.streamingAssetsPath + "/" + base.Data.DungeonPath + "/Minion";
		List<CardData> list = this.LoadCards(path);
		for (int i = 0; i < GameController.getInstance().GameData.SlotsOnPlayerTable.Count; i++)
		{
			if (i < list.Count)
			{
				CardData childCardData = list[i];
				GameController.getInstance().GameData.SlotsOnPlayerTable[i].SetChildCardData(childCardData);
				CardSlotData cardSlotData = GameController.getInstance().GameData.SlotsOnPlayerTable[i];
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.角色))
				{
					cardSlotData.ChildCardData.SetLevel(Convert.ToInt32(cardSlotData.ChildCardData.Attrs["Level"]));
				}
			}
			else
			{
				GameController.getInstance().GameData.SlotsOnPlayerTable[i].SetChildCardData(null);
			}
		}
		GameController.getInstance().InitPlayerTable();
	}

	private void OnBattleEnd()
	{
	}

	private void Test()
	{
		int intAttr = this.monster.GetIntAttr("aa");
		int intAttr2 = this.monster.GetIntAttr("ah");
		int num = this.monster.GetIntAttr("ac");
		int intAttr3 = this.monster.GetIntAttr("ba");
		int intAttr4 = this.monster.GetIntAttr("bh");
		int num2 = this.monster.GetIntAttr("bc");
		int num3 = intAttr2 * num;
		int num4 = intAttr4 * num2;
		while (num3 > 0 && num4 > 0)
		{
			Debug.Log(string.Concat(new string[]
			{
				"a造成",
				(num * intAttr).ToString(),
				"伤害, b造成",
				(num2 * intAttr3).ToString(),
				"伤害"
			}));
			num3 -= intAttr3 * num2;
			num4 -= intAttr * num;
			num = this.GetCount(num3, intAttr2);
			num2 = this.GetCount(num4, intAttr4);
			Debug.Log(string.Concat(new string[]
			{
				"a剩",
				num.ToString(),
				"个(",
				(num * intAttr).ToString(),
				"/",
				num3.ToString(),
				"), b剩",
				num2.ToString(),
				"个(",
				(num2 * intAttr3).ToString(),
				"/",
				num4.ToString(),
				")"
			}));
		}
	}

	private int GetCount(int ch, int hp)
	{
		int result;
		if (ch <= 0)
		{
			result = 0;
		}
		else
		{
			result = ch / hp + ((ch % hp > 0) ? 1 : 0);
		}
		return result;
	}

	private CardData monster;
}
