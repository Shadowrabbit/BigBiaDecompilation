using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
	public static ModelPoolManager PoolManager
	{
		get
		{
			return ModelPoolManager.Instance;
		}
	}

	public static CardSlot InitCardSlot(CardSlotData data, float DisplayPositionY = 0.111f)
	{
		DisplayModel displayModel = CardSlot.PoolManager.SpawnModel("DisplaySlot");
		CardSlot component = displayModel.GameObject.GetComponent<CardSlot>();
		component.SlotModel = displayModel;
		component.transform.position = new Vector3(data.DisplayPositionX, DisplayPositionY, data.DisplayPositionZ);
		component.CardSlotData = data;
		component.CardSlotData.SlotType = data.SlotType;
		component.transform.forward = (new Vector3[]
		{
			Vector3.forward,
			Vector3.right,
			Vector3.back,
			Vector3.left,
			Vector3.up
		})[(int)data.SlotForward];
		component.UpdateView();
		data.CardSlotGameObject = component;
		component.transform.localScale = new Vector3(data.SlotScale, data.SlotScale, data.SlotScale);
		switch (data.SlotType)
		{
		case CardSlotData.Type.UndisplayFreeze:
			component.GetComponent<BoxCollider>().enabled = false;
			break;
		}
		if (data.ChildCardData != null && !string.IsNullOrEmpty(data.ChildCardData.ModID))
		{
			Card.InitCard(data.ChildCardData).PutInSlot(component);
		}
		return component;
	}

	private void Awake()
	{
		if (this.ChildCard != null && this.ChildCard.CardData != null && this.CardSlotData != null)
		{
			this.ChildCard.CurrentCardSlot = this;
			this.ChildCard.CardData.CurrentCardSlotData = this.CardSlotData;
		}
		if (this.CardSlotData != null)
		{
			this.CardSlotData.CardSlotGameObject = this;
		}
	}

	private void Start()
	{
		this.UpdateView();
	}

	public void UpdateView()
	{
		if (this.Border != null)
		{
			this.Border.sprite = null;
		}
		if (this.Border != null)
		{
			this.Icon.sprite = this.IconSprite[this.CardSlotData.IconIndex];
		}
	}

	public void OnMouseDownHandeler()
	{
		if (UIController.LockLevel != UIController.UILevel.None)
		{
			return;
		}
		if (DungeonOperationMgr.Instance != null && DungeonOperationMgr.Instance.IsInBattle)
		{
			return;
		}
		if (GameController.ins.CurrentAct != null)
		{
			return;
		}
		if (GameController.ins.GameData.isInDungeon && this.CardSlotData.CanClick && DungeonOperationMgr.Instance != null && DungeonOperationMgr.Instance.CurrentPositionInMap != null && Input.GetMouseButtonDown(0))
		{
			if (this.ChildCard != null && this.ChildCard.CardData.ModID == "门")
			{
				DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.TryToOpenDoor(this.CardSlotData));
				return;
			}
			if (this.ChildCard != null && this.ChildCard.CardData.ModID == "宝箱")
			{
				DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.TryToOpenBox(this.CardSlotData));
				return;
			}
			DungeonOperationMgr.Instance.CurrentPositionInMap = this.CardSlotData;
			DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.ChessmanJumpAndShowSlot(true, true, null));
		}
	}

	public void SetBorder(int index)
	{
		if (index < 0)
		{
			this.Border.sprite = null;
			return;
		}
		this.Border.sprite = this.BorderSprite[index];
	}

	public void SetIcon(int index)
	{
		if (index < 0)
		{
			this.Icon.sprite = null;
			return;
		}
		this.Icon.sprite = this.IconSprite[index];
	}

	public void Terminate()
	{
		if (this.ChildCard != null)
		{
			this.ChildCard.Terminate();
		}
		this.CardSlotData.Terminate();
		this.DeleteSlot();
	}

	public void ClearSlot()
	{
		this.ChildCard = null;
	}

	public void RemoveCard()
	{
	}

	public void DeleteSlot()
	{
		CardSlot.PoolManager.UnSpawnModel(this.SlotModel);
		this.ResetData();
	}

	public void ResetData()
	{
		this.SlotModel = null;
		this.CardSlotData = null;
		this.ClearSlot();
	}

	public CardSlotData CardSlotData;

	public SpriteRenderer Icon;

	public SpriteRenderer Border;

	public List<Sprite> BorderSprite;

	public List<Sprite> IconSprite;

	public Card ChildCard;

	public DisplayModel SlotModel;

	public const string c_PrefabName = "DisplaySlot";
}
