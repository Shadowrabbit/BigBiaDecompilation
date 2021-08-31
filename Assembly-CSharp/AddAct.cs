using System;
using System.Collections.Generic;
using UnityEngine;

public class AddAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		cardSlotData.OnlyAcceptOneCard = true;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.3f, 0f, 0f), this.Source.CardData.ContainsNumber, false, null, this.ContainSlots, cardSlotData);
		if (this.Source.CardData.ContainsIDs != null)
		{
			for (int i = 0; i < this.Source.CardData.ContainsIDs.Count; i++)
			{
				GameController.getInstance().CardDataInWorldMap.ContainsKey(this.Source.CardData.ContainsIDs[i]);
			}
		}
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	private void Update()
	{
	}

	public override void OnActOKButton()
	{
		base.OnActOKButton();
		this.Source.CardData.ContainsIDs = new List<string>();
		for (int i = 0; i < this.ContainSlots.Count; i++)
		{
			if (this.ContainSlots[i].ChildCard != null)
			{
				this.Source.CardData.ContainsIDs.Add(this.ContainSlots[i].ChildCard.CardData.ID);
			}
		}
		this.Source.CardData.DoAllLogic("AfterAdd", new object[]
		{
			this
		});
		base.StartCoroutine(base.ActEndAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	public List<CardSlot> ContainSlots;

	public Transform SlotsTrans;
}
