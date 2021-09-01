using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAct : GameAct
{
	private void Start()
	{
		this.CanSleep = true;
		this.Source.CardData.DoAllLogic("BeforeSleep", new object[]
		{
			this
		});
		if (!this.CanSleep)
		{
			UnityEngine.Object.Destroy(base.gameObject, 0f);
			return;
		}
		this.Init();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<GetAllButton>().GameAct = this;
		this.GetAllButton = base.GetComponentInChildren<GetAllButton>();
		this.InputSlots = new List<CardSlot>();
		this.RewardSlots = new List<CardSlot>();
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
		new List<CardSlotData>();
		this.rotateCardSlot();
	}

	private IEnumerator Execute(int VigNum, int EneNum)
	{
		this.RewardID = new List<string>();
		this.Result = new List<bool>();
		List<Card> cards = new List<Card>();
		List<CardSlot> slots = new List<CardSlot>();
		foreach (CardSlot pcs in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(pcs == null))
			{
				if (pcs != null && pcs.ChildCard != null && pcs.ChildCard.CardData.Name == "精力")
				{
					CardSlot cardSlot = CardSlot.InitCardSlot(new CardSlotData(), 0.111f);
					this.InputTrans.position += new Vector3(1.3f, 0f, 0f);
					cardSlot.transform.SetParent(base.transform, false);
					cardSlot.transform.position = this.InputTrans.position;
					cardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
					cards.Add(pcs.ChildCard);
					slots.Add(cardSlot);
					yield return GameAct.PutCardInSlotAni(pcs.ChildCard, cardSlot, 0.2f);
				}
				if (pcs != null && pcs.ChildCard != null && pcs.ChildCard.CardData.Name == "体力")
				{
					CardSlot cardSlot2 = CardSlot.InitCardSlot(new CardSlotData(), 0.111f);
					this.InputTrans.position += new Vector3(1.3f, 0f, 0f);
					cardSlot2.transform.SetParent(base.transform, false);
					cardSlot2.transform.position = this.InputTrans.position;
					cardSlot2.CardSlotData.SlotType = CardSlotData.Type.Freeze;
					cards.Add(pcs.ChildCard);
					slots.Add(cardSlot2);
					yield return GameAct.PutCardInSlotAni(pcs.ChildCard, cardSlot2, 0.2f);
				}
				pcs = null;
			}
		}
		CardSlot[] array = null;
		for (int j = 0; j < VigNum; j++)
		{
		}
		for (int k = 0; k < EneNum; k++)
		{
		}
		GameController.getInstance().GameEventManager.DayPass();
		yield break;
	}

	private void rotateCardSlot()
	{
		base.StartCoroutine(this.rotateCardSlotCor());
	}

	private IEnumerator rotateCardSlotCor()
	{
		UIController.LockLevel = UIController.UILevel.All;
		int num;
		for (int i = 0; i < this.Result.Count; i = num + 1)
		{
			if (!(this.InputSlots[i].ChildCard == null))
			{
				if (this.Result[i])
				{
					yield return base.StartCoroutine(GameController.getInstance().RotateCardAnimate(this.InputSlots[i], "判定成功"));
				}
				else
				{
					yield return base.StartCoroutine(GameController.getInstance().RotateCardAnimate(this.InputSlots[i], "判定失败"));
				}
				yield return new WaitForSeconds(0.2f);
			}
			num = i;
		}
		yield return new WaitForSeconds(1f);
		yield return base.StartCoroutine(this.Execute(3, 3));
		this.rotateTable();
		yield break;
	}

	private void rotateTable()
	{
		base.InitCardSlotOnActTable(this.RewardTrans, new Vector3(1.3f, 0f, 0f), this.RewardID.Count, true, this.RewardID, this.RewardSlots, null);
		GameController.getInstance().GameData.Energy = GameController.getInstance().GameData.MaxEnergy;
		base.StartCoroutine(base.rotateTableCor());
	}

	public override void OnActGetAllButton()
	{
		base.OnActGetAllButton();
		base.StartCoroutine(this.ActGetAllAni(this.RewardSlots));
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		foreach (CardSlot cardSlot in this.InputSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Normal;
		}
	}

	public List<CardSlot> InputSlots;

	public Transform InputTrans;

	public List<string> RewardID;

	public Transform RewardTrans;

	public List<CardSlot> RewardSlots;

	public List<bool> Result;

	public bool CanSleep;
}
