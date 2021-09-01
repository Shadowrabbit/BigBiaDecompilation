using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideShop1Act : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<RefreshButton>().GameAct = this;
		this.RefreshButton = base.GetComponentInChildren<RefreshButton>();
		base.GetComponentInChildren<Altar>().transform.GetComponent<BoxCollider>().enabled = false;
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		this.allCardDatas = GameController.getInstance().CardDataModMap.Cards;
		this.allMinions = new List<CardData>();
		this.cardNum = new int[]
		{
			18,
			15,
			13,
			11,
			9,
			6
		};
		foreach (CardData cardData in this.allCardDatas)
		{
			if (cardData.HasTag(TagMap.道具))
			{
				this.allMinions.Add(cardData);
			}
		}
		this.minionGoodsCount = 10;
		this.OptionNames.Add("匕首");
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData);
		foreach (CardSlot cardSlot in this.OptionSlots)
		{
			Card childCard = cardSlot.ChildCard;
			if (!(childCard == null) && childCard.CardData != null)
			{
				childCard.PriceText.transform.parent.gameObject.SetActive(true);
				childCard.PriceText.text = (childCard.CardData.Price.ToString() ?? "");
			}
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null)
			{
				if (!raycastHit.collider.GetComponent<CardSlot>())
				{
					return;
				}
				if (raycastHit.collider.GetComponent<CardSlot>().ChildCard != null && raycastHit.collider.GetComponent<CardSlot>())
				{
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Act)
					{
						return;
					}
					GameController.getInstance().StartCoroutine(this.onCardClick(raycastHit.collider.GetComponent<CardSlot>().ChildCard));
				}
			}
		}
	}

	public IEnumerator onCardClick(Card card)
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			yield break;
		}
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			if (card.CardData.Price > GameController.getInstance().GameData.Money)
			{
				GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_35"), card.CardData.Price), 1f, 2f, 1f, 1f);
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"), 1f, 2f, 1f, 1f);
				yield break;
			}
			DungeonOperationMgr.Instance.ChangeMoney(-card.CardData.Price);
			CardSlotData cardSlotData2 = null;
			foreach (CardSlotData cardSlotData3 in GameController.getInstance().PlayerSlotSets)
			{
				if (cardSlotData3 != null && (cardSlotData3.TagWhiteList == 0UL || (cardSlotData3.TagWhiteList & 65536UL) != 0UL) && cardSlotData3.ChildCardData == null)
				{
					cardSlotData2 = cardSlotData3;
					break;
				}
			}
			if (cardSlotData2 == null)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"), 1f, 2f, 1f, 1f);
				yield break;
			}
			if (card != null)
			{
				card.PriceText.transform.parent.gameObject.SetActive(false);
			}
			yield return base.StartCoroutine(card.JumpToSlot(cardSlotData2.CardSlotGameObject, 0.3f, true));
			yield return DungeonOperationMgr.Instance.DungeonHandler.CheckTargetCount(card.CardData, 3);
			UIController.LockLevel = UIController.UILevel.AreaTable;
			this.m_CardCount--;
		}
		else if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			CardSlotData.Type slotType = cardSlotData.SlotType;
		}
		yield break;
	}

	public override void OnActCancelButton()
	{
		if (this.m_CardCount > 0)
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_45"), 1f, 2f, 1f, 1f);
			return;
		}
		base.OnActCancelButton();
		CardSlotData currentCardSlotData = this.Source.CardData.CurrentCardSlotData;
		this.Source.CardData.DeleteCardData();
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
	}

	public override void OnRefreshButton()
	{
	}

	public override void OnUpgradeButton()
	{
		if (GameController.getInstance().GameData.PlayerCardData.Level >= 5)
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
			return;
		}
		if (GameController.getInstance().GameData.Money < GameController.getInstance().GameData.PlayerCardData.Level + 1)
		{
			GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_37"), GameController.getInstance().GameData.PlayerCardData.Level + 1), 1f, 2f, 1f, 1f);
			return;
		}
		DungeonOperationMgr.Instance.ChangeMoney(-(GameController.getInstance().GameData.PlayerCardData.Level + 1));
		GameController.getInstance().GameData.PlayerCardData.Level++;
	}

	public List<string> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	private int minionGoodsCount;

	private List<CardData> allCardDatas;

	private List<CardData> allMinions;

	private int[] cardNum;

	private int m_CardCount = 1;
}
