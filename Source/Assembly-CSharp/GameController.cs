using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PixelCrushers.DialogueSystem;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VoxelBuilder;
using XLua;

public class GameController : MonoBehaviour
{
	public static GameController getInstance()
	{
		return GameController.ins;
	}

	private void Awake()
	{
		GameController.ins = this;
		GameController.PersistentDataPath = Application.persistentDataPath;
		this.AsyncEventManager = new AsyncEventManager();
		this.GameEventManager = new GameEventManager();
		this.jsonsFromWorkShop = new List<FileInfo>();
		PlayerPrefs.DeleteKey("PatientName");
		JsonConvert.DefaultSettings = (() => new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All,
			Converters = new List<JsonConverter>
			{
				new StringEnumConverter(),
				new TaskStepConverter()
			}
		});
		this.CardDataInWorldMap.Clear();
		this.GameLogic = base.gameObject.AddComponent<GameLogic>();
		this.GameLogic.Init();
		this.PNGResourceCache = new Dictionary<string, byte[]>();
		if (SteamManager.Initialized)
		{
			List<PublishedFileId_t> subscribedItems = global::SteamController.Instance.SteamUGC.GetSubscribedItems();
			this.LuaLogicCache = new Dictionary<string, string>();
			Debug.Log("共计订阅" + subscribedItems.Count.ToString() + "个MOD");
			foreach (PublishedFileId_t nPublishedFileID in subscribedItems)
			{
				ulong num;
				string path;
				uint num2;
				SteamUGC.GetItemInstallInfo(nPublishedFileID, out num, out path, 256U, out num2);
				this.LoadModFiles(path);
			}
		}
		if (!Directory.Exists(Application.dataPath + "/Mod"))
		{
			Directory.CreateDirectory(Application.dataPath + "/Mod");
		}
		this.LoadModFiles(Application.dataPath + "/Mod");
		this.LoadMod();
		foreach (string text in GlobalController.Instance.GlobalData.UnlockDataPathFromNewspaper)
		{
			if (!ModManager.IsModWorking(text))
			{
				try
				{
					ModManager.SetLockModWorking(text);
				}
				catch (Exception ex)
				{
					Debug.LogError("MOD加载失败：" + text);
					Debug.LogError(ex.Message);
				}
			}
		}
		GlobalController.Instance.GlobalData.UnLockCharacterTag = (GlobalController.Instance.GlobalData.UnLockCharacterTag | CharacterTag.受虐狂 | CharacterTag.善良 | CharacterTag.大度 | CharacterTag.弱智 | CharacterTag.忠诚 | CharacterTag.猥琐);
		this.AllPersonEvents = new List<PersonEvent>();
		foreach (PersonEvent personEvent in PersonEvent.GetAllPersonEvents())
		{
			if (personEvent.ID < 1000 || GlobalController.Instance.GlobalData.UnLockedPersonEventID.Contains(personEvent.ID))
			{
				this.AllPersonEvents.Add(personEvent);
			}
		}
	}

	private void LoadModFiles(string path)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.png", SearchOption.AllDirectories))
		{
			Debug.Log("加载来自创意工坊的PNG图片:" + fileInfo.FullName);
			byte[] value = File.ReadAllBytes(fileInfo.FullName);
			if (!this.PNGResourceCache.ContainsKey(fileInfo.JustName()))
			{
				this.PNGResourceCache.Add(fileInfo.JustName(), value);
			}
		}
		directoryInfo = new DirectoryInfo(path);
		foreach (FileInfo fileInfo2 in directoryInfo.GetFiles("*.lua", SearchOption.AllDirectories))
		{
			Debug.Log("加载来自创意工坊的LUA脚本:" + fileInfo2.FullName);
			string value2 = File.ReadAllText(fileInfo2.FullName);
			if (!this.LuaLogicCache.ContainsKey(fileInfo2.JustName()))
			{
				this.LuaLogicCache.Add(fileInfo2.JustName(), value2);
			}
		}
		directoryInfo = new DirectoryInfo(path);
		this.jsonsFromWorkShop.AddRange(directoryInfo.GetFiles("*.json", SearchOption.AllDirectories));
		directoryInfo = new DirectoryInfo(path);
		this.jsonsFromWorkShop.AddRange(directoryInfo.GetFiles("*.card", SearchOption.AllDirectories));
	}

	private void Start()
	{
		SceneManager.sceneLoaded += this.SceneLoadedCallBack;
		SceneManager.sceneUnloaded += this.SceneUnloadedCallBack;
		GlobalController instance = GlobalController.Instance;
		instance.OnLanguageChangedEvent = (Action<LanguageType>)Delegate.Combine(instance.OnLanguageChangedEvent, new Action<LanguageType>(this.OnLanguageChange));
		this.LoadGameScene();
		GlobalController.Instance.ChangeGlobalMoney(0);
		GlobalController.Instance.ChangeTwistedEggCoupon(0);
		if (GameData.CurrentGameType == GameData.GameType.Normal)
		{
			Vector3 position = Camera.main.transform.position;
			Camera.main.transform.position = Camera.main.transform.position * 1.2f;
			Camera.main.transform.DOMove(position, 1f, false);
		}
		this.UIController.MaskPanel.SetActive(true);
		this.UIController.MaskPanel.GetComponent<Image>().color = Color.black;
		this.UIController.HideBlackMask(delegate
		{
			UIController.LockLevel = UIController.UILevel.None;
		}, 1f);
		if (GlobalController.Instance.GameSettingController.info.language == LanguageType.EN)
		{
			DialogueManager.instance.SetLanguage("en");
			return;
		}
		DialogueManager.instance.SetLanguage("");
	}

	private void OnLanguageChange(LanguageType obj)
	{
		if (obj == LanguageType.ZH_CN)
		{
			DialogueManager.instance.SetLanguage("");
			return;
		}
		if (obj != LanguageType.EN)
		{
			return;
		}
		DialogueManager.instance.SetLanguage("en");
	}

	private void LoadMod()
	{
		if (this.AreaDataModMap == null || this.AreaDataModMap.Areas == null || this.AreaDataModMap.Areas.Count == 0)
		{
			this.AreaDataModMap = SaveLoad.InitAreaDataMap();
		}
		if (this.CardDataModMap == null || this.CardDataModMap.Cards == null || this.CardDataModMap.Cards.Count == 0)
		{
			this.CardDataModMap = SaveLoad.InitCardDataMap("Cards");
		}
		if (this.BuildingModMap == null || this.BuildingModMap.Cards == null || this.BuildingModMap.Cards.Count == 0)
		{
			this.BuildingModMap = SaveLoad.InitCardDataMap("Buildings");
		}
		this.BookDataModMap = SaveLoad.InitBookDataMap();
		this.TaskDataMap = SaveLoad.InitTaskDataMap();
	}

	public void SaveGame()
	{
		try
		{
			if (GameData.CurrentGameType == GameData.GameType.Endless)
			{
				GameController.GameSavingSyncLock = false;
				return;
			}
			this.DeleteAllSaveData();
			GameData gameData = GameController.getInstance().GameData;
			gameData.SavedGameType = GameData.CurrentGameType;
			gameData.Seed = SYNCRandom.Seed;
			string contents = JsonConvert.SerializeObject(gameData, Formatting.Indented, new JsonSerializerSettings
			{
				DefaultValueHandling = DefaultValueHandling.Ignore
			});
			File.WriteAllText(GameController.PersistentDataPath + "/Save/" + DateTime.UtcNow.ToString("yyyy_MM_dd_mm_ss") + ".sav", contents, Encoding.UTF8);
			LoggerWriter.Instance.CreateAndWriteLogFile();
			GlobalController.Instance.AdvanceDataController.SaveAdvanceDataInfo();
			GlobalController.Instance.SaveGlobalData();
		}
		catch (Exception ex)
		{
			Debug.LogError("保存失败");
			Debug.LogError(ex.Message);
			Debug.LogError(ex.StackTrace);
		}
		GameController.GameSavingSyncLock = false;
	}

	public bool LoadGame()
	{
		FileInfo[] files = new DirectoryInfo(Application.persistentDataPath + "/Save/").GetFiles("*.sav", SearchOption.AllDirectories);
		int num = 0;
		if (num >= files.Length)
		{
			return false;
		}
		try
		{
			GameData gameData = JsonConvert.DeserializeObject(File.ReadAllText(files[num].DirectoryName + "/" + files[num].Name, Encoding.UTF8), new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.All
			}) as GameData;
			GameData.CurrentGameType = gameData.SavedGameType;
			GameController.ins.GameData = gameData;
			SYNCRandom.Rebuild(GameController.ins.GameData.Seed);
			foreach (CardSlotData cardSlotData in gameData.SlotsOnPlayerTable)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.英雄))
				{
					this.GameData.PlayerCardData = cardSlotData.ChildCardData;
				}
			}
			GlobalController.Instance.AdvanceDataController.LoadAdvanceDataInfo();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
			Debug.Log(ex.StackTrace);
			Debug.Log("读取进度失败  -  " + files[num].DirectoryName + "/" + files[num].Name);
			return false;
		}
		return true;
	}

	public bool DeleteAllSaveData()
	{
		FileInfo[] files = new DirectoryInfo(GameController.PersistentDataPath + "/Save/").GetFiles("*.sav", SearchOption.AllDirectories);
		for (int i = 0; i < files.Length; i++)
		{
			files[0].Delete();
		}
		return true;
	}

	public IEnumerator LoadHomeScene()
	{
		this.UIController.MaskPanel.SetActive(true);
		yield return SceneManager.LoadSceneAsync("Home", LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("Home"));
		this.UIController.HideBlackMask(delegate
		{
		}, 0.5f);
		yield break;
	}

	public IEnumerator LoadGuideHomeScene()
	{
		yield return SceneManager.LoadSceneAsync("GuideHome", LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("GuideHome"));
		this.MainCamera.transform.GetChild(0).GetComponent<CameraShake>().MaskPanel.DOFade(0f, 0.1f).OnComplete(delegate
		{
			this.MainCamera.transform.GetChild(0).GetComponent<CameraShake>().MaskPanel.gameObject.SetActive(false);
		});
		yield break;
	}

	public IEnumerator ShowTable(TableType tableType, bool hideMainTable = false)
	{
		switch (tableType)
		{
		case TableType.BattleTable:
			if (this.CurrentTableType != TableType.BattleTable)
			{
				GameController.ins.UIController.HideItemTableOnAreaTable();
				GameController.ins.UIController.HideMinionTableOnAreaTable();
				GameController.ins.UIController.HideSkillTableOnAreaTable();
				GameController.ins.UIController.ShowBattleTableOnArea();
				this.CurrentTableType = TableType.BattleTable;
			}
			break;
		case TableType.MinionsTable:
			if (this.CurrentTableType != TableType.MinionsTable)
			{
				GameController.ins.UIController.HideItemTableOnAreaTable();
				GameController.ins.UIController.HideMinionTableOnAreaTable();
				GameController.ins.UIController.HideSkillTableOnAreaTable();
				GameController.ins.UIController.HideBattleTableOnAreaTable();
				GameController.ins.UIController.ShowMinionTableOnArea();
				this.CurrentTableType = TableType.MinionsTable;
			}
			break;
		case TableType.ItemsTable:
			if (this.CurrentTableType != TableType.ItemsTable)
			{
				GameController.ins.UIController.HideItemTableOnAreaTable();
				GameController.ins.UIController.HideMinionTableOnAreaTable();
				GameController.ins.UIController.HideSkillTableOnAreaTable();
				GameController.ins.UIController.HideBattleTableOnAreaTable();
				GameController.ins.UIController.ShowItemTableOnArea();
				this.CurrentTableType = TableType.ItemsTable;
			}
			break;
		case TableType.MagicTable:
			if (this.CurrentTableType != TableType.MagicTable)
			{
				GameController.ins.UIController.HideItemTableOnAreaTable();
				GameController.ins.UIController.HideMinionTableOnAreaTable();
				GameController.ins.UIController.HideSkillTableOnAreaTable();
				GameController.ins.UIController.HideBattleTableOnAreaTable();
				GameController.ins.UIController.ShowSkillTableOnArea();
				this.CurrentTableType = TableType.MagicTable;
			}
			break;
		default:
			if (tableType == TableType.NoTable && this.CurrentTableType != TableType.NoTable)
			{
				GameController.ins.UIController.HideItemTableOnAreaTable();
				GameController.ins.UIController.HideMinionTableOnAreaTable();
				GameController.ins.UIController.HideSkillTableOnAreaTable();
				GameController.ins.UIController.HideBattleTableOnAreaTable();
				this.CurrentTableType = TableType.NoTable;
			}
			break;
		}
		yield break;
	}

	private void LoadGameScene()
	{
		if (SaveLoad.WillLoadFile.Equals("LoadScene"))
		{
			FileInfo[] files = new DirectoryInfo(Application.streamingAssetsPath + "/Save/").GetFiles("*", SearchOption.AllDirectories);
			int i = 0;
			int num = 0;
			while (i < files.Length)
			{
				if (files[i].Name.IndexOf("meta") <= 0)
				{
					num++;
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.UndisplaySlotPrefab);
					gameObject.transform.SetParent(this.PlayerTableSlotParent, true);
					CardSlot component = gameObject.GetComponent<CardSlot>();
					component.CardSlotData = new CardSlotData();
					component.CardSlotData.SlotType = CardSlotData.Type.Undisplay;
					gameObject.transform.localPosition = new Vector3((float)(num % 15) + 0.05f * (float)(num % 15), 0f, (float)(num / 15) + (float)(num / 15) * 0.05f);
					CardData cardData = CardData.CopyCardData(this.CardDataModMap.getCardDataByModID("软盘"), true);
					cardData.desc = "存档文件";
					cardData.Attrs.Add("FileName", files[i].Name);
					cardData.Name = files[i].Name;
					cardData.HP = 0;
					cardData._ATK = 0;
					cardData.CardTags = 0UL;
					component.CardSlotData.SetChildCardData(cardData);
				}
				i++;
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.LoadModelOfType("UndisplaySlot", 0));
			gameObject2.transform.SetParent(this.PlayerTableSlotParent, true);
			gameObject2.GetComponent<CardSlot>().CardSlotData = new CardSlotData();
			gameObject2.GetComponent<CardSlot>().CardSlotData.SlotType = CardSlotData.Type.Undisplay;
			GameController.getInstance().GameEventManager.OnCardChangeSlotEvent += this.func;
		}
		else if (string.IsNullOrEmpty(SaveLoad.WillLoadFile))
		{
			base.GetComponent<SaveLoad>().InitWorld();
			this.InitWorld();
			this.GameEventManager.GameStart();
		}
		else
		{
			SaveLoad.Load(SaveLoad.WillLoadFile);
			TicketController.Instance.InitTicketContent();
			this.InitWorld();
		}
		this.GameEventManager.MoneyChange(this.GameData.Money);
		this.GameEventManager.MoneyChange(this.GameData.Money);
		List<CardData> list = new List<CardData>();
		foreach (KeyValuePair<string, CardData> keyValuePair in this.CardDataInWorldMap)
		{
			list.Add(keyValuePair.Value);
		}
		foreach (CardData cardData2 in list)
		{
			cardData2.OnGameLoaded();
		}
		foreach (KeyValuePair<string, AreaData> keyValuePair2 in this.GameData.AreaMap)
		{
			foreach (AreaLogic areaLogic in keyValuePair2.Value.Logics)
			{
				areaLogic.OnGameLoaded();
			}
		}
		if (GlobalController.Instance.IsLoadGame)
		{
			this.LoadGame();
			base.StartCoroutine(GameController.ins.ShowTable(TableType.BattleTable, false));
			foreach (JournalsBean journalsBean in GameController.ins.GameData.JournalsList)
			{
				TextMeshProUGUI journalsText = GameController.ins.UIController.JournalsText;
				journalsText.text = journalsText.text + "\n\n" + journalsBean.ToString();
				GameController.ins.UIController.JournalsScroll.gameObject.SetActive(false);
				GameController.ins.UIController.JournalsScroll.gameObject.SetActive(true);
				GameController.ins.UIController.JournalsScroll.GetComponent<RectTransform>().ForceUpdateRectTransforms();
				GameController.ins.UIController.JournalsScroll.verticalScrollbar.value = 0f;
			}
			DungeonController.Instance.GameSettleData = GameController.ins.GameData.GameSettleData;
		}
		else
		{
			this.DeleteAllSaveData();
		}
		this.ShowTable();
	}

	public bool IsTimeStop
	{
		get
		{
			return this.isTimeStop;
		}
	}

	public void ChangeTimePause(bool value)
	{
		if (this.isTimeStop == value)
		{
			return;
		}
		this.isTimeStop = !this.isTimeStop;
		this.GameEventManager.ChangeDeltaTime((float)(this.isTimeStop ? 0 : 1));
	}

	public void ChangeTimeScale(float scale)
	{
		this.GameEventManager.ChangeDeltaTime(scale);
	}

	public void func(CardSlot oldCardSlot, CardSlot newCardSlot, Card card)
	{
		if (newCardSlot.CardSlotData.SlotType == CardSlotData.Type.Normal)
		{
			SaveLoad.WillLoadFile = (card.CardData.Attrs["FileName"] as string);
			GameController.getInstance().GameEventManager.OnCardChangeSlotEvent -= this.func;
			base.StartCoroutine(base.GetComponent<SaveLoad>().LoadScene());
		}
	}

	public void EnterLoadScene()
	{
		SaveLoad.WillLoadFile = "LoadScene";
		base.StartCoroutine(base.GetComponent<SaveLoad>().LoadScene());
	}

	private void OnDestroy()
	{
		CommonAttribute.MaterialMap.Clear();
		CommonAttribute.MaterialModIDMap.Clear();
	}

	public void InitWorld()
	{
		foreach (AreaData areaData in this.GameData.AreaMap.Values)
		{
			if (areaData.CardSlotDatas != null)
			{
				foreach (CardSlotData cardSlotData in areaData.CardSlotDatas)
				{
					cardSlotData.CurrentAreaData = areaData;
					if (cardSlotData.ChildCardData != null)
					{
						cardSlotData.ChildCardData.CurrentCardSlotData = cardSlotData;
					}
				}
			}
		}
		this.CityMap = this.GetCityMap();
	}

	public void ShowTable()
	{
		if (!this.GameData.AreaMap.ContainsKey(this.GameData.CurrentAreaId))
		{
			return;
		}
		AreaData areaData;
		if (GameData.CurrentGameType == GameData.GameType.Endless && !GlobalController.Instance.IsLoadGame)
		{
			this.GameData.CurrentAreaId = "英雄之家";
			areaData = this.GameData.AreaMap[this.GameData.CurrentAreaId];
		}
		else
		{
			areaData = this.GameData.AreaMap[this.GameData.CurrentAreaId];
		}
		if (!string.IsNullOrEmpty(areaData.AdvocateName) || !string.IsNullOrEmpty(areaData.TabooName))
		{
			if (!string.IsNullOrEmpty(areaData.AdvocateName))
			{
				this.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_36"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord(areaData.AdvocateName),
					"\n<size=16>\n",
					LocalizationMgr.Instance.GetLocalizationWord(areaData.AdvocateDESC),
					"</size>"
				});
				this.UIController.AreaAdvocateDesc.GetComponent<ContentSizeFitter>().SetLayoutVertical();
				this.UIController.AreaAdvocateDesc.transform.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			}
			else
			{
				this.UIController.AreaAdvocateDesc.text = "无";
			}
			if (!string.IsNullOrEmpty(areaData.TabooName))
			{
				this.UIController.AreaTabooDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_37"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord(areaData.TabooName),
					"\n<size=16>\n",
					LocalizationMgr.Instance.GetLocalizationWord(areaData.TabooDESC),
					"</size>"
				});
				this.UIController.AreaTabooDesc.GetComponent<ContentSizeFitter>().SetLayoutVertical();
				this.UIController.AreaTabooDesc.transform.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			}
			else
			{
				this.UIController.AreaTabooDesc.text = "无";
			}
			this.UIController.AreaAdvocateDesc.transform.parent.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			this.UIController.AreaAdvocateDesc.transform.parent.parent.DOMoveX(0f, 0.5f, false);
		}
		else
		{
			this.UIController.AreaAdvocateDesc.transform.parent.parent.DOMoveX(-300f, 0.5f, false);
		}
		this.UIController.CurrentAreaDataPanel.SetCurrentAreaDataContent(this.GameData.CurrentAreaId);
		this.CurrentArea = new GameObject(areaData.Name);
		this.CurrentArea.transform.SetParent(this.Opposite.transform, false);
		this.CurrentTable = UnityEngine.Object.Instantiate<GameObject>(this.LoadModelOfType("AreaTable", 0));
		UnityEngine.Object.Instantiate<GameObject>(this.LoadModelOfType(areaData.TableModel, 0)).transform.SetParent(this.CurrentTable.transform, false);
		this.CurrentTable.GetComponent<OppositeTable>().templateArea = this.CurrentArea;
		this.CurrentTable.GetComponent<OppositeTable>().Init(areaData, 0f);
		foreach (AreaLogic areaLogic in areaData.Logics)
		{
			base.StartCoroutine(areaLogic.OnAlreadEnter());
		}
		this.InitPlayerTable();
		SYNCRandom.Rebuild(DateTime.Now.Millisecond);
	}

	public void InitPlayerTable()
	{
		if (this.PlayerSlotSets == null)
		{
			this.PlayerSlotSets = new List<CardSlotData>();
		}
		this.PlayerSlotSets.Clear();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Player;
		cardSlotData.IconIndex = 0;
		foreach (CardSlot cardSlot in this.CardSlotsOnPlayerTable)
		{
			if (cardSlot != null)
			{
				UnityEngine.Object.DestroyImmediate(cardSlot.gameObject);
			}
		}
		CardData playerCardData = this.GameData.PlayerCardData;
		foreach (CardSlotData cardSlotData2 in this.GameData.SlotsOnPlayerTable)
		{
		}
		this.CardSlotsOnPlayerTable = new CardSlot[this.GameData.SlotsOnPlayerTable.Count];
		this.BlueLineSlots = new List<CardSlotData>();
		this.YellowLineSlots = new List<CardSlotData>();
		this.RedLineSlots = new List<CardSlotData>();
		for (int j = 0; j < this.GameData.SlotsOnPlayerTable.Count; j++)
		{
			if (this.GameData.SlotsOnPlayerTable[j].DisplayPositionX <= 13f)
			{
				if (j / (this.GameData.SlotsOnPlayerTable.Count / 3) == 0)
				{
					this.GameData.SlotsOnPlayerTable[j].Color = CardSlotData.LineColor.blue;
					this.GameData.SlotsOnPlayerTable[j].GridPositionX = j % (this.GameData.SlotsOnPlayerTable.Count / 3);
					this.GameData.SlotsOnPlayerTable[j].GridPositionY = 0;
					this.BlueLineSlots.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				else if (j / (this.GameData.SlotsOnPlayerTable.Count / 3) == 2)
				{
					this.GameData.SlotsOnPlayerTable[j].Color = CardSlotData.LineColor.Yellow;
					this.GameData.SlotsOnPlayerTable[j].GridPositionX = j % (this.GameData.SlotsOnPlayerTable.Count / 3);
					this.GameData.SlotsOnPlayerTable[j].GridPositionY = 2;
					this.YellowLineSlots.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				else if (j / (this.GameData.SlotsOnPlayerTable.Count / 3) == 1)
				{
					this.GameData.SlotsOnPlayerTable[j].Color = CardSlotData.LineColor.Red;
					this.GameData.SlotsOnPlayerTable[j].GridPositionX = j % (this.GameData.SlotsOnPlayerTable.Count / 3);
					this.GameData.SlotsOnPlayerTable[j].GridPositionY = 1;
					this.RedLineSlots.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				if (!this.GameData.SlotsOnPlayerTable[j].Attrs.ContainsKey("Col"))
				{
					this.GameData.SlotsOnPlayerTable[j].Attrs.Add("Col", j % (this.GameData.SlotsOnPlayerTable.Count / 3));
				}
				this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Undisplay;
				this.GameData.SlotsOnPlayerTable[j].IconIndex = 1;
				CardSlot cardSlot2 = CardSlot.InitCardSlot(this.GameData.SlotsOnPlayerTable[j], 0f);
				cardSlot2.transform.SetParent(this.PlayerTableSlotParent, false);
				this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 524424UL;
				this.GameData.SlotsOnPlayerTable[j].OnlyAcceptOneCard = true;
				cardSlot2.CardSlotData.MarkFlipState(true);
				if (j % 15 == 3 || j % 15 > 9)
				{
					this.GameData.SlotsOnPlayerTable[j].IconIndex = 0;
					this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Freeze;
				}
				if (j % 15 == 4 || j % 15 == 5)
				{
					this.GameData.SlotsOnPlayerTable[j].IconIndex = 5;
					this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 12884967426UL;
					this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Undisplay;
					this.GameData.SlotsOnPlayerTable[j].OnlyAcceptOneCard = false;
				}
				if (GameData.CurrentGameType == GameData.GameType.Normal)
				{
					if (j % 15 == 8 || j % 15 == 7 || j % 15 == 6 || j % 15 == 9)
					{
						this.GameData.SlotsOnPlayerTable[j].IconIndex = 4;
						this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 64UL;
						this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Undisplay;
						this.GameData.SlotsOnPlayerTable[j].OnlyAcceptOneCard = false;
					}
				}
				else
				{
					if (j % 15 == 7 || j % 15 == 6)
					{
						this.GameData.SlotsOnPlayerTable[j].IconIndex = 4;
						this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 64UL;
						this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Undisplay;
						this.GameData.SlotsOnPlayerTable[j].OnlyAcceptOneCard = false;
					}
					if (j % 15 == 8 || j % 15 == 9)
					{
						this.GameData.SlotsOnPlayerTable[j].IconIndex = 12;
						this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 17179869184UL;
						this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Undisplay;
						this.GameData.SlotsOnPlayerTable[j].OnlyAcceptOneCard = false;
					}
				}
				this.CardSlotsOnPlayerTable[j] = cardSlot2.GetComponent<CardSlot>();
				cardSlot2.UpdateView();
				if (this.GameData.SlotsOnPlayerTable[j].ChildCardData != null && this.GameData.SlotsOnPlayerTable[j].ChildCardData.Name == null)
				{
					int count = this.GameData.SlotsOnPlayerTable[j].ChildCardData.Count;
					CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.GameData.SlotsOnPlayerTable[j].ChildCardData.ModID), true);
					if (count > 1)
					{
						cardData.Count = count;
					}
					cardData.PutInSlotData(cardSlot2.CardSlotData, true);
				}
				this.PlayerSlotSets.Add(this.CardSlotsOnPlayerTable[j].CardSlotData);
			}
		}
	}

	public AreaData GetCurrentAreaData()
	{
		return this.GameData.AreaMap[this.GameData.CurrentAreaId];
	}

	public void InitCOOPPlayerTable()
	{
		if (this.PlayerSlotSets == null)
		{
			this.PlayerSlotSets = new List<CardSlotData>();
		}
		this.PlayerSlotSets.Clear();
		foreach (CardSlot cardSlot in this.CardSlotsOnPlayerTable)
		{
			if (cardSlot != null)
			{
				UnityEngine.Object.DestroyImmediate(cardSlot.gameObject);
			}
		}
		CardData playerCardData = this.GameData.PlayerCardData;
		foreach (CardSlotData cardSlotData in this.GameData.SlotsOnPlayerTable)
		{
			cardSlotData.SetChildCardData(null);
		}
		this.CardSlotsOnPlayerTable = new CardSlot[this.GameData.SlotsOnPlayerTable.Count];
		this.BlueLineSlots = new List<CardSlotData>();
		this.YellowLineSlots = new List<CardSlotData>();
		this.RedLineSlots = new List<CardSlotData>();
		this.PlayerTableTempArea = new List<CardSlotData>();
		this.PublicArea = new List<CardSlotData>();
		this.PartnerArea = new List<CardSlotData>();
		for (int j = 0; j < this.GameData.SlotsOnPlayerTable.Count; j++)
		{
			int num = this.GameData.SlotsOnPlayerTable.Count / 3;
			if (this.GameData.SlotsOnPlayerTable[j].DisplayPositionX <= 13f)
			{
				if (j / num == 0)
				{
					this.GameData.SlotsOnPlayerTable[j].Color = CardSlotData.LineColor.blue;
					this.BlueLineSlots.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				else if (j / num == 2)
				{
					this.GameData.SlotsOnPlayerTable[j].Color = CardSlotData.LineColor.Yellow;
					this.YellowLineSlots.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				else if (j / num == 1)
				{
					this.GameData.SlotsOnPlayerTable[j].Color = CardSlotData.LineColor.Red;
					this.RedLineSlots.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				if (!this.GameData.SlotsOnPlayerTable[j].Attrs.ContainsKey("Col"))
				{
					this.GameData.SlotsOnPlayerTable[j].Attrs.Add("Col", j % 5);
				}
				else
				{
					this.GameData.SlotsOnPlayerTable[j].Attrs["Col"] = j % 5;
				}
				this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Undisplay;
				this.GameData.SlotsOnPlayerTable[j].IconIndex = 1;
				CardSlot cardSlot2 = CardSlot.InitCardSlot(this.GameData.SlotsOnPlayerTable[j], 0f);
				cardSlot2.transform.SetParent(this.PlayerTableSlotParent, false);
				this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 128UL;
				cardSlot2.CardSlotData.MarkFlipState(true);
				if (j % num == 3 || j % num == 4 || j % num == 8 || j % num == 9)
				{
					CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("卡槽锁"), true).PutInSlotData(cardSlot2.CardSlotData, true);
					this.GameData.SlotsOnPlayerTable[j].IconIndex = 3;
					this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Freeze;
				}
				else if (j % num == 5 || j % num == 6 || j % num == 7)
				{
					this.GameData.SlotsOnPlayerTable[j].IconIndex = 1;
					this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 128UL;
					this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.OnlyPut;
					this.PublicArea.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				else if (j % num > 9)
				{
					this.GameData.SlotsOnPlayerTable[j].IconIndex = 11;
					this.GameData.SlotsOnPlayerTable[j].TagWhiteList = 8UL;
					this.GameData.SlotsOnPlayerTable[j].SlotType = CardSlotData.Type.Freeze;
					this.PartnerArea.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				else
				{
					this.PlayerTableTempArea.Add(this.GameData.SlotsOnPlayerTable[j]);
				}
				this.CardSlotsOnPlayerTable[j] = cardSlot2.GetComponent<CardSlot>();
				cardSlot2.UpdateView();
				if (this.GameData.SlotsOnPlayerTable[j].ChildCardData != null && this.GameData.SlotsOnPlayerTable[j].ChildCardData.Name == null)
				{
					int count = this.GameData.SlotsOnPlayerTable[j].ChildCardData.Count;
					CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.GameData.SlotsOnPlayerTable[j].ChildCardData.ModID), true);
					if (count > 1)
					{
						cardData.Count = count;
					}
					cardData.PutInSlotData(cardSlot2.CardSlotData, true);
				}
				this.PlayerSlotSets.Add(this.CardSlotsOnPlayerTable[j].CardSlotData);
			}
		}
		this.CreatePlayer("金箍王子");
	}

	public void InitVSPlayerTable()
	{
		if (this.PlayerSlotSets == null)
		{
			this.PlayerSlotSets = new List<CardSlotData>();
		}
		this.PlayerSlotSets.Clear();
		foreach (CardSlot cardSlot in this.CardSlotsOnPlayerTable)
		{
			if (cardSlot != null)
			{
				UnityEngine.Object.DestroyImmediate(cardSlot.gameObject);
			}
		}
		CardData playerCardData = this.GameData.PlayerCardData;
		foreach (CardSlotData cardSlotData in this.GameData.SlotsOnPlayerTable)
		{
			cardSlotData.SetChildCardData(null);
		}
		this.CardSlotsOnPlayerTable = new CardSlot[this.GameData.SlotsOnPlayerTable.Count];
		this.BlueLineSlots = new List<CardSlotData>();
		this.YellowLineSlots = new List<CardSlotData>();
		this.RedLineSlots = new List<CardSlotData>();
		this.PlayerTableTempArea = new List<CardSlotData>();
		this.PublicArea = new List<CardSlotData>();
		this.PartnerArea = new List<CardSlotData>();
		int num = this.GameData.SlotsOnPlayerTable.Count / 3;
		int num2 = 0;
		while (num2 < this.GameData.SlotsOnPlayerTable.Count && num2 / num < 3)
		{
			if (this.GameData.SlotsOnPlayerTable[num2].DisplayPositionX > 13f)
			{
				this.GameData.SlotsOnPlayerTable[num2] = null;
			}
			else
			{
				if (num2 / num == 0)
				{
					this.GameData.SlotsOnPlayerTable[num2].Color = CardSlotData.LineColor.blue;
					this.BlueLineSlots.Add(this.GameData.SlotsOnPlayerTable[num2]);
					this.PlayerSlotSets[num2].GridPositionX = num2 % num;
					this.PlayerSlotSets[num2].GridPositionY = num2 / num;
				}
				else if (num2 / num == 2)
				{
					this.GameData.SlotsOnPlayerTable[num2].Color = CardSlotData.LineColor.Yellow;
					this.YellowLineSlots.Add(this.GameData.SlotsOnPlayerTable[num2]);
					this.PlayerSlotSets[num2].GridPositionX = num2 % num;
					this.PlayerSlotSets[num2].GridPositionY = num2 / num;
				}
				else if (num2 / num == 1)
				{
					this.GameData.SlotsOnPlayerTable[num2].Color = CardSlotData.LineColor.Red;
					this.RedLineSlots.Add(this.GameData.SlotsOnPlayerTable[num2]);
					this.PlayerSlotSets[num2].GridPositionX = num2 % num;
					this.PlayerSlotSets[num2].GridPositionY = num2 / num;
				}
				if (!this.GameData.SlotsOnPlayerTable[num2].Attrs.ContainsKey("Col"))
				{
					this.GameData.SlotsOnPlayerTable[num2].Attrs.Add("Col", num2 % 5);
				}
				else
				{
					this.GameData.SlotsOnPlayerTable[num2].Attrs["Col"] = num2 % 5;
				}
				this.GameData.SlotsOnPlayerTable[num2].SlotType = CardSlotData.Type.Undisplay;
				this.GameData.SlotsOnPlayerTable[num2].IconIndex = 1;
				CardSlot cardSlot2 = CardSlot.InitCardSlot(this.GameData.SlotsOnPlayerTable[num2], 0f);
				cardSlot2.transform.SetParent(this.PlayerTableSlotParent, false);
				this.GameData.SlotsOnPlayerTable[num2].TagWhiteList = 128UL;
				cardSlot2.CardSlotData.MarkFlipState(true);
				if (num2 % num == 3 || num2 % num == 4 || num2 % num > 7)
				{
					CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("卡槽锁"), true).PutInSlotData(cardSlot2.CardSlotData, true);
					this.GameData.SlotsOnPlayerTable[num2].IconIndex = 3;
					this.GameData.SlotsOnPlayerTable[num2].SlotType = CardSlotData.Type.Freeze;
					this.GameData.SlotsOnPlayerTable[num2] = null;
				}
				else
				{
					if (num2 % num != 5 && num2 % num != 6 && num2 % num != 7)
					{
						this.PlayerTableTempArea.Add(this.GameData.SlotsOnPlayerTable[num2]);
						this.GameData.SlotsOnPlayerTable[num2] = null;
						goto IL_4D9;
					}
					this.GameData.SlotsOnPlayerTable[num2].IconIndex = 1;
					this.GameData.SlotsOnPlayerTable[num2].TagWhiteList = 128UL;
					this.GameData.SlotsOnPlayerTable[num2].SlotType = CardSlotData.Type.OnlyPut;
					this.PublicArea.Add(this.GameData.SlotsOnPlayerTable[num2]);
				}
				this.CardSlotsOnPlayerTable[num2] = cardSlot2.GetComponent<CardSlot>();
				cardSlot2.UpdateView();
			}
			IL_4D9:
			num2++;
		}
		for (int j = this.GameData.SlotsOnPlayerTable.Count - 1; j >= 0; j--)
		{
			if (this.GameData.SlotsOnPlayerTable[j] == null)
			{
				this.GameData.SlotsOnPlayerTable.RemoveAt(j);
			}
			else
			{
				this.PlayerSlotSets.Insert(0, this.GameData.SlotsOnPlayerTable[j]);
			}
		}
		for (int k = 0; k < this.PlayerSlotSets.Count; k++)
		{
			this.PlayerSlotSets[k].GridPositionX = k % 3;
			this.PlayerSlotSets[k].GridPositionY = k / 3;
		}
		this.CreatePlayer("战斗核心");
		VSModeController.Instance.MyBattleCore = this.GameData.PlayerCardData;
	}

	public void CreatePlayer(string name)
	{
		CardData cardData = CardData.CopyCardData(this.CardDataModMap.getCardDataByModID(name), true);
		if (GameData.CurrentGameType != GameData.GameType.Endless)
		{
			cardData = this.GetHeroDataByLevel(cardData);
		}
		this.PlayerToy = Card.InitCard(cardData);
		this.PlayerToy.SetCardData(cardData);
		this.GameData.PlayerCardData = cardData;
		this.InitPlayerTable();
		this.PlayerCardSlot = this.PlayerSlotSets[1].CardSlotGameObject;
		if (MultiPlayerController.Instance != null)
		{
			CSteamID currentLobbyID = MultiPlayerController.Instance.CurrentLobbyID;
			this.PlayerCardSlot = this.PublicArea[1].CardSlotGameObject;
			cardData.Attrs.Add("Col", 1);
		}
		else if (VSModeController.Instance != null)
		{
			CSteamID currentLobbyID2 = VSModeController.Instance.CurrentLobbyID;
			this.PlayerCardSlot = this.PublicArea[1].CardSlotGameObject;
			cardData.Attrs.Add("Col", 1);
		}
		this.PlayerCardSlot.CardSlotData.ClearCardData();
		cardData.PutInSlotData(this.PlayerCardSlot.CardSlotData, true);
		this.PlayerToy.gameObject.AddComponent<Hero>();
		if (GlobalController.Instance.AdvanceDataController.GetEWaiWuQi())
		{
			CardData cardData2 = null;
			foreach (CardData cardData3 in this.CardDataModMap.Cards)
			{
				if (cardData3.HasTag(TagMap.装备))
				{
					cardData2 = CardData.CopyCardData(cardData3, true);
				}
			}
			if (cardData2 != null)
			{
				cardData2.PutInSlotData(this.PlayerSlotSets[3], true);
			}
		}
		if (GlobalController.Instance.AdvanceDataController.GetYaoShuiDengJi() > 0)
		{
			int yaoShuiDengJi = GlobalController.Instance.AdvanceDataController.GetYaoShuiDengJi();
			List<CardData> list = new List<CardData>();
			foreach (CardData cardData4 in this.CardDataModMap.Cards)
			{
				if (cardData4.HasTag(TagMap.药水) && cardData4.Rare == yaoShuiDengJi && cardData4.ModID.Contains("生命药水"))
				{
					list.Add(CardData.CopyCardData(cardData4, true));
				}
			}
			if (list.Count > 0)
			{
				list[SYNCRandom.Range(0, list.Count)].PutInSlotData(this.GetEmptySlotDataByCardTag(TagMap.药水), true);
			}
		}
		if (GlobalController.Instance.GetGlobalHadItem() != null && GameData.CurrentGameType != GameData.GameType.Endless)
		{
			CardData cardData5 = CardData.CopyCardData(GlobalController.Instance.GetGlobalHadItem(), true);
			cardData5.PutInSlotData(this.GetEmptySlotDataByCardData(cardData5), true);
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志24"), null, cardData5.Name, null, null, null, null));
			GlobalController.Instance.SetGlobalHadItem(null);
		}
		if (!string.IsNullOrEmpty(GlobalController.Instance.GetStartGameItem()) && GameData.CurrentGameType != GameData.GameType.Endless)
		{
			if (this.CardDataModMap.getCardDataByModID(GlobalController.Instance.GetStartGameItem()) == null)
			{
				List<CardData> list2 = new List<CardData>();
				foreach (CardData cardData6 in GameController.ins.CardDataModMap.Cards)
				{
					if ((cardData6.HasTag(TagMap.药水) || cardData6.HasTag(TagMap.食物) || cardData6.HasTag(TagMap.工具) || cardData6.HasTag(TagMap.放置物)) && !cardData6.HasTag(TagMap.特殊))
					{
						list2.Add(CardData.CopyCardData(cardData6, true));
					}
				}
				CardData cardData7 = CardData.CopyCardData(list2[SYNCRandom.Range(0, list2.Count)], true);
				cardData7.PutInSlotData(this.GetEmptySlotDataByCardData(cardData7), true);
				JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志25"), null, LocalizationMgr.Instance.GetLocalizationWord(cardData7.Name), null, null, null, null));
				GlobalController.Instance.SetStartGameItem("");
			}
			else
			{
				CardData cardData8 = Card.InitCardDataByID(GlobalController.Instance.GetStartGameItem());
				cardData8.PutInSlotData(this.GetEmptySlotDataByCardData(cardData8), true);
				JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志25"), null, LocalizationMgr.Instance.GetLocalizationWord(cardData8.Name), null, null, null, null));
				GlobalController.Instance.SetStartGameItem("");
			}
		}
		DungeonController.Instance.GetHero();
	}

	public bool IsPlayerCardSlotData(CardSlotData cardSlot)
	{
		return this.PlayerSlotSets.Contains(cardSlot);
	}

	public Card FindCard(string name)
	{
		Card card = this.FindCardOnPlayerTable(name);
		if (card != null)
		{
			return card;
		}
		foreach (Card card2 in this.CurrentTable.GetComponent<OppositeTable>().transform.GetComponentsInChildren<Card>(true))
		{
			if (card2.CardData.Name.Equals(name))
			{
				return card2;
			}
		}
		return null;
	}

	public Card FindCardOnPlayerTable(string name)
	{
		foreach (CardSlot cardSlot in this.CardSlotsOnPlayerTable)
		{
			if (cardSlot != null && cardSlot.ChildCard != null && cardSlot.ChildCard.CardData.Name.Equals(name))
			{
				return cardSlot.ChildCard;
			}
		}
		return null;
	}

	public int FindCardOnPlayerTableCount(string name)
	{
		int num = 0;
		foreach (CardSlot cardSlot in this.CardSlotsOnPlayerTable)
		{
			if (cardSlot != null && cardSlot.ChildCard != null && cardSlot.ChildCard.CardData.Name.Equals(name))
			{
				num += cardSlot.ChildCard.CardData.Count;
			}
		}
		return num;
	}

	public int FindCardOnPlayerTableByType(CardData targetCardData)
	{
		int num = 0;
		if (targetCardData != null && (targetCardData.CardTags & 16UL) > 0UL)
		{
			num += targetCardData.Count;
		}
		return num;
	}

	private Dictionary<AreaData, List<object[]>> GetCityMap()
	{
		Dictionary<AreaData, List<object[]>> dictionary = new Dictionary<AreaData, List<object[]>>();
		List<AreaData> list = new List<AreaData>();
		foreach (KeyValuePair<string, AreaData> keyValuePair in this.GameData.AreaMap)
		{
			if (keyValuePair.Value.ID.Split(new char[]
			{
				'/'
			}).Length == 3)
			{
				list.Add(keyValuePair.Value);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			AreaData key = list[i];
			List<object[]> list2 = new List<object[]>();
			for (int j = 0; j < list.Count; j++)
			{
				if (j != i)
				{
					int num = Mathf.Abs(list[j].XInMap - list[i].XInMap) + Mathf.Abs(list[j].YInMap - list[i].YInMap);
					float num2 = 0.5f;
					num = (((int)((float)num * num2) > 0) ? ((int)((float)num * num2)) : 1);
					object[] item = new object[]
					{
						list[j],
						num
					};
					list2.Add(item);
				}
			}
			dictionary.Add(key, list2);
		}
		return dictionary;
	}

	public void OnMoveInTheWorld(Area middleArea, Area nextArea)
	{
		this.m_SkipNext = nextArea;
		if (this.CurrentCityID.Equals(nextArea.AreaData.ID))
		{
			this.OnTableChange(nextArea.AreaData, true);
			return;
		}
		AreaData key = GameController.getInstance().GameData.AreaMap[GameController.getInstance().CurrentCityID];
		foreach (object[] array in this.CityMap[key])
		{
			if ((AreaData)array[0] == nextArea.AreaData)
			{
				middleArea.GetComponent<AreaChange>().SetNextAreaDataID(((AreaData)array[0]).ID);
				middleArea.GetComponent<AreaChange>().CardCount = (int)array[1];
			}
		}
		this.OnTableChange(middleArea.AreaData, true);
	}

	public IEnumerator RotateCardAnimate(CardSlot cardSlot, string newCardID)
	{
		Vector3 startPos = cardSlot.ChildCard.transform.position;
		base.GetComponent<AudioSource>().Play();
		int num2;
		for (int i = 1; i <= 20; i = num2 + 1)
		{
			float num = Mathf.Lerp(-1f, 1f, (float)i / 20f);
			cardSlot.ChildCard.transform.position = startPos + new Vector3(0f, -num * num + 1f, 0f);
			cardSlot.ChildCard.transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(0f, 1440f, (float)i / 20f), Vector3.forward);
			yield return new WaitForSeconds(0.025f);
			num2 = i;
		}
		cardSlot.ChildCard.CardData.DeleteCardData();
		CardData childCardData = Card.InitCardDataByID(newCardID);
		cardSlot.CardSlotData.SetChildCardData(childCardData);
		yield break;
	}

	public void SkipBtn()
	{
		this.CurrentCityID = this.m_SkipNext.AreaData.ID;
		this.OnTableChange(this.m_SkipNext.AreaData, true);
	}

	public void ChangeCurrentArea()
	{
		this.CurrentArea.transform.GetChild(0).DOMove(this.CurrentArea.transform.GetChild(0).position - new Vector3(0f, 1f, 0f), 1f, false);
	}

	public void OnDayPast()
	{
	}

	private void Update()
	{
		LuaEnv luaenv = CardLogicAdapter.luaenv;
	}

	public IEnumerator UnlockCardSlot(int line)
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			yield break;
		}
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		int i = slotsOnPlayerTable.Count / 3 * line;
		while (i < slotsOnPlayerTable.Count / 3 * (line + 1))
		{
			if (slotsOnPlayerTable[i].ChildCardData != null && slotsOnPlayerTable[i].SlotType == CardSlotData.Type.Freeze)
			{
				if (slotsOnPlayerTable[i].ChildCardData.CardGameObject != null)
				{
					CardData childCardData = slotsOnPlayerTable[i].ChildCardData;
					slotsOnPlayerTable[i].SlotType = CardSlotData.Type.Undisplay;
					slotsOnPlayerTable[i].IconIndex = 1;
					slotsOnPlayerTable[i].CardSlotGameObject.UpdateView();
					GameObject go = UnityEngine.Object.Instantiate<GameObject>(slotsOnPlayerTable[i].ChildCardData.CardGameObject.gameObject, slotsOnPlayerTable[i].ChildCardData.CardGameObject.gameObject.transform.parent, true);
					UnityEngine.Object.Destroy(go.GetComponent<Card>());
					childCardData.DeleteCardData();
					foreach (Transform transform in go.transform.GetChild(4).GetChild(0).GetChilds())
					{
						transform.gameObject.AddComponent<Rigidbody>();
						transform.gameObject.AddComponent<BoxCollider>();
						transform.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f, go.transform.position - Vector3.up - Vector3.forward * 0.2f, 5f);
					}
					slotsOnPlayerTable[i].SlotType = CardSlotData.Type.Undisplay;
					slotsOnPlayerTable[i].IconIndex = 1;
					slotsOnPlayerTable[i].CardSlotGameObject.UpdateView();
					slotsOnPlayerTable[i].ChildCardData = null;
					yield return new WaitForSeconds(4f);
					UnityEngine.Object.DestroyImmediate(go);
					go = null;
					break;
				}
				break;
			}
			else
			{
				i++;
			}
		}
		yield return null;
		yield break;
	}

	public void OnTableChange(AreaData nextAreaData, bool playAnimation = true)
	{
		this.isTimeStop = true;
		UIController.LockLevel = UIController.UILevel.All;
		this.NextAreaData = nextAreaData;
		this.CurrentTable.GetComponent<OppositeTable>().Exit();
		this.NextArea = new GameObject(nextAreaData.Name);
		this.NextArea.transform.SetParent(this.Opposite.transform, false);
		this.NextTable = UnityEngine.Object.Instantiate<GameObject>(this.LoadModelOfType("AreaTable", 0));
		if (nextAreaData.TableModel != null)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.LoadModelOfType(nextAreaData.TableModel, 0)).transform.SetParent(this.NextTable.transform, false);
		}
		base.StartCoroutine(this.ChangeEffect(nextAreaData, playAnimation));
	}

	private IEnumerator ChangeEffect(AreaData nextAreaData, bool playAnimation = true)
	{
		AreaData areaData = this.GameData.AreaMap[this.GameData.CurrentAreaId];
		if (playAnimation)
		{
			foreach (AreaLogic areaLogic in areaData.Logics)
			{
				yield return areaLogic.ExitProcess();
			}
			List<AreaLogic>.Enumerator enumerator = default(List<AreaLogic>.Enumerator);
		}
		OppositeTable component = this.NextTable.GetComponent<OppositeTable>();
		this.Gear.GetComponent<Animator>().SetBool("turn", true);
		component.templateArea = this.NextArea;
		component.Init(nextAreaData, 0.25f);
		base.StartCoroutine(GameController.ins.ShowTable(TableType.BattleTable, false));
		if (!string.IsNullOrEmpty(nextAreaData.AdvocateName) || !string.IsNullOrEmpty(nextAreaData.TabooName))
		{
			if (!string.IsNullOrEmpty(nextAreaData.AdvocateName))
			{
				this.UIController.AreaAdvocateDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_36"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord(nextAreaData.AdvocateName),
					"\n<size=16>\n",
					LocalizationMgr.Instance.GetLocalizationWord(nextAreaData.AdvocateDESC),
					"</size>"
				});
				this.UIController.AreaAdvocateDesc.GetComponent<ContentSizeFitter>().SetLayoutVertical();
				this.UIController.AreaAdvocateDesc.transform.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			}
			else
			{
				this.UIController.AreaAdvocateDesc.text = "无";
			}
			if (!string.IsNullOrEmpty(nextAreaData.TabooName))
			{
				this.UIController.AreaTabooDesc.text = string.Concat(new string[]
				{
					LocalizationMgr.Instance.GetLocalizationWord("T_37"),
					" - ",
					LocalizationMgr.Instance.GetLocalizationWord(nextAreaData.TabooName),
					"\n<size=16>\n",
					LocalizationMgr.Instance.GetLocalizationWord(nextAreaData.TabooDESC),
					"</size>"
				});
				this.UIController.AreaTabooDesc.GetComponent<ContentSizeFitter>().SetLayoutVertical();
				this.UIController.AreaTabooDesc.transform.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			}
			else
			{
				this.UIController.AreaTabooDesc.text = "无";
			}
			this.UIController.AreaAdvocateDesc.transform.parent.parent.GetComponent<ContentSizeFitter>().SetLayoutVertical();
			this.UIController.AreaAdvocateDesc.transform.parent.parent.DOMoveX(0f, 0.5f, false);
		}
		else
		{
			this.UIController.AreaAdvocateDesc.transform.parent.parent.DOMoveX(-300f, 0.5f, false);
		}
		EffectAudioManager.Instance.PlayEffectAudio(24, null);
		this.CurrentArea.transform.Rotate(new Vector3(180f, 0f, 0f));
		this.GameEventManager.ExitArea(this.GameData.CurrentAreaId);
		this.GameData.CurrentAreaId = nextAreaData.ID;
		this.UIController.CurrentAreaDataPanel.SetCurrentAreaDataContent(this.GameData.CurrentAreaId);
		if (this.NextArea.name == "World" && this.Effect != null)
		{
			for (int j = this.Effect.transform.childCount - 1; j >= 0; j--)
			{
				UnityEngine.Object.Destroy(this.Effect.transform.GetChild(j).gameObject, 0f);
			}
		}
		if (!playAnimation)
		{
			this.Opposite.GetComponent<Animator>().speed = 100f;
		}
		else
		{
			this.Opposite.GetComponent<Animator>().speed = 1f;
		}
		this.Opposite.GetComponent<Animator>().SetTrigger("Play");
		yield return new WaitForSeconds(0.75f);
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			this.CurrentArea.transform.Translate(0f, -1f, 0f);
			yield return new WaitForSeconds(0.02f);
			num = i;
		}
		this.CurrentTable.GetComponent<OppositeTable>().Terminate();
		UnityEngine.Object.DestroyImmediate(this.CurrentArea.gameObject);
		this.CurrentArea = this.NextArea;
		this.NextArea = null;
		this.CurrentTable = this.NextTable;
		this.NextTable = null;
		UIController.LockLevel = UIController.UILevel.None;
		GameController.getInstance().GameEventManager.EnterArea(this.CurrentTable.GetComponent<OppositeTable>().areaData.ID);
		this.Gear.GetComponent<Animator>().SetBool("turn", false);
		this.isTimeStop = false;
		if (nextAreaData.ParentArea != null && nextAreaData.ParentArea.ID == "/World")
		{
			if (!nextAreaData.ID.Equals("建造场景"))
			{
				this.UIController.ShowBackToHomeButton();
			}
		}
		else
		{
			this.UIController.HideBackToHomeButton();
			this.UIController.ShowCancelGameBtn();
		}
		if (nextAreaData != null)
		{
			nextAreaData.ID == "/World";
		}
		yield return this.CurrentTable.GetComponent<OppositeTable>().OnAlreadEnter();
		yield break;
		yield break;
	}

	public IEnumerator CameraMove(float view, Vector3 pos, Vector3 rot, float duration)
	{
		Sequence sequence = DOTween.Sequence();
		sequence.Insert(0f, Camera.main.DOFieldOfView(view, duration));
		sequence.Insert(0f, Camera.main.transform.DOMove(pos, duration, false));
		sequence.Insert(0f, Camera.main.transform.DORotate(rot, duration, RotateMode.Fast));
		yield return sequence.Play<Sequence>().WaitForCompletion();
		yield break;
	}

	public IEnumerator CameraMoveRevert(float view, Vector3 pos, Vector3 rot, float duration)
	{
		Sequence sequence = DOTween.Sequence();
		sequence.Insert(0f, Camera.main.DOFieldOfView(view, duration));
		sequence.Insert(0f, Camera.main.transform.DOMove(pos, duration, false));
		sequence.Insert(0f, Camera.main.transform.DORotate(rot, duration, RotateMode.Fast));
		sequence.Insert(1f, Camera.main.DOFieldOfView(view, duration));
		sequence.Insert(1f, Camera.main.transform.DOMove(Camera.main.transform.position, duration, false));
		sequence.Insert(1f, Camera.main.transform.DORotate(Camera.main.transform.rotation.eulerAngles, duration, RotateMode.Fast));
		yield return sequence.Play<Sequence>().WaitForCompletion();
		yield break;
	}

	public void CreateSubtitle(string content, float openTime = 1f, float showTime = 2f, float closeTime = 1f, float fontScale = 1f)
	{
		EffectAudioManager.Instance.PlayEffectAudio(20, null);
		this.Subtitle.AddSubTitle(content, openTime, showTime, closeTime, fontScale);
	}

	private void FixedUpdate()
	{
		if (this.willGiveCardsName.Count > 0 && !this.isGiving)
		{
			this.isGiving = true;
			base.StartCoroutine(this.GiveACardIEnumerator(this.willGiveCardsName[0]));
		}
	}

	public void GiveACard(string name)
	{
		CardData item = Card.InitCardDataByID(name);
		this.willGiveCardsName.Add(item);
	}

	public void GiveACardData(CardData cardData)
	{
		this.willGiveCardsName.Add(cardData);
	}

	private IEnumerator GiveACardIEnumerator(CardData cardData)
	{
		Card.InitACardOnPlayerTable(cardData);
		yield return new WaitForSeconds(1.5f);
		this.willGiveCardsName.Remove(cardData);
		this.isGiving = false;
		yield break;
	}

	public void GiveCards(string str)
	{
		string[] names = str.Split(new char[]
		{
			','
		});
		base.StartCoroutine(this.GiveCardsIEnumerator(names));
	}

	private IEnumerator GiveCardsIEnumerator(string[] names)
	{
		string[] array = names;
		for (int i = 0; i < array.Length; i++)
		{
			Card.InitACardOnPlayerTable(Card.InitCardDataByID(array[i]));
			yield return new WaitForSeconds(1.5f);
		}
		array = null;
		yield return null;
		yield break;
	}

	public void ActiveTask(string name, Card source = null)
	{
		if (!this.GameData.TaskMap.ContainsKey(name))
		{
			TaskData taskDataByModID = this.TaskDataMap.getTaskDataByModID(name);
			if (taskDataByModID == null)
			{
				return;
			}
			TaskData value = TaskData.CopyTaskData(taskDataByModID);
			this.GameData.TaskMap.Add(name, value);
		}
		TaskData taskData = this.GameData.TaskMap[name];
		if (!taskData.IsActive())
		{
			taskData.Active();
			CardData cardData = Card.InitCardDataByID("任务");
			cardData.Name = name;
			cardData.desc = taskData.Des;
			if (source == null)
			{
				source = this.PlayerToy;
			}
			Card.InitACardDataToPlayerTable(cardData);
		}
	}

	public TaskData GetTask(string name)
	{
		if (this.GameData.TaskMap.ContainsKey(name))
		{
			return this.GameData.TaskMap[name];
		}
		return null;
	}

	public void SettleTask(string name)
	{
		TaskData task = this.GetTask(name);
		if (task != null && !task.IsSettled)
		{
			task.IsSettled = true;
			GameController.getInstance().GameEventManager.TaskSettle(name);
		}
	}

	public GameObject LoadModelOfType(string modelName, int modelType = 0)
	{
		GameObject gameObject = new GameObject();
		switch (modelType)
		{
		case 0:
			gameObject = (GameObject)Resources.Load(modelName);
			break;
		case 1:
			gameObject = BuilderHelper.LoadThenConvertToGameObject(modelName);
			gameObject.transform.localScale = Vector3.one * 0.0625f;
			gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
			break;
		}
		return gameObject;
	}

	private void SceneLoadedCallBack(Scene scene, LoadSceneMode sceneType)
	{
		if (scene.name.Equals("Home"))
		{
			GameController.getInstance().MainCamera.SetActive(false);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("Home"));
		}
		if (scene.name.Equals("GuideHome"))
		{
			GameController.getInstance().MainCamera.SetActive(false);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("GuideHome"));
		}
	}

	private void SceneUnloadedCallBack(Scene scene)
	{
		if (scene.name.Equals("Home") && GameController.getInstance().MainCamera)
		{
			GameController.getInstance().MainCamera.SetActive(true);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
		}
		if (scene.name.Equals("GuideHome"))
		{
			base.StartCoroutine(this.LoadHomeScene());
		}
	}

	public void ShowGuideCanvas(int startIndex, int endIndex)
	{
		this.GuideCanvas.ShowGuideContent(startIndex, endIndex, delegate
		{
			this.ChangeTimePause(true);
			Time.timeScale = 0f;
			this.GuideCanvas.gameObject.SetActive(true);
		});
	}

	public int HasEmptCardSlotOnPlayerTable()
	{
		List<CardSlot> list = new List<CardSlot>();
		foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null) && cardSlot.CardSlotData.ChildCardData == null)
			{
				list.Add(cardSlot);
			}
		}
		return list.Count;
	}

	public int HasEmptCardSlotOnPlayerTable(ulong tag)
	{
		List<CardSlot> list = new List<CardSlot>();
		foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null) && (cardSlot.CardSlotData.ChildCardData == null || !cardSlot.CardSlotData.ChildCardData.HasTag((TagMap)tag)))
			{
				list.Add(cardSlot);
			}
		}
		return list.Count;
	}

	public void ShowAmountText(Vector3 position, string value, Color color, int index = 0, bool pop = false, bool loop = false)
	{
		if (value.Equals("\n<color=white>攻击</color>"))
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AmountText);
		gameObject.GetComponent<AmoutTextEffect>().isPop = pop;
		gameObject.GetComponent<AmoutTextEffect>().isLoop = loop;
		if (color == Color.grey)
		{
			gameObject.GetComponentInChildren<TMP_Text>().color = Color.white;
		}
		else
		{
			gameObject.GetComponentInChildren<TMP_Text>().color = color;
		}
		gameObject.GetComponentInChildren<TMP_Text>().text = value;
		gameObject.transform.SetParent(this.AmountText.transform.parent);
		Vector3 vector = Camera.main.WorldToScreenPoint(position);
		gameObject.transform.position = new Vector3(vector.x, vector.y - 20f + (float)(index * 25), vector.z);
		gameObject.SetActive(true);
	}

	public void ShowLogicChanged(Vector3 position, string value, CardLogicColor color)
	{
		if (color == CardLogicColor.blue)
		{
			value = "\n<color=#00d7ff>" + value + "</color>";
		}
		else
		{
			value = string.Concat(new string[]
			{
				"\n<color=",
				color.ToString(),
				">",
				value,
				"</color>"
			});
		}
		this.ShowAmountText(position, value, Color.white, 0, false, false);
	}

	private void OnApplicationQuit()
	{
		GlobalController.Instance.SaveGlobalData();
		Debug.Log("游戏退出");
	}

	public CardData GetHeroDataByLevel(CardData data)
	{
		if (GlobalController.Instance.GlobalData.HerosLevel.ContainsKey(data.ModID))
		{
			foreach (HeroExtraBean heroExtraBean in GlobalController.Instance.HeroHomeDataController.GetHerosHomeDataConfig().HerosHomeDataConfig)
			{
				if (heroExtraBean.HeroModID.Equals(data.ModID))
				{
					for (int i = 0; i < GlobalController.Instance.GlobalData.HerosLevel[data.ModID].Count; i++)
					{
						ExtraBean extraBean = heroExtraBean.ExtraList[GlobalController.Instance.GlobalData.HerosLevel[data.ModID][i]];
						switch (extraBean.Type)
						{
						case HeroExtraType.ATK:
							data._ATK += extraBean.ExtraValue;
							break;
						case HeroExtraType.ATKTimes:
							data._AttackTimes += extraBean.ExtraValue;
							break;
						case HeroExtraType.HP:
							data.HP = (data.MaxHP += extraBean.ExtraValue);
							break;
						case HeroExtraType.CRIT:
							data._CRIT += extraBean.ExtraValue;
							break;
						case HeroExtraType.Armor:
							data.Armor = (data.MaxArmor += extraBean.ExtraValue);
							break;
						}
						if (!string.IsNullOrEmpty(extraBean.LogicName))
						{
							data.AddLogic(extraBean.LogicName, extraBean.LogicLayer);
						}
					}
				}
			}
		}
		return data;
	}

	public CardSlotData GetEmptySlotDataByCardTag(TagMap type)
	{
		foreach (CardSlotData cardSlotData in this.PlayerSlotSets)
		{
			if (cardSlotData.SlotType != CardSlotData.Type.Freeze && (cardSlotData.TagWhiteList & (ulong)type) != 0UL && cardSlotData.ChildCardData == null)
			{
				return cardSlotData;
			}
		}
		this.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
		return null;
	}

	public CardSlotData GetEmptySlotDataByCardData(CardData data)
	{
		if (data.HasTag(TagMap.药水))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.药水);
		}
		if (data.HasTag(TagMap.工具))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.工具);
		}
		if (data.HasTag(TagMap.放置物))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.放置物);
		}
		if (data.HasTag(TagMap.食物))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.食物);
		}
		if (data.HasTag(TagMap.随从))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.随从);
		}
		if (data.HasTag(TagMap.道具))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.道具);
		}
		if (data.HasTag(TagMap.奇遇))
		{
			return this.GetEmptySlotDataByCardTag(TagMap.奇遇);
		}
		this.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
		return null;
	}

	public static GameController ins = null;

	public static Color32[] RowColor = new Color32[]
	{
		new Color32(0, 142, byte.MaxValue, byte.MaxValue),
		new Color32(byte.MaxValue, 0, 0, byte.MaxValue),
		new Color32(250, 220, 0, byte.MaxValue),
		new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue),
		new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue)
	};

	public static bool GameSavingSyncLock = false;

	public static string PersistentDataPath;

	[NonSerialized]
	public GameEventManager GameEventManager;

	public AsyncEventManager AsyncEventManager;

	public GameLogic GameLogic;

	public Card PlayerToy;

	public CardSlot PlayerCardSlot;

	public CardSlot[] CardSlotsOnPlayerTable;

	public List<CardSlotData> PlayerSlotSets;

	public Transform HomeTable;

	public Transform PlayerTable;

	public int GameSpeed = 1;

	public int CardSlotsOnPlayerTableWidth = 15;

	public int CardSlotsOnPlayerTableHeight = 6;

	public PlayerTableTextLabel playerTableText;

	public Camera UICamera;

	public Transform PlayerTableSlotParent;

	public Transform WorldTableSlotParent;

	public GameObject UndisplaySlotPrefab;

	public List<string> CardsFromMods = new List<string>();

	public UIController UIController;

	public DialogueController DialogueController;

	public GameData GameData = new GameData();

	public Transform CameraTrans;

	public GameObject Opposite;

	public GameObject CurrentArea;

	public GameObject CurrentTable;

	public GameObject NextArea;

	public GameObject NextTable;

	public AreaData NextAreaData;

	public GameObject LastArea;

	public GameObject Effect;

	public GameAct CurrentAct;

	public GameObject Evental;

	public GameObject EventalTable;

	public int IDIndex;

	public Dictionary<string, CardData> CardDataInWorldMap = new Dictionary<string, CardData>();

	public CardDataMap CardDataModMap;

	public CardDataMap BuildingModMap;

	public AreaDataMap AreaDataModMap;

	public BookDataMap BookDataModMap;

	public TaskDataMap TaskDataMap;

	public GameSettingInfo gameSettingInfo;

	public List<CardSlotData> RedLineSlots;

	public List<CardSlotData> YellowLineSlots;

	public List<CardSlotData> BlueLineSlots;

	public List<PersonEvent> AllPersonEvents;

	[Header("世界移动跳转桌面")]
	public Area WorldMoveArea;

	[Header("日志控制器")]
	public LogController LogCtrl;

	[Header("临时世界位置")]
	public string CurrentCityID;

	public bool IsUseCommandLine;

	public Dictionary<string, byte[]> PNGResourceCache;

	public Dictionary<string, string> LuaLogicCache;

	public List<FileInfo> jsonsFromWorkShop;

	public TableType CurrentTableType = TableType.NoTable;

	private bool isTimeStop;

	private float IntervelMS = 0.1f;

	private float DeltaT;

	private float LastFrameT;

	public List<CardSlotData> PlayerTableTempArea = new List<CardSlotData>();

	public List<CardSlotData> PublicArea = new List<CardSlotData>();

	public List<CardSlotData> PartnerArea = new List<CardSlotData>();

	public Dictionary<AreaData, List<object[]>> CityMap = new Dictionary<AreaData, List<object[]>>();

	private Area m_SkipNext;

	public SubtitleCanvas Subtitle;

	private List<CardData> willGiveCardsName = new List<CardData>();

	private bool isGiving;

	public GameObject MainCamera;

	[Header("齿轮")]
	public GameObject Gear;

	public GameObject Gan;

	[Header("引导图集")]
	public GuideCanvasController GuideCanvas;

	public GameObject AmountText;

	public string HeroHomeCurrentHeroModID;
}
