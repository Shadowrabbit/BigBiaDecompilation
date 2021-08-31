using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<FrontCancelButton>().GameAct = this;
		this.FrontCancelButton = base.GetComponentInChildren<FrontCancelButton>();
		this.InputSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		CardSlotData cardSlotData2 = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Normal;
		cardSlotData2.SlotType = CardSlotData.Type.Normal;
		CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
		CardSlot cardSlot2 = CardSlot.InitCardSlot(cardSlotData2, 0.111f);
		cardSlot.transform.SetParent(base.transform, false);
		cardSlot2.transform.SetParent(base.transform, false);
		cardSlot.transform.position = this.InputTran1.position;
		cardSlot2.transform.position = this.InputTran2.position;
		this.InputSlots.Add(cardSlot);
		this.InputSlots.Add(cardSlot2);
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
		if (!(this.InputSlots[0].ChildCard != null) || this.InputSlots[0].ChildCard.CardData == null || !(this.InputSlots[1].ChildCard != null) || this.InputSlots[1].ChildCard.CardData == null)
		{
			GameController.getInstance().CreateSubtitle("必须放入两个物品", 1f, 2f, 1f, 1f);
			return;
		}
		if ((this.InputSlots[0].ChildCard.CardData.Name == "鲑鱼" && this.InputSlots[1].ChildCard.CardData.Name == "油") || (this.InputSlots[0].ChildCard.CardData.Name == "油" && this.InputSlots[1].ChildCard.CardData.Name == "鲑鱼"))
		{
			this.rotateTable();
			return;
		}
		GameController.getInstance().CreateSubtitle("抢先体验版不具备此功能", 1f, 2f, 1f, 1f);
	}

	private void rotateTable()
	{
		CardSlot cardSlot = CardSlot.InitCardSlot(new CardSlotData(), 0.111f);
		cardSlot.transform.SetParent(base.transform, false);
		cardSlot.transform.position = this.ResultTrans.position;
		cardSlot.transform.rotation = this.ResultTrans.rotation;
		base.StartCoroutine(base.rotateTableCor());
		for (int i = 0; i < this.InputSlots.Count; i++)
		{
			if (this.InputSlots[i] != null && this.InputSlots[i].ChildCard != null)
			{
				this.InputSlots[i].ChildCard.gameObject.SetActive(false);
			}
		}
		base.SetBackEnable();
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		foreach (CardSlot cardSlot in this.InputSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Normal;
		}
	}

	public override void OnActFrontCancelButton()
	{
		base.SetAllButton(false);
		base.StartCoroutine(this.FrontCancel());
	}

	public IEnumerator FrontCancel()
	{
		yield return base.StartCoroutine(this.ActGetAllAni(this.InputSlots));
		this.OnActCancelButton();
		yield break;
	}

	public List<CardSlot> InputSlots;

	public Transform InputTran1;

	public Transform InputTran2;

	public Transform ResultTrans;
}
