using System;
using Steamworks;
using UnityEngine;

public class Leaderboards : MonoBehaviour
{
	private void OnEnable()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		this.m_callResultFIndLeaderboard = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnFindLeaderboard));
		this.m_callResultUploadScore = CallResult<LeaderboardScoreUploaded_t>.Create(new CallResult<LeaderboardScoreUploaded_t>.APIDispatchDelegate(this.OnUploadScore));
		this.m_callResultDownloadScores = CallResult<LeaderboardScoresDownloaded_t>.Create(new CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate(this.OnDownloadScore));
	}

	private void Update()
	{
		bool initialized = SteamManager.Initialized;
	}

	private void FindLeaderboard(string leaderboardName)
	{
		SteamAPICall_t steamAPICall_t = SteamUserStats.FindLeaderboard("LiveRound");
		Debug.Log(steamAPICall_t);
		this.m_callResultFIndLeaderboard.Set(steamAPICall_t, new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnFindLeaderboard));
	}

	private void OnFindLeaderboard(LeaderboardFindResult_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bLeaderboardFound == 0 || bIOFailure)
		{
			Debug.Log("Leaderboard cound not be found");
			return;
		}
		this.m_CurrentLeaderboard = pCallback.m_hSteamLeaderboard;
	}

	private bool UploadScore(int score)
	{
		if (this.m_CurrentLeaderboard.m_SteamLeaderboard == 0UL)
		{
			return false;
		}
		SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(this.m_CurrentLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, null, 0);
		this.m_callResultUploadScore.Set(hAPICall, new CallResult<LeaderboardScoreUploaded_t>.APIDispatchDelegate(this.OnUploadScore));
		return true;
	}

	private void OnUploadScore(LeaderboardScoreUploaded_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bSuccess == 0 || bIOFailure)
		{
			Debug.Log("Score coule not be upload to Steam");
		}
	}

	private bool DownloadScores()
	{
		if (this.m_CurrentLeaderboard.m_SteamLeaderboard == 0UL)
		{
			return false;
		}
		SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(this.m_CurrentLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, -4, 5);
		this.m_callResultDownloadScores.Set(hAPICall, new CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate(this.OnDownloadScore));
		return true;
	}

	private void OnDownloadScore(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
	{
		if (!bIOFailure)
		{
			this.m_nLeaderboardEntries = ((pCallback.m_cEntryCount > 50) ? 50 : pCallback.m_cEntryCount);
			Debug.Log(this.m_nLeaderboardEntries);
			for (int i = 0; i < this.m_nLeaderboardEntries; i++)
			{
				SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, i, out this.m_leaderboardEntries[i], null, 0);
			}
		}
	}

	private SteamLeaderboard_t m_CurrentLeaderboard;

	public int m_nLeaderboardEntries;

	public LeaderboardEntry_t[] m_leaderboardEntries = new LeaderboardEntry_t[50];

	private int maxScore = 10;

	private CallResult<LeaderboardFindResult_t> m_callResultFIndLeaderboard;

	private CallResult<LeaderboardScoreUploaded_t> m_callResultUploadScore;

	private CallResult<LeaderboardScoresDownloaded_t> m_callResultDownloadScores;
}
