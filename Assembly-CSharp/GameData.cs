using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class GameData
{
	[JsonIgnore]
	public int Money
	{
		get
		{
			if (this.MoneyCheck != 0 && this._Money != (this.MoneyCheck ^ 65297) && !this.isFake)
			{
				this.isFake = true;
				if (GameController.ins != null)
				{
					YesPanel yesPanel = GameController.ins.UIController.YesPanel;
					yesPanel.MainText.text = LocalizationMgr.Instance.GetLocalizationWord("UI_作弊");
					GameController.ins.StartCoroutine(yesPanel.StartChoosing());
				}
			}
			return this._Money;
		}
		set
		{
			this.MoneyCheck = (value ^ 65297);
			this._Money = value;
		}
	}

	[JsonIgnore]
	public int level
	{
		get
		{
			if (this.levelCheck != 0 && this._level != (this.levelCheck ^ 65297) && !this.isFake)
			{
				this.isFake = true;
				if (GameController.ins != null)
				{
					YesPanel yesPanel = GameController.ins.UIController.YesPanel;
					yesPanel.MainText.text = LocalizationMgr.Instance.GetLocalizationWord("UI_作弊");
					GameController.ins.StartCoroutine(yesPanel.StartChoosing());
				}
			}
			return this._level;
		}
		set
		{
			this._level = value;
			this.levelCheck = (value ^ 65297);
		}
	}

	public int GetEnergyCount(EnergyUI.EnergyType type)
	{
		int num = 0;
		for (int i = 0; i < GameController.ins.GameData.EnergyList.Count; i++)
		{
			if (GameController.ins.GameData.EnergyList[i] == (int)type)
			{
				num++;
			}
		}
		return num;
	}

	public bool isFake;

	public static GameData.GameType CurrentGameType;

	public GameData.GameType SavedGameType;

	public int BuyMinionCount;

	public List<string> ContractStringList;

	[JsonProperty("Money")]
	public int _Money;

	public int MoneyCheck;

	public int Days;

	public int DeltaT;

	public int TorchNum;

	public int KeyNum = 1;

	public DungeonTheme DungeonTheme;

	public int Agreenment;

	public List<CardData> DungeonArea = new List<CardData>();

	public int CurrentDungeonIndex;

	public int levelCheck;

	[JsonProperty("level")]
	public int _level = 1;

	public int Seed;

	public int MaxSatiety;

	public int Satiety;

	public int MaxEnergy;

	public List<Party> Partys = new List<Party>();

	public string CurrentAreaId;

	public AreaData RootArea;

	public List<CardSlotData> SlotsOnPlayerTable;

	public List<CardSlotData> SlotsOnHomeTable;

	public CardData PlayerCardData;

	public int Energy;

	public int EventStep;

	public static int MAX_EventStep = 5;

	public int step;

	public Dictionary<string, AreaData> AreaMap = new Dictionary<string, AreaData>();

	public Dictionary<string, TaskData> TaskMap = new Dictionary<string, TaskData>();

	public List<CardData> DeadMinionsList = new List<CardData>();

	public GameSettleData GameSettleData = new GameSettleData();

	public bool isInDungeon;

	public int StepInDungeon;

	public List<JournalsBean> JournalsList = new List<JournalsBean>();

	public string StartHeroModID;

	public string PaiPaiBossModelPath;

	public string DungeonGUID;

	public CardData InnerMinionCardData;

	public GameData.DungeonType CurrentDungeonType;

	public List<int> EnergyList;

	public FaithData FaithData;

	public int CurFaithPoint;

	public enum GameType
	{
		Normal,
		Endless,
		COOP,
		VS
	}

	public enum DungeonType
	{
		Dungeon,
		Scene
	}
}
