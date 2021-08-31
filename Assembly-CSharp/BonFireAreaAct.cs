using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BonFireAreaAct : GameAct
{
	private void Start()
	{
		base.GetComponentInChildren<CancelButton>().GameAct = this;
		this.CancelButton = base.GetComponentInChildren<CancelButton>();
		this.Init();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		CardSlotData cardSlotData = CardSlotData.CopyCardSlotData(new CardSlotData
		{
			SlotOwnerType = CardSlotData.OwnerType.Act,
			SlotType = CardSlotData.Type.Freeze
		});
		cardSlotData.TagWhiteList = 128UL;
		CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
		cardSlot.transform.SetParent(this.BonFireSlotTrans, false);
		cardSlot.transform.localPosition = Vector3.zero;
		cardSlot.transform.Rotate(this.BonFireSlotTrans.rotation.eulerAngles);
		Card.InitCardDataByID("帐篷").PutInSlotData(cardSlotData, true);
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
			UIController.HideBlackMaskCallBack <>9__1;
			GameController.getInstance().UIController.ShowBlackMask(delegate
			{
				UIController uicontroller = GameController.getInstance().UIController;
				UIController.HideBlackMaskCallBack call;
				if ((call = <>9__1) == null)
				{
					call = (<>9__1 = delegate()
					{
						foreach (CardSlotData cardSlotData2 in GameController.getInstance().PlayerSlotSets)
						{
							if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
							{
								float num = (float)GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi();
								num = (float)this.Source.CardData.Rare * 0.2f + num * 0.1f;
								DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardSlotData2.ChildCardData, Mathf.CeilToInt((float)cardSlotData2.ChildCardData.MaxHP * num), card.CardData, false, 0, true, false));
								ParticlePoolManager.Instance.Spawn("Effect/HealHp", 3f).transform.position = cardSlotData2.CardSlotGameObject.transform.position;
							}
						}
						this.OnEnd();
					});
				}
				uicontroller.HideBlackMask(call, 0.5f);
			}, 0.5f);
		}
		yield break;
	}

	private void OnEnd()
	{
		UIController.LockLevel = UIController.UILevel.None;
		this.OnActCancelButton();
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		this.Source.CardData.DeleteCardData();
	}

	public Transform BonFireSlotTrans;
}
