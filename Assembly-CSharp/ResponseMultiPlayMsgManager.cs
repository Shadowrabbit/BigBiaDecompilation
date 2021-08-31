using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class ResponseMultiPlayMsgManager : MonoBehaviour
{
	private void Start()
	{
		this.ReciveMsgQueue = MultiPlayerController.Instance.MultiPlayRecerveMsgQueue;
		CSteamID currentLobbyID = MultiPlayerController.Instance.CurrentLobbyID;
		GameController.getInstance().GameEventManager.OnMerByEvent += this.OnMerBy;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.OnCardChangeSlot;
		MultiPlayerController.Instance.OnStateChangeEvent += this.OnStateChange;
	}

	private void OnDestroy()
	{
		CSteamID currentLobbyID = MultiPlayerController.Instance.CurrentLobbyID;
		GameController.getInstance().GameEventManager.OnMerByEvent -= this.OnMerBy;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.OnCardChangeSlot;
		MultiPlayerController.Instance.OnStateChangeEvent -= this.OnStateChange;
	}

	private void OnStateChange(MultiPlayerController.GameStateType gameState)
	{
		switch (gameState)
		{
		case MultiPlayerController.GameStateType.None:
			goto IL_28C;
		case MultiPlayerController.GameStateType.NotStart:
			break;
		case MultiPlayerController.GameStateType.P1Turn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("等待1P回合结束");
			MultiPlayArea.Instance.StartCoroutine(MultiPlayArea.Instance.GetEnemyTurn());
			if (MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Host)
			{
				MultiPlayArea.Instance.GetAndPutMinionTurn();
				goto IL_28C;
			}
			goto IL_28C;
		case MultiPlayerController.GameStateType.P2Turn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("等待2P回合结束");
			if (MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Host)
			{
				foreach (CardSlotData cardSlotData in MultiPlayArea.Instance.P1AreaSlots)
				{
					if (cardSlotData.ChildCardData != null)
					{
						cardSlotData.ChildCardData.DeleteCardData();
					}
				}
			}
			if (MultiPlayerController.Instance.MyIdentity != MultiPlayerController.Identity.Client)
			{
				goto IL_28C;
			}
			MultiPlayArea.Instance.GetAndPutMinionTurn();
			using (List<CardSlotData>.Enumerator enumerator = MultiPlayArea.Instance.P2AreaSlots.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cardSlotData2 = enumerator.Current;
					if (cardSlotData2.ChildCardData != null)
					{
						cardSlotData2.ChildCardData.DeleteCardData();
					}
				}
				goto IL_28C;
			}
			break;
		case MultiPlayerController.GameStateType.StartBattleSync:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("正在同步战斗数据");
			if (MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Host)
			{
				foreach (CardSlotData cardSlotData3 in MultiPlayArea.Instance.P2AreaSlots)
				{
					if (cardSlotData3.ChildCardData != null)
					{
						cardSlotData3.ChildCardData.DeleteCardData();
					}
				}
			}
			if (MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Client)
			{
				foreach (CardSlotData cardSlotData4 in MultiPlayArea.Instance.P1AreaSlots)
				{
					if (cardSlotData4.ChildCardData != null)
					{
						cardSlotData4.ChildCardData.DeleteCardData();
					}
				}
			}
			this.SyncCard();
			goto IL_28C;
		case MultiPlayerController.GameStateType.WaittingStartBattleSync:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("正在等待玩家加入...");
			goto IL_28C;
		case MultiPlayerController.GameStateType.BattleTurn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("等待战斗回合结束");
			base.StartCoroutine(DungeonOperationMgr.Instance.EndTurnProcess(false));
			goto IL_28C;
		case MultiPlayerController.GameStateType.EndBattleSync:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("正在结算战斗数据");
			this.SyncCard();
			goto IL_28C;
		case MultiPlayerController.GameStateType.WaittingEndBattleSync:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("正在等待玩家结束...");
			goto IL_28C;
		default:
			goto IL_28C;
		}
		GameController.ins.UIController.ShowMultiPlayTurnStatePanel("等待游戏开始");
		IL_28C:
		this.m_state = gameState;
	}

	private void SyncCard()
	{
		if (MultiPlayerController.Instance.MyIdentity == MultiPlayerController.Identity.Host)
		{
			SyncCardsMultiPlayMsg syncCardsMultiPlayMsg = new SyncCardsMultiPlayMsg();
			syncCardsMultiPlayMsg.cards = new List<CardData>();
			foreach (CardSlotData cardSlotData in GameController.getInstance().PublicArea)
			{
				if (cardSlotData.ChildCardData != null)
				{
					syncCardsMultiPlayMsg.cards.Add(cardSlotData.ChildCardData);
				}
				else
				{
					syncCardsMultiPlayMsg.cards.Add(null);
				}
			}
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(syncCardsMultiPlayMsg);
		}
	}

	private void OnCardChangeSlot(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null)
		{
			if (GameController.getInstance().PlayerTableTempArea.Contains(newCardSlot))
			{
				GetCardMultiPlayMsg getCardMultiPlayMsg = new GetCardMultiPlayMsg();
				getCardMultiPlayMsg.AimSlotIndex = GameController.getInstance().PlayerTableTempArea.IndexOf(newCardSlot);
				getCardMultiPlayMsg.ModID = card.ModID;
				MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(getCardMultiPlayMsg);
			}
			if (MultiPlayArea.Instance.P1AreaSlots.Contains(newCardSlot))
			{
				AreaTableCreateCardPlayMsg areaTableCreateCardPlayMsg = new AreaTableCreateCardPlayMsg();
				areaTableCreateCardPlayMsg.AimSlotIndex = MultiPlayArea.Instance.P1AreaSlots.IndexOf(newCardSlot);
				areaTableCreateCardPlayMsg.ModID = card.ModID;
				MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(areaTableCreateCardPlayMsg);
			}
			return;
		}
		if (GameController.getInstance().PublicArea.Contains(newCardSlot) && GameController.getInstance().PlayerTableTempArea.Contains(oldCardSlot))
		{
			ChangeSlotToPublicAreaMultiPlayMsg changeSlotToPublicAreaMultiPlayMsg = new ChangeSlotToPublicAreaMultiPlayMsg();
			changeSlotToPublicAreaMultiPlayMsg.AimSlotIndex = GameController.getInstance().PublicArea.IndexOf(newCardSlot);
			changeSlotToPublicAreaMultiPlayMsg.FromSlotIndex = GameController.getInstance().PlayerTableTempArea.IndexOf(oldCardSlot);
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(changeSlotToPublicAreaMultiPlayMsg);
			return;
		}
		if (GameController.getInstance().PlayerTableTempArea.Contains(newCardSlot) && GameController.getInstance().PlayerTableTempArea.Contains(oldCardSlot))
		{
			ChangeSlotMultiPlayMsg changeSlotMultiPlayMsg = new ChangeSlotMultiPlayMsg();
			changeSlotMultiPlayMsg.FromSlotIndex = GameController.getInstance().PlayerTableTempArea.IndexOf(oldCardSlot);
			changeSlotMultiPlayMsg.AimSlotIndex = GameController.getInstance().PlayerTableTempArea.IndexOf(newCardSlot);
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(changeSlotMultiPlayMsg);
			return;
		}
		if (GameController.getInstance().PlayerTableTempArea.Contains(newCardSlot) && MultiPlayArea.Instance.P1AreaSlots.Contains(oldCardSlot))
		{
			AreaTableChangeSlotPlayMsg areaTableChangeSlotPlayMsg = new AreaTableChangeSlotPlayMsg();
			areaTableChangeSlotPlayMsg.FromSlotIndex = MultiPlayArea.Instance.P1AreaSlots.IndexOf(oldCardSlot);
			areaTableChangeSlotPlayMsg.AimSlotIndex = GameController.getInstance().PlayerTableTempArea.IndexOf(newCardSlot);
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(areaTableChangeSlotPlayMsg);
			return;
		}
		if (MultiPlayArea.Instance.P1AreaSlots.Contains(oldCardSlot) && GameController.getInstance().PublicArea.Contains(newCardSlot))
		{
			AreaTableToPublicAreaPlayMsg areaTableToPublicAreaPlayMsg = new AreaTableToPublicAreaPlayMsg();
			areaTableToPublicAreaPlayMsg.FromSlotIndex = MultiPlayArea.Instance.P1AreaSlots.IndexOf(oldCardSlot);
			areaTableToPublicAreaPlayMsg.AimSlotIndex = GameController.getInstance().PublicArea.IndexOf(newCardSlot);
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(areaTableToPublicAreaPlayMsg);
		}
	}

	private void OnMerBy(CardData target, CardData from)
	{
		if (GameController.getInstance().PlayerTableTempArea.Contains(target.CurrentCardSlotData) && GameController.getInstance().PlayerTableTempArea.Contains(from.CurrentCardSlotData))
		{
			MergeCardMultiPlayMsg mergeCardMultiPlayMsg = new MergeCardMultiPlayMsg();
			for (int i = 0; i < GameController.getInstance().PlayerTableTempArea.Count; i++)
			{
				if (GameController.getInstance().PlayerTableTempArea[i] == from.CurrentCardSlotData)
				{
					mergeCardMultiPlayMsg.FromSlotIndex = i;
				}
				if (GameController.getInstance().PlayerTableTempArea[i] == target.CurrentCardSlotData)
				{
					mergeCardMultiPlayMsg.AimSlotIndex = i;
				}
			}
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(mergeCardMultiPlayMsg);
			return;
		}
		if (GameController.getInstance().PublicArea.Contains(target.CurrentCardSlotData) && GameController.getInstance().PlayerTableTempArea.Contains(from.CurrentCardSlotData))
		{
			MergeCardToPublicAreaMultiPlayMsg mergeCardToPublicAreaMultiPlayMsg = new MergeCardToPublicAreaMultiPlayMsg();
			for (int j = 0; j < GameController.getInstance().PlayerTableTempArea.Count; j++)
			{
				if (GameController.getInstance().PlayerTableTempArea[j] == from.CurrentCardSlotData)
				{
					mergeCardToPublicAreaMultiPlayMsg.FromSlotIndex = j;
				}
			}
			for (int k = 0; k < GameController.getInstance().PublicArea.Count; k++)
			{
				if (GameController.getInstance().PublicArea[k] == target.CurrentCardSlotData)
				{
					mergeCardToPublicAreaMultiPlayMsg.AimSlotIndex = k;
				}
			}
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(mergeCardToPublicAreaMultiPlayMsg);
			return;
		}
		if (GameController.getInstance().PublicArea.Contains(target.CurrentCardSlotData) && MultiPlayArea.Instance.P1AreaSlots.Contains(from.CurrentCardSlotData))
		{
			MergeCardToPublicAreaFromAreaTableMultiPlayMsg mergeCardToPublicAreaFromAreaTableMultiPlayMsg = new MergeCardToPublicAreaFromAreaTableMultiPlayMsg();
			mergeCardToPublicAreaFromAreaTableMultiPlayMsg.AimSlotIndex = GameController.getInstance().PublicArea.IndexOf(target.CurrentCardSlotData);
			mergeCardToPublicAreaFromAreaTableMultiPlayMsg.FromSlotIndex = MultiPlayArea.Instance.P1AreaSlots.IndexOf(from.CurrentCardSlotData);
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(mergeCardToPublicAreaFromAreaTableMultiPlayMsg);
			return;
		}
		if (GameController.getInstance().PlayerTableTempArea.Contains(target.CurrentCardSlotData) && MultiPlayArea.Instance.P1AreaSlots.Contains(from.CurrentCardSlotData))
		{
			MergeCardToPlayerTableFromAreaTableMultiPlayMsg mergeCardToPlayerTableFromAreaTableMultiPlayMsg = new MergeCardToPlayerTableFromAreaTableMultiPlayMsg();
			mergeCardToPlayerTableFromAreaTableMultiPlayMsg.AimSlotIndex = GameController.getInstance().PlayerTableTempArea.IndexOf(target.CurrentCardSlotData);
			mergeCardToPlayerTableFromAreaTableMultiPlayMsg.FromSlotIndex = MultiPlayArea.Instance.P1AreaSlots.IndexOf(from.CurrentCardSlotData);
			MultiPlayerController.Instance.MultiPlaySendMsgQueue.Enqueue(mergeCardToPlayerTableFromAreaTableMultiPlayMsg);
		}
	}

	private void Update()
	{
		CSteamID currentLobbyID = MultiPlayerController.Instance.CurrentLobbyID;
		if (this.ReciveMsgQueue.Count > 0)
		{
			MultiPlayMsg multiPlayMsg = this.ReciveMsgQueue.Dequeue();
			if (multiPlayMsg is GetCardMultiPlayMsg)
			{
				this.ResponseGetCardMsg((GetCardMultiPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is ChangeSlotMultiPlayMsg)
			{
				this.ResponseChangeSlotMsg((ChangeSlotMultiPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is ChangeSlotToPublicAreaMultiPlayMsg)
			{
				this.ResponseChangeSlotToPublicAreaMsg((ChangeSlotToPublicAreaMultiPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is AreaTableToPublicAreaPlayMsg)
			{
				this.ResponseChangeAreaTableSlotToPublicAreaMsg((AreaTableToPublicAreaPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is MergeCardMultiPlayMsg)
			{
				this.ResponseMergeCardMsg((MergeCardMultiPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is MergeCardToPublicAreaMultiPlayMsg)
			{
				this.ResponseMergeCardToPublicAreaMsg((MergeCardToPublicAreaMultiPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is AreaTableCreateCardPlayMsg)
			{
				this.ResponseAreaTableCreateCardMsg((AreaTableCreateCardPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is AreaTableChangeSlotPlayMsg)
			{
				this.ResponseAreaTableChangeSlotToPlayerMsg((AreaTableChangeSlotPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is SyncCardsMultiPlayMsg)
			{
				bool flag = false;
				if (MultiPlayerController.Instance.GameState == MultiPlayerController.GameStateType.StartBattleSync)
				{
					MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.WaittingStartBattleSync);
					flag = true;
				}
				else if (MultiPlayerController.Instance.GameState == MultiPlayerController.GameStateType.EndBattleSync)
				{
					MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.WaittingEndBattleSync);
				}
				this.ResponseSyncBattleCardMsg((SyncCardsMultiPlayMsg)multiPlayMsg);
				if (flag)
				{
					MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.BattleTurn);
					return;
				}
				MultiPlayerController.Instance.StateChange(MultiPlayerController.GameStateType.P1Turn);
				return;
			}
			else
			{
				if (multiPlayMsg is MergeCardToPlayerTableFromAreaTableMultiPlayMsg)
				{
					this.ResponseMergeCardToPlayerTableFromAreaTableMsg((MergeCardToPlayerTableFromAreaTableMultiPlayMsg)multiPlayMsg);
					return;
				}
				if (multiPlayMsg is MergeCardToPublicAreaFromAreaTableMultiPlayMsg)
				{
					this.ResponseMergeCardToPublicAreaFromAreaTablMsg((MergeCardToPublicAreaFromAreaTableMultiPlayMsg)multiPlayMsg);
				}
			}
		}
	}

	private void ResponseGetCardMsg(GetCardMultiPlayMsg msg)
	{
		Card.InitCardDataByID(msg.ModID).PutInSlotData(GameController.getInstance().PartnerArea[msg.AimSlotIndex], false);
	}

	private void ResponseChangeSlotMsg(ChangeSlotMultiPlayMsg msg)
	{
		GameController.getInstance().PartnerArea[msg.FromSlotIndex].ChildCardData.PutInSlotData(GameController.getInstance().PartnerArea[msg.AimSlotIndex], false);
	}

	private void ResponseChangeSlotToPublicAreaMsg(ChangeSlotToPublicAreaMultiPlayMsg msg)
	{
		GameController.getInstance().PartnerArea[msg.FromSlotIndex].ChildCardData.PutInSlotData(GameController.getInstance().PublicArea[msg.AimSlotIndex], false);
	}

	private void ResponseChangeAreaTableSlotToPublicAreaMsg(AreaTableToPublicAreaPlayMsg msg)
	{
		MultiPlayArea.Instance.P2AreaSlots[msg.FromSlotIndex].ChildCardData.PutInSlotData(GameController.getInstance().PublicArea[msg.AimSlotIndex], false);
	}

	private void ResponseMergeCardMsg(MergeCardMultiPlayMsg msg)
	{
		GameController.getInstance().PartnerArea[msg.AimSlotIndex].ChildCardData.MergeBy(GameController.getInstance().PartnerArea[msg.FromSlotIndex].ChildCardData, false, false);
		GameController.getInstance().PartnerArea[msg.FromSlotIndex].ChildCardData.DeleteCardData();
	}

	private void ResponseMergeCardToPublicAreaMsg(MergeCardToPublicAreaMultiPlayMsg msg)
	{
		GameController.getInstance().PublicArea[msg.AimSlotIndex].ChildCardData.MergeBy(GameController.getInstance().PartnerArea[msg.FromSlotIndex].ChildCardData, false, false);
		GameController.getInstance().PartnerArea[msg.FromSlotIndex].ChildCardData.DeleteCardData();
	}

	private void ResponseMergeCardToPublicAreaFromAreaTablMsg(MergeCardToPublicAreaFromAreaTableMultiPlayMsg msg)
	{
		GameController.getInstance().PublicArea[msg.AimSlotIndex].ChildCardData.MergeBy(MultiPlayArea.Instance.P2AreaSlots[msg.FromSlotIndex].ChildCardData, false, false);
		MultiPlayArea.Instance.P2AreaSlots[msg.FromSlotIndex].ChildCardData.DeleteCardData();
	}

	private void ResponseMergeCardToPlayerTableFromAreaTableMsg(MergeCardToPlayerTableFromAreaTableMultiPlayMsg msg)
	{
		GameController.getInstance().PartnerArea[msg.AimSlotIndex].ChildCardData.MergeBy(MultiPlayArea.Instance.P2AreaSlots[msg.FromSlotIndex].ChildCardData, false, false);
		MultiPlayArea.Instance.P2AreaSlots[msg.FromSlotIndex].ChildCardData.DeleteCardData();
	}

	private void ResponseAreaTableCreateCardMsg(AreaTableCreateCardPlayMsg msg)
	{
		Card.InitCardDataByID(msg.ModID).PutInSlotData(MultiPlayArea.Instance.P2AreaSlots[msg.AimSlotIndex], false);
	}

	private void ResponseAreaTableChangeSlotToPlayerMsg(AreaTableChangeSlotPlayMsg msg)
	{
		MultiPlayArea.Instance.P2AreaSlots[msg.FromSlotIndex].ChildCardData.PutInSlotData(GameController.getInstance().PartnerArea[msg.AimSlotIndex], false);
	}

	private void ResponseSyncBattleCardMsg(SyncCardsMultiPlayMsg msg)
	{
		for (int i = 0; i < GameController.getInstance().PublicArea.Count; i++)
		{
			if (GameController.getInstance().PublicArea[i].ChildCardData != null)
			{
				GameController.getInstance().PublicArea[i].ChildCardData.DeleteCardData();
			}
			if (msg.cards[i] != null)
			{
				msg.cards[i].PutInSlotData(GameController.getInstance().PublicArea[i], false);
				if (msg.cards[i].HasTag(TagMap.英雄))
				{
					GameController.getInstance().GameData.PlayerCardData = msg.cards[i];
					GameController.getInstance().PlayerToy = Card.InitCard(msg.cards[i]);
				}
			}
		}
	}

	public Queue<MultiPlayMsg> ReciveMsgQueue = new Queue<MultiPlayMsg>();

	private MultiPlayerController.GameStateType m_state = MultiPlayerController.GameStateType.None;
}
