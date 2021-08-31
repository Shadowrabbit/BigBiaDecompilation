using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
	public void Init()
	{
		this.ToysInWorld = new List<CardData>();
		this.tradeLogic = new TradeLogic();
		this.fisher = new FisherHouse();
		this.trader = new List<CardData>();
		GameController.getInstance().GameEventManager.OnGameStartEvent += this.OnGameStart;
		GameController.getInstance().GameEventManager.OnDayPassEvent += this.OnDayPass;
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent += this.CardChangeSlot;
		GameController.getInstance().GameEventManager.OnTaskStateChangedEvent += this.OnTaskStateChanged;
		GameController.getInstance().GameEventManager.OnTaskStepStateChangedEvent += this.OnTaskStepStateChanged;
		GameController.getInstance().GameEventManager.OnTaskSettleEvent += this.OnTaskSettle;
	}

	private void Start()
	{
	}

	public void ToyBorn(CardData toyData)
	{
		this.ToysInWorld.Add(toyData);
	}

	private void OnGameStart()
	{
	}

	private void OnDayPass()
	{
		this.trader.Clear();
		foreach (CardData cardData in this.ToysInWorld)
		{
			if (cardData != null && cardData.Attrs != null && cardData.Attrs.ContainsKey("Trader"))
			{
				this.trader.Add(cardData);
			}
		}
		this.tradeLogic.Trade(this.trader);
		base.StartCoroutine(this.CallLogic(this.trader));
		new LinkedList<AreaData>();
		foreach (KeyValuePair<string, AreaData> keyValuePair in GameController.getInstance().GameData.AreaMap)
		{
			foreach (AreaLogic areaLogic in keyValuePair.Value.Logics)
			{
				areaLogic.IsDone = false;
			}
		}
		foreach (KeyValuePair<string, AreaData> keyValuePair2 in GameController.getInstance().GameData.AreaMap)
		{
			foreach (AreaLogic areaLogic2 in keyValuePair2.Value.Logics)
			{
				if (!areaLogic2.IsDone)
				{
					areaLogic2.OnDayPass();
				}
			}
		}
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (AreaData areaData in GameController.getInstance().GameData.AreaMap.Values)
		{
			if (areaData.CardSlotDatas != null)
			{
				list.AddRange(areaData.CardSlotDatas);
			}
		}
		foreach (CardSlotData cardSlotData in list)
		{
			foreach (CardSlotLogic cardSlotLogic in cardSlotData.Logics)
			{
				cardSlotLogic.OnDayPassed();
			}
		}
	}

	private IEnumerator CallLogic(List<CardData> toys)
	{
		int timesOneFrame = 60;
		int times = timesOneFrame;
		int num;
		for (int i = 0; i < toys.Count; i = num + 1)
		{
			if (i >= timesOneFrame)
			{
				times += timesOneFrame;
				yield return null;
			}
			toys[i].DoAllLogic("OnDayPass", Array.Empty<object>());
			num = i;
		}
		yield break;
	}

	private void OnTaskStateChanged(string taskName)
	{
		foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null))
			{
				Card childCard = cardSlot.ChildCard;
				if (childCard != null)
				{
					childCard.CardData.DoAllLogic("OnTaskUpdate", new object[]
					{
						taskName
					});
				}
			}
		}
		TaskData task = GameController.getInstance().GetTask(taskName);
		TaskState state = task.State;
		if (task.Conversations.ContainsKey(state))
		{
			TaskData.TaskConversation taskConversation = task.Conversations[state];
			Conversation conversation = DialogueManager.MasterDatabase.GetConversation(taskConversation.Conversation);
			if (taskConversation.Conversant.Equals("大哥大"))
			{
				GameController.getInstance().GameEventManager.EarlyProcessTask(task);
			}
			else
			{
				Toy toy = GameController.getInstance().FindCard(taskConversation.Conversant) as Toy;
				if (toy == null && conversation != null)
				{
					toy.StartDialogue(taskConversation.Conversation);
				}
			}
		}
		if (task.State == TaskState.SUCCESS && task.AutoSettle)
		{
			GameController.getInstance().SettleTask(taskName);
		}
	}

	private void OnTaskStepStateChanged(string taskName, int index)
	{
		TaskData task = GameController.getInstance().GetTask(taskName);
		if (task.StepConversations.ContainsKey(index))
		{
			TaskData.TaskConversation taskConversation = task.StepConversations[index];
			Conversation conversation = DialogueManager.MasterDatabase.GetConversation(taskConversation.Conversation);
			if (taskConversation.Conversant.Equals("大哥大"))
			{
				GameController.getInstance().GameEventManager.EarlyProcessTask(task);
				return;
			}
			Toy toy = GameController.getInstance().FindCard(taskConversation.Conversant) as Toy;
			if (conversation != null && toy != null)
			{
				toy.StartDialogue(taskConversation.Conversation);
			}
		}
	}

	private void OnTaskSettle(string task)
	{
		foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null))
			{
				Card childCard = cardSlot.ChildCard;
				if (childCard != null)
				{
					childCard.CardData.DoAllLogic("OnTaskSettle", new object[]
					{
						task
					});
				}
			}
		}
	}

	private void CardChangeSlot(CardSlot oldCardSlot, CardSlot newCardSlot, Card card)
	{
		if (newCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Trash)
		{
			foreach (CardSlotLogic cardSlotLogic in newCardSlot.CardSlotData.Logics)
			{
				cardSlotLogic.OnCardPutIn(oldCardSlot, newCardSlot, card);
			}
		}
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent -= this.CardChangeSlot;
		GameController.getInstance().GameEventManager.OnGameStartEvent -= this.OnGameStart;
		GameController.getInstance().GameEventManager.OnDayPassEvent -= this.OnDayPass;
		GameController.getInstance().GameEventManager.OnTaskStateChangedEvent -= this.OnTaskStateChanged;
		GameController.getInstance().GameEventManager.OnTaskStepStateChangedEvent -= this.OnTaskStepStateChanged;
		GameController.getInstance().GameEventManager.OnTaskSettleEvent -= this.OnTaskSettle;
	}

	public List<CardData> ToysInWorld;

	private List<CardData> trader;

	private TradeLogic tradeLogic;

	private FisherHouse fisher;
}
