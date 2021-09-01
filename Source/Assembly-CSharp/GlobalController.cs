using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalController : MonoBehaviour
{
	private void Awake()
	{
		GlobalController.Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(this);
		JsonConvert.DefaultSettings = (() => new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.All,
			Converters = new List<JsonConverter>
			{
				new StringEnumConverter(),
				new TaskStepConverter()
			}
		});
		Application.targetFrameRate = 60;
		this.GameSettingController = new GameSettingController();
		this.GlobalDataController = new GlobalDataController();
		this.AdditionalDataController = new AdditionalDataController();
		this.HomeDataController = new HomeDataController();
		this.EnemyConfigController = new EnemyConfigController();
		this.AdvanceDataController = new AdvanceDataController();
		this.HeroHomeDataController = new HeroHomeDataController();
		this.LogDataController = new LogDataController();
	}

	private void Start()
	{
		this.IsUseCommunityCards = true;
		BGMusicManager.Instance.PlayBGMusic(0, 0, null);
		this.GameSettingController.Init();
		this.AdvanceDataController.Init();
		this.HeroHomeDataController.Init();
		this.GlobalDataController.Init();
		this.HomeDataController.Init();
		this.LogDataController.Init();
		if (VSModeController.Instance != null)
		{
			VSModeController.Instance = null;
		}
		if (MultiPlayerController.Instance != null)
		{
			MultiPlayerController.Instance = null;
		}
		if (this.GlobalData.GlobalAttr == null)
		{
			this.GlobalData.GlobalAttr = new Dictionary<string, object>();
		}
		if (!this.GlobalData.IsSetting && !Application.systemLanguage.ToString().Contains("Chinese"))
		{
			this.GameSettingController.ApplyLanguage(LanguageType.EN);
			this.ENTipPanel.SetActive(true);
		}
		if (!new DirectoryInfo(Application.persistentDataPath + "/Save/").Exists)
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Save/");
		if (directoryInfo != null)
		{
			FileInfo[] files = directoryInfo.GetFiles("*.sav", SearchOption.AllDirectories);
			if (files != null && files.Length != 0)
			{
				this.LoadGamePanel.SetActive(true);
			}
			else
			{
				this.LoadGamePanel.SetActive(false);
			}
		}
		else
		{
			this.LoadGamePanel.SetActive(false);
		}
		if (SteamController.Instance != null)
		{
			SteamController.Instance.Init();
		}
		if (!this.GlobalData.VersionIDForUpdate.Equals(this.VersionForUpdateStr))
		{
			UnityEngine.Object.Instantiate(Resources.Load("Newspaper/UpdateContent"));
			this.ChangeGlobalVersionForUpdate(this.VersionForUpdateStr);
		}
	}

	public void LoadGame()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath + "/Save/");
		if (directoryInfo != null)
		{
			FileInfo[] files = directoryInfo.GetFiles("*.sav", SearchOption.AllDirectories);
			if (files != null && files.Length != 0)
			{
				this.LoadGamePanel.SetActive(false);
				this.IsLoadGame = true;
				PlayerPrefs.SetString("SceneName", "Main");
				SceneManager.LoadScene("LoadingScene");
			}
		}
	}

	public void ClearSaveData()
	{
		this.LoadGamePanel.SetActive(false);
		this.IsLoadGame = false;
	}

	public void CloseENTipPanel()
	{
		this.ENTipPanel.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			this.CloseSettingPanel();
		}
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
						CardSlotData cardSlotData = new CardSlotData();
						cardSlotData.SlotOwnerType = CardSlotData.OwnerType.SecondaryAct;
						cardSlotData.TagWhiteList = 128UL;
						if (j < 6 && i < 1)
						{
							cardSlotData.SlotType = CardSlotData.Type.Normal;
							cardSlotData.IconIndex = 1;
						}
						else
						{
							cardSlotData.SlotType = CardSlotData.Type.Freeze;
							cardSlotData.IconIndex = 2;
						}
						CardSlotData item = CardSlotData.CopyCardSlotData(cardSlotData);
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
						CardSlotData cardSlotData2 = new CardSlotData();
						cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.SecondaryAct;
						cardSlotData2.TagWhiteList = 65536UL;
						if (l < 6 && k < 1)
						{
							cardSlotData2.SlotType = CardSlotData.Type.Normal;
							cardSlotData2.IconIndex = 4;
						}
						else
						{
							cardSlotData2.SlotType = CardSlotData.Type.Freeze;
							cardSlotData2.IconIndex = 2;
						}
						CardSlotData item2 = CardSlotData.CopyCardSlotData(cardSlotData2);
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
					CardSlotData cardSlotData3 = new CardSlotData();
					cardSlotData3.SlotOwnerType = CardSlotData.OwnerType.SecondaryAct;
					cardSlotData3.TagWhiteList = 8UL;
					if (n < 6 && m < 1)
					{
						cardSlotData3.SlotType = CardSlotData.Type.Normal;
						cardSlotData3.IconIndex = 11;
					}
					else
					{
						cardSlotData3.SlotType = CardSlotData.Type.Freeze;
						cardSlotData3.IconIndex = 2;
					}
					CardSlotData item3 = CardSlotData.CopyCardSlotData(cardSlotData3);
					list.Add(item3);
				}
			}
			GlobalController.Instance.HomeDataController.SetMagicTableCardSlotDatasToHomeData(list);
		}
	}

	public void SetAudioSourceOutPutAudioGroup(AudioSource audioSource, AudioGroup group)
	{
		audioSource.outputAudioMixerGroup = this.AudioMixer.FindMatchingGroups("Master")[(int)group];
	}

	public void ShowSettingPanel()
	{
		this.m_Lock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		this.SettingPanel.gameObject.SetActive(true);
	}

	public void CloseSettingPanel()
	{
		if (this.SettingPanel.gameObject.activeInHierarchy)
		{
			EffectAudioManager.Instance.PlayEffectAudio(6, null);
			this.SettingPanel.gameObject.SetActive(false);
			this.GameSettingController.SaveSettingInfo();
			UIController.LockLevel = this.m_Lock;
		}
	}

	public void ChangeGlobalMoney(int value)
	{
		this.GlobalData.Money += value;
		GameController.ins.UIController.MoneyText.text = (this.GlobalData.Money.ToString() ?? "");
	}

	public int ChangeGlobalSaveMoney(int value)
	{
		this.GlobalData.GlobalSaveMoney += value;
		return this.GlobalData.GlobalSaveMoney;
	}

	public void ChangeTwistedEggCoupon(int value)
	{
		this.GlobalData.TwistedEggCoupon += value;
		GameController.ins.UIController.TwistedEggCouponText.text = (this.GlobalData.TwistedEggCoupon.ToString() ?? "");
	}

	public void SetContractLevelByHeroModID(string modID, int level)
	{
		if (this.GlobalData.HeroContractLevel.ContainsKey(modID))
		{
			this.GlobalData.HeroContractLevel[modID] = level;
			return;
		}
		this.GlobalData.HeroContractLevel.Add(modID, level);
	}

	public int GetContractLevelByHeroModID(string modID)
	{
		if (this.GlobalData.HeroContractLevel.ContainsKey(modID))
		{
			return this.GlobalData.HeroContractLevel[modID];
		}
		this.GlobalData.HeroContractLevel.Add(modID, 1);
		return 1;
	}

	public bool ContractLevelContainsHeroID(string modID)
	{
		return this.GlobalData.HeroContractLevel.ContainsKey(modID);
	}

	public void ChangeDungeonEnterTimes(int value)
	{
		this.GlobalData.DungeonEnterTimes += value;
	}

	public void ChangeGuideState(bool isGuided)
	{
		this.GlobalData.IsGuide = isGuided;
	}

	public void ChangeGuideBattleState(bool isGuided)
	{
		this.GlobalData.IsGuideBattel = isGuided;
	}

	public void ChangeGlobalVersion(string value)
	{
		this.GlobalData.VersionID = value;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void ChangeGlobalVersionForUpdate(string value)
	{
		this.GlobalData.VersionIDForUpdate = value;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void SetGlobalCardModID(string modID)
	{
		this.GlobalData.GainsCardModID = modID;
	}

	public string GetGlobalCardModID()
	{
		return this.GlobalData.GainsCardModID;
	}

	public void AddDataToUnlockDataPathFormNewspaper(string path)
	{
		this.GlobalData.UnlockDataPathFromNewspaper.Add(path);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void SetUnlockDataPathFormNewspaper(List<string> dataPath)
	{
		this.GlobalData.UnlockDataPathFromNewspaper = dataPath;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public List<string> GetUnlockDataPathFormNewspaper()
	{
		return this.GlobalData.UnlockDataPathFromNewspaper;
	}

	public void AddHaveReadNewspapersData(string newspaperName)
	{
		this.GlobalData.HaveReadNewspapers.Add(newspaperName);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void SetHaveReadNewspapersData(List<string> datas)
	{
		this.GlobalData.HaveReadNewspapers = datas;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public List<string> GetHaveReadNewspapersData()
	{
		return this.GlobalData.HaveReadNewspapers;
	}

	public Dictionary<int, string> GetGlobalMainTable()
	{
		return this.GlobalData.MainTableCardsWithPos;
	}

	public void RecoverGlobalMainTable(Dictionary<int, string> dic)
	{
		this.GlobalData.MainTableCardsWithPos = dic;
	}

	public void AddElementToGlobalMainTable(Dictionary<int, string> dic)
	{
		foreach (KeyValuePair<int, string> keyValuePair in dic)
		{
			this.GlobalData.MainTableCardsWithPos.Add(keyValuePair.Key, keyValuePair.Value);
		}
	}

	public void AddElementToGlobalMainTable(int pos, string modID)
	{
		this.GlobalData.MainTableCardsWithPos.Add(pos, modID);
	}

	public void RemoveGlobalMainTableElementAtPos(int pos)
	{
		this.GlobalData.MainTableCardsWithPos.Remove(pos);
	}

	public void RemoveGlobalMainTableElementAtPos(List<int> pos)
	{
		foreach (int key in pos)
		{
			this.GlobalData.MainTableCardsWithPos.Remove(key);
		}
	}

	public List<string> GetGlobalToysModIDToBag()
	{
		return this.GlobalData.GlobalToysModID;
	}

	public void SetGlobalToysModIDToBag(List<string> toysID)
	{
		this.GlobalData.GlobalToysModID = toysID;
	}

	public void AddGlobalToysModIDToBag(List<string> toysID)
	{
		foreach (string item in toysID)
		{
			this.GlobalData.GlobalToysModID.Add(item);
		}
	}

	public void AddGlobalToysModIDToBag(string toyID)
	{
		this.GlobalData.GlobalToysModID.Add(toyID);
	}

	public List<string> GetGlobalToysModIDToTimeMachine()
	{
		return this.GlobalData.GlobalToysModIDToTimeMachine;
	}

	public void SetGlobalToysModIDToTimeMachine(List<string> toysID)
	{
		this.GlobalData.GlobalToysModIDToTimeMachine = toysID;
	}

	public void RemoveLockedToy(CardData toy)
	{
		this.RemoveLockedToys(new List<CardData>
		{
			toy
		});
	}

	public void RemoveLockedToy(string toyID)
	{
		this.RemoveLockedToys(new List<string>
		{
			toyID
		});
	}

	public void RemoveLockedMedicine(CardData medicine)
	{
		this.RemoveLockedItems(new List<CardData>
		{
			medicine
		});
	}

	public void RemoveFromAllItemsToUnLocked(List<CardData> items)
	{
		foreach (CardData cardData in items)
		{
			if (this.GlobalData.AllItemsID.Contains(cardData.ModID))
			{
				this.GlobalData.AllItemsID.Remove(cardData.ModID);
			}
		}
		this.AddUnLockedItems(items);
	}

	public void RemoveFromAllToysToUnLocked(List<CardData> toys)
	{
		foreach (CardData cardData in toys)
		{
			if (this.GlobalData.AllToysID.Contains(cardData.ModID))
			{
				this.GlobalData.AllToysID.Remove(cardData.ModID);
			}
		}
		this.AddUnLockedToys(toys);
	}

	public void AddToysToAllToys(List<string> toysID)
	{
		foreach (string item in toysID)
		{
			if (!this.GlobalData.AllToysID.Contains(item))
			{
				this.GlobalData.AllToysID.Add(item);
			}
		}
	}

	public void AddItemsToALLItems(List<string> itemsID)
	{
		foreach (string item in itemsID)
		{
			if (!this.GlobalData.AllItemsID.Contains(item))
			{
				this.GlobalData.AllItemsID.Add(item);
			}
		}
	}

	public void RemoveFromAllToys(List<CardData> toys)
	{
		for (int i = 0; i < toys.Count; i++)
		{
			if (this.GlobalData.AllToysID.Contains(toys[i].ModID))
			{
				this.GlobalData.AllToysID.Remove(toys[i].ModID);
			}
		}
		this.AddLockedToys(toys);
	}

	public void RemoveFromAllToys(List<string> toyIDs)
	{
		for (int i = 0; i < toyIDs.Count; i++)
		{
			if (this.GlobalData.AllToysID.Contains(toyIDs[i]))
			{
				this.GlobalData.AllToysID.Remove(toyIDs[i]);
			}
		}
		this.AddLockedToys(toyIDs);
	}

	public void AddLockedToys(List<CardData> toys)
	{
		for (int i = 0; i < toys.Count; i++)
		{
			if (!this.GlobalData.LockedToysModID.Contains(toys[i].ModID))
			{
				this.GlobalData.LockedToysModID.Add(toys[i].ModID);
			}
		}
	}

	public void AddLockedToys(List<string> toysID)
	{
		for (int i = 0; i < toysID.Count; i++)
		{
			if (!this.GlobalData.LockedToysModID.Contains(toysID[i]))
			{
				this.GlobalData.LockedToysModID.Add(toysID[i]);
			}
		}
	}

	public void RemoveLockedToys(List<CardData> toys)
	{
		for (int i = 0; i < toys.Count; i++)
		{
			if (this.GlobalData.LockedToysModID.Contains(toys[i].ModID))
			{
				this.GlobalData.LockedToysModID.Remove(toys[i].ModID);
			}
		}
		this.AddUnLockedToys(toys);
	}

	public void RemoveLockedToys(List<string> toyIDs)
	{
		for (int i = 0; i < toyIDs.Count; i++)
		{
			if (this.GlobalData.LockedToysModID.Contains(toyIDs[i]))
			{
				this.GlobalData.LockedToysModID.Remove(toyIDs[i]);
			}
		}
		this.AddUnLockedToys(toyIDs);
	}

	public void AddUnLockedToys(List<CardData> toys)
	{
		for (int i = 0; i < toys.Count; i++)
		{
			if (!this.GlobalData.UnLockedToysModID.Contains(toys[i].ModID))
			{
				this.GlobalData.UnLockedToysModID.Add(toys[i].ModID);
			}
		}
	}

	public void AddUnLockedToys(List<string> toysID)
	{
		for (int i = 0; i < toysID.Count; i++)
		{
			if (!this.GlobalData.UnLockedToysModID.Contains(toysID[i]))
			{
				this.GlobalData.UnLockedToysModID.Add(toysID[i]);
			}
		}
	}

	public void SetHerosLevel(string modID, int level)
	{
		if (this.GlobalData.HerosLevel.ContainsKey(modID))
		{
			this.GlobalData.HerosLevel[modID].Add(level);
		}
		else
		{
			this.GlobalData.HerosLevel.Add(modID, new List<int>
			{
				level
			});
		}
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void AddSelectedMinons(List<string> minionsModID)
	{
		List<string> list = new List<string>();
		foreach (string item in minionsModID)
		{
			list.Add(item);
		}
		this.GlobalData.SelectedMinions = list;
	}

	public List<string> GetHadMinionsID()
	{
		return this.GlobalData.HadMinions;
	}

	public void AddHadMinions(string minionModID)
	{
		this.GlobalData.HadMinions.Add(minionModID);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void AddHadMinions(List<string> minionsModID)
	{
		foreach (string item in minionsModID)
		{
			this.GlobalData.HadMinions.Add(item);
		}
	}

	public void SetHadMinions(List<string> minionsModID)
	{
		this.GlobalData.HadMinions = minionsModID;
	}

	public void RemoveFromAllItems(List<CardData> items)
	{
		foreach (CardData cardData in items)
		{
			if (this.GlobalData.AllItemsID.Contains(cardData.ModID))
			{
				this.GlobalData.AllItemsID.Remove(cardData.ModID);
			}
		}
		this.AddLockedItems(items);
	}

	public void RemoveFromAllItems(List<string> itemsID)
	{
		foreach (string item in itemsID)
		{
			if (this.GlobalData.AllItemsID.Contains(item))
			{
				this.GlobalData.AllItemsID.Remove(item);
			}
		}
		this.AddLockedItems(itemsID);
	}

	public void AddLockedItems(List<CardData> items)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (!this.GlobalData.LockedItemsModID.Contains(items[i].ModID))
			{
				this.GlobalData.LockedItemsModID.Add(items[i].ModID);
			}
		}
	}

	public void AddLockedItems(List<string> itemsID)
	{
		for (int i = 0; i < itemsID.Count; i++)
		{
			if (!this.GlobalData.LockedItemsModID.Contains(itemsID[i]))
			{
				this.GlobalData.LockedItemsModID.Add(itemsID[i]);
			}
		}
	}

	public void RemoveLockedItems(List<CardData> items)
	{
		foreach (CardData cardData in items)
		{
			if (this.GlobalData.LockedItemsModID.Contains(cardData.ModID))
			{
				this.GlobalData.LockedItemsModID.Remove(cardData.ModID);
			}
		}
		this.AddUnLockedItems(items);
	}

	public void RemoveLockedItems(List<string> itemsID)
	{
		foreach (string item in itemsID)
		{
			if (this.GlobalData.LockedItemsModID.Contains(item))
			{
				this.GlobalData.LockedItemsModID.Remove(item);
			}
		}
		this.AddUnLockedItems(itemsID);
	}

	public void AddUnLockedItems(List<CardData> items)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (!this.GlobalData.UnLockedItemsModID.Contains(items[i].ModID))
			{
				this.GlobalData.UnLockedItemsModID.Add(items[i].ModID);
			}
		}
	}

	public void AddUnLockedItems(List<string> itemsID)
	{
		for (int i = 0; i < itemsID.Count; i++)
		{
			if (!this.GlobalData.UnLockedItemsModID.Contains(itemsID[i]))
			{
				this.GlobalData.UnLockedItemsModID.Add(itemsID[i]);
			}
		}
	}

	public void RemoveLockedSpacee(CardData space)
	{
		this.RemoveLockedSpaces(new List<CardData>
		{
			space
		});
	}

	public void AddLockedSpaces(List<CardData> spaces)
	{
		for (int i = 0; i < spaces.Count; i++)
		{
			if (!this.GlobalData.LockedSpacesModID.Contains(spaces[i].ModID))
			{
				this.GlobalData.LockedSpacesModID.Add(spaces[i].ModID);
			}
		}
	}

	public void AddLockedSpaces(List<string> spacesID)
	{
		for (int i = 0; i < spacesID.Count; i++)
		{
			if (!this.GlobalData.LockedSpacesModID.Contains(spacesID[i]))
			{
				this.GlobalData.LockedSpacesModID.Add(spacesID[i]);
			}
		}
	}

	public void RemoveLockedSpaces(List<CardData> spaces)
	{
		foreach (CardData cardData in spaces)
		{
			if (this.GlobalData.LockedSpacesModID.Contains(cardData.ModID))
			{
				this.GlobalData.LockedSpacesModID.Remove(cardData.ModID);
			}
		}
		this.AddUnLockedSpaces(spaces);
	}

	public void RemoveLockedSpaces(List<string> spacesID)
	{
		foreach (string item in spacesID)
		{
			if (this.GlobalData.LockedSpacesModID.Contains(item))
			{
				this.GlobalData.LockedSpacesModID.Remove(item);
			}
		}
		this.AddUnLockedSpaces(spacesID);
	}

	public void AddUnLockedSpaces(List<CardData> spaces)
	{
		for (int i = 0; i < spaces.Count; i++)
		{
			if (!this.GlobalData.UnLockedSpacesModID.Contains(spaces[i].ModID))
			{
				this.GlobalData.UnLockedSpacesModID.Add(spaces[i].ModID);
			}
		}
	}

	public void AddUnLockedSpaces(List<string> spacesID)
	{
		for (int i = 0; i < spacesID.Count; i++)
		{
			if (!this.GlobalData.UnLockedSpacesModID.Contains(spacesID[i]))
			{
				this.GlobalData.UnLockedSpacesModID.Add(spacesID[i]);
			}
		}
	}

	public void SaveGlobalData()
	{
		if (GameController.ins != null)
		{
			GameController.ins.GameEventManager.SaveGame();
		}
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
		this.AdvanceDataController.SaveAdvanceDataInfo();
		GlobalController.Instance.HomeDataController.SaveHomeDataInfo();
	}

	public void SetGlobalHadItem(CardData data)
	{
		this.GlobalData.GlobalHadItem = data;
	}

	public CardData GetGlobalHadItem()
	{
		return this.GlobalData.GlobalHadItem;
	}

	public void SetStartGameItem(string modID)
	{
		this.GlobalData.StartGameItem = modID;
	}

	public string GetStartGameItem()
	{
		return this.GlobalData.StartGameItem;
	}

	public void SetGlobalSetting(bool flag)
	{
		this.GlobalData.IsSetting = flag;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public bool GetGlobalSetting()
	{
		return this.GlobalData.IsSetting;
	}

	public void SetGlobalCharaterTags(CharacterTag tag)
	{
		this.GlobalData.GlobalCharacterTags.Add(tag);
	}

	public List<CharacterTag> getGlobalCharaterTags()
	{
		return this.GlobalData.GlobalCharacterTags;
	}

	public EnemyConfigData GetEnemyConfig()
	{
		return this.EnemyConfigController.LoadEnemyConfigInfo();
	}

	public List<string> GetBuildingMinionsModID()
	{
		return this.GlobalData.BuildingMinions;
	}

	public void SetBuildingMinionsModID(List<string> minionsID)
	{
		this.GlobalData.BuildingMinions = minionsID;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void AddBuildingMinionsModID(string minionID)
	{
		this.GlobalData.BuildingMinions.Add(minionID);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void RemoveBuidlingMinionModID(string minionID)
	{
		this.GlobalData.BuildingMinions.Remove(minionID);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void AddBuildingLogics(string logicName)
	{
		this.GlobalData.BuildingLogics.Add(logicName);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void RemoveBuildingLogic(string logicName)
	{
		this.GlobalData.BuildingLogics.Remove(logicName);
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public void ChangeBuildingWealth(int val)
	{
		this.GlobalData.BuildingWealth += val;
		this.GlobalDataController.SaveGlobalInfo(this.GlobalData);
	}

	public int GetBuildingWealth()
	{
		return this.GlobalData.BuildingWealth;
	}

	public void OnLanguageChanged(LanguageType type)
	{
		if (type == LanguageType.EN)
		{
			GameObject entipPanel = this.ENTipPanel;
			if (entipPanel != null)
			{
				entipPanel.SetActive(true);
			}
		}
		Action<LanguageType> onLanguageChangedEvent = this.OnLanguageChangedEvent;
		if (onLanguageChangedEvent == null)
		{
			return;
		}
		onLanguageChangedEvent(type);
	}

	private void CopyGlobalFile()
	{
		string str = "Global.json";
		string persistentDataPath = Application.persistentDataPath;
		string text = Application.persistentDataPath + "/GlobalBack/";
		DirectoryInfo directoryInfo = new DirectoryInfo(persistentDataPath);
		new DirectoryInfo(text);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		directoryInfo.GetFiles();
		File.Copy(persistentDataPath + "/" + str, Path.Combine(text, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + "_" + str), true);
	}

	public void SetIsUseCommunityCards()
	{
		this.IsUseCommunityCards = this.IsUseCommunityCardsToggle.isOn;
	}

	public static GlobalController Instance;

	[NonSerialized]
	public GlobalData GlobalData;

	public AudioMixer AudioMixer;

	public GameSettingController GameSettingController;

	public GlobalDataController GlobalDataController;

	public AdditionalDataController AdditionalDataController;

	public HomeDataController HomeDataController;

	public EnemyConfigController EnemyConfigController;

	public AdvanceDataController AdvanceDataController;

	public List<CardData> TempLockedObjs = new List<CardData>();

	public List<CardData> TempUnLockedObjs = new List<CardData>();

	public string VersionStr;

	public string VersionForUpdateStr;

	public GameObject LoadGamePanel;

	public GameObject ENTipPanel;

	public bool IsLoadGame;

	public HeroHomeDataController HeroHomeDataController;

	public LogDataController LogDataController;

	[Header("音频管理器 ESC呼出面板")]
	public SettingManager SettingPanel;

	private UIController.UILevel m_Lock;

	public Action<LanguageType> OnLanguageChangedEvent;

	public bool IsUseCommunityCards = true;

	public Toggle IsUseCommunityCardsToggle;
}
