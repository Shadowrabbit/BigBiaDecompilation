using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class AdditionalDataController
{
	public AdditionalData LoadAdditionalInfo()
	{
		return JsonConvert.DeserializeObject(File.ReadAllText(this.settingPath), typeof(AdditionalData)) as AdditionalData;
	}

	public void SaveAdditionalInfo(AdditionalData data)
	{
		if (File.Exists(this.settingPath))
		{
			File.Delete(this.settingPath);
		}
		string contents = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
		{
			DefaultValueHandling = DefaultValueHandling.Ignore
		});
		File.WriteAllText(this.settingPath, contents);
	}

	private string settingPath = Path.Combine(Application.streamingAssetsPath, "AdditionalData.json");
}
