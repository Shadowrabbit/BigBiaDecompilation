using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class HeroHomeDataController
{
	public void Init()
	{
		this.LoadHeroHomeDataInfo();
	}

	public void LoadHeroHomeDataInfo()
	{
		if (!File.Exists(this.settingPath))
		{
			Debug.LogError("英雄之家配置文件不存在！");
			return;
		}
		string value = File.ReadAllText(this.settingPath);
		this.info = (JsonConvert.DeserializeObject(value, typeof(HeroHomeData)) as HeroHomeData);
	}

	public HeroHomeData GetHerosHomeDataConfig()
	{
		return this.info;
	}

	private HeroHomeData info;

	public string settingPath = Application.streamingAssetsPath + "/HeroHomeConfig.json";
}
