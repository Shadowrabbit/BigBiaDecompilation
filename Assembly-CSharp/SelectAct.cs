using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectAct : GameAct
{
	private void Start()
	{
		this.Init();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if ((cardData.CardTags & 8UL) > 0UL)
			{
				list.Add(cardData);
			}
		}
		if (list.Count > 0)
		{
			for (int i = 0; i < 3; i++)
			{
				CardData cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
				bool flag = false;
				foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
				{
					if (cardSlot != null && cardSlot.CardSlotData.ChildCardData != null && cardSlot.CardSlotData.ChildCardData.ModID == cardData2.ModID)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					i--;
				}
				else
				{
					this.OptionNames.Add(cardData2.ModID);
					list.Remove(cardData2);
				}
			}
		}
		this.OptionSlots = new List<CardSlot>();
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.3f, 0f, 0f), this.OptionNames.Count, true, this.OptionNames, this.OptionSlots, null);
		GameEventManager gameEventManager = GameController.getInstance().GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.CardPutInSlot));
	}

	private void CardPutInSlot(CardSlotData sourceSlot, CardData cardData)
	{
		if (sourceSlot != null && sourceSlot.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			GameEventManager gameEventManager = GameController.getInstance().GameEventManager;
			gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.CardPutInSlot));
			UIController.LockLevel = UIController.UILevel.None;
			this.OnActCancelButton();
			this.Source.CardData.DeleteCardData();
		}
	}

	public List<string> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;
}
