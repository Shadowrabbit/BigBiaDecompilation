using System;

public class GainsItemData
{
	public string ModID;

	public GainsItemData.SourceType Source;

	public int Count;

	public string DESC;

	public enum SourceType
	{
		KillBoss,
		PassFloor,
		KillElite,
		Event,
		Win,
		Other
	}
}
