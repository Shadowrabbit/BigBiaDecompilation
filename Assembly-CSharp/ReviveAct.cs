using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReviveAct : GameAct
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
		foreach (CardData cardData in GameController.ins.GameData.DeadMinionsList)
		{
			if (!cardData.HasTag(TagMap.英雄) && !cardData.HasTag(TagMap.衍生物))
			{
				cardData.HP = 1;
				cardData.IsAttacked = false;
				this.OptionNames.Add(Card.InitCard(cardData));
			}
		}
		if (this.OptionNames.Count == 0)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_51"), 1f, 2f, 1f, 1f);
			GameController.ins.GameData.Money += 30;
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), GameController.ins.GameData.DeadMinionsList.Count, this.OptionNames, null, cardSlotData);
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
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(card.CardData);
			if (emptySlotDataByCardData == null)
			{
				this.isClicked = false;
				yield break;
			}
			yield return base.StartCoroutine(card.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true));
			GameController.ins.GameData.DeadMinionsList.Remove(card.CardData);
			JournalsConversationManager.PutJournals(new JournalsBean
			{
				FormatString = LocalizationMgr.Instance.GetLocalizationWord("T_复活"),
				Origin = LocalizationMgr.Instance.GetLocalizationWord(card.CardData.Name) + "·" + card.CardData.PersonName
			});
			this.isClicked = false;
			UIController.LockLevel = UIController.UILevel.AreaTable;
			bool flag = true;
			using (List<CardSlot>.Enumerator enumerator = this.OptionSlots.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ChildCard != null)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				this.OnActCancelButton();
			}
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
	}

	public override void OnUpgradeButton()
	{
	}

	public List<Card> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	public Transform SellSlotTrans;

	private List<CardData> allCardDatas = new List<CardData>();

	private bool isClicked;
}
