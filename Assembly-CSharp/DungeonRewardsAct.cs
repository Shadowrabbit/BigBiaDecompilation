using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonRewardsAct : GameAct
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
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.食物) && !cardData.HasTag(TagMap.特殊))
			{
				CardData cardData2 = CardData.CopyCardData(cardData, true);
				switch (cardData2.Rare)
				{
				case 1:
					this.allRare1Items.Add(cardData2);
					this.allItems.Add(cardData2);
					break;
				case 2:
					this.allRare2Items.Add(cardData2);
					this.allItems.Add(cardData2);
					break;
				case 3:
					this.allRare3Items.Add(cardData2);
					this.allItems.Add(cardData2);
					break;
				case 4:
					this.allRare4Items.Add(cardData2);
					this.allItems.Add(cardData2);
					break;
				default:
					this.allRare1Items.Add(cardData2);
					this.allItems.Add(cardData2);
					break;
				}
			}
		}
		List<int> list = new List<int>();
		if (GameData.CurrentGameType == GameData.GameType.Normal)
		{
			if (this.allItems.Count > 3)
			{
				List<CardData> list2 = new List<CardData>();
				switch (DungeonController.Instance.BattleLevel)
				{
				case 0:
					list2 = this.allRare1Items;
					break;
				case 1:
					list2 = this.allRare2Items;
					break;
				case 2:
					list2 = this.allRare3Items;
					break;
				case 3:
					list2 = this.allRare4Items;
					break;
				}
				for (int i = 0; i < 3; i++)
				{
					int num = SYNCRandom.Range(0, list2.Count);
					while (list.Contains(num))
					{
						num = SYNCRandom.Range(0, list2.Count);
					}
					list.Add(num);
					this.OptionNames.Add(list2[num].ModID);
				}
			}
			else
			{
				for (int j = 0; j < this.allItems.Count; j++)
				{
					if (GlobalController.Instance.AdvanceDataController.GetChouWaZi() || !this.allItems[j].ModID.Equals("臭袜子"))
					{
						this.OptionNames.Add(this.allItems[j].ModID);
					}
				}
			}
			if (GameController.ins.GameData.Agreenment >= 11 && this.OptionNames.Count >= 3 && SYNCRandom.Range(0, 101) < 30)
			{
				this.OptionNames.RemoveAt(SYNCRandom.Range(0, this.OptionNames.Count));
				this.OptionNames.Add("破鞋");
			}
			this.OptionSlots = new List<CardSlot>();
			CardSlotData cardSlotData = new CardSlotData();
			cardSlotData.SlotType = CardSlotData.Type.Freeze;
			cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
			base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData);
		}
		if (GameData.CurrentGameType == GameData.GameType.Endless)
		{
			Card card = Card.InitCard(Card.InitCardDataByID("金币"));
			card.CardData.MaxCount = 99999;
			card.CardData.Count = Mathf.CeilToInt((Mathf.Pow(2f, (float)(DungeonController.Instance.BattleLevel + 1)) - 1f) * 50f);
			List<Card> list3 = new List<Card>();
			list3.Add(card);
			this.OptionSlots = new List<CardSlot>();
			CardSlotData cardSlotData2 = new CardSlotData();
			cardSlotData2.SlotType = CardSlotData.Type.Freeze;
			cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.Act;
			base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, list3, null, cardSlotData2);
		}
		GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_34"), 1f, 2f, 1f, 1f);
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
		if (this.isClicked)
		{
			yield break;
		}
		this.isClicked = true;
		CardSlotData cardSlotData = null;
		if (card != null && card.CardData != null && card.CardData.CurrentCardSlotData != null)
		{
			cardSlotData = card.CardData.CurrentCardSlotData;
		}
		if (cardSlotData != null && cardSlotData.SlotOwnerType == CardSlotData.OwnerType.Act)
		{
			if (card.CardData.ModID.Equals("火把"))
			{
				GameController.getInstance().ShowLogicChanged(card.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_火把") + " +" + (DungeonController.Instance.BattleLevel + 1).ToString(), CardLogicColor.white);
				card.CardData.DeleteCardData();
				GameController.ins.GameData.TorchNum += DungeonController.Instance.BattleLevel + 1;
				Vector3 position = GameController.getInstance().playerTableText.Money.transform.position + new Vector3(1f, 0f, 0f);
				string name = "Effect/HealMoney";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = position;
				UIController.LockLevel = UIController.UILevel.AreaTable;
				this.OnActCancelButton();
				yield break;
			}
			if (card.CardData.ModID.Equals("金币"))
			{
				GameController.getInstance().ShowLogicChanged(card.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_金币") + "+" + card.CardData.Count.ToString(), CardLogicColor.white);
				DungeonOperationMgr.Instance.ChangeMoney(card.CardData.Count);
				Vector3 position2 = GameController.getInstance().playerTableText.Money.transform.position;
				string name2 = "Effect/HealMoney";
				ParticlePoolManager.Instance.Spawn(name2, 3f).transform.position = position2;
				card.CardData.DeleteCardData();
				UIController.LockLevel = UIController.UILevel.AreaTable;
				this.OnActCancelButton();
				yield break;
			}
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				this.isClicked = false;
				yield break;
			}
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(card.CardData);
			if (emptySlotDataByCardData == null)
			{
				this.isClicked = false;
				yield break;
			}
			yield return base.StartCoroutine(card.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true));
			UIController.LockLevel = UIController.UILevel.AreaTable;
			this.OnActCancelButton();
		}
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		UIController.LockLevel = UIController.UILevel.None;
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
	}

	public override void OnRefreshButton()
	{
	}

	public override void OnUpgradeButton()
	{
	}

	public List<string> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	public Transform SellSlotTrans;

	private List<CardData> allRare1Items = new List<CardData>();

	private List<CardData> allRare2Items = new List<CardData>();

	private List<CardData> allRare3Items = new List<CardData>();

	private List<CardData> allRare4Items = new List<CardData>();

	private List<CardData> allItems = new List<CardData>();

	private bool isClicked;
}
