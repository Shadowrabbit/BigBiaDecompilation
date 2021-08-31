using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<GetAllButton>().GameAct = this;
		this.GetAllButton = base.GetComponentInChildren<GetAllButton>();
		base.GetComponentInChildren<FrontCancelButton>().GameAct = this;
		this.FrontCancelButton = base.GetComponentInChildren<FrontCancelButton>();
		CardSlotData csd = new CardSlotData();
		if (this.Source.CardData.Attrs.ContainsKey("MakeNum"))
		{
			int num = Convert.ToInt32(this.Source.CardData.Attrs["MakeNum"]);
			base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.3f, 0f, 0f), num + 1, false, null, this.InputSlots, csd);
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
		List<CardSlotData> list = new List<CardSlotData>();
		int num = 0;
		for (int i = 0; i < this.InputSlots.Count; i++)
		{
			if (this.InputSlots[i].ChildCard != null && this.InputSlots[i].ChildCard.CardData.Name == "精力")
			{
				num++;
			}
		}
		if (num < 1)
		{
			GameController.getInstance().CreateSubtitle("必须要放置1张精力卡牌", 1f, 2f, 1f, 1f);
			return;
		}
		foreach (CardSlot cardSlot in this.InputSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
			list.Add(cardSlot.CardSlotData);
		}
		this.Source.CardData.DoAllLogic("OnMake", new object[]
		{
			this.InputSlots,
			this.RewardCardDatas
		});
		base.InitCardSlotOnActTable(this.RewardTrans, new Vector3(1.3f, 0f, 0f), this.RewardCardDatas.Count, false, null, this.RewardSlots, null);
		for (int j = 0; j < this.RewardCardDatas.Count; j++)
		{
		}
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
	}

	public override void OnActFrontCancelButton()
	{
		base.SetAllButton(false);
		base.StartCoroutine(this.FrontCancel());
	}

	public IEnumerator FrontCancel()
	{
		yield return base.StartCoroutine(this.ActGetAllAni(this.InputSlots));
		base.OnActCancelButton();
		yield break;
	}

	public List<CardSlot> InputSlots;

	public List<CardData> RewardCardDatas;

	public List<CardSlot> RewardSlots;

	public Transform SlotsTrans;

	public Transform RewardTrans;
}
