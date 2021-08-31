using System;
using System.Collections;
using DG.Tweening;
using HighlightingSystem;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeMachineController : CardAnimationController
{
	private void Start()
	{
		GameController.ins.GameEventManager.OnSaveGameEvent += this.Save;
		this.CreateSlot();
		this.TimeMachineUIChontroller.InitPanel();
	}

	private void OnDestroy()
	{
		GameController.ins.GameEventManager.OnSaveGameEvent -= this.Save;
	}

	private void Save()
	{
		if (this.SlotData.ChildCardData == null)
		{
			if (GlobalController.Instance.GlobalData.GlobalAttr.ContainsKey("TimeMachine_CurrentCard"))
			{
				GlobalController.Instance.GlobalData.GlobalAttr.Remove("TimeMachine_CurrentCard");
			}
			return;
		}
		if (GlobalController.Instance.GlobalData.GlobalAttr.ContainsKey("TimeMachine_CurrentCard"))
		{
			GlobalController.Instance.GlobalData.GlobalAttr["TimeMachine_CurrentCard"] = this.SlotData.ChildCardData.ModID;
			return;
		}
		GlobalController.Instance.GlobalData.GlobalAttr.Add("TimeMachine_CurrentCard", this.SlotData.ChildCardData.ModID);
	}

	private void Update()
	{
		if (Input.GetMouseButton(1))
		{
			if (this.m_isPlaying || !this.TimeMachineAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.open"))
			{
				return;
			}
			base.StartCoroutine(this.WaitForAnimationPlayOver("close"));
		}
	}

	private void CreateSlot()
	{
		CardSlot cardSlot = CardSlot.InitCardSlot(CardSlotData.CopyCardSlotData(new CardSlotData
		{
			SlotOwnerType = CardSlotData.OwnerType.SecondaryAct,
			SlotType = CardSlotData.Type.OnlyTake,
			IconIndex = 3
		}), 0.111f);
		cardSlot.transform.SetParent(this.SlotPoint, false);
		cardSlot.transform.localPosition = Vector3.zero;
		cardSlot.transform.localScale = Vector3.one;
		cardSlot.Icon.transform.localPosition = Vector3.zero;
		this.SlotData = cardSlot.CardSlotData;
		if (GlobalController.Instance.GlobalData.GlobalAttr.ContainsKey("TimeMachine_CurrentCard") && GlobalController.Instance.GlobalData.GlobalAttr["TimeMachine_CurrentCard"] != null)
		{
			try
			{
				Card.InitCardDataByID(GlobalController.Instance.GlobalData.GlobalAttr["TimeMachine_CurrentCard"].ToString()).PutInSlotData(this.SlotData, true);
			}
			catch (Exception ex)
			{
				Debug.LogError("复原打印机卡槽错误,ModID:" + GlobalController.Instance.GlobalData.GlobalAttr["TimeMachine_CurrentCard"].ToString());
				Debug.LogError(ex.Message);
				Debug.LogError(ex.StackTrace);
			}
		}
	}

	private IEnumerator WaitForAnimationPlayOver(string triggerName)
	{
		this.m_isPlaying = true;
		if (triggerName.Equals("close"))
		{
			this.TimeMachineUIChontroller.gameObject.SetActive(false);
		}
		else
		{
			base.transform.parent.GetComponent<Highlighter>().enabled = false;
			GameController.getInstance().UIController.HideCardTablesButtons();
			UIController.LockLevel = UIController.UILevel.All;
			Camera.main.transform.GetComponentInChildren<CameraScaleAndRoll>().IsCanMove = false;
			this.m_CameraPos = Camera.main.transform.localPosition;
			this.m_CamereRot = Camera.main.transform.localRotation;
			Camera.main.transform.DOMove(this.CameraPoint1.position, 0.2f, false);
			Camera.main.transform.DORotate(this.CameraPoint1.rotation.eulerAngles, 0.2f, RotateMode.Fast);
			this.TimeMachineAnimator.Rebind();
		}
		this.TimeMachineAnimator.SetTrigger(triggerName);
		yield return new WaitForSeconds(0.8334f);
		if (triggerName.Equals("open"))
		{
			this.TimeMachineUIChontroller.gameObject.SetActive(true);
			this.TimeMachineUIChontroller.InitPanel();
			Camera.main.transform.DOMove(this.CameraPoint2.position, 0.5f, false);
			Camera.main.transform.DORotate(this.CameraPoint2.rotation.eulerAngles, 0.5f, RotateMode.Fast);
			Camera.main.GetComponent<CameraEffect>().PostProcessVolume.profile.GetSetting<DepthOfField>().active = false;
			yield return new WaitForSeconds(0.7f);
		}
		else
		{
			base.transform.parent.GetComponent<Highlighter>().enabled = true;
			Camera.main.transform.DOLocalMove(this.m_CameraPos, 0.2f, false);
			Camera.main.transform.DOLocalRotate(this.m_CamereRot.eulerAngles, 0.2f, RotateMode.Fast);
			Camera.main.GetComponent<CameraEffect>().PostProcessVolume.profile.GetSetting<DepthOfField>().active = true;
			yield return new WaitForSeconds(0.5f);
			Camera.main.transform.GetComponentInChildren<CameraScaleAndRoll>().IsCanMove = true;
			UIController.LockLevel = UIController.UILevel.None;
			GameController.getInstance().UIController.ShowCardTablesButtons();
		}
		this.m_isPlaying = false;
		yield break;
	}

	public override void PlayAnimation_Open()
	{
		if (this.m_isPlaying || this.TimeMachineAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.open"))
		{
			return;
		}
		base.StartCoroutine(this.WaitForAnimationPlayOver("open"));
	}

	public override void PlayAnimation_Close()
	{
		if (this.m_isPlaying || !this.TimeMachineAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.open"))
		{
			return;
		}
		base.StartCoroutine(this.WaitForAnimationPlayOver("close"));
	}

	public TimeMachineUIChontroller TimeMachineUIChontroller;

	public Animator TimeMachineAnimator;

	public Transform SlotPoint;

	public CardSlotData SlotData;

	public Transform CameraPoint1;

	public Transform CameraPoint2;

	private bool m_isPlaying;

	private Transform m_CameraParent;

	private Vector3 m_CameraPos;

	private Quaternion m_CamereRot;
}
