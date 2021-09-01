using System;
using Steamworks;

public static class SteamConstant
{
	public static void Init(AppId_t gameID, CSteamID userID)
	{
		SteamConstant.GameID = new CGameID(gameID);
		SteamConstant.UserID = userID;
		UGCQueryCondition.Init();
	}

	public static ulong GetUserID()
	{
		return SteamConstant.UserID.m_SteamID;
	}

	public static CGameID GameID;

	public static CSteamID UserID;
}
