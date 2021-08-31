using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfinityTavernAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		CardSlotData cardSlotData = CardSlotData.CopyCardSlotData(new CardSlotData
		{
			SlotOwnerType = CardSlotData.OwnerType.Area,
			SlotType = CardSlotData.Type.Freeze
		});
		cardSlotData.TagWhiteList = 128UL;
		CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
		cardSlot.transform.SetParent(this.SellSlotTrans, false);
		cardSlot.transform.localPosition = Vector3.zero;
		cardSlot.transform.Rotate(this.SellSlotTrans.rotation.eulerAngles);
		Card.InitCardDataByID("出售").PutInSlotData(cardSlotData, true);
		this.allCardDatas = GameController.getInstance().CardDataModMap.Cards;
		this.AlllockedItemNames = GlobalController.Instance.GlobalData.LockedItemsModID;
		this.allMinions = new List<CardData>();
		foreach (CardData cardData in this.allCardDatas)
		{
			if (cardData.HasTag(TagMap.随从) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.英雄) && !cardData.HasTag(TagMap.特殊) && cardData.Level == 1)
			{
				this.allMinions.Add(CardData.CopyCardData(cardData, true));
			}
		}
		this.minionGoodsCount = 10;
		for (int i = 0; i < this.Source.CardData.Rare + 2; i++)
		{
			CardData cardData2 = this.allMinions[SYNCRandom.Range(0, this.allMinions.Count)];
			this.allMinions.Remove(cardData2);
			cardData2._ATK = Mathf.CeilToInt((float)cardData2._ATK * (1f + 0.2f * (float)(this.Source.CardData.Rare - 1)));
			cardData2.MaxHP = (cardData2.HP = Mathf.CeilToInt((float)cardData2.MaxHP * (1f + 0.2f * (float)(this.Source.CardData.Rare - 1))));
			this.Minions.Add(Card.InitCard(cardData2));
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData2 = new CardSlotData();
		cardSlotData2.SlotType = CardSlotData.Type.Freeze;
		cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), this.Minions.Count, this.Minions, this.OptionSlots, cardSlotData2);
		foreach (CardSlot cardSlot2 in this.OptionSlots)
		{
			Card childCard = cardSlot2.ChildCard;
			if (!(childCard == null) && childCard.CardData != null)
			{
				childCard.CardData.Price = 300;
				childCard.PriceText.transform.parent.gameObject.SetActive(true);
				childCard.PriceText.text = (Mathf.CeilToInt((float)childCard.CardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
			}
		}
		GameController.getInstance().GameEventManager.EnterAllShopAndTavern();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null && raycastHit.collider.GetComponent<CardSlot>().ChildCard != null)
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					return;
				}
				if (GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>().IsUseDirectionSkill)
				{
					return;
				}
				if (raycastHit.collider.GetComponent<CardSlot>())
				{
					if (raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Area)
					{
						foreach (CardLogic cardLogic in raycastHit.collider.GetComponent<CardSlot>().ChildCard.CardData.CardLogics)
						{
							cardLogic.OnLeftClick(null);
						}
						return;
					}
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
			if ((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate > (float)GameController.getInstance().GameData.Money)
			{
				GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_35"), Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate)), 1f, 2f, 1f, 1f);
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				yield break;
			}
			DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(card.CardData);
			if (emptySlotDataByCardData == null)
			{
				yield break;
			}
			if (card != null)
			{
				card.PriceText.transform.parent.gameObject.SetActive(false);
			}
			yield return base.StartCoroutine(card.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true));
			UIController.LockLevel = UIController.UILevel.AreaTable;
		}
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		CardSlotData currentCardSlotData = this.Source.CardData.CurrentCardSlotData;
		if (!this.Source.CardData.HasTag(TagMap.随从))
		{
			this.Source.CardData.DeleteCardData();
		}
	}

	public List<string> OptionNames;

	public List<Card> Minions;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	public Transform SellSlotTrans;

	private int minionGoodsCount;

	private List<CardData> allCardDatas;

	private List<string> AlllockedItemNames;

	private List<CardData> allMinions;

	public TMP_Text RefreshPriceText;
}
