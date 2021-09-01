using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventBonFireAreaAct : GameAct
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
		CardSlot cardSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
		cardSlot.transform.SetParent(this.BonFireSlotTrans, false);
		cardSlot.transform.localPosition = Vector3.zero;
		cardSlot.transform.Rotate(this.BonFireSlotTrans.rotation.eulerAngles);
		Card.InitCardDataByID("火把").PutInSlotData(cardSlotData, true);
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
			if (card.CardData.ModID.Equals("事件篝火"))
			{
				card.CardData.DeleteCardData();
				UIController.HideBlackMaskCallBack <>9__1;
				GameController.getInstance().UIController.ShowBlackMask(delegate
				{
					UIController uicontroller = GameController.getInstance().UIController;
					UIController.HideBlackMaskCallBack call;
					if ((call = <>9__1) == null)
					{
						call = (<>9__1 = delegate()
						{
							float num = (float)GlobalController.Instance.AdvanceDataController.GetGouHuoDengJi();
							if (num != 0f)
							{
								if (num != 1f)
								{
									if (num != 2f)
									{
										if (num != 3f)
										{
										}
									}
								}
							}
							foreach (CardSlotData cardSlotData2 in GameController.getInstance().PlayerSlotSets)
							{
								if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
								{
									DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardSlotData2.ChildCardData, Mathf.CeilToInt((float)cardSlotData2.ChildCardData.MaxHP * 0.4f), card.CardData, false, 0, true, false));
									ParticlePoolManager.Instance.Spawn("Effect/HealHp", 3f).transform.position = cardSlotData2.CardSlotGameObject.transform.position;
								}
							}
						});
					}
					uicontroller.HideBlackMask(call, 0.5f);
				}, 0.5f);
			}
			else if (card.CardData.ModID.Equals("火把"))
			{
				GameController.getInstance().ShowLogicChanged(card.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_火把") + " +5", CardLogicColor.red);
				card.CardData.DeleteCardData();
				GameController.ins.GameData.TorchNum += 5;
				Vector3 position = GameController.getInstance().playerTableText.Money.transform.position + new Vector3(1f, 0f, 0f);
				string name = "Effect/HealMoney";
				ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = position;
			}
		}
		yield break;
	}

	public override void OnActCancelButton()
	{
		base.OnActCancelButton();
		this.OnEnd();
	}

	private void OnEnd()
	{
		UIController.LockLevel = UIController.UILevel.None;
		this.Source.CardData.DeleteCardData();
	}

	public Transform BonFireSlotTrans;
}
