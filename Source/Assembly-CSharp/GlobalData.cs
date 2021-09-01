using System;
using System.Collections.Generic;

[Serializable]
public class GlobalData : GlobalDataBase
{
	public int Money = 20;

	public int TwistedEggCoupon;

	public string GameTime;

	public int DungeonEnterTimes;

	public int DungeonWinTimes;

	public List<string> AllToysID = new List<string>();

	public List<string> AllItemsID = new List<string>();

	public List<string> LockedMonstersModID = new List<string>();

	public List<string> UnLockedMonstersModID = new List<string>();

	public List<string> LockedMagicsModID = new List<string>();

	public List<string> LockedEquipsModID = new List<string>();

	public List<string> UnLockedEquipsModID = new List<string>();

	public List<string> LockedItemsModID = new List<string>();

	public List<string> UnLockedItemsModID = new List<string>();

	public List<string> LockedToysModID = new List<string>();

	public List<string> UnLockedToysModID = new List<string>();

	public List<string> LockedSpacesModID = new List<string>();

	public List<string> UnLockedSpacesModID = new List<string>();

	public List<string> SelectedMinions = new List<string>();

	public List<string> HadMinions = new List<string>();

	public int HadSlotCount = 4;

	public Dictionary<string, List<int>> HerosLevel = new Dictionary<string, List<int>>();

	public CardData GlobalHadItem;

	public Dictionary<string, int> HeroContractLevel = new Dictionary<string, int>();

	public int GlobalSaveMoney;

	public string StartGameItem = "";

	public bool IsSetting;

	public string VersionIDForUpdate = "1";

	public List<CharacterTag> GlobalCharacterTags = new List<CharacterTag>();

	public List<string> LockedNewspapersModID = new List<string>();

	public List<string> UnLockedNewspapeModID = new List<string>();

	public string VersionID;

	public bool IsGuide;

	public bool IsGuideBattel;

	public Dictionary<DungeonTheme, DungeonThemeData> DungeonThemeLockData;

	public int CurrentUnlockLevel;

	public int CurrentUnlockEXP;

	public Dictionary<int, string> MainTableCardsWithPos;

	public string GainsCardModID = "";

	public List<string> GlobalToysModID = new List<string>();

	public List<string> GlobalToysModIDToTimeMachine = new List<string>();

	public Dictionary<string, object> GlobalAttr = new Dictionary<string, object>();

	public List<int> UnLockedPersonEventID = new List<int>();

	public CharacterTag UnLockCharacterTag;

	public List<string> UnlockDataPathFromNewspaper = new List<string>();

	public List<string> HaveReadNewspapers = new List<string>();

	public int JackpotOfSlotsSpecialToy;

	public float HighestPointsOfDodging;

	public int BuildingWealth;

	public List<string> BuildingMinions = new List<string>();

	public List<string> BuildingLogics = new List<string>();
}
