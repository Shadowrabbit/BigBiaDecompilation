using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class EnemySpawner : CardSlotLogic
{
	public override void OnDayPassed()
	{
		if (base.Data.ChildCardData != null)
		{
			return;
		}
		string attr = base.Data.GetAttr("SpawnerName");
		string path = Application.streamingAssetsPath + attr;
		List<CardData> list = this.LoadToys(path);
		if (list.Count == 0)
		{
			return;
		}
		CardData cardData = JsonConvert.DeserializeObject<CardData>(JsonConvert.SerializeObject(list[UnityEngine.Random.Range(0, list.Count)]));
		cardData.ActDatas = new List<ActData>();
		ActData actData = new ActData();
		actData.Name = "战斗";
		actData.Type = "Act/Battle";
		actData.Model = "ActTable/Battle";
		cardData.ActDatas.Add(actData);
		cardData.IsToy = true;
		cardData.CurrentAreaID = base.Data.CurrentAreaData.ID;
		base.Data.SetChildCardData(cardData);
	}

	public override void OnCardPutIn(CardSlot fromSlot, CardSlot tarSlot, Card card)
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
}
