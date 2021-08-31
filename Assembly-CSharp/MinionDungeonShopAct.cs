using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionDungeonShopAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<RefreshButton>().GameAct = this;
		this.RefreshButton = base.GetComponentInChildren<RefreshButton>();
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
		if (this.Source.CardData.Attrs.ContainsKey("Goods") && this.Source.CardData.GetAttr("Goods").Trim() != "")
		{
			this.GoodsNames = this.Source.CardData.GetAttr("Goods").Split(new char[]
			{
				','
			});
		}
		if (this.GoodsNames != null && this.GoodsNames.Length != 0)
		{
			foreach (string text in this.GoodsNames)
			{
				this.GoodsNamesList.Add(text);
				CardData item = Card.InitCardDataByID(text);
				this.allMinions.Add(item);
			}
		}
		this.minionGoodsCount = 10;
		for (int j = 0; j < this.allMinions.Count; j++)
		{
			CardData cardData = this.allMinions[j];
			this.OptionNames.Add(cardData.ModID);
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData2 = new CardSlotData();
		cardSlotData2.SlotType = CardSlotData.Type.Freeze;
		cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData2);
		foreach (CardSlot cardSlot2 in this.OptionSlots)
		{
			Card childCard = cardSlot2.ChildCard;
			if (!(childCard == null) && childCard.CardData != null)
			{
				childCard.PriceText.transform.parent.gameObject.SetActive(true);
				childCard.PriceText.text = (Mathf.CeilToInt((float)childCard.CardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
			}
		}
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
				GameController.getInstance().CreateSubtitle("购买需要花费" + Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() + "金币！金币不足！", 1f, 2f, 1f, 1f);
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle("你没有足够的卡槽", 1f, 2f, 1f, 1f);
				yield break;
			}
			DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
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
				GameController.getInstance().CreateSubtitle("你没有足够的卡槽", 1f, 2f, 1f, 1f);
				yield break;
			}
			if (card != null)
			{
				card.PriceText.transform.parent.gameObject.SetActive(false);
			}
			for (int i = 0; i < this.GoodsNamesList.Count; i++)
			{
				if (this.GoodsNamesList[i] == card.CardData.ModID)
				{
					this.GoodsNamesList.Remove(this.GoodsNamesList[i]);
					break;
				}
			}
			string text = "";
			if (this.GoodsNamesList.Count > 0)
			{
				for (int j = 0; j < this.GoodsNamesList.Count; j++)
				{
					text += this.GoodsNamesList[j];
					if (j != this.GoodsNamesList.Count - 1)
					{
						text += ",";
					}
				}
			}
			this.Source.CardData.Attrs["Goods"] = text;
			yield return base.StartCoroutine(card.JumpToSlot(cardSlotData2.CardSlotGameObject, 0.3f, true));
			yield return DungeonOperationMgr.Instance.DungeonHandler.CheckTargetCount(card.CardData, 3);
			UIController.LockLevel = UIController.UILevel.AreaTable;
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
		CardSlotData currentCardSlotData = this.Source.CardData.CurrentCardSlotData;
		if (!this.Source.CardData.HasTag(TagMap.随从))
		{
			this.Source.CardData.DeleteCardData();
		}
	}

	public override void OnRefreshButton()
	{
	}

	public override void OnUpgradeButton()
	{
		if (GameController.getInstance().GameData.PlayerCardData.Level >= 5)
		{
			GameController.getInstance().CreateSubtitle("已满级！", 1f, 2f, 1f, 1f);
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

	public Transform SellSlotTrans;

	private int minionGoodsCount;

	private List<CardData> allCardDatas;

	private List<string> AlllockedItemNames;

	private List<CardData> allMinions;

	private List<string> GoodsNamesList = new List<string>();

	private string[] GoodsNames;

	private int[] cardNum;
}
