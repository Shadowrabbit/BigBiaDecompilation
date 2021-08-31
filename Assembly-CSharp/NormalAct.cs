using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalAct : GameAct
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
		this.ResultText.gameObject.SetActive(false);
		this.InputSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.OnlyAcceptOneCard = true;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		cardSlotData.TagWhiteList = 3UL;
		base.InitCardSlotOnActTable(this.InputTrans, new Vector3(1.3f, 0f, 0f), this.ActData.InputSlotNum, false, null, this.InputSlots, cardSlotData);
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
		this.Result = new List<bool>();
		this.Reward = new List<CardData>();
		if (this.Source.CardData.Attrs.ContainsKey("FishLevel"))
		{
			for (int i = 0; i < this.InputSlots.Count; i++)
			{
				if (this.InputSlots[i].ChildCard != null && this.InputSlots[i].ChildCard.CardData.Attrs.ContainsKey("FishLevel"))
				{
					num++;
				}
			}
			int num2 = Convert.ToInt32(this.Source.CardData.Attrs["FishLevel"]);
			if (num < num2)
			{
				GameController.getInstance().CreateSubtitle("必须要放置" + num2.ToString() + "张对应卡牌", 1f, 2f, 1f, 1f);
				return;
			}
		}
		if (this.Source.CardData.Attrs.ContainsKey("HuntLevel"))
		{
			for (int j = 0; j < this.InputSlots.Count; j++)
			{
				if (this.InputSlots[j].ChildCard != null && this.InputSlots[j].ChildCard.CardData.Attrs.ContainsKey("HuntLevel"))
				{
					num++;
				}
			}
			int num3 = Convert.ToInt32(this.Source.CardData.Attrs["HuntLevel"]);
			if (num < num3)
			{
				GameController.getInstance().CreateSubtitle("必须要放置" + num3.ToString() + "张对应卡牌", 1f, 2f, 1f, 1f);
				return;
			}
		}
		foreach (CardSlot cardSlot in this.InputSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
			list.Add(cardSlot.CardSlotData);
			if (this.Source.CardData.Attrs.ContainsKey("FishLevel") && cardSlot.ChildCard != null)
			{
				this.Reward.Add(cardSlot.ChildCard.CardData);
			}
		}
		this.Source.CardData.DoAllLogic("OnFishing", new object[]
		{
			this
		});
		this.Source.CardData.DoAllLogic("OnHunting", new object[]
		{
			list,
			this.Result,
			this.Reward
		});
		this.rotateCardSlot();
	}

	protected override IEnumerator ActStartAni(Vector3 eventalOffset, Vector3 oppositeOffset, int during)
	{
		base.SetAllButton(false);
		yield return base.StartCoroutine(base.ActStartAni(eventalOffset, oppositeOffset, during));
		base.SetFrontEnable();
		yield break;
	}

	private void rotateCardSlot()
	{
		base.StartCoroutine(this.rotateCardSlotCor());
	}

	private IEnumerator rotateCardSlotCor()
	{
		UIController.LockLevel = UIController.UILevel.All;
		int i = 0;
		while (i < this.Result.Count && i < this.InputSlots.Count)
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
			int num = i;
			i = num + 1;
		}
		yield return new WaitForSeconds(1f);
		this.rotateTable();
		yield break;
	}

	private void rotateTable()
	{
		this.RewardSlots = new List<CardSlot>();
		for (int i = 0; i < this.Reward.Count; i++)
		{
			CardData cardData = this.Reward[i];
			CardSlot cardSlot = CardSlot.InitCardSlot(new CardSlotData(), 0.111f);
			this.RewardSlots.Add(cardSlot);
			cardSlot.transform.SetParent(base.transform, false);
			cardSlot.transform.position = this.ResultTrans.position + new Vector3(1.3f * (float)i, 0f, 0f);
			cardSlot.transform.rotation = this.ResultTrans.rotation;
			this.ResultText.gameObject.SetActive(true);
		}
		base.StartCoroutine(base.rotateTableCor());
		base.SetBackEnable();
	}

	public override void OnActGetAllButton()
	{
		base.OnActGetAllButton();
		base.StartCoroutine(this.ActGetAllAni(this.RewardSlots));
	}

	public override void OnActCancelButton()
	{
		base.SetAllButton(false);
		List<CardSlot> list = new List<CardSlot>();
		int num = 0;
		foreach (CardSlot cardSlot in GameController.getInstance().CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null) && cardSlot.ChildCard == null && !list.Contains(cardSlot))
			{
				num++;
			}
		}
		List<CardSlot> rewardSlots = this.RewardSlots;
		for (int j = rewardSlots.Count - 1; j >= 0; j--)
		{
			if (rewardSlots[j].ChildCard == null || rewardSlots[j].ChildCard.CardData == null || string.IsNullOrEmpty(rewardSlots[j].ChildCard.CardData.Name))
			{
				rewardSlots.Remove(rewardSlots[j]);
			}
		}
		if (num < rewardSlots.Count)
		{
			GameController.getInstance().CreateSubtitle("当前没有足够的空间装载卡牌！", 1f, 2f, 1f, 1f);
			return;
		}
		base.StartCoroutine(this.ActEndIEnumerator(rewardSlots, delegate
		{
			base.OnActCancelButton();
			this.Source.DeleteCard();
		}));
	}

	private IEnumerator ActEndIEnumerator(List<CardSlot> tempList, NormalAct.ActEndCallBack call)
	{
		yield return base.StartCoroutine(this.ActGetAllAni(tempList));
		call();
		yield break;
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

	public Transform InputTrans;

	public List<CardData> Reward;

	public Transform ResultTrans;

	public List<CardSlot> RewardSlots;

	public List<bool> Result;

	public TextMeshProUGUI ResultText;

	private delegate void ActEndCallBack();
}
