using System;
using UnityEngine;

public class PickAct : GameAct
{
	private void Start()
	{
		this.Init();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null)
			{
				if (raycastHit.collider.name.Contains("RedButton"))
				{
					UIController.LockLevel = UIController.UILevel.None;
					GameController.getInstance().StartCoroutine(GameController.getInstance().UnlockCardSlot(1));
					this.OnEnd();
					return;
				}
				if (raycastHit.collider.name.Contains("YellowButton"))
				{
					UIController.LockLevel = UIController.UILevel.None;
					GameController.getInstance().StartCoroutine(GameController.getInstance().UnlockCardSlot(2));
					this.OnEnd();
					return;
				}
				if (raycastHit.collider.name.Contains("BlueButton"))
				{
					UIController.LockLevel = UIController.UILevel.None;
					GameController.getInstance().StartCoroutine(GameController.getInstance().UnlockCardSlot(0));
					this.OnEnd();
				}
			}
		}
	}

	private void OnEnd()
	{
		UIController.LockLevel = UIController.UILevel.None;
		this.OnActCancelButton();
		CardSlotData currentCardSlotData = this.Source.CardData.CurrentCardSlotData;
		DungeonOperationMgr.Instance.SetLockOperation(false);
		this.Source.CardData.DeleteCardData();
		DungeonOperationMgr.Instance.FlipAllFlopableCards();
	}
}
