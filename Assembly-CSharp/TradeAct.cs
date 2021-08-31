using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradeAct : GameAct
{
	private void Start()
	{
		this.Init();
		this.MoneyCount.text = 0.ToString() + " ";
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<NextButton>().tradeAct = this;
		this.NextButton = base.GetComponentInChildren<NextButton>();
		base.GetComponentInChildren<PreButton>().tradeAct = this;
		this.PreButton = base.GetComponentInChildren<PreButton>();
		this.m_CardIds = this.Source.CardData.Belongings;
		this.m_Count = this.m_CardIds.Count;
		this.m_PageItemCount = this.m_Rows * this.m_Colums;
		this.m_PageCount = this.m_Count / this.m_PageItemCount + 1;
		base.StartCoroutine(this.LoadCardAndSlotOnTable("next"));
		for (int i = 0; i < 45; i++)
		{
			CardSlot.InitCardSlot(new CardSlotData
			{
				DisplayPositionX = this.PlayerSlotsTrans.localPosition.x + 1.3f * (float)(i % 15),
				DisplayPositionZ = this.PlayerSlotsTrans.localPosition.z - 1.3f * (float)(i / 15),
				SlotOwnerType = CardSlotData.OwnerType.SecondaryAct
			}, 0.12f).transform.SetParent(base.transform, false);
		}
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent += this.Transaction;
		this.eventalOffset = new Vector3(0f, 6f, 4.5f);
		this.oppositeOffset = new Vector3(0f, 0f, 11.2f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCardChangeSlotEvent -= this.Transaction;
	}

	private void Update()
	{
	}

	private void Transaction(CardSlot oldCardSlot, CardSlot newCardSlot, Card card)
	{
		int num = this.GetFinalPrice(card.CardData) * card.CardData.Count;
		if (oldCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act && newCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
		{
			this.m_CurrentItems.Remove(oldCardSlot);
			this.m_CardIds.Remove(card.CardData.Name);
			this.m_WillSellList.Add(card.CardData.Name);
			UnityEngine.Object.Destroy(oldCardSlot.gameObject, 0f);
		}
		else if (oldCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct && newCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			this.m_WillSellList.Remove(card.CardData.Name);
			this.curPrice -= num;
		}
		else if (oldCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act && newCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			this.m_CurrentItems.Remove(oldCardSlot);
			this.m_CardIds.Remove(card.CardData.Name);
			this.curPrice -= num;
			UnityEngine.Object.Destroy(oldCardSlot.gameObject, 0f);
		}
		else if (oldCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Player && newCardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
		{
			this.m_WillSellList.Add(card.CardData.Name);
			this.curPrice += num;
		}
		this.MoneyCount.text = (this.curPrice.ToString() ?? "");
		this.RefreshSlotState(0);
	}

	private void RefreshSlotState(int deltaMoney)
	{
		foreach (CardSlot cardSlot in this.m_CurrentItems)
		{
			if (cardSlot.ChildCard != null && cardSlot.ChildCard.CardData != null)
			{
				if (this.GetFinalPrice(cardSlot.ChildCard.CardData) > GameController.getInstance().GameData.Money + this.curPrice)
				{
					cardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
				}
				else
				{
					cardSlot.CardSlotData.SlotType = CardSlotData.Type.Normal;
				}
			}
			else
			{
				cardSlot.CardSlotData.SlotType = CardSlotData.Type.Normal;
			}
		}
	}

	private int GetFinalPrice(CardData goodCardData)
	{
		int num = goodCardData.Price;
		if (GameController.getInstance().GameData.AreaMap.ContainsKey(GameController.getInstance().GameData.CurrentAreaId) && GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].Attrs.ContainsKey("GoodsDic") && GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].Attrs["GoodsDic"] != null)
		{
			Dictionary<string, int> dictionary = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].Attrs["GoodsDic"] as Dictionary<string, int>;
			int num2 = 0;
			if (dictionary.ContainsKey(goodCardData.Name))
			{
				num2 = dictionary[goodCardData.Name];
			}
			num = goodCardData.Price - num2;
		}
		num = ((num > goodCardData.Price + goodCardData.PriceMaxFluctuation) ? (goodCardData.Price + goodCardData.PriceMaxFluctuation) : num);
		return (num < goodCardData.Price - goodCardData.PriceMaxFluctuation) ? (goodCardData.Price - goodCardData.PriceMaxFluctuation) : num;
	}

	public override void OnActCancelButton()
	{
		if (GameController.getInstance().GameData.Money + this.curPrice >= 0)
		{
			GameController.getInstance().GameData.Money += this.curPrice;
			GameController.getInstance().GameEventManager.MoneyChange(GameController.getInstance().GameData.Money);
			this.Source.CardData.Belongings = new List<string>();
			foreach (string item in this.m_CardIds)
			{
				this.Source.CardData.Belongings.Add(item);
			}
			foreach (string item2 in this.m_WillSellList)
			{
				this.Source.CardData.Belongings.Add(item2);
			}
			base.OnActCancelButton();
			return;
		}
		GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_1"), 1f, 2f, 1f, 1f);
	}

	public void OnNextButton()
	{
		this.m_Count = this.m_CardIds.Count;
		if (this.m_IsAnimate)
		{
			return;
		}
		if (this.m_CurPageNumb < this.m_PageCount)
		{
			if (this.m_Count > this.m_PageItemCount)
			{
				this.m_CurPageNumb++;
			}
			this.rotateTable("next");
		}
	}

	public void OnPreviousButton()
	{
		if (this.m_IsAnimate)
		{
			return;
		}
		if (this.m_CurPageNumb > 1)
		{
			this.m_CurPageNumb--;
			this.rotateTable("pre");
		}
	}

	private void rotateTable(string type)
	{
		base.StartCoroutine(this.LoadCardAndSlotOnTable(type));
		base.StartCoroutine(this.rotateTableCur());
	}

	private IEnumerator rotateTableCur()
	{
		this.m_IsAnimate = true;
		UIController.LockLevel = UIController.UILevel.All;
		int num;
		for (int i = 1; i <= 30; i = num + 1)
		{
			this.TurnTable.rotation = Quaternion.AngleAxis(Mathf.Lerp(0f, 180f, (float)i / 30f), Vector3.left);
			yield return new WaitForSeconds(0.01f);
			num = i;
		}
		UIController.LockLevel = UIController.UILevel.AreaTable;
		yield break;
	}

	private IEnumerator LoadCardAndSlotOnTable(string type)
	{
		this.m_Count = this.m_CardIds.Count;
		if (this.m_CurPageNumb == 1)
		{
			this.PreButton.gameObject.SetActive(false);
		}
		else
		{
			this.PreButton.gameObject.SetActive(true);
		}
		if (this.m_CurPageNumb == this.m_PageCount || this.m_Count <= this.m_PageItemCount)
		{
			this.NextButton.gameObject.SetActive(false);
		}
		else
		{
			this.NextButton.gameObject.SetActive(true);
		}
		for (int j = this.m_CurrentItems.Count - 1; j >= 0; j--)
		{
			UnityEngine.Object.Destroy(this.m_CurrentItems[j].ChildCard.CardData.CardGameObject.gameObject, 0f);
		}
		for (int k = this.m_CurrentSlots.Count - 1; k >= 0; k--)
		{
			UnityEngine.Object.Destroy(this.m_CurrentSlots[k].gameObject, 0f);
		}
		yield return new WaitForSeconds(1f);
		this.m_CurrentItems = new List<CardSlot>();
		this.m_CurrentSlots = new List<CardSlot>();
		int i = this.m_PageItemCount * this.m_CurPageNumb - this.m_PageItemCount;
		while (i < this.m_PageItemCount * this.m_CurPageNumb && i != this.m_Count)
		{
			CardSlot cardSlot = CardSlot.InitCardSlot(new CardSlotData
			{
				DisplayPositionX = this.SlotsTrans.localPosition.x + 1.3f * (float)(i % this.m_Colums),
				DisplayPositionZ = this.SlotsTrans.localPosition.z - 1.3f * (float)(i % this.m_PageItemCount / this.m_Colums),
				SlotOwnerType = CardSlotData.OwnerType.Act,
				SlotType = CardSlotData.Type.OnlyTake
			}, 0.111f);
			cardSlot.transform.SetParent(base.transform, false);
			this.m_CurrentItems.Add(cardSlot);
			this.m_CurrentSlots.Add(cardSlot);
			yield return new WaitForSeconds(0.01f);
			int num = i;
			i = num + 1;
		}
		this.m_IsAnimate = false;
		this.RefreshSlotState(0);
		yield break;
	}

	public Transform SlotsTrans;

	public Transform PlayerSlotsTrans;

	public TMP_Text MoneyCount;

	public Transform TurnTable;

	public NextButton NextButton;

	public PreButton PreButton;

	private List<string> m_CardIds = new List<string>();

	private List<string> m_WillSellList = new List<string>();

	private int m_Count;

	private int m_Colums = 15;

	private int m_Rows = 3;

	private int m_PageItemCount;

	private int m_CurPageNumb = 1;

	private int m_PageCount;

	private bool m_IsAnimate;

	private List<CardSlot> m_CurrentItems = new List<CardSlot>();

	private List<CardSlot> m_CurrentSlots = new List<CardSlot>();

	private int curPrice;
}
