using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class HomeDataController
{
	public void Init()
	{
		if (!File.Exists(this.settingPath))
		{
			this.CreateHomeDataInfo();
			this.CheckCardsTablesSlotDatas();
			return;
		}
		this.LoadHomeDataInfo();
	}

	public void CreateHomeDataInfo()
	{
		this.info = new HomeData();
		this.SaveHomeDataInfo();
	}

	public void LoadHomeDataInfo()
	{
		string value = File.ReadAllText(this.settingPath);
		this.info = (JsonConvert.DeserializeObject(value, typeof(HomeData)) as HomeData);
		if (this.info == null)
		{
			this.CreateHomeDataInfo();
		}
	}

	public void SaveHomeDataInfo()
	{
		if (File.Exists(this.settingPath))
		{
			File.Delete(this.settingPath);
		}
		string contents = JsonConvert.SerializeObject(this.info, Formatting.Indented);
		File.WriteAllText(this.settingPath, contents);
	}

	public void SetPlayerTableCardSlotDatasToHomeData(List<CardSlotData> slotDatas)
	{
		this.info.PlayerTableCardSlotDatas = slotDatas;
		this.SaveHomeDataInfo();
	}

	public List<CardSlotData> GetPlayerTableCardSlotDatasToHomeData()
	{
		return this.info.PlayerTableCardSlotDatas;
	}

	public void SetItemTableCardSlotDatasToHomeData(List<CardSlotData> slotDatas)
	{
		this.info.ItemTableCardSlotDatas = slotDatas;
		this.SaveHomeDataInfo();
	}

	public List<CardSlotData> GetItemTableCardSlotDatasToHomeData()
	{
		return this.info.ItemTableCardSlotDatas;
	}

	public void SetMagicTableCardSlotDatasToHomeData(List<CardSlotData> slotDatas)
	{
		this.info.MagicTableCardSlotDatas = slotDatas;
		this.SaveHomeDataInfo();
	}

	public List<CardSlotData> GetMagicTableCardSlotDatasToHomeData()
	{
		return this.info.MagicTableCardSlotDatas;
	}

	public void SetOppositeTableCardSlotDatasToHomeData(List<CardSlotData> slotDatas)
	{
		this.info.OppositeTableCardSlotDatas = slotDatas;
	}

	public List<CardSlotData> GetOppositeTableCardSlotDatasToHomeData()
	{
		return this.info.OppositeTableCardSlotDatas;
	}

	private void CheckCardsTablesSlotDatas()
	{
		this.InitCardsTables("Minion", -1);
		this.InitCardsTables("Item", -1);
		this.InitCardsTables("Skill", -1);
	}

	private void InitCardsTables(string type, int dir)
	{
		int num = 19;
		int num2 = 2;
		List<CardSlotData> list = new List<CardSlotData>();
		if (type != null)
		{
			if (type == "Minion")
			{
				for (int i = 0; i < num2; i++)
				{
					for (int j = 0; j < num; j++)
					{
						CardSlotData item = CardSlotData.CopyCardSlotData(new CardSlotData
						{
							SlotOwnerType = CardSlotData.OwnerType.Player,
							SlotType = CardSlotData.Type.Normal,
							TagWhiteList = 128UL,
							IconIndex = 1
						});
						list.Add(item);
					}
				}
				GlobalController.Instance.HomeDataController.SetPlayerTableCardSlotDatasToHomeData(list);
				return;
			}
			if (type == "Item")
			{
				for (int k = 0; k < num2; k++)
				{
					for (int l = 0; l < num; l++)
					{
						CardSlotData item2 = CardSlotData.CopyCardSlotData(new CardSlotData
						{
							SlotOwnerType = CardSlotData.OwnerType.Player,
							SlotType = CardSlotData.Type.Normal,
							TagWhiteList = 65536UL,
							IconIndex = 4
						});
						list.Add(item2);
					}
				}
				GlobalController.Instance.HomeDataController.SetItemTableCardSlotDatasToHomeData(list);
				return;
			}
			if (!(type == "Skill"))
			{
				return;
			}
			for (int m = 0; m < num2; m++)
			{
				for (int n = 0; n < num; n++)
				{
					CardSlotData item3 = CardSlotData.CopyCardSlotData(new CardSlotData
					{
						SlotOwnerType = CardSlotData.OwnerType.Player,
						SlotType = CardSlotData.Type.Normal,
						TagWhiteList = 8UL,
						IconIndex = 11
					});
					list.Add(item3);
				}
			}
			GlobalController.Instance.HomeDataController.SetMagicTableCardSlotDatasToHomeData(list);
		}
	}

	public HomeData info;

	public string settingPath = Path.Combine(Application.persistentDataPath, "HomeData.json");
}
