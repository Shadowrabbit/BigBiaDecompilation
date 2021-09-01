using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class CommonAttribute
{
	public static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
	{
		TypeNameHandling = TypeNameHandling.All
	};

	public static string[] MaterialNames = new string[]
	{
		"木头",
		"纤维",
		"生肉",
		"皮革",
		"沙",
		"石头",
		"水",
		"铜",
		"铁",
		"熟肉",
		"铂金",
		"土",
		"金",
		"钻石",
		"陶瓷",
		"米",
		"面",
		"蔬菜",
		"熟面",
		"空间"
	};

	public static Color32[] MaterialColors;

	public static Dictionary<string, Color> MaterialMap = new Dictionary<string, Color>();

	public static Dictionary<string, string> MaterialModIDMap = new Dictionary<string, string>();

	public static Dictionary<string, GameMaterial> GameMaterials = new Dictionary<string, GameMaterial>
	{
		{
			"木头",
			new GameMaterial("木头", "木头", default(Color32), 1f, 0.1f, "", 1f)
		},
		{
			"纤维",
			new GameMaterial("纤维", "纤维", default(Color32), 1.1f, 0f, "", 0.5f)
		},
		{
			"生肉",
			new GameMaterial("生肉", "生肉", default(Color32), 1.5f, 1f, "", 0f)
		},
		{
			"皮革",
			new GameMaterial("皮革", "皮革", default(Color32), 2f, 0.2f, "", 0.1f)
		},
		{
			"沙",
			new GameMaterial("沙", "沙", default(Color32), 0.1f, 0f, "沙", 0f)
		},
		{
			"石头",
			new GameMaterial("石头", "石头", default(Color32), 0.2f, 0f, "石头", 0f)
		},
		{
			"水",
			new GameMaterial("水", "水", default(Color32), 0f, 0f, "", 0f)
		},
		{
			"铜",
			new GameMaterial("铜", "铜", default(Color32), 5f, 0f, "铜", 0f)
		},
		{
			"铁",
			new GameMaterial("铁", "铁", default(Color32), 8f, 0f, "铁", 0f)
		},
		{
			"熟肉",
			new GameMaterial("熟肉", "熟肉", default(Color32), 2f, 1.65f, "", 0f)
		},
		{
			"铂金",
			new GameMaterial("铂金", "铂金", default(Color32), 11f, 0f, "铂金", 0f)
		},
		{
			"土",
			new GameMaterial("土", "土", default(Color32), 1f, 0f, "土", 0f)
		},
		{
			"金",
			new GameMaterial("金", "金", default(Color32), 10f, 0f, "金", 0f)
		},
		{
			"钻石",
			new GameMaterial("钻石", "钻石", default(Color32), 1000f, 0f, "钻石", 0f)
		},
		{
			"陶瓷",
			new GameMaterial("陶瓷", "陶瓷", default(Color32), 7f, 0f, "陶瓷", 0f)
		},
		{
			"米",
			new GameMaterial("米", "米", default(Color32), 1.3f, 1f, "", 0f)
		},
		{
			"面",
			new GameMaterial("面", "面", default(Color32), 1.3f, 1f, "熟面", 0f)
		},
		{
			"蔬菜",
			new GameMaterial("蔬菜", "蔬菜", default(Color32), 1.5f, 1.2f, "蔬菜", 0f)
		},
		{
			"熟面",
			new GameMaterial("熟面", "熟面", default(Color32), 1.4f, 1.1f, "熟面", 0f)
		},
		{
			"空间",
			new GameMaterial("空间", "空间", default(Color32), 999f, 0f, "空间", 0f)
		}
	};
}
