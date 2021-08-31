using System;
using System.Collections.Generic;
using UnityEngine;

public class ShowToyController : MonoBehaviour
{
	private void Start()
	{
		this.CreateSlotOnToyTable();
	}

	private void CreateSlotOnToyTable()
	{
		this.m_CSDs = new List<CardSlotData>();
		for (int i = 0; i < 5; i++)
		{
			CardSlot cardSlot = CardSlot.InitCardSlot(CardSlotData.CopyCardSlotData(new CardSlotData
			{
				SlotOwnerType = CardSlotData.OwnerType.SecondaryAct,
				SlotType = CardSlotData.Type.OnlyTake,
				IconIndex = 10
			}), 0.111f);
			cardSlot.transform.SetParent(this.ShowPoint1, false);
			switch (i)
			{
			case 0:
				cardSlot.transform.localPosition = Vector3.zero;
				break;
			case 1:
				cardSlot.transform.localPosition = Vector3.zero + new Vector3(-1f, 0f, 0f);
				break;
			case 2:
				cardSlot.transform.localPosition = Vector3.zero + new Vector3(1f, 0f, 0f);
				break;
			case 3:
				cardSlot.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, 1f);
				break;
			case 4:
				cardSlot.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, -1f);
				break;
			}
			cardSlot.transform.localScale = Vector3.one;
			this.m_CSDs.Add(cardSlot.CardSlotData);
		}
	}

	public void PutToyInSlot(List<string> modIDs)
	{
		if (this.m_CSDs != null)
		{
			switch (modIDs.Count)
			{
			case 1:
				Card.InitCardDataByID(modIDs[0]).PutInSlotData(this.m_CSDs[0], true);
				return;
			case 2:
				Card.InitCardDataByID(modIDs[0]).PutInSlotData(this.m_CSDs[1], true);
				Card.InitCardDataByID(modIDs[1]).PutInSlotData(this.m_CSDs[2], true);
				return;
			case 3:
				Card.InitCardDataByID(modIDs[0]).PutInSlotData(this.m_CSDs[1], true);
				Card.InitCardDataByID(modIDs[1]).PutInSlotData(this.m_CSDs[0], true);
				Card.InitCardDataByID(modIDs[2]).PutInSlotData(this.m_CSDs[2], true);
				return;
			case 4:
				Card.InitCardDataByID(modIDs[0]).PutInSlotData(this.m_CSDs[1], true);
				Card.InitCardDataByID(modIDs[1]).PutInSlotData(this.m_CSDs[2], true);
				Card.InitCardDataByID(modIDs[2]).PutInSlotData(this.m_CSDs[3], true);
				Card.InitCardDataByID(modIDs[3]).PutInSlotData(this.m_CSDs[4], true);
				return;
			case 5:
				Card.InitCardDataByID(modIDs[0]).PutInSlotData(this.m_CSDs[0], true);
				Card.InitCardDataByID(modIDs[1]).PutInSlotData(this.m_CSDs[1], true);
				Card.InitCardDataByID(modIDs[2]).PutInSlotData(this.m_CSDs[2], true);
				Card.InitCardDataByID(modIDs[3]).PutInSlotData(this.m_CSDs[3], true);
				Card.InitCardDataByID(modIDs[4]).PutInSlotData(this.m_CSDs[4], true);
				break;
			default:
				return;
			}
		}
	}

	public void DeleteCardInCSD()
	{
		if (this.m_CSDs != null)
		{
			foreach (CardSlotData cardSlotData in this.m_CSDs)
			{
				if (cardSlotData.ChildCardData != null)
				{
					cardSlotData.ChildCardData.DeleteCardData();
				}
			}
		}
	}

	public bool CheckCSDNull()
	{
		using (List<CardSlotData>.Enumerator enumerator = this.m_CSDs.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ChildCardData != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null && raycastHit.collider.gameObject == this.CloseBtn)
			{
				GameController.getInstance().UIController.HideToyTableOnMainTable();
			}
		}
	}

	public Transform ShowPoint1;

	public GameObject CloseBtn;

	private List<CardSlotData> m_CSDs = new List<CardSlotData>();
}
