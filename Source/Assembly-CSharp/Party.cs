using System;
using System.Collections.Generic;

[Serializable]
public class Party
{
	public string ID;

	public string ModID;

	public string Name;

	public int FriendlyDegree;

	public string LeaderID;

	public string HomeAreaID;

	public List<string> PeopleIDs = new List<string>();
}
