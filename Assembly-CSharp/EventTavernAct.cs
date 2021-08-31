using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTavernAct : GameAct
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
		List<CardSlotData> playerBattleArea = DungeonOperationMgr.Instance.PlayerBattleArea;
		List<CardData> list = new List<CardData>();
		foreach (CardSlotData cardSlotData in playerBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				list.Add(cardSlotData.ChildCardData);
			}
		}
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.CardTags == 128UL && !cardData.HasTag(TagMap.特殊))
			{
				CardData cardData2 = CardData.CopyCardData(cardData, true);
				bool flag = false;
				if (cardData2 != null)
				{
					if (list.Count > 0)
					{
						using (List<CardData>.Enumerator enumerator3 = list.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								if (enumerator3.Current.ModID == cardData2.ModID)
								{
									flag = true;
									break;
								}
							}
						}
					}
					if (!flag)
					{
						this.allCardDatas.Add(cardData2);
					}
				}
			}
		}
		List<int> list2 = new List<int>();
		if (this.allCardDatas.Count > 3)
		{
			for (int i = 0; i < 3; i++)
			{
				int num = SYNCRandom.Range(0, this.allCardDatas.Count);
				while (list2.Contains(num))
				{
					num = SYNCRandom.Range(0, this.allCardDatas.Count);
				}
				list2.Add(num);
				this.OptionNames.Add(this.allCardDatas[num].ModID);
			}
		}
		else
		{
			for (int j = 0; j < this.allCardDatas.Count; j++)
			{
				this.OptionNames.Add(this.allCardDatas[j].ModID);
			}
		}
		this.OptionSlots = new List<CardSlot>();
		CardSlotData cardSlotData2 = new CardSlotData();
		cardSlotData2.SlotType = CardSlotData.Type.Freeze;
		cardSlotData2.SlotOwnerType = CardSlotData.OwnerType.Act;
		base.InitCardSlotOnActTable(this.SlotsTrans, new Vector3(1.2f, 0f, 0f), 8, true, this.OptionNames, this.OptionSlots, cardSlotData2);
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
			if (GameController.getInstance().HasEmptCardSlotOnPlayerTable() < 1)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				this.isClicked = false;
				yield break;
			}
			CardSlotData emptySlotDataByCardData = GameController.ins.GetEmptySlotDataByCardData(card.CardData);
			if (emptySlotDataByCardData == null)
			{
				GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_2"), 1f, 2f, 1f, 1f);
				this.isClicked = false;
				yield break;
			}
			yield return base.StartCoroutine(card.JumpToSlot(emptySlotDataByCardData.CardSlotGameObject, 0.3f, true));
			DungeonController.Instance.GameSettleData.GetMinionNum++;
			JournalsConversationManager.PutJournals(new JournalsBean(string.Format(LocalizationMgr.Instance.GetLocalizationWord("SM_日志18"), LocalizationMgr.Instance.GetLocalizationWord(card.CardData.Name) + card.CardData.PersonName), null, null, null, null, null, null));
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

	public List<string> OptionNames;

	public List<CardSlot> OptionSlots;

	public Transform SlotsTrans;

	public Transform SellSlotTrans;

	private List<CardData> allCardDatas = new List<CardData>();

	private bool isClicked;
}
