using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.UI;

public class DungeonCreatorMachine : MonoBehaviour
{
	private void Start()
	{
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		this.BottonMaterial = this.LeftButton.GetComponent<MeshRenderer>().material;
		this.BottonMaterial2 = this.RightButton.GetComponent<MeshRenderer>().material;
		this.BottonMaterial3 = this.MiddleButton.GetComponent<MeshRenderer>().material;
		this.HasCard = false;
		this.ButtonCanvas.worldCamera = Camera.main;
		this.EnterButton.interactable = false;
		this.ButtonCanvas.gameObject.SetActive(false);
		this.BottonMaterial.SetColor("_EmissionColor", Color.black);
		this.BottonMaterial2.SetColor("_EmissionColor", Color.black);
		this.BottonMaterial3.SetColor("_EmissionColor", Color.black);
		if (GlobalController.Instance.GlobalData.GlobalAttr.ContainsKey("CardOnDungeonCreator"))
		{
			((CardData)GlobalController.Instance.GlobalData.GlobalAttr["CardOnDungeonCreator"]).PutInSlotData(this.CardSlot.CardSlotData, true);
		}
	}

	private void OnCardPutInSlot(CardSlotData csd, CardData cd)
	{
		if (cd.CurrentCardSlotData != this.CardSlot.CardSlotData)
		{
			if (csd == this.CardSlot.CardSlotData)
			{
				this.HasCard = false;
				this.EnterButton.interactable = false;
				this.ButtonCanvas.gameObject.SetActive(false);
				if (GlobalController.Instance.GlobalData.GlobalAttr.ContainsKey("CardOnDungeonCreator"))
				{
					GlobalController.Instance.GlobalData.GlobalAttr.Remove("CardOnDungeonCreator");
				}
			}
			return;
		}
		if (cd.ModID.Equals("时空挖掘机") || cd.ModID.Equals("烤箱"))
		{
			cd.PutInSlotData(csd, true);
			return;
		}
		this.HasCard = true;
		this.EnterButton.interactable = true;
		this.ButtonCanvas.gameObject.SetActive(true);
		if (GlobalController.Instance.GlobalData.GlobalAttr.ContainsKey("CardOnDungeonCreator"))
		{
			GlobalController.Instance.GlobalData.GlobalAttr["CardOnDungeonCreator"] = cd;
			return;
		}
		GlobalController.Instance.GlobalData.GlobalAttr.Add("CardOnDungeonCreator", cd);
	}

	public void OnEnterButtonClick()
	{
		if (UIController.LockLevel != UIController.UILevel.None || (UIController.UILockStack.Count > 0 && UIController.UILockStack.Peek() != this))
		{
			return;
		}
		base.GetComponentInParent<Highlighter>().enabled = false;
		base.StartCoroutine(this.EnterArea());
		this.EnterButton.interactable = false;
		this.EnterButton.gameObject.SetActive(false);
	}

	public IEnumerator EnterArea()
	{
		UIController.LockLevel = UIController.UILevel.All;
		this.CardSlot.CardSlotData.SlotType = CardSlotData.Type.Freeze;
		CardData cardData = this.CardSlot.ChildCard.CardData;
		this.CardSlot.ChildCard.HideUI();
		if (cardData.HasTag(TagMap.随从))
		{
			new EnterDungeonAct();
			ActData actData = new ActData();
			actData.Type = "Act/进入情境";
			actData.Name = "进入";
			actData.Model = "ActTable/空";
			if (cardData.ActDatas == null)
			{
				cardData.ActDatas = new List<ActData>();
				cardData.ActDatas.Add(actData);
			}
			if (!cardData.Attrs.ContainsKey("AreaDataID"))
			{
				cardData.Attrs.Add("AreaDataID", "内心世界");
			}
			cardData.Attrs["Theme"] = 101;
			if (!cardData.Attrs.ContainsKey("SceneDataID"))
			{
				cardData.Attrs.Add("SceneDataID", "入场选择");
			}
			GameController.ins.GameData.InnerMinionCardData = cardData;
		}
		AreaData areaData = GameController.ins.GameData.AreaMap[this.CardSlot.ChildCard.CardData.GetAttr("AreaDataID")];
		this.Animator.SetTrigger("Open");
		this.CardSlot.transform.SetParent(this.AreaTable);
		this.CardSlot.ChildCard.GetComponent<Highlighter>().enabled = false;
		if (areaData.TableModel != null)
		{
			GameObject gameObject;
			if (this.CardSlot.ChildCard.CardData.GetAttr("AreaDataID") == "BossTree" || this.CardSlot.ChildCard.CardData.GetAttr("AreaDataID") == "BossSnake")
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(GameController.ins.LoadModelOfType("AreaTable/入场选择小", 0));
				gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(GameController.ins.LoadModelOfType(areaData.TableModel, 0));
				gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			}
			gameObject.transform.SetParent(this.AreaTable, false);
			gameObject.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
			gameObject.transform.localPosition = new Vector3(0f, 0f, -0.28f);
			gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
			if (gameObject.GetComponent<MinionInnerTable>() != null)
			{
				gameObject.GetComponent<MinionInnerTable>().ShowModel(this.CardSlot.ChildCard.CardData);
			}
		}
		Camera.main.transform.GetComponentInChildren<CameraScaleAndRoll>().IsCanMove = false;
		Vector3 m_CameraPos = Camera.main.transform.position;
		Quaternion m_CamereRot = Camera.main.transform.rotation;
		Camera.main.transform.DOMove(this.CameraPoint.position, 1f, false);
		Camera.main.transform.DORotate(this.CameraPoint.rotation.eulerAngles, 1f, RotateMode.Fast);
		yield return new WaitForSeconds(1f);
		GameController.ins.UIController.ShowBlackMask(null, 0.5f);
		GameController.ins.UIController.ShowBackToHomeButton();
		GameController.ins.UIController.HideCancelGameBtn();
		GlobalController.Instance.SaveGlobalData();
		yield return new WaitForSeconds(1f);
		Camera.main.transform.position = m_CameraPos;
		Camera.main.transform.rotation = m_CamereRot;
		Camera.main.transform.GetComponentInChildren<CameraScaleAndRoll>().IsCanMove = true;
		this.CardSlot.CardSlotData.SlotType = CardSlotData.Type.Normal;
		UIController.LockLevel = UIController.UILevel.None;
		this.CardSlot.ChildCard.StartAct(this.CardSlot.ChildCard.CardData.ActDatas[0]);
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
		GameController.ins.UIController.HideBlackMask(null, 1f);
		yield break;
	}

	private void Update()
	{
		if (this.HasCard)
		{
			if (this.AnimationProcess >= 1f)
			{
				return;
			}
			this.tempColor = Color.Lerp(Color.black, this.EmissionColor, this.AnimationProcess);
			this.BottonMaterial.SetColor("_EmissionColor", this.tempColor);
			this.BottonMaterial2.SetColor("_EmissionColor", this.tempColor);
			this.BottonMaterial3.SetColor("_EmissionColor", this.tempColor);
			this.AnimationProcess += this.AnimationSpeed;
			return;
		}
		else
		{
			if (this.AnimationProcess <= 0f)
			{
				return;
			}
			this.tempColor = Color.Lerp(Color.black, this.EmissionColor, this.AnimationProcess);
			this.BottonMaterial.SetColor("_EmissionColor", this.tempColor);
			this.BottonMaterial2.SetColor("_EmissionColor", this.tempColor);
			this.BottonMaterial3.SetColor("_EmissionColor", this.tempColor);
			this.AnimationProcess -= this.AnimationSpeed;
			return;
		}
	}

	public BoxCollider LeftButton;

	public BoxCollider RightButton;

	public GameObject MiddleButton;

	public Button EnterButton;

	public Canvas ButtonCanvas;

	public Transform AreaTable;

	public CardSlot CardSlot;

	public Animator Animator;

	public Transform CameraPoint;

	private bool HasCard;

	private bool inAnimation;

	private Material BottonMaterial;

	private Material BottonMaterial2;

	private Material BottonMaterial3;

	private float EmiSSionScale;

	private float AnimationProcess;

	private float AnimationSpeed = 0.02f;

	private Color tempColor = Color.black;

	private float TempIntensity;

	private Color EmissionColor = new Color(0f, 0.627451f, 0.7490196f) * 12f;
}
