using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class BluePrintAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.InputSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.InputTrans, new Vector3(1.3f, 0f, 0f), 1, false, null, this.InputSlots, cardSlotData);
		if (this.Source.CardData.Attrs.ContainsKey("BluePrint"))
		{
			CardData cardData = JsonConvert.DeserializeObject(this.Source.CardData.Attrs["BluePrint"].ToString(), typeof(CardData)) as CardData;
			base.StartCoroutine(base.EmissionEffect(cardData, this.InputSlots[0], 30));
		}
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
				if (this.Source.CardData.Attrs.Count > 0)
				{
					this.Source.CardData.Attrs.Clear();
				}
				this.Source.CardData.Attrs.Add("BluePrint", JsonConvert.SerializeObject(cardSlot.ChildCard.CardData, Formatting.Indented));
			}
		}
	}

	public List<CardSlot> InputSlots;

	public Transform InputTrans;

	public int slotCount;
}
