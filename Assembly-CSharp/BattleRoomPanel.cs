using System;
using System.Collections;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRoomPanel : MonoBehaviour
{
	private void Start()
	{
		SteamUserStats.GetStat("stat_Rank", out this.m_Rank);
		SteamUserStats.SetStat("stat_Rank", this.m_Rank - PlayerPrefs.GetInt("Rank"));
		SteamUserStats.StoreStats();
		PlayerPrefs.SetInt("Rank", 0);
		this.GetMyRank();
	}

	public void CreateGameBtn()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.VSModeController.RefreshLobbyList();
		Debug.Log(SteamFriends.GetFriendPersonaName(SteamApps.GetAppOwner()) + " 正在匹配...");
		this.WaitingPanel.SetActive(true);
		this.CancelBtn.SetActive(false);
		this.BattleBtn.SetActive(false);
	}

	public void GameStartCallBack(string TheOther)
	{
		Debug.Log(SteamFriends.GetFriendPersonaName(SteamApps.GetAppOwner()) + " 游戏开始: " + TheOther);
		SceneManager.LoadScene("Main");
	}

	public void CancelWaiting()
	{
		this.WaitingPanel.SetActive(false);
		Debug.Log(SteamFriends.GetFriendPersonaName(SteamApps.GetAppOwner()) + " 退出等待。");
		this.VSModeController.LeaveLobby();
		this.CancelBtn.SetActive(true);
		this.BattleBtn.SetActive(true);
	}

	public void CancelGameBtn()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.VSModeController.LeaveLobby();
		base.StartCoroutine(this.StartLoading());
	}

	public void GetMyRank()
	{
		SteamUserStats.GetStat("stat_Rank", out this.m_Rank);
		this.RankText.text = "当前Rank分：\n" + (this.m_Rank - PlayerPrefs.GetInt("Rank")).ToString();
	}

	private IEnumerator StartLoading()
	{
		UnityEngine.Object.DestroyImmediate(GlobalController.Instance.gameObject);
		UnityEngine.Object.DestroyImmediate(VSModeController.Instance.gameObject);
		PlayerPrefs.SetString("SceneName", "Menu");
		yield return SceneManager.LoadSceneAsync("LoadingScene");
		yield break;
	}

	public GameObject WaitingPanel;

	public GameObject BattleBtn;

	public GameObject CancelBtn;

	public VSModeController VSModeController;

	private int m_Rank;

	public TMP_Text RankText;
}
