using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RuneAct : GameAct
{
	private void Start()
	{
		this.Init();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		this.allCardDatas = GameController.getInstance().CardDataModMap.Cards;
		this.AlllockedItemNames = GlobalController.Instance.GlobalData.LockedItemsModID;
		this.allRune = new List<CardData>();
		foreach (CardData cardData in this.allCardDatas)
		{
			if (cardData.HasTag(TagMap.符文) && !this.AlllockedItemNames.Contains(cardData.ModID))
			{
				this.allRune.Add(cardData);
			}
		}
		this.minionGoodsCount = 10;
		for (int i = 0; i < 3; i++)
		{
			CardData cardData2 = this.allRune[UnityEngine.Random.Range(0, this.allRune.Count)];
			if (this.OptionNames.Contains(cardData2.ModID))
			{
				i--;
			}
			else
			{
				this.OptionNames.Add(cardData2.ModID);
			}
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.Freeze;
		cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(2f, 0f, 0f), 3, true, this.OptionNames, this.OptionSlots, cardSlotData);
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
			CardSlotData cardSlotData2 = null;
			foreach (CardSlotData cardSlotData3 in GameController.getInstance().PlayerSlotSets)
			{
				if (cardSlotData3 != null && (cardSlotData3.TagWhiteList == 0UL || (cardSlotData3.TagWhiteList & 16384UL) != 0UL) && cardSlotData3.ChildCardData == null && cardSlotData3.Color == (CardSlotData.LineColor)card.CardData.CardLogics[0].Color)
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
			yield return base.StartCoroutine(card.JumpToSlot(cardSlotData2.CardSlotGameObject, 0.3f, true));
			yield return DungeonOperationMgr.Instance.DungeonHandler.CheckTargetCount(card.CardData, 3);
			UIController.LockLevel = UIController.UILevel.AreaTable;
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
		if (this.Source == null)
		{
			return;
		}
		if (this.Source.CardData == null)
		{
			return;
		}
		if (this.Source.CardData.ModID.Equals("符文之地"))
		{
			this.Source.CardData.DeleteCardData();
		}
		if (!PlayerPrefs.HasKey("FirstIn"))
		{
			UnityEngine.Object.Instantiate<GameObject>(ResourceManager.Instance.LoadResource("Newspaper/Demo1026/FirstIn"));
			PlayerPrefs.SetInt("FirstIn", 1);
		}
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

	private int minionGoodsCount;

	private List<CardData> allCardDatas;

	private List<string> AlllockedItemNames;

	private List<CardData> allRune;

	private int[] cardNum;
}
