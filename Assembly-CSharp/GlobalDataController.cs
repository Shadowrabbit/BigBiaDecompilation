using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GlobalDataController
{
	public GlobalController GlobalController
	{
		get
		{
			return GlobalController.Instance;
		}
	}

	public void Init()
	{
		if (!File.Exists(this.settingPath))
		{
			this.CreateGlobalInfo();
		}
		else
		{
			this.LoadGlobalInfo();
		}
		if (this.info.GlobalCharacterTags != null)
		{
			int count = this.info.GlobalCharacterTags.Count;
		}
		if (this.info.DungeonThemeLockData == null)
		{
			this.info.DungeonThemeLockData = new Dictionary<DungeonTheme, DungeonThemeData>();
			DungeonThemeData dungeonThemeData = new DungeonThemeData();
			dungeonThemeData.Theme = DungeonTheme.Desert;
			dungeonThemeData.CurrentLevel = 1;
			dungeonThemeData.UnlockLevel = 1;
			this.info.DungeonThemeLockData.Add(DungeonTheme.Desert, dungeonThemeData);
			dungeonThemeData = new DungeonThemeData();
			dungeonThemeData.Theme = DungeonTheme.Forest;
			dungeonThemeData.CurrentLevel = 1;
			dungeonThemeData.UnlockLevel = 1;
			this.info.DungeonThemeLockData.Add(DungeonTheme.Forest, dungeonThemeData);
			dungeonThemeData = new DungeonThemeData();
			dungeonThemeData.Theme = DungeonTheme.Normal;
			dungeonThemeData.CurrentLevel = 1;
			dungeonThemeData.UnlockLevel = 1;
			this.info.DungeonThemeLockData.Add(DungeonTheme.Normal, dungeonThemeData);
		}
		this.GlobalController.GlobalData = this.info;
	}

	public void CreateGlobalInfo()
	{
		this.info = new GlobalData();
		this.SaveGlobalInfo(this.info);
	}

	public void LoadGlobalInfo()
	{
		string value = File.ReadAllText(this.settingPath);
		this.info = (JsonConvert.DeserializeObject(value, typeof(GlobalData)) as GlobalData);
		if (this.info == null)
		{
			this.CreateGlobalInfo();
		}
	}

	public void SaveGlobalInfo(GlobalData data)
	{
		if (File.Exists(this.settingPath))
		{
			File.Delete(this.settingPath);
		}
		string contents = JsonConvert.SerializeObject(data, Formatting.Indented);
		File.WriteAllText(this.settingPath, contents);
	}

	public object GetGlobalInfo(string type)
	{
		object result = JsonConvert.DeserializeObject(File.ReadAllText(this.settingPath), Type.GetType(type));
		if (this.info == null)
		{
			return result;
		}
		return null;
	}

	public GlobalData info;

	public string settingPath = Path.Combine(Application.persistentDataPath, "Global.json");
}
