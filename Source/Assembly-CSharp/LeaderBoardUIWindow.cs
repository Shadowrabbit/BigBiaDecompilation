using System;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LeaderBoardUIWindow : MonoBehaviour
{
	private void OnEnable()
	{
		this.CloseButton.onClick.AddListener(new UnityAction(this.OnCloseButtonDown));
		if (!SteamManager.Initialized)
		{
			return;
		}
		this.BoardDataPanel.SetActive(false);
		this.Tips.gameObject.SetActive(true);
		this.m_callResultFIndLeaderboard = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnFindLeaderboard));
		this.m_callResultUploadScore = CallResult<LeaderboardScoreUploaded_t>.Create(new CallResult<LeaderboardScoreUploaded_t>.APIDispatchDelegate(this.OnUploadScore));
		this.m_callResultDownloadScores = CallResult<LeaderboardScoresDownloaded_t>.Create(new CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate(this.OnDownloadScore));
		this.FindLeaderboard("LiveRound");
		Debug.Log("leaderbord");
	}

	private void OnCloseButtonDown()
	{
		this.CloseButton.onClick.RemoveAllListeners();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Start()
	{
	}

	private void Update()
	{
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
		if (this.Score > 0 && !GameController.ins.IsUseCommandLine)
		{
			this.UploadScore(this.Score);
			return;
		}
		if (GameController.ins.IsUseCommandLine)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_48"), 1f, 2f, 1f, 1f);
		}
		this.DownloadScores();
	}

	private bool UploadScore(int score)
	{
		if (this.m_CurrentLeaderboard.m_SteamLeaderboard == 0UL)
		{
			return false;
		}
		SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(this.m_CurrentLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, score, null, 0);
		this.m_callResultUploadScore.Set(hAPICall, new CallResult<LeaderboardScoreUploaded_t>.APIDispatchDelegate(this.OnUploadScore));
		return true;
	}

	private void OnUploadScore(LeaderboardScoreUploaded_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bSuccess == 0 || bIOFailure)
		{
			Debug.Log("Score coule not be upload to Steam");
			return;
		}
		this.DownloadScores();
	}

	private bool DownloadScores()
	{
		if (this.m_CurrentLeaderboard.m_SteamLeaderboard == 0UL)
		{
			return false;
		}
		SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(this.m_CurrentLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 1, 50);
		this.m_callResultDownloadScores.Set(hAPICall, new CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate(this.OnDownloadScore));
		return true;
	}

	private void OnDownloadScore(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
	{
		if (!bIOFailure)
		{
			this.BoardDataPanel.SetActive(true);
			this.Tips.gameObject.SetActive(false);
			this.m_nLeaderboardEntries = ((pCallback.m_cEntryCount > 100) ? 100 : pCallback.m_cEntryCount);
			Debug.Log(this.m_nLeaderboardEntries);
			for (int i = 0; i < this.m_nLeaderboardEntries; i++)
			{
				SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, i, out this.m_leaderboardEntries[i], null, 0);
				TextMeshProUGUI textMeshProUGUI = UnityEngine.Object.Instantiate<TextMeshProUGUI>(Resources.Load<TextMeshProUGUI>("UI/排行榜/LeaderText"));
				textMeshProUGUI.transform.SetParent(this.DataGrid.transform, false);
				textMeshProUGUI.text = this.m_leaderboardEntries[i].m_nGlobalRank.ToString();
				TextMeshProUGUI textMeshProUGUI2 = UnityEngine.Object.Instantiate<TextMeshProUGUI>(Resources.Load<TextMeshProUGUI>("UI/排行榜/LeaderText"));
				textMeshProUGUI2.transform.SetParent(this.DataGrid.transform, false);
				textMeshProUGUI2.text = SteamFriends.GetFriendPersonaName(this.m_leaderboardEntries[i].m_steamIDUser);
				TextMeshProUGUI textMeshProUGUI3 = UnityEngine.Object.Instantiate<TextMeshProUGUI>(Resources.Load<TextMeshProUGUI>("UI/排行榜/LeaderText"));
				textMeshProUGUI3.transform.SetParent(this.DataGrid.transform, false);
				textMeshProUGUI3.text = this.m_leaderboardEntries[i].m_nScore.ToString();
			}
			return;
		}
		this.Tips.text = "加载排行榜数据错误 错误代码:0";
	}

	private void OnDisable()
	{
	}

	public Button CloseButton;

	public GameObject BoardDataPanel;

	public TextMeshProUGUI Tips;

	public GameObject DataGrid;

	public int Score = -1;

	private SteamLeaderboard_t m_CurrentLeaderboard;

	public int m_nLeaderboardEntries;

	public LeaderboardEntry_t[] m_leaderboardEntries = new LeaderboardEntry_t[100];

	private int maxScore = 10;

	private CallResult<LeaderboardFindResult_t> m_callResultFIndLeaderboard;

	private CallResult<LeaderboardScoreUploaded_t> m_callResultUploadScore;

	private CallResult<LeaderboardScoresDownloaded_t> m_callResultDownloadScores;
}
