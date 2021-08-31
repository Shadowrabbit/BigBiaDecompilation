using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
	private void Awake()
	{
	}

	private void Start()
	{
		this.gameData = GameController.getInstance().GameData;
	}

	public IEnumerator LoadScene()
	{
		SaveLoad.async = SceneManager.LoadSceneAsync(1);
		while (!SaveLoad.async.isDone)
		{
			yield return null;
		}
		yield return null;
		yield break;
	}

	private void InitFanben()
	{
		FileStream fileStream = File.Create(Application.streamingAssetsPath + "/村庄范本.are");
		Debug.Log(Application.persistentDataPath + " ");
		AreaData areaData = new AreaData();
		areaData.DisplayPositionX = -3f;
		areaData.DisplayPositionY = 0f;
		areaData.Name = "villageName";
		areaData.Model = "normalVillage";
		using (StreamWriter streamWriter = new StreamWriter(fileStream))
		{
			JsonSerializer jsonSerializer = new JsonSerializer();
			jsonSerializer.NullValueHandling = NullValueHandling.Include;
			JsonWriter jsonWriter = new JsonTextWriter(streamWriter)
			{
				Formatting = Formatting.Indented,
				Indentation = 4,
				IndentChar = ' '
			};
			jsonSerializer.Serialize(jsonWriter, areaData);
			jsonWriter.Close();
			streamWriter.Close();
		}
		fileStream.Close();
		fileStream = File.Create(Application.streamingAssetsPath + "/游戏数据范本.are");
		Debug.Log(Application.persistentDataPath + " ");
		new GameData().Money = 100;
		fileStream = File.Create(Application.streamingAssetsPath + "/卡牌范本.are");
		Debug.Log(Application.persistentDataPath + " ");
		CardData cardData = new CardData();
		cardData.Attrs.Add("key", "value");
		cardData.Attrs.Add("key2", "value");
		cardData.Name = "村长";
		cardData.DisplayPositionX = 3f;
		cardData.DisplayPositionY = 0f;
		cardData.Model = "cardExample";
		cardData.Life = CardData.LifeType.Infinite;
		cardData.desc = "村长";
		using (StreamWriter streamWriter2 = new StreamWriter(fileStream))
		{
			JsonSerializer jsonSerializer2 = new JsonSerializer();
			JsonWriter jsonWriter2 = new JsonTextWriter(streamWriter2)
			{
				Formatting = Formatting.Indented,
				Indentation = 4,
				IndentChar = ' '
			};
			jsonSerializer2.Serialize(jsonWriter2, cardData);
			jsonWriter2.Close();
			streamWriter2.Close();
		}
		string contents = JsonConvert.SerializeObject(cardData, new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All
		});
		File.WriteAllText(Application.streamingAssetsPath + "/卡牌范本.are", contents);
	}

	public static void Save(SaveLoad.SaveCallBack call, string fileName = null)
	{
		Debug.Log("保存进度");
		string contents = JsonConvert.SerializeObject(GameController.getInstance().GameData, Formatting.Indented, new JsonSerializerSettings
		{
			DefaultValueHandling = DefaultValueHandling.Ignore
		});
		if (string.IsNullOrEmpty(fileName))
		{
			File.WriteAllText(Application.streamingAssetsPath + "/Save/" + DateTime.UtcNow.ToString("yyyy_MM_dd_mm_ss") + ".json", contents);
		}
		else
		{
			File.WriteAllText(Application.streamingAssetsPath + "/Save/" + fileName + ".json", contents);
		}
		LoggerWriter.Instance.CreateAndWriteLogFile();
		call();
	}

	public static void Load(string filename)
	{
		if (File.Exists(Application.streamingAssetsPath + "/Save/" + filename))
		{
			string value = File.ReadAllText(Application.streamingAssetsPath + "/Save/" + filename);
			GameController.getInstance().GameData = (JsonConvert.DeserializeObject(value, typeof(GameData)) as GameData);
			return;
		}
		Debug.LogError("未找到存档文件");
	}

	public static CardDataMap InitCardDataMap(string filePath = "Cards")
	{
		if (CommonAttribute.MaterialColors == null && CommonAttribute.MaterialNames != null)
		{
			byte[] data = File.ReadAllBytes(Application.streamingAssetsPath + "/init/Template.png");
			Texture2D texture2D = new Texture2D(16, 16);
			texture2D.LoadImage(data);
			CommonAttribute.MaterialColors = new Color32[CommonAttribute.MaterialNames.Length];
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < CommonAttribute.MaterialColors.Length; i++)
			{
				CommonAttribute.MaterialColors[i] = pixels[i];
				CommonAttribute.MaterialMap.Add(CommonAttribute.MaterialNames[i], CommonAttribute.MaterialColors[i]);
				CommonAttribute.GameMaterials[CommonAttribute.MaterialNames[i]].Color = pixels[i];
			}
		}
		string text = Application.streamingAssetsPath + "/Mods/" + filePath + "/";
		CardDataMap cardDataMap = new CardDataMap();
		cardDataMap.Cards = new List<CardData>();
		FileInfo[] array = GameController.ins.jsonsFromWorkShop.ToArray();
		new Color32[0];
		for (int j = 0; j < array.Length; j++)
		{
			try
			{
				Debug.Log("加载来自创意工坊的json:" + array[j].FullName);
				string value = File.ReadAllText(array[j].DirectoryName + "/" + array[j].Name, Encoding.UTF8);
				CardData cardData = JsonConvert.DeserializeObject(value, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				}) as CardData;
				if (cardData == null)
				{
					cardData = (JsonConvert.DeserializeObject(value, typeof(CardData)) as CardData);
				}
				cardData.ModID = array[j].Name.Remove(array[j].Name.LastIndexOf("."), array[j].Name.Length - array[j].Name.LastIndexOf("."));
				if ((cardData.CardTags & 512UL) > 0UL && !cardData.Attrs.ContainsKey("AreaDataID"))
				{
					cardData.Attrs.Add("AreaDataID", cardData.ModID);
				}
				bool flag = false;
				using (List<CardData>.Enumerator enumerator = cardDataMap.Cards.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.ModID.Equals(cardData.ModID))
						{
							Debug.Log("ModID重复:" + cardData.ModID);
							flag = true;
						}
					}
				}
				if (!flag)
				{
					cardDataMap.Cards.Add(cardData);
				}
				GameController.ins.CardsFromMods.Add(cardData.ModID);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
				Debug.Log("正在加载卡牌Mod  -  " + array[j].DirectoryName + "/" + array[j].Name);
			}
		}
		if (Directory.Exists(text))
		{
			FileInfo[] files = new DirectoryInfo(text).GetFiles("*.json", SearchOption.AllDirectories);
			new Color32[0];
			for (int k = 0; k < files.Length; k++)
			{
				try
				{
					string value2 = File.ReadAllText(files[k].DirectoryName + "/" + files[k].Name, Encoding.UTF8);
					CardData cardData2 = JsonConvert.DeserializeObject(value2, new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.All
					}) as CardData;
					if (cardData2 == null)
					{
						cardData2 = (JsonConvert.DeserializeObject(value2, typeof(CardData)) as CardData);
					}
					cardData2.ModID = files[k].Name.Remove(files[k].Name.LastIndexOf("."), files[k].Name.Length - files[k].Name.LastIndexOf("."));
					if ((cardData2.CardTags & 512UL) > 0UL && !cardData2.Attrs.ContainsKey("AreaDataID"))
					{
						cardData2.Attrs.Add("AreaDataID", cardData2.ModID);
					}
					bool flag2 = false;
					using (List<CardData>.Enumerator enumerator = cardDataMap.Cards.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.ModID.Equals(cardData2.ModID))
							{
								Debug.Log("ModID重复:" + cardData2.ModID);
								flag2 = true;
							}
						}
					}
					if (!flag2)
					{
						cardDataMap.Cards.Add(cardData2);
					}
				}
				catch (Exception ex2)
				{
					Debug.Log(ex2.Message);
					Debug.Log("正在加载卡牌Mod  -  " + files[k].DirectoryName + "/" + files[k].Name);
				}
			}
		}
		else
		{
			Debug.LogError("卡牌Mod加载失败");
		}
		text = Application.streamingAssetsPath + "/Mods/Unlock/" + filePath + "/";
		if (Directory.Exists(text))
		{
			FileInfo[] files2 = new DirectoryInfo(text).GetFiles("*.json", SearchOption.AllDirectories);
			new Color32[0];
			for (int l = 0; l < files2.Length; l++)
			{
				try
				{
					string value3 = File.ReadAllText(files2[l].DirectoryName + "/" + files2[l].Name, Encoding.UTF8);
					CardData cardData3 = JsonConvert.DeserializeObject(value3, new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.All
					}) as CardData;
					if (cardData3 == null)
					{
						cardData3 = (JsonConvert.DeserializeObject(value3, typeof(CardData)) as CardData);
					}
					cardData3.ModID = files2[l].Name.Remove(files2[l].Name.LastIndexOf("."), files2[l].Name.Length - files2[l].Name.LastIndexOf("."));
					if ((cardData3.CardTags & 512UL) > 0UL && !cardData3.Attrs.ContainsKey("AreaDataID"))
					{
						cardData3.Attrs.Add("AreaDataID", cardData3.ModID);
					}
					bool flag3 = false;
					using (List<CardData>.Enumerator enumerator = cardDataMap.Cards.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.ModID.Equals(cardData3.ModID))
							{
								Debug.Log("ModID重复:" + cardData3.ModID);
								flag3 = true;
							}
						}
					}
					if (!flag3)
					{
						cardDataMap.Cards.Add(cardData3);
					}
				}
				catch (Exception ex3)
				{
					Debug.Log(ex3.Message);
					Debug.Log("正在加载卡牌Mod  -  " + files2[l].DirectoryName + "/" + files2[l].Name);
				}
			}
		}
		else
		{
			Debug.Log("该目录没有MODPath:" + text);
		}
		if (GlobalController.Instance.IsUseCommunityCards)
		{
			text = Application.streamingAssetsPath + "/Mods/Community/" + filePath + "/";
			if (Directory.Exists(text))
			{
				FileInfo[] files3 = new DirectoryInfo(text).GetFiles("*.json", SearchOption.AllDirectories);
				new Color32[0];
				for (int m = 0; m < files3.Length; m++)
				{
					try
					{
						string value4 = File.ReadAllText(files3[m].DirectoryName + "/" + files3[m].Name, Encoding.UTF8);
						CardData cardData4 = JsonConvert.DeserializeObject(value4, new JsonSerializerSettings
						{
							TypeNameHandling = TypeNameHandling.All
						}) as CardData;
						if (cardData4 == null)
						{
							cardData4 = (JsonConvert.DeserializeObject(value4, typeof(CardData)) as CardData);
						}
						cardData4.ModID = files3[m].Name.Remove(files3[m].Name.LastIndexOf("."), files3[m].Name.Length - files3[m].Name.LastIndexOf("."));
						if ((cardData4.CardTags & 512UL) > 0UL && !cardData4.Attrs.ContainsKey("AreaDataID"))
						{
							cardData4.Attrs.Add("AreaDataID", cardData4.ModID);
						}
						bool flag4 = false;
						using (List<CardData>.Enumerator enumerator = cardDataMap.Cards.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								if (enumerator.Current.ModID.Equals(cardData4.ModID))
								{
									Debug.Log("ModID重复:" + cardData4.ModID);
									flag4 = true;
								}
							}
						}
						if (!flag4)
						{
							cardDataMap.Cards.Add(cardData4);
						}
					}
					catch (Exception ex4)
					{
						Debug.Log(ex4.Message);
						Debug.Log("正在加载卡牌Mod  -  " + files3[m].DirectoryName + "/" + files3[m].Name);
					}
				}
			}
			else
			{
				Debug.Log("该目录没有MODPath:" + text);
			}
		}
		return cardDataMap;
	}

	public static AreaDataMap InitAreaDataMap()
	{
		AreaDataMap areaDataMap = new AreaDataMap();
		areaDataMap.Areas = new List<AreaData>();
		if (GlobalController.Instance.HomeDataController.info == null)
		{
			GlobalController.Instance.HomeDataController.info = new HomeData();
		}
		if (GlobalController.Instance.HomeDataController.info.PhysicsAreaData == null)
		{
			GlobalController.Instance.HomeDataController.info.PhysicsAreaData = new Dictionary<string, AreaData>();
		}
		string path = Application.streamingAssetsPath + "/Mods/Areas/";
		if (Directory.Exists(path))
		{
			FileInfo[] files = new DirectoryInfo(path).GetFiles("*.json", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				string value = File.ReadAllText(files[i].FullName, Encoding.UTF8);
				JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
				jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
				AreaData areaData = null;
				try
				{
					areaData = (JsonConvert.DeserializeObject(value, jsonSerializerSettings) as AreaData);
				}
				catch (Exception ex)
				{
					Debug.LogError(ex.Message);
					Debug.LogError(ex.StackTrace);
				}
				if (areaData == null)
				{
					areaData = (JsonConvert.DeserializeObject(value, typeof(AreaData)) as AreaData);
				}
				areaData.ModID = files[i].Name.Remove(files[i].Name.LastIndexOf("."), files[i].Name.Length - files[i].Name.LastIndexOf("."));
				areaData.ID = areaData.ModID;
				if (areaData.IsPhysicsData)
				{
					if (!GlobalController.Instance.HomeDataController.info.PhysicsAreaData.ContainsKey(areaData.ID))
					{
						GlobalController.Instance.HomeDataController.info.PhysicsAreaData.Add(areaData.ModID, areaData);
						areaDataMap.Areas.Add(areaData);
					}
					else
					{
						areaDataMap.Areas.Add(GlobalController.Instance.HomeDataController.info.PhysicsAreaData[areaData.ModID]);
					}
				}
				else
				{
					areaDataMap.Areas.Add(areaData);
				}
			}
			using (Dictionary<string, AreaData>.Enumerator enumerator = GlobalController.Instance.HomeDataController.info.PhysicsAreaData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, AreaData> keyValuePair = enumerator.Current;
					areaDataMap.Areas.Add(keyValuePair.Value);
				}
				return areaDataMap;
			}
		}
		Debug.LogError("地点Mod加载失败");
		return areaDataMap;
	}

	public static BookDataMap InitBookDataMap()
	{
		string text = Application.streamingAssetsPath + "/Mods/Books/";
		BookDataMap bookDataMap = new BookDataMap();
		bookDataMap.Books = new List<BookData>();
		if (Directory.Exists(text))
		{
			FileInfo[] files = new DirectoryInfo(text).GetFiles("*.json", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				string value = File.ReadAllText(text + "/" + files[i].Name, Encoding.UTF8);
				BookData bookData = JsonConvert.DeserializeObject(value, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				}) as BookData;
				if (bookData == null)
				{
					bookData = (JsonConvert.DeserializeObject(value, typeof(BookData)) as BookData);
				}
				bookData.ModID = files[i].Name.Remove(files[i].Name.LastIndexOf("."), files[i].Name.Length - files[i].Name.LastIndexOf("."));
				bookDataMap.Books.Add(bookData);
			}
		}
		else
		{
			Debug.LogError("书籍加载失败！");
		}
		return bookDataMap;
	}

	public static TaskDataMap InitTaskDataMap()
	{
		string text = Application.streamingAssetsPath + "/Mods/Tasks/";
		TaskDataMap taskDataMap = new TaskDataMap();
		taskDataMap.Tasks = new List<TaskData>();
		if (Directory.Exists(text))
		{
			FileInfo[] files = new DirectoryInfo(text).GetFiles("*.json", SearchOption.AllDirectories);
			for (int i = 0; i < files.Length; i++)
			{
				TaskData taskData = JsonConvert.DeserializeObject(File.ReadAllText(text + "/" + files[i].Name, Encoding.UTF8), typeof(TaskData)) as TaskData;
				taskData.ModID = files[i].Name.Remove(files[i].Name.LastIndexOf("."), files[i].Name.Length - files[i].Name.LastIndexOf("."));
				taskDataMap.Tasks.Add(taskData);
			}
		}
		else
		{
			Debug.LogError("任务Mod加载失败");
		}
		return taskDataMap;
	}

	public void InitWorld()
	{
		FileInfo[] files = new DirectoryInfo(Application.streamingAssetsPath + "/Init/World/").GetFiles("*.json", SearchOption.TopDirectoryOnly);
		string value = File.ReadAllText(Application.streamingAssetsPath + "/Init/World//" + files[0].Name, Encoding.UTF8);
		Debug.Log("加载卡片MOD:" + files[0].Name);
		GameController.getInstance().GameData = (JsonConvert.DeserializeObject(value, typeof(GameData)) as GameData);
		this.gameData = GameController.getInstance().GameData;
		if (Directory.Exists(Application.streamingAssetsPath + "/Init/World"))
		{
			this.GetAllLocalSubDirs(Application.streamingAssetsPath + "/Init/World", null);
		}
		else
		{
			Debug.LogError("未找到存档文件");
		}
		foreach (AreaData areaData in GameController.getInstance().AreaDataModMap.Areas)
		{
			if (!this.gameData.AreaMap.ContainsKey(areaData.ModID))
			{
				this.gameData.AreaMap.Add(areaData.ModID, areaData);
			}
		}
	}

	public void GetAllLocalSubDirs(string rootPath, AreaData area)
	{
		if (string.IsNullOrEmpty(rootPath))
		{
			return;
		}
		string fullPath = Path.GetFullPath(rootPath);
		if (string.IsNullOrEmpty(fullPath))
		{
			return;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
		FileInfo[] files = directoryInfo.GetFiles("*.are", SearchOption.TopDirectoryOnly);
		string value = File.ReadAllText(rootPath + "/" + files[0].Name);
		new JsonSerializerSettings().NullValueHandling = NullValueHandling.Include;
		AreaData areaData = JsonConvert.DeserializeObject(value, new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All
		}) as AreaData;
		if (areaData == null)
		{
			areaData = (JsonConvert.DeserializeObject(value, typeof(AreaData)) as AreaData);
		}
		areaData.ID = fullPath.Remove(0, Application.streamingAssetsPath.Length + "\\Init".Length).Replace('\\', '/');
		this.gameData.AreaMap.Add(areaData.ID, areaData);
		if (this.gameData.RootArea == null || this.gameData.RootArea.Name == null)
		{
			area = areaData;
			this.gameData.RootArea = areaData;
			if (string.IsNullOrEmpty(this.gameData.CurrentAreaId))
			{
				this.gameData.CurrentAreaId = "/World/不华/破屋";
			}
		}
		else
		{
			area.ChildrenAreaIDs.Add(areaData.ID);
			area = areaData;
		}
		FileInfo[] files2 = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files2.Length; i++)
		{
			if (!files2[i].Name.EndsWith(".meta"))
			{
				files2[i].Name.EndsWith(".are");
				if (files2[i].Name.EndsWith(".toy"))
				{
					CardData cardData = JsonConvert.DeserializeObject(File.ReadAllText(rootPath + "/" + files2[i].Name), typeof(CardData)) as CardData;
					if (area.Toys == null)
					{
						area.Toys = new List<CardData>();
					}
					GameController.getInstance().CardDataInWorldMap.Remove(cardData.ID);
					cardData.ID = (rootPath + "/" + files2[i].Name).Remove(0, Application.streamingAssetsPath.Length + "\\Init".Length).Replace('\\', '/');
					GameController.getInstance().CardDataInWorldMap.Add(cardData.ID, cardData);
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.DisplayPositionX = cardData.DisplayPositionX;
					cardSlotData.DisplayPositionZ = cardData.DisplayPositionY;
					cardSlotData.SetChildCardData(cardData);
					if ((cardData.CardTags & 32UL) > 0UL)
					{
						cardSlotData.SlotType = CardSlotData.Type.Grid;
						cardSlotData.IsFreeze = true;
					}
					else
					{
						cardSlotData.SlotType = CardSlotData.Type.UndisplayFreeze;
					}
					cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
					cardData.IsToy = true;
					cardData.CurrentAreaID = area.ID;
					if (area.CardSlotDatas == null)
					{
						area.CardSlotDatas = new List<CardSlotData>();
					}
					area.CardSlotDatas.Add(cardSlotData);
					if (cardData.Attrs.ContainsKey("CurrentParty"))
					{
						foreach (Party party in GameController.getInstance().GameData.Partys)
						{
							if (party.ID == cardData.Attrs["CurrentParty"] as string && cardData.ID != party.LeaderID)
							{
								party.PeopleIDs.Add(cardData.ID);
								Debug.Log(cardData.Name + cardData.ID + "加入" + party.Name);
							}
						}
					}
					GameController.getInstance().GameLogic.ToyBorn(cardData);
				}
			}
		}
		string[] directories = Directory.GetDirectories(fullPath);
		if (directories == null || directories.Length == 0)
		{
			return;
		}
		foreach (string rootPath2 in directories)
		{
			if (area.ChildrenAreaIDs == null)
			{
				area.ChildrenAreaIDs = new List<string>();
			}
			this.GetAllLocalSubDirs(rootPath2, area);
		}
	}

	private GameData gameData;

	private AreaData curArea;

	public static string WillLoadFile = "";

	public static AsyncOperation async = null;

	public delegate void SaveCallBack();
}
