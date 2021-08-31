using System;
using System.Collections.Generic;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class COOPWaitingRoomPanel : MonoBehaviour
{
	private void Start()
	{
		this.RefreshGame();
	}

	public void InitPanel(List<MultiPlayerController.LobbyMsg> roomList)
	{
		if (roomList.Count < 1)
		{
			this.TipText.SetActive(true);
			return;
		}
		this.TipText.SetActive(false);
		using (List<MultiPlayerController.LobbyMsg>.Enumerator enumerator = roomList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				MultiPlayerController.LobbyMsg room = enumerator.Current;
				RectTransform rectTransform = UnityEngine.Object.Instantiate<RectTransform>(this.RoomDescPanel);
				rectTransform.transform.SetParent(this.RoomDescPanel.parent);
				rectTransform.localScale = this.RoomDescPanel.localScale;
				rectTransform.localPosition = this.RoomDescPanel.localPosition;
				rectTransform.localRotation = Quaternion.Euler(Vector3.zero);
				rectTransform.transform.GetChild(0).GetComponent<TMP_Text>().text = room.CreatorName + " 的游戏房间";
				UnityEngine.Object @object = rectTransform;
				ulong id = room.ID;
				@object.name = id.ToString();
				rectTransform.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate()
				{
					this.OnJoinGameBtn(room);
				});
				rectTransform.gameObject.SetActive(true);
				this.m_DescList.Add(rectTransform.gameObject);
			}
		}
		this.Scrollbar.value = 0f;
	}

	public void RefreshPanel(List<MultiPlayerController.LobbyMsg> roomList)
	{
		for (int i = this.m_DescList.Count - 1; i >= 0; i--)
		{
			UnityEngine.Object.DestroyImmediate(this.m_DescList[i]);
		}
		this.m_DescList = new List<GameObject>();
		this.InitPanel(roomList);
	}

	public void RefreshPanelName(ulong id, string name)
	{
		foreach (GameObject gameObject in this.m_DescList)
		{
			if (gameObject.name.Equals(id.ToString()))
			{
				gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = name + " 的游戏房间";
			}
		}
	}

	public void OnJoinGameBtn(MultiPlayerController.LobbyMsg p1)
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.MultiPlayerController.EnterLobby(p1);
		Debug.Log(string.Concat(new string[]
		{
			"P2: ",
			SteamFriends.GetFriendPersonaName(SteamApps.GetAppOwner()),
			" 正在加入 ",
			p1.CreatorName,
			" 的房间..."
		}));
	}

	public void CreateGameBtn()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.MultiPlayerController.CreatLobby();
		Debug.Log(SteamFriends.GetFriendPersonaName(SteamApps.GetAppOwner()) + " 正在创建大厅...");
	}

	public void CreateGameCallBack()
	{
		Debug.Log(SteamFriends.GetFriendPersonaName(SteamApps.GetAppOwner()) + " 大厅创建成功，等待他人加入...");
		this.WaitingPanel.SetActive(true);
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
		this.MultiPlayerController.LeaveLobby();
	}

	public void CancelGameBtn()
	{
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.MultiPlayerController.LeaveLobby();
		UnityEngine.Object.DestroyImmediate(GlobalController.Instance.gameObject);
		SceneManager.LoadScene("Menu");
	}

	public void RefreshGame()
	{
		this.MultiPlayerController.RefreshLobbyList();
	}

	public GameObject TipText;

	public Scrollbar Scrollbar;

	public RectTransform RoomDescPanel;

	public GameObject WaitingPanel;

	public MultiPlayerController MultiPlayerController;

	private List<GameObject> m_DescList = new List<GameObject>();
}
