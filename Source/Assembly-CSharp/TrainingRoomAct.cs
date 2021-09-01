using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingRoomAct : GameAct
{
	private void Start()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.Init();
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		CardSlotData cardSlotData = CardSlotData.CopyCardSlotData(new CardSlotData
		{
			SlotOwnerType = CardSlotData.OwnerType.Act
		});
		cardSlotData.TagWhiteList = 128UL;
		CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
		cardSlot.transform.SetParent(this.BonFireSlotTrans, false);
		cardSlot.transform.localPosition = new Vector3(-2f, 0f, 0f);
		cardSlot.transform.Rotate(this.BonFireSlotTrans.rotation.eulerAngles);
		cardSlot.SetBorder(1);
		this.m_FirstSlot = cardSlotData;
		CardSlotData cardSlotData2 = CardSlotData.CopyCardSlotData(new CardSlotData
		{
			SlotOwnerType = CardSlotData.OwnerType.Act
		});
		cardSlotData2.TagWhiteList = 128UL;
		CardSlot cardSlot2 = CardSlot.InitCardSlot(cardSlotData2, 0.111f);
		cardSlot2.transform.SetParent(this.BonFireSlotTrans, false);
		cardSlot2.transform.localPosition = new Vector3(2f, 0f, 0f);
		cardSlot2.transform.Rotate(this.BonFireSlotTrans.rotation.eulerAngles);
		cardSlot2.SetBorder(1);
		this.m_SecondSlot = cardSlotData2;
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
					CardSlotData.OwnerType slotOwnerType = raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType;
					return;
				}
			}
		}
	}

	private void OnEnd()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
		UIController.LockLevel = UIController.UILevel.None;
		this.OnActCancelButton();
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		if (this.m_FirstSlot.ChildCardData != null)
		{
			this.m_FirstSlot.ChildCardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(this.m_FirstSlot.ChildCardData), true);
		}
		if (this.m_SecondSlot.ChildCardData != null)
		{
			this.m_SecondSlot.ChildCardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(this.m_SecondSlot.ChildCardData), true);
		}
		if (this.m_TrainCount > 0)
		{
			this.Source.CardData.DeleteCardData();
		}
	}

	public override void OnActOKButton()
	{
		base.OnActOKButton();
		if (this.m_FirstSlot.ChildCardData == null || this.m_SecondSlot.ChildCardData == null)
		{
			GameController.getInstance().CreateSubtitle("需要两名随从才可以合成！", 1f, 2f, 1f, 1f);
			return;
		}
		this.m_FirstSlot.ChildCardData.MergeBy(this.m_SecondSlot.ChildCardData, true, false);
		this.m_SecondSlot.ChildCardData.DeleteCardData();
		this.m_FirstSlot.ChildCardData.PutInSlotData(this.GetEmptySlotFromPlayerTable(this.m_FirstSlot.ChildCardData), true);
		this.m_TrainCount++;
		this.OnEnd();
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
		if (oldCardSlot == null || newCardSlot == null)
		{
			return;
		}
		if (oldCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			CardSlotData.OwnerType slotOwnerType = newCardSlot.SlotOwnerType;
		}
		if (newCardSlot.SlotOwnerType == CardSlotData.OwnerType.Player)
		{
			CardSlotData.OwnerType slotOwnerType2 = oldCardSlot.SlotOwnerType;
		}
	}

	private CardSlotData GetEmptySlotFromPlayerTable(CardData card)
	{
		if (GameController.getInstance().GameData.isInDungeon)
		{
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
			{
				if (i % (GameController.getInstance().PlayerSlotSets.Count / 3) < 9 && card.HasTag(TagMap.随从))
				{
					if (GameController.getInstance().PlayerSlotSets[i].ChildCardData == null && GameController.getInstance().PlayerSlotSets[i].TagWhiteList == 128UL)
					{
						return GameController.getInstance().PlayerSlotSets[i];
					}
				}
				else if (i % (GameController.getInstance().PlayerSlotSets.Count / 3) < 11 && i % (GameController.getInstance().PlayerSlotSets.Count / 3) >= 9 && card.HasTag(TagMap.道具) && GameController.getInstance().PlayerSlotSets[i].ChildCardData == null)
				{
					return GameController.getInstance().PlayerSlotSets[i];
				}
			}
		}
		else
		{
			for (int j = 0; j < GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData().Count; j++)
			{
				if (GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData()[j].ChildCardData == null)
				{
					return GlobalController.Instance.HomeDataController.GetPlayerTableCardSlotDatasToHomeData()[j];
				}
			}
		}
		return null;
	}

	public Transform BonFireSlotTrans;

	private CardSlotData m_FirstSlot;

	private CardSlotData m_SecondSlot;

	private int m_TrainCount;
}
