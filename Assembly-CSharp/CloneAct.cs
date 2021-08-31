using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		GameController.ins.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		this.GiftNames = new List<Card>();
		foreach (CardData cardData in this.Gifts)
		{
			this.GiftNames.Add(Card.InitCard(CardData.CopyCardData(cardData, true)));
		}
		this.GiftSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.3f, 0f, 0f), this.GiftNames.Count, this.GiftNames, null, cardSlotData);
		foreach (CardSlot cardSlot in this.GiftSlots)
		{
			cardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null && raycastHit.collider.GetComponent<CardSlot>().ChildCard != null && raycastHit.collider.GetComponent<CardSlot>())
			{
				if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Act)
				{
					return;
				}
				GameController.getInstance().StartCoroutine(this.onCardClick(raycastHit.collider.GetComponent<CardSlot>().ChildCard));
			}
		}
	}

	public IEnumerator onCardClick(Card card)
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			yield break;
		}
		if (this.m_IsClicked)
		{
			yield break;
		}
		this.m_IsClicked = true;
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
			if (!GameController.ins.GameData.isInDungeon)
			{
				GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData();
			}
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(card.CardData);
			if (emptySlotDataByCardData == null)
			{
				this.m_IsClicked = false;
				yield break;
			}
			if (card != null)
			{
				card.PriceText.transform.parent.gameObject.SetActive(false);
			}
			yield return card.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true);
			this.m_IsClicked = false;
			using (List<CardSlot>.Enumerator enumerator = this.GiftSlots.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.CardSlotData.ChildCardData != null)
					{
						yield break;
					}
				}
			}
			this.OnActCancelButton();
		}
		else if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			CardSlotData.Type slotType = cardSlotData.SlotType;
		}
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
	}

	public List<CardData> Gifts;

	private List<Card> GiftNames;

	public List<CardSlot> GiftSlots;

	public Transform SlotsTrans;

	private bool m_IsClicked;
}
