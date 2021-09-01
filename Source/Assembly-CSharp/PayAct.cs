using System;
using System.Collections.Generic;
using UnityEngine;

public class PayAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.InputSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.InputTrans, new Vector3(1.3f, 0f, 0f), this.ActData.InputSlotNum, false, null, this.InputSlots, cardSlotData);
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		foreach (CardSlot cardSlot in this.InputSlots)
		{
			if (cardSlot.ChildCard != null)
			{
				this.Source.CardData.Belongings.Add(cardSlot.ChildCard.CardData.Name);
			}
		}
	}

	public List<CardSlot> InputSlots;

	public Transform InputTrans;

	public int slotCount;
}
