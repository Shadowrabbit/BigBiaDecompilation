using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Steamworks;
using UnityEngine;

public class MultiPlayerController : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		MultiPlayerController.Instance = this;
		this.jsonSerializerSettings = new JsonSerializerSettings();
		this.jsonSerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
	}

	private void Start()
	{
		this.m_LobbyCreated_t = CallResult<LobbyCreated_t>.Create(new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
		this.m_LobbyMatchList_t = CallResult<LobbyMatchList_t>.Create(new CallResult<LobbyMatchList_t>.APIDispatchDelegate(this.OnSearchLobbyFinish));
		this.m_LobbtEnter_t = CallResult<LobbyEnter_t>.Create(new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnEnterLobby));
		this.m_LobbyDataUpdate_t = Callback<LobbyDataUpdate_t>.Create(new Callback<LobbyDataUpdate_t>.DispatchDelegate(this.OnLoobyDataUpdate));
		this.m_LobbyChatUpdate_t = Callback<LobbyChatUpdate_t>.Create(new Callback<LobbyChatUpdate_t>.DispatchDelegate(this.OnChatUpdate));
		this.m_p2PSessionRequestCallback = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate(this.OnP2PSessionRequest));
		this.m_P2PSessionConnectFail_t = Callback<P2PSessionConnectFail_t>.Create(new Callback<P2PSessionConnectFail_t>.DispatchDelegate(this.OnP2PSessionConnectFail));
		SteamMatchmaking.RequestLobbyList();
		this.GameState = MultiPlayerController.GameStateType.None;
		this.CoopWaittingForState = MultiPlayerController.GameStateType.None;
		this.MyID = new CSteamID(SteamConstant.GetUserID());
	}

	public event MultiPlayerController.OnStateChange OnStateChangeEvent;

	public void StateChange(MultiPlayerController.GameStateType gameState)
	{
		if (this.GameState != gameState)
		{
			this.GameState = gameState;
			Debug.Log("进入状态 " + this.GameState.ToString());
			ChangeGameStateMultiPlayMsg changeGameStateMultiPlayMsg = new ChangeGameStateMultiPlayMsg();
			changeGameStateMultiPlayMsg.GameState = gameState;
			this.MultiPlaySendMsgQueue.Enqueue(changeGameStateMultiPlayMsg);
			MultiPlayerController.OnStateChange onStateChangeEvent = this.OnStateChangeEvent;
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
			if (this.CoopWaittingForState < this.GameState || (this.GameState == MultiPlayerController.GameStateType.P1Turn && this.CoopWaittingForState == MultiPlayerController.GameStateType.WaittingEndBattleSync) || this.CoopWaittingForState == MultiPlayerController.GameStateType.EndBattleSync)
			{
				ChangeGameStateMultiPlayMsg changeGameStateMultiPlayMsg = new ChangeGameStateMultiPlayMsg();
				changeGameStateMultiPlayMsg.GameState = this.GameState;
				this.MultiPlaySendMsgQueue.Enqueue(changeGameStateMultiPlayMsg);
			}
			yield return this.TickSecend;
		}
		yield break;
	}

	private IEnumerator msgProcess()
	{
		this.MultiPlaySendMsgQueue = new Queue<MultiPlayMsg>();
		this.MultiPlayRecerveMsgQueue = new Queue<MultiPlayMsg>();
		base.StartCoroutine(this.stateProcess());
		if (this.GameState == MultiPlayerController.GameStateType.NotStart)
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
			MultiPlayMsg tempData = null;
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
					tempData = (JsonConvert.DeserializeObject(@string, this.jsonSerializerSettings) as MultiPlayMsg);
					while (this.GameState == MultiPlayerController.GameStateType.BattleTurn)
					{
						yield return null;
					}
					if (tempData is ChangeGameStateMultiPlayMsg)
					{
						MultiPlayerController.GameStateType gameState = (tempData as ChangeGameStateMultiPlayMsg).GameState;
						this.CoopWaittingForState = gameState;
						Debug.Log("队友状态：" + this.CoopWaittingForState.ToString());
						if ((this.CoopWaittingForState == MultiPlayerController.GameStateType.NotStart || this.CoopWaittingForState == MultiPlayerController.GameStateType.P1Turn) && this.GameState == MultiPlayerController.GameStateType.NotStart)
						{
							this.StateChange(MultiPlayerController.GameStateType.P1Turn);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.P2Turn && this.MyIdentity == MultiPlayerController.Identity.Client)
						{
							this.StateChange(MultiPlayerController.GameStateType.P2Turn);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.StartBattleSync && this.MyIdentity == MultiPlayerController.Identity.Host)
						{
							this.StateChange(MultiPlayerController.GameStateType.StartBattleSync);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.WaittingStartBattleSync && this.MyIdentity == MultiPlayerController.Identity.Host)
						{
							this.StateChange(MultiPlayerController.GameStateType.WaittingStartBattleSync);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.BattleTurn && this.MyIdentity == MultiPlayerController.Identity.Host && this.GameState < MultiPlayerController.GameStateType.BattleTurn)
						{
							this.StateChange(MultiPlayerController.GameStateType.BattleTurn);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.EndBattleSync && this.GameState == MultiPlayerController.GameStateType.EndBattleSync)
						{
							this.StateChange(MultiPlayerController.GameStateType.WaittingEndBattleSync);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.WaittingEndBattleSync && this.MyIdentity == MultiPlayerController.Identity.Host)
						{
							this.StateChange(MultiPlayerController.GameStateType.WaittingEndBattleSync);
						}
						if (this.CoopWaittingForState == MultiPlayerController.GameStateType.P1Turn && this.MyIdentity == MultiPlayerController.Identity.Host && (this.GameState == MultiPlayerController.GameStateType.WaittingEndBattleSync || this.GameState == MultiPlayerController.GameStateType.EndBattleSync))
						{
							this.StateChange(MultiPlayerController.GameStateType.P1Turn);
						}
					}
					else
					{
						this.MultiPlayRecerveMsgQueue.Enqueue(tempData);
					}
				}
				yield return 1;
			}
			yield return 1;
			tempData = null;
		}
		yield break;
	}

	private void Update()
	{
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

	public void EnterLobby(MultiPlayerController.LobbyMsg lobbyMsg)
	{
		SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby(new CSteamID(lobbyMsg.ID));
		this.m_LobbtEnter_t.Set(hAPICall, new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnEnterLobby));
	}

	public void RefreshLobbyList()
	{
		SteamMatchmaking.AddRequestLobbyListFilterSlotsAvailable(1);
		SteamAPICall_t hAPICall = SteamMatchmaking.RequestLobbyList();
		this.m_LobbyMatchList_t.Set(hAPICall, new CallResult<LobbyMatchList_t>.APIDispatchDelegate(this.OnSearchLobbyFinish));
	}

	private void OnChatUpdate(LobbyChatUpdate_t param)
	{
		if ((ulong)param.m_rgfChatMemberStateChange == 1UL)
		{
			Debug.Log("玩家进入:" + SteamFriends.GetFriendPersonaName(new CSteamID(param.m_ulSteamIDUserChanged)));
			this.CurrentCoopsID = new CSteamID(param.m_ulSteamIDUserChanged);
			this.COOPWaitingRoomPanel.GameStartCallBack(SteamFriends.GetFriendPersonaName(this.CurrentCoopsID));
			base.StartCoroutine(this.msgProcess());
			this.MyIdentity = MultiPlayerController.Identity.Host;
			this.WaittingForState = MultiPlayerController.GameStateType.NotStart;
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
		this.COOPWaitingRoomPanel.GameStartCallBack(SteamFriends.GetFriendPersonaName(SteamMatchmaking.GetLobbyOwner(new CSteamID(param.m_ulSteamIDLobby))));
		base.StartCoroutine(this.msgProcess());
		this.MyIdentity = MultiPlayerController.Identity.Client;
		this.WaittingForState = MultiPlayerController.GameStateType.NotStart;
	}

	private void OnSearchLobbyFinish(LobbyMatchList_t param, bool bIOFailure)
	{
		ulong num = (ulong)param.m_nLobbiesMatching;
		Debug.Log("获取房间列表数据成功,房间数:" + num.ToString());
		List<MultiPlayerController.LobbyMsg> list = new List<MultiPlayerController.LobbyMsg>();
		for (ulong num2 = 0UL; num2 < num; num2 += 1UL)
		{
			CSteamID lobbyByIndex = SteamMatchmaking.GetLobbyByIndex((int)num2);
			SteamMatchmaking.RequestLobbyData(lobbyByIndex);
			MultiPlayerController.LobbyMsg lobbyMsg = default(MultiPlayerController.LobbyMsg);
			lobbyMsg.ID = lobbyByIndex.m_SteamID;
			lobbyMsg.CreatorName = SteamMatchmaking.GetLobbyData(lobbyByIndex, "name");
			Debug.Log("房间ID:" + lobbyMsg.ID.ToString());
			Debug.Log("房间创建者:" + lobbyMsg.CreatorName);
			list.Add(lobbyMsg);
		}
		this.COOPWaitingRoomPanel.RefreshPanel(list);
	}

	private void OnLobbyCreated(LobbyCreated_t param, bool bIOFailure)
	{
		this.COOPWaitingRoomPanel.CreateGameCallBack();
		this.CurrentLobbyID = new CSteamID(param.m_ulSteamIDLobby);
		SteamMatchmaking.SetLobbyData(this.CurrentLobbyID, "name", SteamFriends.GetFriendPersonaName(SteamConstant.UserID));
	}

	public COOPWaitingRoomPanel COOPWaitingRoomPanel;

	private CallResult<LobbyCreated_t> m_LobbyCreated_t;

	private CallResult<LobbyMatchList_t> m_LobbyMatchList_t;

	private CallResult<LobbyEnter_t> m_LobbtEnter_t;

	private Callback<LobbyDataUpdate_t> m_LobbyDataUpdate_t;

	private Callback<LobbyChatUpdate_t> m_LobbyChatUpdate_t;

	private Callback<P2PSessionConnectFail_t> m_P2PSessionConnectFail_t;

	private Callback<P2PSessionRequest_t> m_p2PSessionRequestCallback;

	public CSteamID CurrentLobbyID;

	public CSteamID CurrentCoopsID;

	public CSteamID MyID;

	public MultiPlayerController.Identity MyIdentity;

	public static MultiPlayerController Instance;

	private JsonSerializerSettings jsonSerializerSettings;

	public Queue<MultiPlayMsg> MultiPlaySendMsgQueue;

	public Queue<MultiPlayMsg> MultiPlayRecerveMsgQueue;

	public MultiPlayerController.GameStateType GameState;

	public MultiPlayerController.GameStateType WaittingForState;

	public MultiPlayerController.GameStateType CoopWaittingForState;

	private WaitForSeconds TickSecend = new WaitForSeconds(1f);

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
		P2Turn,
		StartBattleSync,
		WaittingStartBattleSync,
		BattleTurn,
		EndBattleSync,
		WaittingEndBattleSync
	}

	public struct LobbyMsg
	{
		public ulong ID;

		public string CreatorName;
	}

	public delegate void OnStateChange(MultiPlayerController.GameStateType gameState);
}
