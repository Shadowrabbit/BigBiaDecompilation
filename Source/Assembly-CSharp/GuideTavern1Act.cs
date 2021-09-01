using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTavern1Act : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<Altar>().transform.GetComponent<BoxCollider>().enabled = false;
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		this.allCardDatas = GameController.getInstance().CardDataModMap.Cards;
		this.allLevel1Minions = new List<CardData>();
		this.allLevel2Minions = new List<CardData>();
		this.allLevel3Minions = new List<CardData>();
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
			if ((cardData.CardTags & 128UL) > 0UL && (cardData.CardTags & 524288UL) <= 0UL && cardData.Rare == 1)
			{
				for (int i = 0; i < this.cardNum[cardData.Level]; i++)
				{
					switch (cardData.Level)
					{
					case 1:
						this.allLevel1Minions.Add(cardData);
						break;
					case 2:
						this.allLevel2Minions.Add(cardData);
						break;
					case 3:
						this.allLevel3Minions.Add(cardData);
						break;
					default:
						this.allLevel1Minions.Add(cardData);
						break;
					}
				}
			}
		}
		this.minionGoodsCount = 10;
		this.OptionNames.Add("无名之辈");
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData);
		foreach (CardSlot cardSlot in this.OptionSlots)
		{
			Card childCard = cardSlot.ChildCard;
			if (!(childCard == null))
			{
				CardData cardData2 = childCard.CardData;
			}
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null && raycastHit.collider.GetComponent<CardSlot>() != null && raycastHit.collider.GetComponent<CardSlot>().ChildCard != null && raycastHit.collider.GetComponent<CardSlot>())
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
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			if (DungeonOperationMgr.Instance.DungeonHandler.CheckTargetCardCount(card.CardData, 3))
			{
				switch (card.CardData.Level)
				{
				case 1:
					this.allLevel1Minions.Remove(card.CardData);
					break;
				case 2:
					this.allLevel2Minions.Remove(card.CardData);
					break;
				case 3:
					this.allLevel3Minions.Remove(card.CardData);
					break;
				}
				yield return DungeonOperationMgr.Instance.DungeonHandler.CheckTargetCount(card.CardData, 3);
				UIController.LockLevel = UIController.UILevel.AreaTable;
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"), 1f, 2f, 1f, 1f);
				yield break;
			}
			CardSlotData cardSlotData2 = null;
			foreach (CardSlotData cardSlotData3 in GameController.getInstance().PlayerSlotSets)
			{
				if (cardSlotData3 != null && (cardSlotData3.TagWhiteList == 0UL || (cardSlotData3.TagWhiteList & 128UL) != 0UL) && cardSlotData3.ChildCardData == null)
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
			switch (card.CardData.Level)
			{
			case 1:
				this.allLevel1Minions.Remove(card.CardData);
				break;
			case 2:
				this.allLevel2Minions.Remove(card.CardData);
				break;
			case 3:
				this.allLevel3Minions.Remove(card.CardData);
				break;
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
		this.OnActCancelButton();
		yield break;
	}

	public override void OnActCancelButton()
	{
		if (this.m_CardCount > 0)
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_46"), 1f, 2f, 1f, 1f);
			return;
		}
		base.OnActCancelButton();
		CardSlotData currentCardSlotData = this.Source.CardData.CurrentCardSlotData;
		this.Source.CardData.DeleteCardData();
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
		ResourceManager.Instance.LoadResource("Newspaper/Tutorials/Step3");
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
			GameController.getInstance().CreateSubtitle("升级需要花费" + (GameController.getInstance().GameData.PlayerCardData.Level + 1).ToString() + "金币！金币不足！", 1f, 2f, 1f, 1f);
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

	private List<CardData> allLevel1Minions;

	private List<CardData> allLevel2Minions;

	private List<CardData> allLevel3Minions;

	private int[] cardNum;

	private int m_CardCount = 1;
}
