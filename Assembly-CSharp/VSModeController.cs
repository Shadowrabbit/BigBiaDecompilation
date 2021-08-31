using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VSModeController : MonoBehaviour
{
	private void OnDestroy()
	{
		this.m_LobbyCreated_t.Cancel();
		this.m_LobbyMatchList_t.Cancel();
		this.m_LobbtEnter_t.Cancel();
		this.m_UserStatsReceived_t.Cancel();
		this.m_LobbyDataUpdate_t.Unregister();
		this.m_LobbyChatUpdate_t.Dispose();
		this.m_P2PSessionConnectFail_t.Unregister();
		base.StopAllCoroutines();
		Debug.Log("退出vsMODE");
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.jsonSerializerSettings = new JsonSerializerSettings();
		this.jsonSerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
	}

	private void Start()
	{
		VSModeController.Instance = this;
		SteamUserStats.GetStat("stat_Rank", out this.Rank);
		this.OldRank = this.Rank;
		this.m_LobbyCreated_t = CallResult<LobbyCreated_t>.Create(new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
		this.m_LobbyMatchList_t = CallResult<LobbyMatchList_t>.Create(new CallResult<LobbyMatchList_t>.APIDispatchDelegate(this.OnSearchLobbyFinish));
		this.m_LobbtEnter_t = CallResult<LobbyEnter_t>.Create(new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnEnterLobby));
		this.m_LobbyDataUpdate_t = Callback<LobbyDataUpdate_t>.Create(new Callback<LobbyDataUpdate_t>.DispatchDelegate(this.OnLoobyDataUpdate));
		this.m_LobbyChatUpdate_t = Callback<LobbyChatUpdate_t>.Create(new Callback<LobbyChatUpdate_t>.DispatchDelegate(this.OnChatUpdate));
		this.m_p2PSessionRequestCallback = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate(this.OnP2PSessionRequest));
		this.m_P2PSessionConnectFail_t = Callback<P2PSessionConnectFail_t>.Create(new Callback<P2PSessionConnectFail_t>.DispatchDelegate(this.OnP2PSessionConnectFail));
		this.m_UserStatsReceived_t = CallResult<UserStatsReceived_t>.Create(new CallResult<UserStatsReceived_t>.APIDispatchDelegate(this.OnRequestUserStats));
		SteamMatchmaking.RequestLobbyList();
		this.GameState = VSModeController.GameStateType.None;
		this.CoopWaittingForState = VSModeController.GameStateType.None;
		this.MyName = SteamFriends.GetFriendPersonaName(SteamConstant.UserID);
		this.MyID = new CSteamID(SteamConstant.GetUserID());
	}

	public event VSModeController.OnStateChange OnStateChangeEvent;

	public void StateChange(VSModeController.GameStateType gameState)
	{
		if (this.GameState != gameState)
		{
			this.GameState = gameState;
			Debug.Log("进入状态 " + this.GameState.ToString());
			ChangeVSGameStateMultiPlayMsg changeVSGameStateMultiPlayMsg = new ChangeVSGameStateMultiPlayMsg();
			changeVSGameStateMultiPlayMsg.GameState = gameState;
			this.MultiPlaySendMsgQueue.Enqueue(changeVSGameStateMultiPlayMsg);
			VSModeController.OnStateChange onStateChangeEvent = this.OnStateChangeEvent;
			if (onStateChangeEvent == null)
			{
				return;
			}
			onStateChangeEvent(gameState);
		}
	}

	private IEnumerator stateProcess()
	{
		yield return this.TickSecend;
		for (;;)
		{
			if ((this.CoopWaittingForState == VSModeController.GameStateType.NotStart || this.CoopWaittingForState == VSModeController.GameStateType.P1Turn) && this.GameState == VSModeController.GameStateType.NotStart)
			{
				this.StateChange(VSModeController.GameStateType.P1Turn);
			}
			if (this.GameState == VSModeController.GameStateType.P1BattleTurn)
			{
				if (!this.IsInBattle && !this.IsOPInBattle)
				{
					this.StateChange(VSModeController.GameStateType.P2Turn);
				}
			}
			else if (this.GameState == VSModeController.GameStateType.P2BattleTurn && !this.IsInBattle && !this.IsOPInBattle)
			{
				this.StateChange(VSModeController.GameStateType.P1Turn);
			}
			if (this.GameState == VSModeController.GameStateType.P1Turn && this.MyIdentity == VSModeController.Identity.Host)
			{
				UIController.LockLevel = UIController.UILevel.None;
			}
			else if (this.GameState == VSModeController.GameStateType.P2Turn && this.MyIdentity == VSModeController.Identity.Client)
			{
				UIController.LockLevel = UIController.UILevel.None;
			}
			else
			{
				UIController.LockLevel = UIController.UILevel.All;
			}
			yield return null;
		}
		yield break;
	}

	private IEnumerator msgProcess()
	{
		this.MultiPlaySendMsgQueue = new Queue<MultiPlayMsg>();
		this.MultiPlayRecerveMsgQueue = new Queue<MultiPlayMsg>();
		base.StartCoroutine(this.stateProcess());
		if (this.GameState == VSModeController.GameStateType.NotStart)
		{
		}
		for (;;)
		{
			CSteamID currentCoopsID = this.CurrentCoopsID;
			while (this.MultiPlaySendMsgQueue.Count > 0)
			{
				string text = JsonConvert.SerializeObject(this.MultiPlaySendMsgQueue.Dequeue(), Formatting.None, this.jsonSerializerSettings);
				byte[] array = new byte[text.Length * 2];
				Buffer.BlockCopy(text.ToCharArray(), 0, array, 0, array.Length);
				Debug.Log("发送消息:" + Encoding.Unicode.GetString(array));
				SteamNetworking.SendP2PPacket(this.CurrentCoopsID, array, (uint)array.Length, EP2PSend.k_EP2PSendReliable, 0);
				yield return null;
			}
			uint num;
			while (SteamNetworking.IsP2PPacketAvailable(out num, 0))
			{
				byte[] array2 = new byte[num];
				uint num2;
				CSteamID csteamID;
				if (SteamNetworking.ReadP2PPacket(array2, num, out num2, out csteamID, 0))
				{
					string @string = Encoding.Unicode.GetString(array2);
					Debug.Log("接收消息:" + @string);
					MultiPlayMsg multiPlayMsg = JsonConvert.DeserializeObject(@string, this.jsonSerializerSettings) as MultiPlayMsg;
					if (multiPlayMsg is ChangeVSGameStateMultiPlayMsg)
					{
						VSModeController.GameStateType gameState = (multiPlayMsg as ChangeVSGameStateMultiPlayMsg).GameState;
						this.CoopWaittingForState = gameState;
						Debug.Log("队友状态：" + this.CoopWaittingForState.ToString());
						if (this.CoopWaittingForState == VSModeController.GameStateType.P1BattleTurn && this.MyIdentity == VSModeController.Identity.Client)
						{
							VSModeController.Instance.StateChange(VSModeController.GameStateType.P1BattleTurn);
							VSModeController.Instance.IsInBattle = true;
							VSModeController.Instance.IsOPInBattle = true;
							base.StartCoroutine(DungeonOperationMgr.Instance.VSModeEndTurnProcess(false));
						}
						else if (this.CoopWaittingForState == VSModeController.GameStateType.P2BattleTurn && this.MyIdentity == VSModeController.Identity.Host)
						{
							VSModeController.Instance.StateChange(VSModeController.GameStateType.P2BattleTurn);
							VSModeController.Instance.IsInBattle = true;
							VSModeController.Instance.IsOPInBattle = true;
							base.StartCoroutine(DungeonOperationMgr.Instance.VSModeEndTurnProcess(false));
						}
					}
					else if (multiPlayMsg is VSBattleFinishPlayMsg)
					{
						this.IsOPInBattle = false;
					}
					else
					{
						this.MultiPlayRecerveMsgQueue.Enqueue(multiPlayMsg);
					}
				}
				yield return 1;
			}
			yield return 1;
		}
		yield break;
	}

	private void OnP2PSessionRequest(P2PSessionRequest_t request)
	{
		CSteamID steamIDRemote = request.m_steamIDRemote;
		SteamNetworking.AcceptP2PSessionWithUser(steamIDRemote);
	}

	private void OnP2PSessionConnectFail(P2PSessionConnectFail_t param)
	{
		byte eP2PSessionError = param.m_eP2PSessionError;
	}

	public void LeaveLobby()
	{
		SteamMatchmaking.LeaveLobby(this.CurrentLobbyID);
	}

	public void CreatLobby()
	{
		SteamAPICall_t hAPICall = SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 2);
		this.m_LobbyCreated_t.Set(hAPICall, new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
	}

	public void EnterLobby(VSModeController.LobbyMsg lobbyMsg)
	{
		SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby(new CSteamID(lobbyMsg.ID));
		this.m_LobbtEnter_t.Set(hAPICall, new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnEnterLobby));
	}

	public void RefreshLobbyList()
	{
		SteamMatchmaking.AddRequestLobbyListFilterSlotsAvailable(1);
		SteamMatchmaking.AddRequestLobbyListNearValueFilter("Rank", 5000);
		SteamAPICall_t hAPICall = SteamMatchmaking.RequestLobbyList();
		this.m_LobbyMatchList_t.Set(hAPICall, new CallResult<LobbyMatchList_t>.APIDispatchDelegate(this.OnSearchLobbyFinish));
	}

	private void OnChatUpdate(LobbyChatUpdate_t param)
	{
		if ((ulong)param.m_rgfChatMemberStateChange == 1UL)
		{
			this.OPName = SteamFriends.GetFriendPersonaName(new CSteamID(param.m_ulSteamIDUserChanged));
			Debug.Log("玩家进入:" + this.OPName);
			this.CurrentCoopsID = new CSteamID(param.m_ulSteamIDUserChanged);
			SteamAPICall_t hAPICall = SteamUserStats.RequestUserStats(this.CurrentCoopsID);
			this.m_UserStatsReceived_t.Set(hAPICall, new CallResult<UserStatsReceived_t>.APIDispatchDelegate(this.OnRequestUserStats));
			this.MyIdentity = VSModeController.Identity.Host;
			this.WaittingForState = VSModeController.GameStateType.NotStart;
		}
		if ((ulong)param.m_rgfChatMemberStateChange == 2UL)
		{
			this.OPName = SteamFriends.GetFriendPersonaName(new CSteamID(param.m_ulSteamIDUserChanged));
			Debug.Log("玩家离开:" + this.OPName);
			if (param.m_ulSteamIDUserChanged == this.OPID.m_SteamID)
			{
				if (this.GameState > VSModeController.GameStateType.NotStart)
				{
					this.Win();
				}
				else
				{
					base.StartCoroutine(this.OutOfRoom());
				}
			}
			else if (this.GameState > VSModeController.GameStateType.NotStart)
			{
				this.Loss();
			}
			else
			{
				base.StartCoroutine(this.OutOfRoom());
			}
		}
		Debug.Log((EChatMemberStateChange)param.m_rgfChatMemberStateChange);
	}

	private void OnLoobyDataUpdate(LobbyDataUpdate_t param)
	{
	}

	private void OnEnterLobby(LobbyEnter_t param, bool bIOFailure)
	{
		this.CurrentLobbyID = new CSteamID(param.m_ulSteamIDLobby);
		this.CurrentCoopsID = SteamMatchmaking.GetLobbyOwner(new CSteamID(param.m_ulSteamIDLobby));
		this.OPName = SteamFriends.GetFriendPersonaName(SteamMatchmaking.GetLobbyOwner(new CSteamID(param.m_ulSteamIDLobby)));
		SteamAPICall_t hAPICall = SteamUserStats.RequestUserStats(this.CurrentCoopsID);
		this.m_UserStatsReceived_t.Set(hAPICall, new CallResult<UserStatsReceived_t>.APIDispatchDelegate(this.OnRequestUserStats));
		this.MyIdentity = VSModeController.Identity.Client;
		this.WaittingForState = VSModeController.GameStateType.NotStart;
	}

	private void OnRequestUserStats(UserStatsReceived_t param, bool bIOFailure)
	{
		string str = "获取状态:";
		string str2 = param.m_eResult.ToString();
		string str3 = " ID:";
		CSteamID currentCoopsID = this.CurrentCoopsID;
		Debug.Log(str + str2 + str3 + currentCoopsID.ToString());
		if (param.m_eResult != EResult.k_EResultOK)
		{
			string str4 = "错误:";
			string str5 = param.m_eResult.ToString();
			string str6 = " ID:";
			currentCoopsID = this.CurrentCoopsID;
			Debug.Log(str4 + str5 + str6 + currentCoopsID.ToString());
		}
		this.OPID = param.m_steamIDUser;
		SteamUserStats.GetUserStat(this.OPID, "stat_Rank", out this.OPRank);
		this.COOPWaitingRoomPanel.GameStartCallBack(SteamFriends.GetFriendPersonaName(this.CurrentCoopsID));
		base.StartCoroutine(this.msgProcess());
	}

	private void OnSearchLobbyFinish(LobbyMatchList_t param, bool bIOFailure)
	{
		ulong num = (ulong)param.m_nLobbiesMatching;
		Debug.Log("获取房间列表数据成功,房间数:" + num.ToString());
		new List<VSModeController.LobbyMsg>();
		for (ulong num2 = 0UL; num2 < num; num2 += 1UL)
		{
			CSteamID lobbyByIndex = SteamMatchmaking.GetLobbyByIndex((int)num2);
			this.EnterLobby(new VSModeController.LobbyMsg
			{
				CreatorName = "",
				ID = lobbyByIndex.m_SteamID
			});
		}
		if (num == 0UL)
		{
			this.CreatLobby();
		}
	}

	private void OnLobbyCreated(LobbyCreated_t param, bool bIOFailure)
	{
		SteamUserStats.GetStat("stat_Rank", out this.Rank);
		this.CurrentLobbyID = new CSteamID(param.m_ulSteamIDLobby);
		SteamMatchmaking.SetLobbyData(this.CurrentLobbyID, "name", SteamFriends.GetFriendPersonaName(SteamConstant.UserID));
		SteamMatchmaking.SetLobbyData(this.CurrentLobbyID, "Rank", this.Rank.ToString());
	}

	public void Win()
	{
		this.GameState = VSModeController.GameStateType.None;
		if (this.OPRank >= this.Rank)
		{
			this.Rank = this.Rank + 50 + ((this.OPRank - this.Rank > 50) ? 50 : (this.OPRank - this.Rank));
			SteamUserStats.SetStat("stat_Rank", this.Rank);
		}
		else
		{
			this.Rank = this.Rank + 50 - (((this.Rank - this.OPRank) / 2 > 25) ? 25 : ((this.Rank - this.OPRank) / 2));
			SteamUserStats.SetStat("stat_Rank", this.Rank);
		}
		SteamUserStats.StoreStats();
		GameController.getInstance().UIController.ShowGameEndTip(1);
		base.StartCoroutine(this.OutOfRoom());
	}

	public void Loss()
	{
		this.GameState = VSModeController.GameStateType.None;
		if (this.OPRank >= this.Rank)
		{
			this.Rank = this.Rank - 50 + ((this.OPRank - this.Rank > 50) ? 50 : (this.OPRank - this.Rank));
			SteamUserStats.SetStat("stat_Rank", this.Rank);
		}
		else
		{
			this.Rank = this.Rank - 50 - (((this.Rank - this.OPRank) / 2 > 25) ? 25 : ((this.Rank - this.OPRank) / 2));
			SteamUserStats.SetStat("stat_Rank", this.Rank);
		}
		SteamUserStats.StoreStats();
		GameController.getInstance().UIController.ShowGameEndTip(0);
		base.StartCoroutine(this.OutOfRoom());
	}

	private IEnumerator OutOfRoom()
	{
		yield return new WaitForSeconds(3f);
		EffectAudioManager.Instance.PlayEffectAudio(6, null);
		this.LeaveLobby();
		UnityEngine.Object.DestroyImmediate(base.gameObject);
		UnityEngine.Object.DestroyImmediate(VSModeController.Instance);
		SceneManager.LoadScene("Battle");
		yield break;
	}

	public int Rank;

	public int OPRank;

	public int OldRank;

	public int OldOPRank;

	public string MyName;

	public string OPName;

	public CSteamID OPID;

	public CardData MyBattleCore;

	public CardData OPBattleCore;

	public BattleRoomPanel COOPWaitingRoomPanel;

	private CallResult<LobbyCreated_t> m_LobbyCreated_t;

	private CallResult<LobbyMatchList_t> m_LobbyMatchList_t;

	private CallResult<LobbyEnter_t> m_LobbtEnter_t;

	private CallResult<UserStatsReceived_t> m_UserStatsReceived_t;

	private Callback<LobbyDataUpdate_t> m_LobbyDataUpdate_t;

	private Callback<LobbyChatUpdate_t> m_LobbyChatUpdate_t;

	private Callback<P2PSessionConnectFail_t> m_P2PSessionConnectFail_t;

	private Callback<P2PSessionRequest_t> m_p2PSessionRequestCallback;

	public CSteamID CurrentLobbyID;

	public CSteamID CurrentCoopsID;

	public CSteamID MyID;

	public VSModeController.Identity MyIdentity;

	public static VSModeController Instance;

	private JsonSerializerSettings jsonSerializerSettings;

	public Queue<MultiPlayMsg> MultiPlaySendMsgQueue;

	public Queue<MultiPlayMsg> MultiPlayRecerveMsgQueue;

	public VSModeController.GameStateType GameState;

	public VSModeController.GameStateType WaittingForState;

	public VSModeController.GameStateType CoopWaittingForState;

	private WaitForSeconds TickSecend = new WaitForSeconds(1f);

	public bool IsInBattle;

	public bool IsOPInBattle;

	public enum Identity
	{
		Host,
		Client
	}

	public enum GameStateType
	{
		None = -1,
		NotStart,
		P1Turn,
		P1BattleTurn,
		P2Turn,
		P2BattleTurn
	}

	public struct LobbyMsg
	{
		public ulong ID;

		public string CreatorName;
	}

	public delegate void OnStateChange(VSModeController.GameStateType gameState);
}
