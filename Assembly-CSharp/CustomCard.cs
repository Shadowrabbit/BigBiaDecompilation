using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using VoxelBuilder;

public class CustomCard
{
	public void Create(string cardName, CustomCard.callback call)
	{
		this.CreateCustomCardFile(cardName, new CardData
		{
			ModID = cardName,
			Rare = 3,
			ItemType = ItemData.ItemTypes.Custom,
			Life = CardData.LifeType.Infinite,
			LimitedTime = 0f,
			Frequency = 0,
			CardTags = 1UL,
			desc = "这是一个自定义卡牌",
			Logic = null,
			CardLogicClassNames = null,
			MaxHP = 300,
			HP = 300,
			_ATK = 10,
			ATKRange = 3,
			_CRIT = 3,
			SPD = 1,
			MoveRange = 4,
			Attrs = null,
			Price = 100,
			Name = cardName,
			DisplayPositionX = 0f,
			DisplayPositionY = 0f,
			Model = cardName,
			Life = CardData.LifeType.Infinite
		}, call);
	}

	private void CreateCustomCardFile(string cardName, CardData cardData, CustomCard.callback call)
	{
		FileInfo fileInfo = new FileInfo(this.path + "/" + cardName + ".json");
		if (!fileInfo.Exists)
		{
			StreamWriter streamWriter = fileInfo.CreateText();
			streamWriter.WriteLine(JsonConvert.SerializeObject(cardData));
			streamWriter.Close();
			streamWriter.Dispose();
		}
		else
		{
			Debug.LogError("自定义文件已存在");
		}
		call();
	}

	public CardData GetCustomCardFile(string cardName, string cardDesc = "这是一张自定义卡牌", int cardCount = 0, string fileName = "DefaultCustomCard")
	{
		CardData cardData = new CardData();
		if (File.Exists(this.path + "/" + fileName + ".json"))
		{
			cardData = JsonConvert.DeserializeObject<CardData>(File.ReadAllText(this.path + "/" + fileName + ".json"));
		}
		cardData.Name = BuilderHelper.LoadFile(cardName).Name;
		cardData.ID = cardName;
		cardData.Model = cardName;
		cardData.ModID = cardName;
		cardData.desc = cardDesc;
		cardData.Count = cardCount;
		return cardData;
	}

	private string path = Application.streamingAssetsPath + "/Mods/CustomCards/";

	public delegate void callback();
}
