using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class EnemyConfigController
{
	public void Init()
	{
		if (!File.Exists(this.settingPath))
		{
			this.CreateSettingInfo();
			return;
		}
		this.LoadEnemyConfigInfo();
	}

	public void CreateSettingInfo()
	{
		this.info = new EnemyConfigData();
		EnemyConfigBean enemyConfigBean = new EnemyConfigBean();
		enemyConfigBean.EnemiesModID = new List<string>
		{
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		enemyConfigBean.DifficultRatio = new List<float>
		{
			0f,
			0f,
			0f,
			0f,
			0f,
			0f,
			0f,
			0f,
			0f
		};
		this.info.EnemyConfigBeans.Add(enemyConfigBean);
		this.SaveEnemyConfigInfo(this.info);
	}

	public EnemyConfigData LoadEnemyConfigInfo()
	{
		return JsonConvert.DeserializeObject(File.ReadAllText(this.settingPath), typeof(EnemyConfigData)) as EnemyConfigData;
	}

	public void SaveEnemyConfigInfo(EnemyConfigData data)
	{
		if (File.Exists(this.settingPath))
		{
			File.Delete(this.settingPath);
		}
		string contents = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
		{
			TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
			TypeNameHandling = TypeNameHandling.None,
			DefaultValueHandling = DefaultValueHandling.Ignore
		});
		File.WriteAllText(this.settingPath, contents);
	}

	public EnemyConfigData info;

	private string settingPath = Path.Combine(Application.streamingAssetsPath, "EnemyConfig.json");
}
