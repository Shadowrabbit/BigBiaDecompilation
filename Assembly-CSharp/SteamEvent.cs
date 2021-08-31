using System;
using System.Collections.Generic;
using Steamworks;

public class SteamEvent
{
	public Action<PublishedFileId_t, bool, string> OnCreateItem;

	public Action<bool, string> OnSubmitItem;

	public Action<List<SteamUGCDetails_t>, bool, string> OnQueryItem;

	public Action<SetUserItemVoteResult_t, bool, string> OnUserItemVote;

	public Action<GetUserItemVoteResult_t, bool, string> OnGetUserItemVote;
}
