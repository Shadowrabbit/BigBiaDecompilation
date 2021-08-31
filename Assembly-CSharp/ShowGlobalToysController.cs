using System;
using System.Collections.Generic;
using UnityEngine;

public class ShowGlobalToysController : MonoBehaviour
{
	private void Start()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.OnCardChangeSlot;
		this.m_Toys = new List<string>();
		this.m_Toys = GlobalController.Instance.GetGlobalToysModIDToBag();
		this.CreateSlotsOnTable();
	}

	private void CreateSlotsOnTable()
	{
		this.m_Slots = new List<CardSlot>();
		for (int i = 0; i < this.m_Rows; i++)
		{
			for (int j = 0; j < this.m_Columns; j++)
			{
				CardSlot cardSlot = CardSlot.InitCardSlot(CardSlotData.CopyCardSlotData(new CardSlotData
				{
					SlotOwnerType = CardSlotData.OwnerType.SecondaryAct,
					SlotType = CardSlotData.Type.Normal,
					TagWhiteList = 32UL,
					IconIndex = 10
				}), 0.111f);
				cardSlot.transform.SetParent(this.ShowPoint1, false);
				cardSlot.transform.localPosition = new Vector3((float)j, 0f, (float)(i * -1));
				cardSlot.transform.localScale = Vector3.one;
				this.m_Slots.Add(cardSlot);
			}
		}
		this.CreateCardsAndPutInSlots(0);
	}

	private void CreateCardsAndPutInSlots(int pageIndex)
	{
		int num = pageIndex * this.m_Rows * this.m_Columns;
		int num2 = num + ((this.m_Toys.Count - num > this.m_Rows * this.m_Columns) ? (this.m_Rows * this.m_Columns) : (this.m_Toys.Count - num));
		this.ClearCards();
		this.m_CurrentPageIndex = pageIndex;
		for (int i = num; i < num2; i++)
		{
			CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.m_Toys[i]), true).PutInSlotData(this.m_Slots[i - num].CardSlotData, true);
		}
	}

	private void ClearCards()
	{
		for (int i = this.m_Slots.Count - 1; i >= 0; i--)
		{
			if (this.m_Slots[i].CardSlotData.ChildCardData != null)
			{
				this.m_Slots[i].CardSlotData.ChildCardData.DeleteCardData();
			}
		}
	}

	public void NextPage()
	{
		if ((this.m_CurrentPageIndex + 1) * this.m_Rows * this.m_Columns >= this.m_Toys.Count)
		{
			GameController.getInstance().CreateSubtitle("当前已经是最后一页！", 1f, 2f, 1f, 1f);
			return;
		}
		this.CreateCardsAndPutInSlots(this.m_CurrentPageIndex + 1);
	}

	public void PrePage()
	{
		if ((this.m_CurrentPageIndex - 1) * this.m_Rows * this.m_Columns < 0)
		{
			GameController.getInstance().CreateSubtitle("当前已经是第一页！", 1f, 2f, 1f, 1f);
			return;
		}
		this.CreateCardsAndPutInSlots(this.m_CurrentPageIndex - 1);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null)
			{
				if (raycastHit.collider.gameObject == this.CloseBtn)
				{
					GameController.getInstance().UIController.HideToysTableOnMainTable();
				}
				if (raycastHit.collider.gameObject == this.NextBtn)
				{
					this.NextPage();
				}
				if (raycastHit.collider.gameObject == this.PreBtn)
				{
					this.PrePage();
				}
			}
		}
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.OnCardChangeSlot;
	}

	private void OnCardChangeSlot(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot != null && oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct && newCardSlot.CardSlotGameObject.transform.parent.parent != base.transform && oldCardSlot.CardSlotGameObject.transform.parent.parent == base.transform)
		{
			this.m_Toys.Remove(card.ModID);
			GlobalController.Instance.SetGlobalToysModIDToBag(this.m_Toys);
		}
		if (oldCardSlot != null && oldCardSlot.CardSlotGameObject.transform.parent.parent != base.transform && newCardSlot.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct && newCardSlot.CardSlotGameObject.transform.parent.parent == base.transform)
		{
			this.m_Toys.Add(card.ModID);
			GlobalController.Instance.SetGlobalToysModIDToBag(this.m_Toys);
		}
	}

	public Transform ShowPoint1;

	public GameObject NextBtn;

	public GameObject PreBtn;

	public GameObject CloseBtn;

	private int m_Columns = 19;

	private int m_Rows = 2;

	private int m_CurrentPageIndex;

	private List<string> m_Toys = new List<string>();

	private List<CardSlot> m_Slots = new List<CardSlot>();
}
