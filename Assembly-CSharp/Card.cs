using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HighlightingSystem;
using HighlightingSystem.Demo;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : Item
{
	public CardData CardData
	{
		get
		{
			return this.m_CardData;
		}
	}

	public static GameController GameController
	{
		get
		{
			return GameController.getInstance();
		}
	}

	public static GameEventManager GameEventManager
	{
		get
		{
			return Card.GameController.GameEventManager;
		}
	}

	public Vector3 GetModelSize(Transform varTransform)
	{
		Vector3 position = varTransform.position;
		Quaternion rotation = varTransform.rotation;
		Vector3 localScale = varTransform.localScale;
		varTransform.position = Vector3.zero;
		varTransform.rotation = Quaternion.Euler(Vector3.zero);
		Renderer[] array = varTransform.GetComponentsInChildren<Renderer>();
		List<Renderer> list = new List<Renderer>();
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i].transform.GetComponent<ParticleSystem>() != null))
			{
				list.Add(array[i]);
			}
		}
		array = list.ToArray();
		Vector3 vector = Vector3.zero;
		foreach (Renderer renderer in array)
		{
			vector += renderer.bounds.center;
		}
		vector /= (float)array.Length;
		Bounds bounds = new Bounds(vector, Vector3.zero);
		Renderer[] array2 = array;
		for (int j = 0; j < array2.Length; j++)
		{
			Bounds bounds2 = array2[j].bounds;
			bounds.Encapsulate(bounds2);
		}
		varTransform.position = position;
		varTransform.rotation = rotation;
		varTransform.localScale = localScale;
		return bounds.size;
	}

	public static ModelPoolManager CardPool
	{
		get
		{
			return ModelPoolManager.Instance;
		}
	}

	public Dictionary<DungeonAffix, GameObject> affixesImg { get; private set; } = new Dictionary<DungeonAffix, GameObject>();

	public override void Init()
	{
		base.Init();
		this.CanBeSelected = true;
		this.IsHideUI = false;
		this.DMGPanel.SetActive(false);
		this.IsAttackedMask.SetActive(false);
		this.HaveLogic.SetActive(false);
		this.UnHappySpriteRenderer.gameObject.SetActive(false);
		this.RefreshCountText();
		if ((this.CardData.HasTag(TagMap.怪物) || this.CardData.HasTag(TagMap.随从) || this.CardData.HasTag(TagMap.衍生物) || this.CardData.HasTag(TagMap.装备)) && this.CardData.ModID != "血条")
		{
			this.LevelText.transform.parent.gameObject.SetActive(true);
			this.HPText.transform.parent.gameObject.SetActive(true);
		}
		else
		{
			this.HideUI();
		}
		this.ActionTipsPanel.SetActive(false);
		if (this.CardData.ActDatas != null && this.CardData.ActDatas.Count > 0)
		{
			for (int i = 0; i < this.CardData.ActDatas.Count; i++)
			{
				this.options.Add(new Dropdown.OptionData(this.CardData.ActDatas[i].Name));
			}
		}
		this.DizzyAnimationSprite.SetActive(false);
		this.CardData.CardGameObject = this;
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			cardLogic.OnGameObjectInit();
		}
		this.RefreshCardDisplay();
		if (this.DisplayGameObjectOnAreaTable != null)
		{
			this.DisplayGameObjectOnAreaTable.transform.SetParent(base.transform, false);
		}
		if (this.CardData.GetBoolAttr(Constant.CardAttributeName.IsHidden))
		{
			base.gameObject.SetActive(false);
		}
		this.canDrag = true;
		this.isDragging = false;
		this.isMouseDown = false;
		this.PriceText.transform.parent.gameObject.SetActive(false);
		this.ModelScale = this.DisplayGameObjectOnPlayerTable.transform.lossyScale;
		Vector3 modelSize = this.GetModelSize(base.transform);
		this.ModelSize = new Vector3(modelSize.x / this.ModelScale.x, modelSize.y / this.ModelScale.y, modelSize.z / this.ModelScale.z);
		if (this.CardData.ModID == "时空挖掘机" || this.CardData.ModID == "地下城生成器2" || this.CardData.ModID == "烤箱")
		{
			base.GetComponent<Highlighter>().forceRender = true;
		}
	}

	public void RefreshCardDisplay()
	{
		if (this.DisplayGameObjectOnPlayerTable != null)
		{
			Card.CardPool.UnSpawnModel(this.DisplayGameObjectOnPlayerTable);
		}
		if (GameController.ins.PNGResourceCache.ContainsKey(this.CardData.Model))
		{
			this.CardData.ItemType = ItemData.ItemTypes.material;
		}
		switch (this.CardData.ItemType)
		{
		case ItemData.ItemTypes.normal:
			if (!string.IsNullOrEmpty(this.CardData.Model))
			{
				this.DisplayGameObjectOnPlayerTable = Card.CardPool.SpawnModel(this.CardData.Model);
				if (this.DisplayGameObjectOnPlayerTable.GameObject.name == "Empty Model")
				{
					this.UnHappySpriteRenderer.gameObject.SetActive(true);
					this.UnHappySpriteRenderer.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = this.CardData.Name;
				}
				if (this.DisplayGameObjectOnPlayerTable != null && this.DisplayGameObjectOnPlayerTable.GameObject != null && this.DisplayGameObjectOnPlayerTable.GameObject.GetComponent<BoxCollider>() != null)
				{
					base.GetComponent<BoxCollider>().size = new Vector3(this.DisplayGameObjectOnPlayerTable.GameObject.GetComponent<BoxCollider>().size.x * this.DisplayGameObjectOnPlayerTable.GameObject.transform.localScale.x, this.DisplayGameObjectOnPlayerTable.GameObject.GetComponent<BoxCollider>().size.y * this.DisplayGameObjectOnPlayerTable.GameObject.transform.localScale.y, this.DisplayGameObjectOnPlayerTable.GameObject.GetComponent<BoxCollider>().size.z * this.DisplayGameObjectOnPlayerTable.GameObject.transform.localScale.z);
					base.GetComponent<BoxCollider>().center = this.DisplayGameObjectOnPlayerTable.GameObject.GetComponent<BoxCollider>().center;
					this.DisplayGameObjectOnPlayerTable.GameObject.GetComponent<BoxCollider>().enabled = false;
				}
				else
				{
					base.GetComponent<BoxCollider>().size = new Vector3(1f, 0.3f, 1f);
					base.GetComponent<BoxCollider>().center = Vector3.zero;
				}
				this.DisplayGameObjectOnPlayerTable.transform.position = Vector3.zero;
				if (this.CardData.CoveredWidth > 1)
				{
					this.DisplayGameObjectOnPlayerTable.transform.position += Vector3.right * 0.5f * ((float)this.CardData.CoveredWidth - 1f);
					base.GetComponent<BoxCollider>().size = new Vector3((float)this.CardData.CoveredWidth - 0.1f, base.GetComponent<BoxCollider>().size.y, (float)this.CardData.CoveredHeight - 0.1f);
					base.GetComponent<BoxCollider>().center = this.DisplayGameObjectOnPlayerTable.transform.position;
				}
				if (this.CardData.CoveredHeight > 1)
				{
					this.DisplayGameObjectOnPlayerTable.transform.position += Vector3.back * 0.5f * ((float)this.CardData.CoveredHeight - 1f);
					base.GetComponent<BoxCollider>().size = new Vector3((float)this.CardData.CoveredWidth - 0.1f, base.GetComponent<BoxCollider>().size.y, (float)this.CardData.CoveredHeight - 0.1f);
					base.GetComponent<BoxCollider>().center = this.DisplayGameObjectOnPlayerTable.transform.position;
				}
			}
			else
			{
				this.UnHappySpriteRenderer.gameObject.SetActive(true);
				this.UnHappySpriteRenderer.GetComponentInChildren<TextMeshProUGUI>().text = this.CardData.Name;
				this.DisplayGameObjectOnPlayerTable = Card.CardPool.SpawnModel("Card/Unknown");
			}
			if (this.CardData.AreaModel != null && this.CardData.AreaModel != "")
			{
				this.DisplayGameObjectOnAreaTable = Card.CardPool.SpawnModel(this.CardData.AreaModel);
				this.DisplayGameObjectOnAreaTable.SetActive(false);
				this.DisplayGameObjectOnAreaTable.transform.Rotate(Vector3.up, (float)(90 * this.CardData.rotateTime));
			}
			break;
		case ItemData.ItemTypes.material:
			this.DisplayGameObjectOnPlayerTable = ModelPoolManager.Instance.SpawnModel(this.CardData.Model);
			this.DisplayGameObjectOnPlayerTable.transform.SetParent(base.transform, false);
			this.DisplayGameObjectOnPlayerTable.transform.localScale = new Vector3(1f, 1f, 1f);
			break;
		}
		if (this.DisplayGameObjectOnPlayerTable != null)
		{
			this.DisplayGameObjectOnPlayerTable.transform.SetParent(base.transform, false);
			this.DisplayGameObjectOnPlayerTable.transform.localRotation = Quaternion.Euler(0f, (float)(this.CardData.rotateTime * 90), 0f);
			if (this.BottomGameObject != null)
			{
				Card.CardPool.UnSpawnModel(this.BottomGameObject);
			}
			if (this.CardData.Rare != 0)
			{
				this.DisplayGameObjectOnPlayerTable.transform.localPosition = new Vector3(0f, 0.0625f, 0f);
				string cardBottomName = this.CardData.GetCardBottomName();
				this.BottomGameObject = Card.CardPool.SpawnModel(cardBottomName);
				this.BottomGameObject.transform.SetParent(base.transform, false);
			}
		}
	}

	public static GameObject InitWithOutData(CardData CardData, bool withBottom = true)
	{
		DisplayModel displayModel = null;
		GameObject gameObject = new GameObject("GO");
		switch (CardData.ItemType)
		{
		case ItemData.ItemTypes.normal:
			if (!string.IsNullOrEmpty(CardData.Model))
			{
				displayModel = Card.CardPool.SpawnModel(CardData.Model);
			}
			else
			{
				displayModel = Card.CardPool.SpawnModel("Card/Unknown");
			}
			if (CardData.AreaModel != null && CardData.AreaModel != "")
			{
				DisplayModel displayModel2 = Card.CardPool.SpawnModel(CardData.AreaModel);
				displayModel2.SetActive(false);
				displayModel2.transform.Rotate(Vector3.up, (float)(90 * CardData.rotateTime));
			}
			break;
		}
		if (displayModel != null)
		{
			displayModel.transform.SetParent(gameObject.transform, false);
			displayModel.transform.localRotation = Quaternion.Euler(0f, (float)(CardData.rotateTime * 90), 0f);
			if (CardData.Rare != 0 && withBottom)
			{
				displayModel.transform.localPosition = new Vector3(0f, 0.0625f, 0f);
				string cardBottomName = CardData.GetCardBottomName();
				Card.CardPool.SpawnModel(cardBottomName).transform.SetParent(gameObject.transform, false);
			}
		}
		return gameObject;
	}

	private void Update()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f, 1 << LayerMask.NameToLayer("Card"));
			if (raycastHit.collider != null && raycastHit.collider.gameObject == base.gameObject)
			{
				this.mouseStartPos = Input.mousePosition;
				if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.PlayerSlot) > UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
				{
					return;
				}
				if (this.CardData.IsAttacked)
				{
					return;
				}
				this.OnRightClick();
				return;
			}
		}
		this.RefreshCountText();
		this.ShowUI();
		if (!this.isMouseDown)
		{
			this.isDragging = false;
			this.canDrag = true;
			return;
		}
		if (Input.GetMouseButtonUp(0) || !Application.isFocused)
		{
			this.isMouseDown = false;
			this.canDrag = true;
			this.animateName = "";
			if (!this.isDragging && Vector3.Distance(this.mouseStartPos, Input.mousePosition) <= 30f)
			{
				this.OnClick();
			}
			if (!this.isDragging)
			{
				return;
			}
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
			foreach (CardSlot cardSlot in base.GetComponentsInChildren<CardSlot>())
			{
				cardSlot.GetComponent<BoxCollider>().enabled = true;
				if (cardSlot.ChildCard != null)
				{
					cardSlot.ChildCard.GetComponent<BoxCollider>().enabled = true;
				}
			}
			Card.GameController.ChangeTimePause(false);
			this.isDragging = false;
			this.ActionTipsPanel.SetActive(false);
			if (this.HandleCardSacrifice())
			{
				return;
			}
			if (!this.canDrag || (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>() != null && (this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType == CardSlotData.Type.Freeze || this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType == CardSlotData.Type.OnlyTake || this.targetSlot.GetComponent<CardSlot>().CardSlotData.IsFreeze)) || !this.CheckSlotUseable())
			{
				this.CardData.PutInSlotData(this.startSlot.CardSlotData, true);
				this.PutInSlot(this.startSlot);
				return;
			}
			if (this.targetSlot != null && this.targetSlot.GetComponentInChildren<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			EffectAudioManager.Instance.PlayEffectAudio(26, null);
			base.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().ChildCard == null)
			{
				CardSlot component = this.targetSlot.GetComponent<CardSlot>();
				if (component.CardSlotData.SlotType != CardSlotData.Type.Grid || (this.CardData.CardTags & 32UL) <= 0UL || this.DisplayGameObjectOnAreaTable == null)
				{
					DisplayModel displayGameObjectOnAreaTable = this.DisplayGameObjectOnAreaTable;
				}
				if (this.CardData.Count > 1 && component.CardSlotData.OnlyAcceptOneCard)
				{
					CardData cardData = CardData.CopyCardData(this.CardData, true);
					cardData.Count = 1;
					cardData.PutInSlotData(component.CardSlotData, true);
					this.CardData.Count--;
					if (this.startSlot.ChildCard != this)
					{
						this.startSlot.ChildCard.CardData.Count += this.CardData.Count;
						this.startSlot.ChildCard.RefreshCountText();
						this.DeleteCard();
						return;
					}
					this.PutInSlot(this.startSlot);
					this.RefreshCountText();
					return;
				}
				else
				{
					this.CardData.PutInSlotData(component.CardSlotData, true);
					if (this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.Trash)
					{
						return;
					}
				}
			}
			else if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData != this.CardData && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.ModID != null && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.ModID.Equals(this.CardData.ModID) && !this.targetSlot.GetComponent<CardSlot>().CardSlotData.OnlyAcceptOneCard && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.Count + this.CardData.Count <= this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.MaxCount)
			{
				this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.Count += this.CardData.Count;
				this.targetSlot.GetComponent<CardSlot>().ChildCard.CountNumTextPanel.SetActive(true);
				this.targetSlot.GetComponent<CardSlot>().ChildCard.CountNumText.text = "X" + this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.Count.ToString();
				this.CardData.DeleteCardData();
			}
			else if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData != this.CardData)
			{
				if (this.CardData.HasTag(TagMap.模块) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.食物))
				{
					this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.MergeBy(this.CardData, true, false);
					if (this.CardData.Count <= 1)
					{
						this.CardData.DeleteCardData();
						return;
					}
					this.CardData.Count--;
					if (this.startSlot.ChildCard != this)
					{
						this.startSlot.ChildCard.CardData.Count += this.CardData.Count;
						this.startSlot.ChildCard.RefreshCountText();
						this.CardData.DeleteCardData();
						return;
					}
					this.PutInSlot(this.startSlot);
					return;
				}
				else if (this.CardData.HasTag(TagMap.道具) && !this.CardData.HasTag(TagMap.装备) && !this.CardData.HasTag(TagMap.模块) && !this.CardData.HasTag(TagMap.食物) && (this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.随从) || this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.怪物) || this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.衍生物)))
				{
					this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.MergeBy(this.CardData, true, false);
					if (this.CardData.Count <= 1)
					{
						this.CardData.DeleteCardData();
						return;
					}
					this.CardData.Count--;
					if (this.startSlot.ChildCard != this)
					{
						this.startSlot.ChildCard.CardData.Count += this.CardData.Count;
						this.startSlot.ChildCard.RefreshCountText();
						this.CardData.DeleteCardData();
						return;
					}
					this.PutInSlot(this.startSlot);
					return;
				}
				else if ((this.CardData.HasTag(TagMap.奇遇) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.奇遇) && this.CardData.ModID == this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.ModID) || (this.CardData.HasTag(TagMap.食物) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.随从)) || (this.CardData.HasTag(TagMap.食物) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.食物)) || (GameController.ins.GameData.FaithData.TanYu > 2 && this.CardData.HasTag(TagMap.随从) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.英雄) && this.startSlot.CardSlotData.SlotType != CardSlotData.Type.OnlyTake))
				{
					if ((this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.随从) && this.CardData.Rare < 5) || (this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.食物) && this.CardData.Rare < 4))
					{
						if (this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.Rare == this.CardData.Rare)
						{
							this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.MergeBy(this.CardData, true, false);
							this.CardData.DeleteCardData();
							return;
						}
						GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_24"), 1f, 2f, 1f, 1f);
					}
					else if (GameController.ins.GameData.FaithData.TanYu > 2 && this.CardData.HasTag(TagMap.随从) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.英雄))
					{
						if (this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.Rare == this.CardData.Rare)
						{
							this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.MergeBy(this.CardData, true, false);
							this.CardData.DeleteCardData();
							return;
						}
						GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_24"), 1f, 2f, 1f, 1f);
					}
					else if (this.CardData.HasTag(TagMap.奇遇) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.奇遇) && this.CardData.ModID == this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.ModID)
					{
						if (this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.Rare == this.CardData.Rare)
						{
							this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.MergeBy(this.CardData, true, false);
							this.CardData.DeleteCardData();
							return;
						}
						GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_24"), 1f, 2f, 1f, 1f);
					}
					else
					{
						GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_12"), 1f, 2f, 1f, 1f);
					}
					if (this.startSlot.ChildCard != this)
					{
						this.startSlot.ChildCard.CardData.Count += this.CardData.Count;
						this.startSlot.ChildCard.RefreshCountText();
						this.CardData.DeleteCardData();
						return;
					}
					this.PutInSlot(this.startSlot);
					return;
				}
				else if (this.CardData.HasTag(TagMap.随从) && this.targetSlot.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.随从))
				{
					Card childCard = this.targetSlot.GetComponent<CardSlot>().ChildCard;
					childCard.PutInSlot(this.startSlot);
					childCard.CardData.PutInSlotData(this.startSlot.CardSlotData, true);
					this.PutInSlot(this.targetSlot.GetComponent<CardSlot>());
					this.CardData.PutInSlotData(this.targetSlot.GetComponent<CardSlot>().CardSlotData, true);
				}
				else
				{
					if (this.startSlot.ChildCard != this)
					{
						this.startSlot.ChildCard.CardData.Count += this.CardData.Count;
						this.startSlot.ChildCard.RefreshCountText();
						this.CardData.DeleteCardData();
						return;
					}
					this.PutInSlot(this.startSlot);
					return;
				}
			}
			else
			{
				if (this.startSlot.ChildCard != this)
				{
					this.startSlot.ChildCard.CardData.Count += this.CardData.Count;
					this.startSlot.ChildCard.RefreshCountText();
					this.CardData.DeleteCardData();
					return;
				}
				this.PutInSlot(this.startSlot);
				return;
			}
			this.isDragging = false;
			return;
		}
		else
		{
			if (!this.isDragging && Vector3.Distance(this.mouseStartPos, Input.mousePosition) > 30f)
			{
				if (this.CardData.affixesDic.ContainsKey(DungeonAffix.paralysis) && this.CardData.affixesDic[DungeonAffix.paralysis] > 0)
				{
					return;
				}
				if (!this.canDrag)
				{
					return;
				}
				this.isDragging = true;
				Card.GameController.ChangeTimePause(true);
				GameUIController.Instance.CloseTips();
				foreach (CardSlot cardSlot2 in base.GetComponentsInChildren<CardSlot>())
				{
					cardSlot2.GetComponent<BoxCollider>().enabled = false;
					if (cardSlot2.ChildCard != null)
					{
						cardSlot2.ChildCard.GetComponent<BoxCollider>().enabled = false;
					}
				}
				if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl)) && this.CardData.Count > 1)
				{
					Card card = Card.InitCard(CardData.CopyCardData(this.CardData, true));
					if (Input.GetKey(KeyCode.LeftControl))
					{
						card.CardData.Count = 1;
					}
					else
					{
						card.CardData.Count = this.CardData.Count / 2;
					}
					this.CardData.Count -= card.CardData.Count;
					card.transform.position = CameraUtils.MyScreenPointToWorldPoint(Input.mousePosition, base.transform);
					card.startPos = CameraUtils.MyScreenPointToWorldPoint(Input.mousePosition, base.transform);
					card.startSlot = this.CurrentCardSlot;
					card.isDragging = true;
					card.isMouseDown = true;
					card.RefreshCountText();
					this.RefreshCountText();
					this.isDragging = false;
					this.isMouseDown = false;
					return;
				}
				this.startPos = base.transform.position;
				this.startSlot = this.CurrentCardSlot;
				base.transform.position += Vector3.up * 0.5f;
				this.lastPos = CameraUtils.MyScreenPointToWorldPoint(Input.mousePosition, base.transform);
				this.targetSlot = this.CurrentCardSlot.transform;
				if (this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType == CardSlotData.Type.Undisplay)
				{
					this.targetSlot.GetComponent<CardSlot>().Border.enabled = true;
				}
				EffectAudioManager.Instance.PlayEffectAudio(26, null);
			}
			if (!this.isDragging)
			{
				return;
			}
			this.ActionTipsPanel.SetActive(false);
			GameUIController.Instance.CloseTips();
			this.endPos = CameraUtils.MyScreenPointToWorldPoint(Input.mousePosition, base.transform);
			this.offset = (this.endPos - this.lastPos + 2f * this.offset) / 3f;
			this.offset.y = 0f;
			base.transform.position = new Vector3(this.endPos.x, base.transform.position.y, this.endPos.z);
			base.transform.rotation = Quaternion.AngleAxis((this.offset.magnitude * 300f > 30f) ? -30f : (-(this.offset.magnitude * 300f)), Vector3.Cross(this.offset, Vector3.up));
			this.lastPos = this.endPos;
			if (!this.CheckSlotUseable())
			{
				this.SetActionTipsPanel(true, "X", Color.red);
				Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.red;
				return;
			}
			RaycastHit raycastHit2;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit2, 100f, 1 << LayerMask.NameToLayer("Slot"));
			if (!(raycastHit2.collider != null))
			{
				if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
				{
					this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
				}
				this.targetSlot = null;
				return;
			}
			CardSlot component2 = raycastHit2.collider.GetComponent<CardSlot>();
			if (component2 != null)
			{
				base.transform.position = new Vector3(base.transform.position.x, component2.transform.position.y + 0.5f, base.transform.position.z);
				base.transform.localScale = component2.transform.localScale;
				this.OnCardDragOnASlot(component2);
				return;
			}
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.targetSlot = null;
			return;
		}
	}

	private void OnMouseOver()
	{
		if (EventSystem.current.IsPointerOverGameObject() || UIController.LockLevel == UIController.UILevel.All || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			if (GameController.ins.CurrentAct != null && GameController.ins.CurrentAct.GetType() == typeof(StartConversationAct))
			{
				GameUIController.Instance.OpenTips(this.CardData, base.transform.position);
			}
			return;
		}
		if ((double)this.HPText.transform.parent.localScale.x < 1.2)
		{
			this.HPText.transform.parent.localScale *= 1.03f;
		}
		if ((double)this.ATKText.transform.parent.localScale.x < 1.2)
		{
			this.ATKText.transform.parent.localScale *= 1.03f;
		}
		if (this.CurrentCardSlot != null && this.CurrentCardSlot.CardSlotData != null)
		{
			CardSlotData.Type slotType = this.CurrentCardSlot.CardSlotData.SlotType;
		}
		if (this.isDragging)
		{
			return;
		}
		if (!this.CardData.ModID.Equals("地下城卡背") && !this.CardData.ModID.Equals("地下城特殊提示卡背"))
		{
			GameUIController.Instance.OpenTips(this.CardData, base.transform.position);
		}
	}

	private void OnMouseExit()
	{
		if (this.CurrentCardSlot != null && this.CurrentCardSlot.CardSlotData != null)
		{
			CardSlotData.Type slotType = this.CurrentCardSlot.CardSlotData.SlotType;
		}
		GameUIController.Instance.CloseTips();
		this.HPText.transform.parent.localScale = Vector3.one;
		this.ATKText.transform.parent.localScale = Vector3.one;
	}

	public void OnMouseDownHandler()
	{
		this.dTime = 0f;
		this.mouseStartPos = Input.mousePosition;
		if (EventSystem.current.IsPointerOverGameObject() || (UIController.LockLevel & UIController.UILevel.PlayerSlot) > UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		if (this.CardData.IsAttacked)
		{
			return;
		}
		this.isMouseDown = true;
		if (!this.canDrag || (this.CurrentCardSlot != null && this.CurrentCardSlot.CardSlotData != null && (this.CurrentCardSlot.CardSlotData.SlotType == CardSlotData.Type.OnlyPut || this.CurrentCardSlot.CardSlotData.SlotType == CardSlotData.Type.Freeze || this.CurrentCardSlot.CardSlotData.SlotType == CardSlotData.Type.UndisplayFreeze || this.CurrentCardSlot.CardSlotData.IsFreeze)))
		{
			this.canDrag = false;
			return;
		}
		if (this.CardData.affixesDic.ContainsKey(DungeonAffix.paralysis) && this.CardData.affixesDic[DungeonAffix.paralysis] > 0)
		{
			this.canDrag = false;
		}
		if (GameController.ins.GameData.isInDungeon && this.CardData.CurrentCardSlotData.SlotOwnerType != CardSlotData.OwnerType.Player && !this.CardData.HasTag(TagMap.道具) && !this.CardData.HasTag(TagMap.法术) && !this.CardData.HasTag(TagMap.装备) && !this.CardData.HasTag(TagMap.符文) && !this.CardData.HasTag(TagMap.基本) && !this.CardData.HasTag(TagMap.随从))
		{
			this.canDrag = false;
			return;
		}
		this.isDragging = false;
	}

	public bool HandleCardSacrifice()
	{
		RaycastHit raycastHit;
		Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, 10f, 1 << LayerMask.NameToLayer("sacrifice"));
		if (raycastHit.collider == null)
		{
			return false;
		}
		Altar component = raycastHit.collider.GetComponent<Altar>();
		if (component == null)
		{
			return false;
		}
		GameController.getInstance().GameData.Money += Mathf.CeilToInt((float)this.CardData.Price / 3f);
		ParticlePoolManager.Instance.Spawn("Effect/Equip", 3f).transform.position = component.transform.position;
		this.CardData.DeleteCardData();
		return true;
	}

	private void OnCardDragOnASlot(CardSlot tar)
	{
		base.transform.SetParent(tar.transform);
		base.transform.localScale = Vector3.one;
		if ((this.CardData.HasTag(TagMap.玩具) || this.CardData.HasTag(TagMap.机器) || this.CardData.HasTag(TagMap.地点) || this.CardData.HasTag(TagMap.地下城入口)) && tar.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.SecondaryAct)
		{
			this.targetSlot = tar.transform;
			base.gameObject.layer = LayerMask.NameToLayer("Default");
			if (Physics.CheckBox(base.GetComponent<BoxCollider>().center + tar.transform.position, base.GetComponent<BoxCollider>().size / 2f - new Vector3(0.1f, -3f, 0.1f), Quaternion.Euler(0f, 0f, 0f), 1 << LayerMask.NameToLayer("Card")))
			{
				tar.GetComponent<CardSlot>().Border.enabled = false;
				this.ActionTipsPanel.SetActive(true);
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "重叠";
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
				Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.red;
				if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType == CardSlotData.Type.Undisplay)
				{
					this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
				}
				this.targetSlot = null;
				base.gameObject.layer = LayerMask.NameToLayer("Card");
				return;
			}
			base.gameObject.layer = LayerMask.NameToLayer("Card");
		}
		if ((this.CardData.CardTags & 32UL) > 0UL)
		{
			DisplayModel displayGameObjectOnAreaTable = this.DisplayGameObjectOnAreaTable;
		}
		if ((tar.CardSlotData.ChildCardData == null || tar.CardSlotData.ChildCardData == this.CardData || string.IsNullOrEmpty(tar.CardSlotData.ChildCardData.Name)) && (tar.CardSlotData.SlotType == CardSlotData.Type.Normal || tar.CardSlotData.SlotType == CardSlotData.Type.Undisplay || tar.CardSlotData.SlotType == CardSlotData.Type.Grid || tar.CardSlotData.SlotType == CardSlotData.Type.OnlyPut))
		{
			if (tar.CardSlotData.TagWhiteList == 0UL || (tar.CardSlotData.TagWhiteList & this.CardData.CardTags) != 0UL)
			{
				if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
				{
					this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
				}
				this.targetSlot = tar.transform;
				if (this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType == CardSlotData.Type.Undisplay)
				{
					this.targetSlot.GetComponent<CardSlot>().Border.enabled = true;
					this.animateName = "";
				}
				if (this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotOwnerType != CardSlotData.OwnerType.Player)
				{
					this.ActionTipsPanel.SetActive(true);
					this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "√";
					this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
					Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
					this.PlayAnimationForCardSlotChild(this.targetSlot, "OnCardDragIn");
				}
			}
			else
			{
				this.ActionTipsPanel.SetActive(true);
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "X";
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
				Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.red;
			}
		}
		else if (tar.CardSlotData.ChildCardData != null && tar.CardSlotData.ChildCardData != this.CardData && tar.CardSlotData.ChildCardData.ModID != null && this.CardData.ModID != null && tar.CardSlotData.ChildCardData.ModID.Equals(this.CardData.ModID) && !tar.CardSlotData.OnlyAcceptOneCard && tar.CardSlotData.ChildCardData.Count + this.CardData.Count <= tar.CardSlotData.ChildCardData.MaxCount)
		{
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.targetSlot = tar.transform;
			this.ActionTipsPanel.SetActive(true);
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "+";
		}
		else if (tar.CardSlotData.ChildCardData != null && tar.CardSlotData.ChildCardData != this.CardData && (tar.CardSlotData.ChildCardData.AcceptTags & this.CardData.CardTags) != 0UL)
		{
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.targetSlot = tar.transform;
			this.ActionTipsPanel.SetActive(true);
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "抵消";
		}
		else if (tar.CardSlotData.ChildCardData != null && tar.CardSlotData.ChildCardData != this.CardData && this.CardData.HasTag(TagMap.模块) && tar.CardSlotData.ChildCardData.HasTag(TagMap.食物))
		{
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().Border != null)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.targetSlot = tar.transform;
			this.ActionTipsPanel.SetActive(true);
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "使用";
		}
		else if (tar.CardSlotData.ChildCardData != null && tar.CardSlotData.ChildCardData != this.CardData && (tar.CardSlotData.ChildCardData.HasTag(TagMap.随从) || tar.CardSlotData.ChildCardData.HasTag(TagMap.怪物) || tar.CardSlotData.ChildCardData.HasTag(TagMap.衍生物)) && this.CardData.HasTag(TagMap.道具) && !this.CardData.HasTag(TagMap.装备) && !this.CardData.HasTag(TagMap.模块) && !this.CardData.HasTag(TagMap.食物))
		{
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().Border != null)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.targetSlot = tar.transform;
			this.ActionTipsPanel.SetActive(true);
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "使用";
		}
		else if (tar.CardSlotData.ChildCardData != null && tar.CardSlotData.ChildCardData != this.CardData && ((tar.CardSlotData.ChildCardData.HasTag(TagMap.奇遇) && this.CardData.HasTag(TagMap.奇遇)) || (tar.CardSlotData.ChildCardData.HasTag(TagMap.随从) && this.CardData.HasTag(TagMap.食物)) || (tar.CardSlotData.ChildCardData.HasTag(TagMap.食物) && this.CardData.HasTag(TagMap.食物)) || (GameController.ins.GameData.FaithData != null && GameController.ins.GameData.FaithData.TanYu > 2 && this.CardData.HasTag(TagMap.随从) && tar.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.英雄))))
		{
			this.targetSlot = tar.transform;
			if (tar.CardSlotData.ChildCardData.Rare == this.CardData.Rare && this.CardData.Rare < 5)
			{
				this.ActionTipsPanel.SetActive(true);
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "合成";
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			}
			else if (GameController.ins.GameData.FaithData.TanYu > 2 && this.CardData.HasTag(TagMap.随从) && tar.GetComponent<CardSlot>().ChildCard.CardData.HasTag(TagMap.英雄))
			{
				this.ActionTipsPanel.SetActive(true);
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "合成";
				this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			}
		}
		else if (tar.CardSlotData.ChildCardData != null && tar.CardSlotData.ChildCardData != this.CardData && ((tar.CardSlotData.ChildCardData.HasTag(TagMap.随从) && this.CardData.HasTag(TagMap.随从)) || (tar.CardSlotData.ChildCardData.HasTag(TagMap.装备) && this.CardData.HasTag(TagMap.随从)) || (tar.CardSlotData.ChildCardData.HasTag(TagMap.随从) && this.CardData.HasTag(TagMap.装备)) || (tar.CardSlotData.ChildCardData.HasTag(TagMap.装备) && this.CardData.HasTag(TagMap.装备))) && !tar.CardSlotData.ChildCardData.IsAttacked)
		{
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().Border != null)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.targetSlot = tar.transform;
			this.ActionTipsPanel.SetActive(true);
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.white;
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "交换";
		}
		else
		{
			if (this.targetSlot != null && this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotType != CardSlotData.Type.Normal)
			{
				this.targetSlot.GetComponent<CardSlot>().Border.enabled = false;
			}
			this.ActionTipsPanel.SetActive(true);
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = "X";
			this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
			Camera.main.GetComponent<HighlighterHover>().hoverColor = Color.red;
			this.targetSlot = null;
		}
		if (this.targetSlot != null)
		{
			this.targetSlot.GetComponent<CardSlot>();
			if (this.targetSlot.GetComponent<CardSlot>().CardSlotData.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
			{
				this.DisplayGameObjectOnPlayerTable.transform.localScale = new Vector3(1f / this.ModelSize.x, 0.1f, 1f / this.ModelSize.z);
			}
			else
			{
				this.DisplayGameObjectOnPlayerTable.transform.localScale = this.ModelScale;
			}
			base.transform.localScale = Vector3.one;
		}
	}

	public virtual void OnClick()
	{
		if (EventSystem.current.IsPointerOverGameObject() || UIController.LockLevel != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this) || (GameController.ins.CurrentAct != null && !DungeonOperationMgr.Instance.IsInBattle))
		{
			return;
		}
		this.options = new List<Dropdown.OptionData>();
		if (this.CardData != null && this.CardData.ActDatas != null && this.CardData.ActDatas.Count > 0)
		{
			for (int i = 0; i < this.CardData.ActDatas.Count; i++)
			{
				this.options.Add(new Dropdown.OptionData(this.CardData.ActDatas[i].Name));
			}
		}
		if (this.options.Count > 0 && (DungeonOperationMgr.Instance == null || !DungeonOperationMgr.Instance.IsInBattle) && this.options.Count == 1 && GameData.CurrentGameType == GameData.GameType.Normal)
		{
			this.StartAct(this.CardData.ActDatas[0].Name);
		}
		CardAnimationController componentInChildren = base.GetComponentInChildren<CardAnimationController>();
		if (componentInChildren != null)
		{
			componentInChildren.PlayAnimation_Open();
		}
		DungeonController instance = DungeonController.Instance;
		bool flag;
		if (instance == null)
		{
			flag = true;
		}
		else
		{
			Hero hero = instance.Hero;
			SkillState? skillState = (hero != null) ? new SkillState?(hero.skillState) : null;
			SkillState skillState2 = SkillState.None;
			flag = !(skillState.GetValueOrDefault() == skillState2 & skillState != null);
		}
		if (flag)
		{
			return;
		}
		Card.GameController.GameEventManager.OnClickCard(this);
		this.OnLeftClickedInDungeon();
		if (DungeonOperationMgr.Instance.IsInBattle && TagMapUtil.HasSkillTag(this.CardData))
		{
			foreach (CardLogic cardLogic in this.CardData.CardLogics)
			{
				cardLogic.OnLeftClick(null);
			}
			return;
		}
	}

	public void OnRightClick()
	{
		if (GameController.getInstance().UIController.CreateCardBtnController.IsShow)
		{
			return;
		}
		CardAnimationController componentInChildren = base.GetComponentInChildren<CardAnimationController>();
		if (componentInChildren != null)
		{
			componentInChildren.PlayAnimation_Close();
		}
		if (this.CardData.HasTag(TagMap.随从) && DungeonOperationMgr.Instance != null && DungeonOperationMgr.Instance.IsInBattle)
		{
			this.options = new List<Dropdown.OptionData>();
			List<CardLogic> list = new List<CardLogic>();
			foreach (CardLogic cardLogic in this.CardData.CardLogics)
			{
				if (cardLogic.GetType().GetMethod("OnUseSkill").DeclaringType == cardLogic.GetType())
				{
					Vector3Int needEnergyCount = cardLogic.NeedEnergyCount;
					if (!cardLogic.NeedEnergyCount.Equals(Vector3Int.zero))
					{
						this.options.Add(new Dropdown.OptionData(cardLogic.displayName));
						list.Add(cardLogic);
					}
				}
			}
			List<CardButton> list2 = new List<CardButton>();
			foreach (CardLogic cardLogic2 in list)
			{
				CardButton cardButton = default(CardButton);
				cardButton.logic = cardLogic2;
				cardButton.IsInteractable = true;
				if (cardLogic2.NeedEnergyCount.x > GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Blue) || cardLogic2.NeedEnergyCount.y > GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Red) || cardLogic2.NeedEnergyCount.z > GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Yellow))
				{
					cardButton.IsInteractable = false;
				}
				if (this.CardData.CurrentCardSlotData.Color != (CardSlotData.LineColor)cardButton.logic.Color && cardButton.logic.Color != CardLogicColor.white)
				{
					cardButton.IsInteractable = false;
				}
				list2.Add(cardButton);
			}
			if (list2.Count > 0)
			{
				GameController.getInstance().UIController.CreateCardBtnController.CreateCardButtons(this.CardData, list2);
			}
		}
	}

	public IEnumerator UseSkillPross(CardLogic cl)
	{
		if (!(cl is MinionLogic))
		{
			UIController.LockLevel = UIController.UILevel.All;
			Vector3Int needEnergyCount = cl.NeedEnergyCount;
			int num;
			if (cl.NeedEnergyCount.x > 0)
			{
				for (int i = 0; i < cl.NeedEnergyCount.x; i = num + 1)
				{
					yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Blue, base.transform);
					num = i;
				}
			}
			if (cl.NeedEnergyCount.y > 0)
			{
				for (int i = 0; i < cl.NeedEnergyCount.y; i = num + 1)
				{
					yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Red, base.transform);
					num = i;
				}
			}
			if (cl.NeedEnergyCount.z > 0)
			{
				for (int i = 0; i < cl.NeedEnergyCount.z; i = num + 1)
				{
					yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Yellow, base.transform);
					num = i;
				}
			}
			cl.ShowMe();
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
				{
					CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
					for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
					{
						CardLogic cardLogic = slotCardData.CardLogics[i2];
						if (slotCardData.DizzyLayer <= 0 && (cardLogic.Color >= CardLogicColor.white || cardLogic.Color == (CardLogicColor)cl.CardData.CurrentCardSlotData.Color) && cardLogic.GetType().GetMethod("OnCardBeforeUseSkill").DeclaringType == cardLogic.GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic.OnCardBeforeUseSkill(this.m_CardData, cl));
							yield return routine.coroutine;
							try
							{
								int result = routine.Result;
							}
							catch (Exception ex)
							{
								Debug.LogError(ex.Message);
								Debug.LogError(ex.StackTrace);
							}
							routine = null;
						}
						num = i2;
					}
					slotCardData = null;
				}
				num = i;
			}
			List<CardSlotData> csl = GameController.ins.GetCurrentAreaData().CardSlotDatas;
			foreach (CardSlotData cardSlotData in csl)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.DizzyLayer <= 0)
				{
					CardData slotCardData = cardSlotData.ChildCardData;
					for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
					{
						if (slotCardData.CardLogics[i].GetType().GetMethod("OnCardBeforeUseSkill").DeclaringType == slotCardData.CardLogics[i].GetType())
						{
							Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnCardBeforeUseSkill(this.m_CardData, cl));
							yield return routine.coroutine;
							try
							{
								int result2 = routine.Result;
							}
							catch (Exception ex2)
							{
								Debug.LogError(ex2.Message);
								Debug.LogError(ex2.StackTrace);
							}
							routine = null;
						}
						num = i;
					}
					slotCardData = null;
				}
			}
			List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
			if (cl.GetType().GetMethod("RemakeSkillEffect").DeclaringType == cl.GetType())
			{
				cl.RemakeSkillEffect();
			}
			yield return cl.ShowXuLiEffect(cl.SkillEffect, cl.SkillEffectHold);
			Coroutine<int> routine2 = GlobalController.Instance.StartCoroutine(cl.OnUseSkill());
			yield return routine2.coroutine;
			try
			{
				int result3 = routine2.Result;
			}
			catch (Exception ex3)
			{
				Debug.LogError(ex3.Message);
				Debug.LogError(ex3.StackTrace);
			}
			if (!DungeonOperationMgr.Instance.IsInBattle && this.CardData != null)
			{
				this.CardData.IsAttacked = false;
			}
			for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i = num + 1)
			{
				if (GameController.getInstance().PlayerSlotSets[i].ChildCardData != null)
				{
					GameController.getInstance().PlayerSlotSets[i].ChildCardData.CardGameObject.DMGPanel.SetActive(false);
					CardData slotCardData = GameController.getInstance().PlayerSlotSets[i].ChildCardData;
					if (slotCardData != null && slotCardData.CurrentCardSlotData != null)
					{
						for (int i2 = 0; i2 < slotCardData.CardLogics.Count; i2 = num + 1)
						{
							CardLogic cardLogic2 = slotCardData.CardLogics[i2];
							if (cl.CardData != null && cl.CardData.CurrentCardSlotData != null && slotCardData.DizzyLayer <= 0 && (cardLogic2.Color >= CardLogicColor.white || cardLogic2.Color == (CardLogicColor)cl.CardData.CurrentCardSlotData.Color) && cardLogic2.GetType().GetMethod("OnCardAfterUseSkill").DeclaringType == cardLogic2.GetType())
							{
								Coroutine<int> routine = GlobalController.Instance.StartCoroutine(cardLogic2.OnCardAfterUseSkill(this.m_CardData, cl));
								yield return routine.coroutine;
								try
								{
									int result4 = routine.Result;
								}
								catch (Exception ex4)
								{
									Debug.LogError(ex4.Message);
									Debug.LogError(ex4.StackTrace);
								}
								routine = null;
							}
							num = i2;
						}
						slotCardData = null;
					}
				}
				num = i;
			}
			using (List<CardSlotData>.Enumerator enumerator = csl.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cs = enumerator.Current;
					if (cs != null && cs.ChildCardData != null && cs.ChildCardData.DizzyLayer <= 0 && !string.IsNullOrEmpty(cs.ChildCardData.ModID))
					{
						cs.ChildCardData.CardGameObject.DMGPanel.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).onComplete = delegate()
						{
							cs.ChildCardData.CardGameObject.DMGPanel.SetActive(false);
						};
						CardData slotCardData = cs.ChildCardData;
						for (int i = slotCardData.CardLogics.Count - 1; i >= 0; i = num - 1)
						{
							if (slotCardData.CardLogics[i].GetType().GetMethod("OnCardAfterUseSkill").DeclaringType == slotCardData.CardLogics[i].GetType())
							{
								Coroutine<int> routine = GlobalController.Instance.StartCoroutine(slotCardData.CardLogics[i].OnCardAfterUseSkill(this.m_CardData, cl));
								yield return routine.coroutine;
								try
								{
									int result5 = routine.Result;
								}
								catch (Exception ex5)
								{
									Debug.LogError(ex5.Message);
									Debug.LogError(ex5.StackTrace);
								}
								routine = null;
							}
							num = i;
						}
						slotCardData = null;
					}
				}
			}
			enumerator = default(List<CardSlotData>.Enumerator);
			csl = null;
			routine2 = null;
		}
		UIController.LockLevel = UIController.UILevel.None;
		yield break;
		yield break;
	}

	public void SetActionTipsPanel(bool val, string text, Color color)
	{
		this.ActionTipsPanel.SetActive(val);
		if (!val)
		{
			return;
		}
		this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().text = text;
		this.ActionTipsPanel.GetComponentInChildren<TextMeshProUGUI>().color = color;
	}

	public bool CheckSlotUseable()
	{
		return !Physics.Raycast(base.transform.position, Vector3.down, 0.5f, 1 << LayerMask.NameToLayer("HomeToy"));
	}

	public void SwitchCardToModel()
	{
		this.DisplayGameObjectOnPlayerTable.transform.localScale = this.ModelScale;
	}

	public void SwitchModelToCard()
	{
		this.DisplayGameObjectOnPlayerTable.transform.localScale = new Vector3(1f / this.ModelSize.x, 0.1f, 1f / this.ModelSize.z);
	}

	public void SetCardData(CardData cardData)
	{
		this.m_CardData = cardData;
		cardData.CardGameObject = this;
	}

	private void OnLeftClickedInDungeon()
	{
		if (UIController.LockLevel != UIController.UILevel.None)
		{
			return;
		}
		if (this.CardData.ModID == "墙")
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_穿墙"), 1f, 2f, 1f, 1f);
			return;
		}
		if (DungeonOperationMgr.Instance.CanFlip(this.CardData))
		{
			if (DungeonOperationMgr.Instance.BattleArea != null)
			{
				bool flag = false;
				foreach (CardSlotData cardSlotData in DungeonOperationMgr.Instance.BattleArea)
				{
					if (cardSlotData != null && cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.怪物))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_25"), 1f, 2f, 1f, 1f);
					return;
				}
			}
			DungeonOperationMgr.Instance.Flip(this.CardData, true);
			return;
		}
		if (!this.CardData.IsFlipAnimDone)
		{
			return;
		}
		this.CardData.HasTag(TagMap.怪物);
	}

	public static Card InitCard(CardData cardData)
	{
		DisplayModel displayModel = Card.CardPool.SpawnCard();
		Card component = displayModel.GameObject.GetComponent<Card>();
		component.SetCardData(cardData);
		component.CardInstance = displayModel;
		component.Init();
		return component;
	}

	public static CardData InitCardDataByID(string modId)
	{
		return Card.OnCardCopyed(CardData.CopyCardData(Card.GameController.CardDataModMap.getCardDataByModID(modId), true));
	}

	public static CardData OnCardCopyed(CardData cardData)
	{
		Dictionary<string, object> attrs = cardData.Attrs;
		if ((cardData.CardTags & 512UL) > 0UL)
		{
			AreaData areaData = AreaData.CopyAreaData(Card.GameController.AreaDataModMap.getAreaDataByModID(cardData.ModID));
			foreach (AreaLogic areaLogic in areaData.Logics)
			{
				areaLogic.OnGameLoaded();
			}
			areaData.ID = Guid.NewGuid().ToString();
			Card.GameController.GameData.AreaMap.Add(areaData.ID, areaData);
			if (attrs.ContainsKey("AreaDataID"))
			{
				if (cardData.IsCopy)
				{
					attrs["AreaDataID"] = areaData.ID;
				}
			}
			else
			{
				attrs.Add("AreaDataID", areaData.ID);
			}
		}
		return cardData;
	}

	public bool AddToSlot(CardSlot cardSlot)
	{
		if (cardSlot.ChildCard != null && cardSlot.ChildCard.CardData.ModID == this.CardData.ModID && cardSlot.ChildCard.CardData.MaxCount >= cardSlot.ChildCard.CardData.Count + this.CardData.Count)
		{
			cardSlot.ChildCard.CardData.Count += this.CardData.Count;
			cardSlot.ChildCard.RefreshCountText();
			this.DeleteCard();
			return true;
		}
		return false;
	}

	public void RefreshCountText()
	{
		if (this.m_ShowCount == this.CardData.Count)
		{
			return;
		}
		if (this.CardData.Count > 1)
		{
			this.CountNumTextPanel.SetActive(true);
			this.CountNumText.text = "X" + this.CardData.Count.ToString();
		}
		else
		{
			this.CountNumTextPanel.SetActive(false);
		}
		this.m_ShowCount = this.CardData.Count;
	}

	public void PutInSlot(CardSlot cardSlot)
	{
		if (cardSlot == null)
		{
			return;
		}
		base.transform.SetParent(cardSlot.transform, false);
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.Euler(Vector3.zero);
		cardSlot.ChildCard = this;
		this.CurrentCardSlot = cardSlot;
		this.CardData.CurrentCardSlotData = cardSlot.CardSlotData;
		if (cardSlot.CardSlotData.CurrentAreaData != null && !string.IsNullOrEmpty(cardSlot.CardSlotData.CurrentAreaData.ID))
		{
			this.CardData.CurrentAreaID = cardSlot.CardSlotData.CurrentAreaData.ID;
		}
		if (this.CardData.HasTag(TagMap.机器))
		{
			if (cardSlot.CardSlotData.SlotOwnerType == CardSlotData.OwnerType.SecondaryAct)
			{
				this.DisplayGameObjectOnPlayerTable.transform.localScale = new Vector3(1f / this.ModelSize.x, 0.1f, 1f / this.ModelSize.z);
			}
			else
			{
				this.DisplayGameObjectOnPlayerTable.transform.localScale = this.ModelScale;
			}
			base.transform.localScale = cardSlot.transform.localScale;
		}
	}

	public void DeleteCard()
	{
		foreach (KeyValuePair<DungeonAffix, GameObject> keyValuePair in this.affixesImg)
		{
			UnityEngine.Object.Destroy(this.affixesImg[keyValuePair.Key]);
		}
		this.affixesImg = new Dictionary<DungeonAffix, GameObject>();
		Card.CardPool.UnSpawnCard(this.CardInstance);
		this.ResetData();
		GameUIController.Instance.CloseTips();
	}

	public void ResetData()
	{
		this.options.Clear();
		this.CardInstance = null;
		this.DisplayGameObjectOnPlayerTable = null;
		this.DisplayGameObjectOnAreaTable = null;
		this.BottomGameObject = null;
		if (this.CardData != null)
		{
			this.CardData.Terminate();
			this.m_CardData = null;
		}
		if (this.CurrentCardSlot != null)
		{
			this.CurrentCardSlot = null;
		}
	}

	public void MoveToArea(string id, float x, float z, float rot, bool withCardSlot, bool immediately)
	{
		this.CardData.MoveToArea(id, x, z, rot, withCardSlot);
		if (immediately)
		{
			this.DeleteCard();
		}
	}

	public void ShowUI()
	{
		if (this.IsHideUI)
		{
			return;
		}
		if (this.CardData.RemainTime > 0)
		{
			this.ClockText.transform.parent.gameObject.SetActive(true);
			this.ClockText.text = this.CardData.RemainTime.ToString();
		}
		else
		{
			this.ClockText.transform.parent.gameObject.SetActive(false);
		}
		if (this.CardData.IsAttacked || !this.CanBeSelected)
		{
			this.IsAttackedMask.SetActive(true);
		}
		else
		{
			this.IsAttackedMask.SetActive(false);
		}
		this.HpBar.transform.parent.gameObject.SetActive(false);
		if ((this.CardData.HasTag(TagMap.衍生物) || this.CardData.HasTag(TagMap.怪物) || this.CardData.HasTag(TagMap.随从) || this.CardData.HasTag(TagMap.装备)) && this.CardData.ModID != "血条")
		{
			this.CardData.GetHP();
			if (this.CardData.HP > this.CardData.MaxHP)
			{
				this.HPText.color = Color.green;
			}
			else if (this.CardData.HP < this.CardData.MaxHP)
			{
				this.HPText.color = Color.red;
			}
			else
			{
				this.HPText.color = Color.white;
			}
			this.HPText.text = this.CardData.HP.ToString();
			this.HPText.transform.parent.gameObject.SetActive(true);
			if (this.CardData.HP < this.CardData.MaxHP && this.CardData.HasTag(TagMap.随从))
			{
				this.HpBar.transform.parent.gameObject.SetActive(true);
				this.HpBar.fillAmount = (float)this.CardData.HP / (float)this.CardData.MaxHP;
			}
			else
			{
				this.HpBar.transform.parent.gameObject.SetActive(false);
			}
			int atk = this.CardData.ATK;
			if (this.CardData.wATK > 0)
			{
				this.ATKText.color = Color.green;
			}
			else if (this.CardData.wATK < 0)
			{
				this.ATKText.color = Color.red;
			}
			else
			{
				this.ATKText.color = Color.white;
			}
			if (this.CardData.AttackTimes > 1)
			{
				this.ATKText.text = atk.ToString() + "x" + this.CardData.AttackTimes.ToString();
			}
			else
			{
				this.ATKText.text = atk.ToString();
			}
			this.ATKText.transform.parent.gameObject.SetActive(true);
			if (this.CardData.MaxArmor > 0 || this.CardData.Armor > 0)
			{
				this.LevelText.transform.parent.gameObject.SetActive(true);
				int armor = this.CardData.Armor;
				this.LevelText.text = armor.ToString();
			}
			else
			{
				this.LevelText.transform.parent.gameObject.SetActive(false);
			}
			if (this.CardData.DizzyLayer > 0 && this.CardData.HasTag(TagMap.怪物))
			{
				if (!this.DizzyAnimationSprite.activeSelf)
				{
					this.DizzyAnimationSprite.SetActive(true);
				}
			}
			else
			{
				this.DizzyAnimationSprite.SetActive(false);
			}
			if (this.CardData.HasTag(TagMap.怪物) && this.CardData.CardLogics != null && this.CardData.CardLogics.Count > 0)
			{
				this.HaveLogic.SetActive(true);
			}
			else
			{
				this.HaveLogic.SetActive(false);
			}
		}
		else
		{
			this.DizzyAnimationSprite.SetActive(false);
		}
		if (this.CardData.UsageTimes > 0)
		{
			this.TimerPaner.gameObject.SetActive(true);
			this.TimerPaner.GetComponentInChildren<TextMeshProUGUI>().text = this.CardData.UsageTimes.ToString();
			return;
		}
		this.TimerPaner.gameObject.SetActive(false);
	}

	public void HideUI()
	{
		this.HPText.transform.parent.gameObject.SetActive(false);
		this.ATKText.transform.parent.gameObject.SetActive(false);
		this.LevelText.transform.parent.gameObject.SetActive(false);
		this.TimerPaner.gameObject.SetActive(false);
		this.DizzyAnimationSprite.SetActive(false);
		this.LevelText.transform.parent.gameObject.SetActive(false);
		this.IsHideUI = true;
	}

	public void RefreshAffixIcons()
	{
		if (this.AffixIcons != null)
		{
			foreach (GameObject obj in this.AffixIcons)
			{
				ModelPoolManager.Instance.UnSpawnModel(obj);
			}
		}
		this.AffixIcons = new List<GameObject>();
		if (this.CardData.affixesDic != null)
		{
			foreach (KeyValuePair<DungeonAffix, int> keyValuePair in this.CardData.affixesDic)
			{
				if (keyValuePair.Value > 0)
				{
					ModelPoolManager.Instance.SpawnModel(DungeonOperationMgr.GetDungeonAffixInfo(keyValuePair.Key).defaultSpritePath).GameObject.transform.SetParent(base.transform);
				}
			}
		}
	}

	public static CardSlot FindPutableSlotOnPlayerTable(ulong tag)
	{
		foreach (CardSlot cardSlot in Card.GameController.CardSlotsOnPlayerTable)
		{
			if (!(cardSlot == null) && cardSlot.CardSlotData.ChildCardData == null && (cardSlot.CardSlotData.TagWhiteList & tag) > 0UL)
			{
				return cardSlot;
			}
		}
		return null;
	}

	public IEnumerator GiveACardToPlayerTable(CardData cardData)
	{
		CardSlot slot = Card.FindPutableSlotOnPlayerTable(cardData.CardTags);
		if (slot == null || Card.GameController.HasEmptCardSlotOnPlayerTable() <= 0)
		{
			Card.GameController.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"), 1f, 2f, 1f, 1f);
			yield break;
		}
		Card newCard = Card.InitCard(cardData);
		newCard.CardData.ChangeCardSlot(slot.CardSlotData);
		newCard.transform.position = base.transform.position;
		if (UIController.LockLevel != UIController.UILevel.None)
		{
			yield return null;
		}
		UIController.LockLevel = UIController.UILevel.All;
		newCard.transform.DORotate(new Vector3(0f, 360f, 0f), 1f, RotateMode.WorldAxisAdd);
		newCard.CardData.ChangeCardSlot(slot.CardSlotData);
		yield return newCard.transform.DOJump(slot.transform.position, 1f, 1, 1f, false).WaitForCompletion();
		UIController.LockLevel = UIController.UILevel.None;
		newCard.PutInSlot(slot);
		yield break;
	}

	public override void Terminate()
	{
		this.DeleteCard();
	}

	public static void InitACardDataToPlayerTable(CardData cardData)
	{
		Card.GameController.GiveACardData(cardData);
	}

	public static bool InitACardOnPlayerTable(CardData cardData)
	{
		CardSlot cardSlot = Card.FindPutableSlotOnPlayerTable(cardData.CardTags);
		if (cardSlot == null || Card.GameController.HasEmptCardSlotOnPlayerTable() <= 0)
		{
			Card.GameController.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("T_空间不够了"), 1f, 2f, 1f, 1f);
			return false;
		}
		cardData.PutInSlotData(cardSlot.CardSlotData, true);
		return true;
	}

	private IEnumerator showAtkLine(Vector3 start, Vector3 end)
	{
		this.line.enabled = true;
		this.line.SetPositions(new Vector3[]
		{
			start,
			end
		});
		int num;
		for (int i = 0; i < 20; i = num + 1)
		{
			this.line.startWidth = (float)i / 300f;
			this.line.endWidth = (float)i / 300f;
			yield return new WaitForSeconds(0.03f);
			num = i;
		}
		this.line.GetComponentInChildren<ParticleSystem>().transform.position = (start + end) / 2f;
		this.line.GetComponentInChildren<ParticleSystem>().transform.LookAt(end);
		this.line.GetComponentInChildren<ParticleSystem>().Play();
		this.line.enabled = false;
		yield return new WaitForSeconds(0.1f);
		yield return null;
		yield break;
	}

	public GameAct StartAct(string actName)
	{
		foreach (ActData actData in this.CardData.ActDatas)
		{
			if (actData.Name == actName)
			{
				return this.StartAct(actData);
			}
		}
		return null;
	}

	public GameAct StartAct(ActData actData)
	{
		GameAct gameAct = null;
		if (!string.IsNullOrEmpty(actData.Type))
		{
			Card.GameController.EventalTable = (GameObject)UnityEngine.Object.Instantiate(Resources.Load(actData.Type));
			if (!string.IsNullOrEmpty(actData.Model))
			{
				((GameObject)UnityEngine.Object.Instantiate(Resources.Load(actData.Model))).transform.SetParent(Card.GameController.EventalTable.transform, false);
			}
			Card.GameController.EventalTable.transform.SetParent(Card.GameController.Evental.transform, false);
			gameAct = Card.GameController.EventalTable.GetComponent<GameAct>();
			gameAct.ActData = actData;
			gameAct.Source = this;
			Card.GameController.CurrentAct = gameAct;
			EffectAudioManager.Instance.PlayEffectAudio(25, null);
		}
		Action callback = actData.Callback;
		if (callback != null)
		{
			callback();
		}
		return gameAct;
	}

	public IEnumerator RefreshHPText()
	{
		float.Parse(this.HPText.text);
		int hp = this.CardData.HP;
		this.HPText.text = hp.ToString();
		yield return null;
		yield break;
	}

	public IEnumerator RefreshATKText()
	{
		float oldATK = float.Parse(this.ATKText.text);
		int atk = this.CardData.ATK;
		int num;
		for (int i = 0; i < 21; i = num + 1)
		{
			this.ATKText.text = ((int)Mathf.Lerp(oldATK, (float)atk, (float)i / 20f)).ToString();
			yield return new WaitForSeconds(0.01f);
			num = i;
		}
		this.ATKText.text = atk.ToString();
		yield return null;
		yield break;
	}

	public IEnumerator JumpToSlot(CardSlot slot, float time, bool callEvent = true)
	{
		UIController.UILevel templock = UIController.LockLevel;
		UIController.LockLevel = UIController.UILevel.All;
		Sequence t = this.JumpCardInSlotAniSequence(this, slot, time);
		yield return t.Play<Sequence>().WaitForCompletion();
		if (this.CardData != null)
		{
			this.CardData.PutInSlotData(slot.CardSlotData, callEvent);
		}
		UIController.LockLevel = templock;
		yield return null;
		yield break;
	}

	public Sequence JumpCardInSlotAniSequence(Card card, CardSlot cardSlot, float time)
	{
		Sequence sequence = DOTween.Sequence();
		sequence.Append(card.transform.DOJump(cardSlot.transform.position, 1f, 1, time, false));
		return sequence;
	}

	public void PlayAnimationForCardSlotChild(Transform tarSlot, string aniName)
	{
		if (this.animateName.Equals(aniName))
		{
			return;
		}
		Animator[] componentsInChildren = tarSlot.GetComponentsInChildren<Animator>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].SetTrigger(aniName);
		}
		this.animateName = aniName;
	}

	private Vector3 startPos;

	private Vector3 lastPos;

	private Vector3 endPos;

	private Vector3 offset;

	public bool canDrag = true;

	private bool isDragging;

	private bool isMouseDown;

	public CardSlot CurrentCardSlot;

	[SerializeField]
	private CardData m_CardData;

	public AudioClip PutDownAudio;

	public AudioClip PickUpAudio;

	public TextMeshProUGUI HPText;

	public Image HpBar;

	public TextMeshProUGUI ATKText;

	public TextMeshProUGUI CountNumText;

	public TextMeshProUGUI LevelText;

	public TextMeshProUGUI PriceText;

	public TextMeshProUGUI ClockText;

	public GameObject CountNumTextPanel;

	public GameObject ActionTipsPanel;

	public SpriteRenderer IconSprite;

	public Transform AffixTrans;

	public List<Sprite> UnHappySpriteList;

	public Image UnHappySpriteRenderer;

	public GameObject TimerPaner;

	public GameObject DizzyAnimationSprite;

	public GameObject IsAttackedMask;

	private Transform targetSlot;

	public TextMeshProUGUI DMGText;

	public GameObject DMGPanel;

	public CardLogic CardLogic;

	public GameObject HaveLogic;

	public bool CanBeSelected = true;

	private float dTime;

	private Vector3 mouseStartPos;

	private CardSlot startSlot;

	public LineRenderer line;

	public List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

	private Vector3 ModelSize;

	private Vector3 ModelScale;

	public bool IsHideUI;

	public DisplayModel CardInstance;

	public DisplayModel DisplayGameObjectOnPlayerTable;

	public DisplayModel DisplayGameObjectOnAreaTable;

	public DisplayModel BottomGameObject;

	private int m_ShowCount;

	private static List<string> ActivationModNames = new List<string>
	{
		"输入",
		"输出",
		"制造机",
		"箭头",
		"箭头中",
		"箭头高",
		"推",
		"弩车",
		"机械臂",
		"空间",
		"空间测试"
	};

	private List<GameObject> AffixIcons;

	private string animateName = "";
}
