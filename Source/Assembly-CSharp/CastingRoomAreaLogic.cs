using System;
using UnityEngine;

public class CastingRoomAreaLogic : MonoBehaviour
{
	private void Start()
	{
		GameController.getInstance().GameData.isInDungeon = false;
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent += this.Transaction;
		this.InitSlot();
	}

	private void Transaction(CardSlotData oldCardSlot, CardSlotData newCardSlot, CardData card)
	{
	}

	private void OnDestroy()
	{
		GameController.getInstance().GameEventManager.OnCardDataChangeSlotEvent -= this.Transaction;
		GameController.getInstance().GameData.isInDungeon = true;
	}

	private void InitSlot()
	{
		this.csd = new CardSlotData();
		this.csd.SlotOwnerType = CardSlotData.OwnerType.Area;
		this.csd.SlotType = CardSlotData.Type.Freeze;
		CardSlotData data = CardSlotData.CopyCardSlotData(this.csd);
		CardSlot cardSlot = CardSlot.InitCardSlot(data, 0.111f);
		cardSlot.transform.SetParent(this.SlotTrans, false);
		cardSlot.transform.localPosition = Vector3.zero;
		cardSlot.transform.Rotate(this.SlotTrans.rotation.eulerAngles);
		this.csd = data;
		Card.InitCardDataByID("铸造").PutInSlotData(this.csd, true);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null)
			{
				if (GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>().IsUseDirectionSkill)
				{
					return;
				}
				if (raycastHit.collider.GetComponent<CardSlot>() && raycastHit.collider.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Area)
				{
					foreach (CardLogic cardLogic in raycastHit.collider.GetComponent<CardSlot>().ChildCard.CardData.CardLogics)
					{
						cardLogic.OnLeftClick(null);
					}
					return;
				}
			}
			if (raycastHit.collider != null && raycastHit.collider.gameObject == this.ExitBtn)
			{
				this.ExitCasting();
			}
		}
	}

	private void ExitCasting()
	{
		AreaData parentArea = GameController.getInstance().CurrentTable.GetComponent<OppositeTable>().areaData.ParentArea;
		GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
		GameController.getInstance().OnTableChange(parentArea, true);
	}

	private CardSlotData GetEmptySlotFromPlayerTable()
	{
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (i % (GameController.getInstance().PlayerSlotSets.Count / 3) < 9 && GameController.getInstance().PlayerSlotSets[i].ChildCardData == null && GameController.getInstance().PlayerSlotSets[i].TagWhiteList == 128UL)
			{
				return GameController.getInstance().PlayerSlotSets[i];
			}
		}
		return null;
	}

	public GameObject ExitBtn;

	public Transform SlotTrans;

	private CardSlotData csd;
}
