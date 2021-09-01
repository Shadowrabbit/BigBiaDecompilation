using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonTavernAct : GameAct
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
		if (GlobalController.Instance.GlobalData.SelectedMinions.Count > 0)
		{
			foreach (string modId in GlobalController.Instance.GlobalData.SelectedMinions)
			{
				CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(modId), true);
				if (cardData != null)
				{
					this.allCardDatas.Add(cardData);
				}
			}
		}
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
		foreach (CardData cardData2 in this.allCardDatas)
		{
			if ((cardData2.CardTags & 128UL) > 0UL && (cardData2.CardTags & 524288UL) <= 0UL)
			{
				for (int i = 0; i < this.cardNum[cardData2.Level]; i++)
				{
					switch (cardData2.Level)
					{
					case 1:
						this.allLevel1Minions.Add(cardData2);
						break;
					case 2:
						this.allLevel2Minions.Add(cardData2);
						break;
					case 3:
						this.allLevel3Minions.Add(cardData2);
						break;
					}
				}
			}
		}
		this.minionGoodsCount = 10;
		int seed = SYNCRandom.Seed;
		for (int j = 0; j < GameController.getInstance().GameData.PlayerCardData.Level + 4; j++)
		{
			int num = SYNCRandom.Range(1, 101);
			List<CardData> list = new List<CardData>();
			int num2 = (j - 1 < 0) ? 0 : (j - 1);
			int num3 = 5 * j;
			if (num <= num2 && this.allLevel3Minions.Count > 0)
			{
				list = this.allLevel3Minions;
			}
			else if (num <= num3 && this.allLevel2Minions.Count > 0)
			{
				list = this.allLevel2Minions;
			}
			else if (this.allLevel1Minions.Count > 0)
			{
				list = this.allLevel1Minions;
			}
			if (list.Count > 0)
			{
				CardData cardData3 = list[SYNCRandom.Range(0, list.Count)];
				this.OptionNames.Add(cardData3.ModID);
			}
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
				childCard.PriceText.text = (((float)childCard.CardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
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
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_38"), (float)Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate), 2f, 1f, 1f);
				yield break;
			}
			if (DungeonOperationMgr.Instance.DungeonHandler.CheckTargetCardCount(card.CardData, 3))
			{
				DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
				DungeonController.Instance.GameSettleData.GetMinionNum++;
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
				if (card != null)
				{
					card.PriceText.transform.parent.gameObject.SetActive(false);
				}
				UIController.LockLevel = UIController.UILevel.AreaTable;
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
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
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				yield break;
			}
			if (card != null)
			{
				card.PriceText.transform.parent.gameObject.SetActive(false);
			}
			DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)card.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
			DungeonController.Instance.GameSettleData.GetMinionNum++;
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
		UIController.LockLevel = UIController.UILevel.None;
		this.Source.CardData.DeleteCardData();
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
	}

	public override void OnRefreshButton()
	{
		if (GameController.getInstance().GameData.Money < 20)
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_39"), 1f, 2f, 1f, 1f);
			return;
		}
		EffectAudioManager.Instance.PlayEffectAudio(16, null);
		DungeonOperationMgr.Instance.ChangeMoney(-20);
		this.OptionNames.Clear();
		for (int i = 0; i < GameController.getInstance().GameData.PlayerCardData.Level + 4; i++)
		{
			int num = UnityEngine.Random.Range(1, 101);
			List<CardData> list = new List<CardData>();
			int num2 = (i - 1 < 0) ? 0 : (i - 1);
			int num3 = 5 * i;
			if (num <= num2 && this.allLevel3Minions.Count > 0)
			{
				list = this.allLevel3Minions;
			}
			else if (num <= num3 && this.allLevel2Minions.Count > 0)
			{
				list = this.allLevel2Minions;
			}
			else if (this.allLevel1Minions.Count > 0)
			{
				list = this.allLevel1Minions;
			}
			if (list.Count > 0)
			{
				CardData cardData = list[UnityEngine.Random.Range(0, list.Count)];
				this.OptionNames.Add(cardData.ModID);
			}
		}
		for (int j = 0; j < GameController.getInstance().GameData.PlayerCardData.Level + 4; j++)
		{
			if (this.OptionSlots[j].CardSlotData.ChildCardData != null)
			{
				if (this.OptionSlots[j].CardSlotData.ChildCardData.CardGameObject != null)
				{
					this.OptionSlots[j].CardSlotData.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(false);
				}
				this.OptionSlots[j].CardSlotData.ChildCardData.DeleteCardData();
			}
			CardData cardData2 = Card.InitCardDataByID(this.OptionNames[j]);
			cardData2.PutInSlotData(this.OptionSlots[j].CardSlotData, true);
			cardData2.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
			cardData2.CardGameObject.PriceText.text = (((float)cardData2.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
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

	private int minionGoodsCount;

	private List<CardData> allCardDatas = new List<CardData>();

	private List<CardData> allMinions;

	private List<CardData> allLevel1Minions;

	private List<CardData> allLevel2Minions;

	private List<CardData> allLevel3Minions;

	private int[] cardNum;
}
