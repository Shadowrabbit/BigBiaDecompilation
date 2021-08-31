using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Area : Item
{
	public void Init(AreaData data)
	{
		this.Init();
		this.AreaData = data;
		base.transform.position = new Vector3(data.DisplayPositionX, base.transform.position.y, data.DisplayPositionY);
	}

	private void Start()
	{
		CardSlotData cardSlotData = new CardSlotData();
		cardSlotData.SlotType = CardSlotData.Type.UndisplayFreeze;
		if (!string.IsNullOrEmpty(this.AreaData.Name) && this.AreaNameUI != null)
		{
			this.AreaNameUI.text = this.AreaData.Name;
		}
		this.AreaSlot = CardSlot.InitCardSlot(cardSlotData, 0.111f);
		this.AreaSlot.transform.SetParent(base.transform, false);
	}

	private void Update()
	{
	}

	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.AreaTable) != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		this.EnterArea();
	}

	private IEnumerator Move()
	{
		yield return GameAct.PutCardInSlotAni(GameController.getInstance().PlayerToy, this.AreaSlot, 0.8f);
		this.EnterArea();
		GameController.getInstance().PlayerToy.PutInSlot(GameController.getInstance().PlayerCardSlot);
		yield break;
	}

	public void EnterArea()
	{
		if (GameController.getInstance().GameData.CurrentAreaId.Equals("/World") && this.AreaData.ID.Remove(this.AreaData.ID.LastIndexOf('/')).Equals("/World"))
		{
			GameController.getInstance().OnMoveInTheWorld(GameController.getInstance().WorldMoveArea, this);
			return;
		}
		GameController.getInstance().OnTableChange(this.AreaData, true);
	}

	public AreaData AreaData;

	public CardSlot AreaSlot;

	public TextMeshProUGUI AreaNameUI;
}
