using System;
using Steamworks;

public class UGCQueryCondition
{
	public static void Init()
	{
		UGCQueryCondition.DefaultCondition = new UGCQueryCondition();
		UGCQueryCondition.DefaultCondition.ConsumerAppID = SteamConstant.GameID.AppID();
		UGCQueryCondition.DefaultCondition.CreatorAppID = UGCQueryCondition.DefaultCondition.ConsumerAppID;
	}

	public static UGCQueryCondition DefaultCondition;

	public EUGCQuery Query;

	public EUGCMatchingUGCType MatchingType;

	public AppId_t CreatorAppID;

	public AppId_t ConsumerAppID;

	public string UgcTag;
}
