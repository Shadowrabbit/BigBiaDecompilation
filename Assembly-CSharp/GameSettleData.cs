using System;
using System.Collections.Generic;

public class GameSettleData
{
	public DateTime totalTime;

	public int totalPhysicsDmg;

	public int totalSkillDmg;

	public int totalExp;

	public List<EventData> eventDatas = new List<EventData>();

	public int money;

	public int totalDmg;

	public int FinalFloor;

	public int Turns;

	public int NowTurn;

	public int TurnKills;

	public int KillNum;

	public int GetItemNum;

	public int GetMinionNum;

	public int ThreeComboTimes;

	public int NineComboTimes;

	public int DeathMinionNum;

	public int KillBossNum;

	public List<string> KilledMonsterIDList;

	public List<GainsItemData> GainItems = new List<GainsItemData>();

	public bool IsFirstKilled;
}
