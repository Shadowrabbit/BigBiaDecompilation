using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonShopAct : GameAct
{
	private void Start()
	{
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<RefreshButton>().GameAct = this;
		this.RefreshButton = base.GetComponentInChildren<RefreshButton>();
		this.m_RefreshDefaultPrice = (int)(20f * this.Discount);
		this.RefreshPriceText.text = (this.m_RefreshDefaultPrice.ToString() ?? "");
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
		if (this.allMinions == null)
		{
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
				if (cardData.HasTag(TagMap.道具) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && cardData.Rare <= GameController.ins.GameData.level + 1 && (GlobalController.Instance.AdvanceDataController.GetChouWaZi() || !cardData.ModID.Equals("臭袜子")) && (!this.Source.CardData.HasTag(TagMap.奇遇) || cardData.Rare <= this.Source.CardData.Rare))
				{
					this.allMinions.Add(cardData);
				}
			}
			this.minionGoodsCount = 10;
			if (GameController.ins.GameData.CurrentAreaId.Equals("地下城营地") && GameController.ins.GameData.level < 4)
			{
				this.OptionNames.Add("火把");
				for (int i = 1; i < GameController.getInstance().GameData.PlayerCardData.Level + 8; i++)
				{
					CardData cardData2 = this.allMinions[SYNCRandom.Range(0, this.allMinions.Count)];
					this.OptionNames.Add(cardData2.ModID);
				}
			}
			else
			{
				for (int j = 0; j < GameController.getInstance().GameData.PlayerCardData.Level + 7; j++)
				{
					CardData cardData3 = this.allMinions[SYNCRandom.Range(0, this.allMinions.Count)];
					this.OptionNames.Add(cardData3.ModID);
				}
			}
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData2 = new CardSlotData();
		cardSlotData2.SlotType = CardSlotData.Type.Freeze;
		cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), this.OptionNames.Count, true, this.OptionNames, this.OptionSlots, cardSlotData2);
		foreach (CardSlot cardSlot2 in this.OptionSlots)
		{
			Card childCard = cardSlot2.ChildCard;
			if (!(childCard == null) && childCard.CardData != null)
			{
				if (childCard.CardData.ModID != "火把")
				{
					childCard.CardData.Price = (int)((float)(childCard.CardData.Rare * 100) * this.Discount);
					if (childCard.CardData.HasTag(TagMap.药水) || childCard.CardData.HasTag(TagMap.工具) || childCard.CardData.HasTag(TagMap.放置物))
					{
						childCard.CardData.Price = Mathf.RoundToInt((float)childCard.CardData.Price * 0.8f * this.Discount);
					}
				}
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
			if (card.CardData.ModID.Equals("火把"))
			{
				DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
				GameController.ins.GameData.TorchNum++;
				Vector3 position = GameController.getInstance().playerTableText.Money.transform.position + new Vector3(1f, 0f, 0f);
				string name = "Effect/HealMoney";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = position;
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
		if (GameController.getInstance().GameData.Money < this.m_RefreshDefaultPrice)
		{
			GameController.getInstance().CreateSubtitle(string.Format(LocalizationMgr.Instance.GetLocalizationWord("ZM_36"), this.m_RefreshDefaultPrice), 1f, 2f, 1f, 1f);
			return;
		}
		EffectAudioManager.Instance.PlayEffectAudio(16, null);
		DungeonOperationMgr.Instance.ChangeMoney(-this.m_RefreshDefaultPrice);
		this.m_RefreshDefaultPrice += 20;
		this.RefreshPriceText.text = (this.m_RefreshDefaultPrice.ToString() ?? "");
		this.allMinions.Clear();
		foreach (CardData cardData in this.allCardDatas)
		{
			if (cardData.HasTag(TagMap.道具) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && !this.AlllockedItemNames.Contains(cardData.ModID) && (!this.Source.CardData.HasTag(TagMap.奇遇) || cardData.Rare <= this.Source.CardData.Rare))
			{
				this.allMinions.Add(cardData);
			}
		}
		this.OptionNames.Clear();
		if (GameController.ins.GameData.CurrentAreaId.Equals("地下城营地") && GameController.ins.GameData.level < 4)
		{
			this.OptionNames.Add("火把");
			for (int i = 1; i < GameController.getInstance().GameData.PlayerCardData.Level + 8; i++)
			{
				CardData cardData2 = this.allMinions[UnityEngine.Random.Range(0, this.allMinions.Count)];
				this.OptionNames.Add(cardData2.ModID);
			}
			for (int j = 0; j < GameController.getInstance().GameData.PlayerCardData.Level + 8; j++)
			{
				if (this.OptionSlots[j].CardSlotData.ChildCardData != null)
				{
					if (this.OptionSlots[j].CardSlotData.ChildCardData.CardGameObject != null)
					{
						this.OptionSlots[j].CardSlotData.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(false);
					}
					this.OptionSlots[j].CardSlotData.ChildCardData.DeleteCardData();
				}
				CardData cardData3 = Card.InitCardDataByID(this.OptionNames[j]);
				cardData3.PutInSlotData(this.OptionSlots[j].CardSlotData, true);
				if (cardData3.ModID != "火把")
				{
					cardData3.Price = (int)((float)(cardData3.Rare * 100) * this.Discount);
					if (cardData3.HasTag(TagMap.药水) || cardData3.HasTag(TagMap.工具) || cardData3.HasTag(TagMap.放置物))
					{
						cardData3.Price = Mathf.RoundToInt((float)cardData3.Price * 0.8f * this.Discount);
					}
				}
				cardData3.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
				cardData3.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardData3.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
			}
			return;
		}
		for (int k = 0; k < GameController.getInstance().GameData.PlayerCardData.Level + 7; k++)
		{
			CardData cardData4 = this.allMinions[SYNCRandom.Range(0, this.allMinions.Count)];
			this.OptionNames.Add(cardData4.ModID);
		}
		for (int l = 0; l < GameController.getInstance().GameData.PlayerCardData.Level + 7; l++)
		{
			if (this.OptionSlots[l].CardSlotData.ChildCardData != null)
			{
				if (this.OptionSlots[l].CardSlotData.ChildCardData.CardGameObject != null)
				{
					this.OptionSlots[l].CardSlotData.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(false);
				}
				this.OptionSlots[l].CardSlotData.ChildCardData.DeleteCardData();
			}
			CardData cardData5 = Card.InitCardDataByID(this.OptionNames[l]);
			cardData5.PutInSlotData(this.OptionSlots[l].CardSlotData, true);
			if (cardData5.ModID != "火把")
			{
				cardData5.Price = (int)((float)(cardData5.Rare * 100) * this.Discount);
				if (cardData5.HasTag(TagMap.药水) || cardData5.HasTag(TagMap.工具) || cardData5.HasTag(TagMap.放置物))
				{
					cardData5.Price = Mathf.RoundToInt((float)cardData5.Price * 0.8f * this.Discount);
				}
			}
			cardData5.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
			cardData5.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardData5.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
		}
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

	public Transform SellSlotTrans;

	public float Discount = 1f;

	private int minionGoodsCount;

	private List<CardData> allCardDatas;

	private List<string> AlllockedItemNames;

	private List<CardData> allMinions;

	private int[] cardNum;

	private int m_RefreshDefaultPrice = 20;

	public TMP_Text RefreshPriceText;
}
