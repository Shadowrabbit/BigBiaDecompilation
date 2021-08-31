using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActionSequenceAct : GameAct
{
	private void Start()
	{
		base.GetComponentInChildren<OKButton>().GameAct = this;
		this.OKButton = base.GetComponentInChildren<OKButton>();
		this.Init();
		this.eventalOffset = new Vector3(0f, 6f, 0f);
		this.oppositeOffset = new Vector3(0f, 0f, 2.8f);
		this.during = 30;
		base.StartCoroutine(this.ActStartAni(this.eventalOffset, this.oppositeOffset, this.during));
		this.Slots = new List<CardSlot>();
		base.InitCardSlotOnActTable(this.ActionCardSlotTrans, this.SlotCount, this.Slots, null);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (raycastHit.collider != null && raycastHit.collider.GetComponent<CardSlot>().ChildCard != null)
			{
				EventSystem.current.IsPointerOverGameObject();
				return;
			}
		}
	}

	private void OnEnd()
	{
		UIController.LockLevel = UIController.UILevel.None;
		this.OnActCancelButton();
		this.Source.CardData.DeleteCardData();
	}

	public override void OnActOKButton()
	{
		base.OnActOKButton();
		base.StartCoroutine(this.ActionSequenceCorotine());
	}

	private IEnumerator ActionSequenceCorotine()
	{
		using (List<CardSlot>.Enumerator enumerator = this.Slots.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CardSlotData.ChildCardData != null)
				{
					yield return new WaitForSeconds(2f);
				}
			}
		}
		List<CardSlot>.Enumerator enumerator = default(List<CardSlot>.Enumerator);
		this.OnEnd();
		yield break;
		yield break;
	}

	public Transform ActionCardSlotTrans;

	public int SlotCount = 5;

	private List<CardSlot> Slots;
}
