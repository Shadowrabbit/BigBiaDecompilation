using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<GetAllButton>().GameAct = this;
		this.GetAllButton = base.GetComponentInChildren<GetAllButton>();
		this.Source.CardData.DoAllLogic("OnCollect", new object[]
		{
			this.RewardCardIDs
		});
		base.InitCardSlotOnActTable(this.RewardTrans, new Vector3(1.3f, 0f, 0f), this.RewardCardIDs.Count, true, this.RewardCardIDs, this.RewardSlots, null);
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
	}

	public override void OnActGetAllButton()
	{
		base.OnActGetAllButton();
		base.StartCoroutine(this.ActGetAllAni(this.RewardSlots));
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		this.Source.DeleteCard();
	}

	public List<string> RewardCardIDs;

	public List<CardSlot> RewardSlots;

	public Transform RewardTrans;
}
