using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class ResponseVSPlayMsgManager : MonoBehaviour
{
	private void Start()
	{
		this.ReciveMsgQueue = VSModeController.Instance.MultiPlayRecerveMsgQueue;
		CSteamID currentLobbyID = VSModeController.Instance.CurrentLobbyID;
		GameController.getInstance().GameEventManager.OnMerByEvent += this.OnMerBy;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.OnCardChangeSlot;
		VSModeController.Instance.OnStateChangeEvent += this.OnStateChange;
	}

	private void OnDestroy()
	{
		CSteamID currentLobbyID = VSModeController.Instance.CurrentLobbyID;
		GameController.getInstance().GameEventManager.OnMerByEvent -= this.OnMerBy;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.OnCardChangeSlot;
		VSModeController.Instance.OnStateChangeEvent -= this.OnStateChange;
	}

	private void OnStateChange(VSModeController.GameStateType gameState)
	{
		switch (gameState)
		{
		case VSModeController.GameStateType.None:
			break;
		case VSModeController.GameStateType.NotStart:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("\n等待游戏开始");
			return;
		case VSModeController.GameStateType.P1Turn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("\n等待1P回合结束");
			VSPlayController.Instance.P1Name.text = VSModeController.Instance.MyName + "(Rank:" + VSModeController.Instance.Rank.ToString() + ")";
			VSPlayController.Instance.P2Name.text = VSModeController.Instance.OPName + "(Rank:" + VSModeController.Instance.OPRank.ToString() + ")";
			if (VSModeController.Instance.MyIdentity == VSModeController.Identity.Host)
			{
				VSPlayController.Instance.GetAndPutMinionTurn();
			}
			this.m_Timer = this.Timer("\n等待1P回合结束");
			base.StartCoroutine(this.m_Timer);
			return;
		case VSModeController.GameStateType.P1BattleTurn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("\n等待1P战斗结束");
			if (VSModeController.Instance.MyIdentity == VSModeController.Identity.Host)
			{
				foreach (CardSlotData cardSlotData in VSPlayController.Instance.P1AreaSlots)
				{
					if (cardSlotData.ChildCardData != null)
					{
						cardSlotData.ChildCardData.DeleteCardData();
					}
				}
				this.m_GetMinionsNumb = 0;
			}
			base.StopCoroutine(this.m_Timer);
			return;
		case VSModeController.GameStateType.P2Turn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("\n等待2P回合结束");
			if (VSModeController.Instance.MyIdentity == VSModeController.Identity.Client)
			{
				VSPlayController.Instance.GetAndPutMinionTurn();
			}
			this.m_Timer = this.Timer("\n等待2P回合结束");
			base.StartCoroutine(this.m_Timer);
			return;
		case VSModeController.GameStateType.P2BattleTurn:
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel("\n等待2P战斗结束");
			if (VSModeController.Instance.MyIdentity == VSModeController.Identity.Client)
			{
				foreach (CardSlotData cardSlotData2 in VSPlayController.Instance.P1AreaSlots)
				{
					if (cardSlotData2.ChildCardData != null)
					{
						cardSlotData2.ChildCardData.DeleteCardData();
					}
				}
				this.m_GetMinionsNumb = 0;
			}
			base.StopCoroutine(this.m_Timer);
			break;
		default:
			return;
		}
	}

	private IEnumerator Timer(string str)
	{
		int t = 60;
		GameController.ins.UIController.ShowMultiPlayTurnStatePanel(str + "\n" + t.ToString());
		while (t > 0)
		{
			yield return new WaitForSeconds(1f);
			int num = t;
			t = num - 1;
			GameController.ins.UIController.ShowMultiPlayTurnStatePanel(str + "\n" + t.ToString());
		}
		this.EndTurn();
		yield break;
	}

	private void OnCardChangeSlot(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (GameController.getInstance().PublicArea.Contains(newCardSlot) && !GameController.getInstance().PublicArea.Contains(oldCardSlot))
		{
			VSMoveCardMultiPlayMsg vsmoveCardMultiPlayMsg = new VSMoveCardMultiPlayMsg();
			vsmoveCardMultiPlayMsg.AimSlotIndex = GameController.getInstance().PublicArea.IndexOf(newCardSlot);
			vsmoveCardMultiPlayMsg.CardData = card;
			VSModeController.Instance.MultiPlaySendMsgQueue.Enqueue(vsmoveCardMultiPlayMsg);
		}
		if (VSPlayController.Instance.P1AreaSlots.Contains(oldCardSlot))
		{
			this.m_GetMinionsNumb++;
			if (this.m_GetMinionsNumb > DungeonController.Instance.GameSettleData.Turns || this.m_GetMinionsNumb > 3)
			{
				foreach (CardSlotData cardSlotData in VSPlayController.Instance.P1AreaSlots)
				{
					if (cardSlotData.ChildCardData != null)
					{
						cardSlotData.ChildCardData.DeleteCardData();
					}
				}
				this.m_GetMinionsNumb = 0;
			}
		}
	}

	private void OnMerBy(CardData target, CardData from)
	{
		if (GameController.getInstance().PublicArea.Contains(target.CurrentCardSlotData))
		{
			VSMergeCardMultiPlayMsg vsmergeCardMultiPlayMsg = new VSMergeCardMultiPlayMsg();
			vsmergeCardMultiPlayMsg.CardData = from;
			for (int i = 0; i < GameController.getInstance().PublicArea.Count; i++)
			{
				if (GameController.getInstance().PublicArea[i] == target.CurrentCardSlotData)
				{
					vsmergeCardMultiPlayMsg.AimSlotIndex = i;
				}
			}
			VSModeController.Instance.MultiPlaySendMsgQueue.Enqueue(vsmergeCardMultiPlayMsg);
		}
		if (VSPlayController.Instance.P1AreaSlots.Contains(from.CurrentCardSlotData))
		{
			this.m_GetMinionsNumb++;
			if (this.m_GetMinionsNumb > DungeonController.Instance.GameSettleData.Turns || this.m_GetMinionsNumb > 3)
			{
				foreach (CardSlotData cardSlotData in VSPlayController.Instance.P1AreaSlots)
				{
					if (cardSlotData.ChildCardData != null)
					{
						cardSlotData.ChildCardData.DeleteCardData();
					}
				}
				this.m_GetMinionsNumb = 0;
			}
		}
	}

	private void Update()
	{
		CSteamID currentLobbyID = VSModeController.Instance.CurrentLobbyID;
		if (this.ReciveMsgQueue.Count > 0)
		{
			MultiPlayMsg multiPlayMsg = this.ReciveMsgQueue.Dequeue();
			if (multiPlayMsg is VSMoveCardMultiPlayMsg)
			{
				this.ResponseChangeSlotToPublicAreaMsg((VSMoveCardMultiPlayMsg)multiPlayMsg);
				return;
			}
			if (multiPlayMsg is VSMergeCardMultiPlayMsg)
			{
				this.ResponseMergeCardToPublicAreaMsg((VSMergeCardMultiPlayMsg)multiPlayMsg);
			}
		}
	}

	private void ResponseChangeSlotToPublicAreaMsg(VSMoveCardMultiPlayMsg msg)
	{
		msg.CardData.PutInSlotData(DungeonOperationMgr.Instance.BattleArea[msg.AimSlotIndex], false);
	}

	private void ResponseMergeCardToPublicAreaMsg(VSMergeCardMultiPlayMsg msg)
	{
		DungeonOperationMgr.Instance.BattleArea[msg.AimSlotIndex].ChildCardData.MergeBy(msg.CardData, false, false);
	}

	private void EndTurn()
	{
		if (VSModeController.Instance != null)
		{
			CSteamID currentLobbyID = VSModeController.Instance.CurrentLobbyID;
			if (VSModeController.Instance.GameState == VSModeController.GameStateType.P1Turn && VSModeController.Instance.MyIdentity == VSModeController.Identity.Host)
			{
				VSModeController.Instance.StateChange(VSModeController.GameStateType.P1BattleTurn);
				VSModeController.Instance.IsInBattle = true;
				VSModeController.Instance.IsOPInBattle = true;
				base.StartCoroutine(DungeonOperationMgr.Instance.VSModeEndTurnProcess(true));
			}
			else if (VSModeController.Instance.GameState == VSModeController.GameStateType.P2Turn && VSModeController.Instance.MyIdentity == VSModeController.Identity.Client)
			{
				VSModeController.Instance.StateChange(VSModeController.GameStateType.P2BattleTurn);
				VSModeController.Instance.IsInBattle = true;
				VSModeController.Instance.IsOPInBattle = true;
				base.StartCoroutine(DungeonOperationMgr.Instance.VSModeEndTurnProcess(true));
			}
			base.StopCoroutine(this.m_Timer);
			return;
		}
	}

	public Queue<MultiPlayMsg> ReciveMsgQueue = new Queue<MultiPlayMsg>();

	private IEnumerator m_Timer;

	private int m_GetMinionsNumb;
}
