using System;
using System.Collections.Generic;

[Serializable]
public class GlobalData_Beta1 : GlobalDataBase
{
	public int Money;

	public string GameTime;

	public List<string> AllToysID = new List<string>();

	public List<string> AllHerosID = new List<string>();

	public List<string> AllMedicinesID = new List<string>();

	public List<string> LockedMonstersModID = new List<string>();

	public List<string> UnLockedMonstersModID = new List<string>();

	public List<string> LockedMagicsModID = new List<string>();

	public List<string> LockedEquipsModID = new List<string>();

	public List<string> UnLockedEquipsModID = new List<string>();

	public List<string> LockedMedicinesModID = new List<string>();

	public List<string> UnLockedMedicinesModID = new List<string>();

	public List<string> LockedToysModID = new List<string>();

	public List<string> UnLockedToysModID = new List<string>();

	public List<string> LockedHerosModID = new List<string>();

	public List<string> UnLockedHerosModID = new List<string>();

	public Dictionary<string, List<MinionStateBean>> LockedHeroMinionsModIDAndState = new Dictionary<string, List<MinionStateBean>>();

	public Dictionary<string, HeroExpBean> ExpForHeros = new Dictionary<string, HeroExpBean>();

	public Dictionary<string, string> LockedFurnitureForHeroModID = new Dictionary<string, string>();

	public List<string> LockedNewspapersModID = new List<string>();

	public List<string> UnLockedNewspapeModID = new List<string>();

	public string VersionID;

	public bool IsGuide;

	public bool IsGuideBattel;
}
