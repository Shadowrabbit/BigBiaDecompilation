using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ExhibitionLogic : AreaLogic
{
	public override void BeforeInit()
	{
		base.Data.CardSlotDatas = new List<CardSlotData>();
		for (int i = -9; i <= 9; i++)
		{
			for (int j = -9; j < -2; j++)
			{
				CardSlotData cardSlotData = new CardSlotData();
				cardSlotData.DisplayPositionX = (float)i;
				cardSlotData.DisplayPositionZ = (float)j;
				cardSlotData.SlotType = CardSlotData.Type.Normal;
				cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
				base.Data.CardSlotDatas.Add(cardSlotData);
			}
		}
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		new List<Card>();
		new List<CardSlot>();
		foreach (CardData cardData in cards)
		{
			foreach (CardSlotData cardSlotData2 in base.Data.CardSlotDatas)
			{
				if (cardSlotData2.ChildCardData == null)
				{
					CardData cardData2 = CardData.CopyCardData(cardData, true);
					cardData2.Count = 99;
					cardSlotData2.SetChildCardData(cardData2);
					break;
				}
			}
		}
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
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

	private void OnBattleEnd()
	{
	}
}
