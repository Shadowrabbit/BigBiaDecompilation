using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CastingRoomAreaAct : GameAct
{
	private void Start()
	{
		if ((float)this.Source.CardData.Price * DungeonOperationMgr.Instance.MoneyRate > (float)GameController.getInstance().GameData.Money)
		{
			GameController.getInstance().CreateSubtitle("打造需要" + Mathf.CeilToInt((float)this.Source.CardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() + "金币！金币不足！", 1f, 2f, 1f, 1f);
			this.ActEnd();
			return;
		}
		DungeonOperationMgr.Instance.ChangeMoney(-Mathf.CeilToInt((float)this.Source.CardData.Price * DungeonOperationMgr.Instance.MoneyRate));
		this.Init();
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
		cardSlot.transform.SetParent(this.CastingSlotTrans, false);
		cardSlot.transform.localPosition = Vector3.zero;
		cardSlot.transform.Rotate(this.CastingSlotTrans.rotation.eulerAngles);
		Card.InitCardDataByID("铸造").PutInSlotData(cardSlotData, true);
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
		UIController.LockLevel = UIController.UILevel.None;
		this.OnActCancelButton();
	}

	public Transform CastingSlotTrans;
}
