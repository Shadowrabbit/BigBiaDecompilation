using System;
using System.Collections;
using DG.Tweening;
using HighlightingSystem;
using UnityEngine;

public class OvenController : CardAnimationController
{
	private void Start()
	{
		GameController.ins.GameEventManager.OnSaveGameEvent += this.Save;
		this.CreateSlot();
	}

	private void OnDestroy()
	{
		GameController.ins.GameEventManager.OnSaveGameEvent -= this.Save;
	}

	private void Save()
	{
		CardData childCardData = this.SlotData.ChildCardData;
	}

	private void Update()
	{
		if (Input.GetMouseButton(1))
		{
			if (this.m_isPlaying || !this.OvenAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.open"))
			{
				return;
			}
			RaycastHit raycastHit;
			Physics.Raycast(CameraUtils.MainCamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f);
			if (raycastHit.collider != null && raycastHit.collider.transform.GetComponent<Card>() && raycastHit.collider.transform.GetComponent<Card>().CardData.ModID.Equals("烤箱"))
			{
				base.StartCoroutine(this.WaitForAnimationPlayOver("close"));
			}
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
		this.SlotData = cardSlot.CardSlotData;
	}

	private IEnumerator WaitForAnimationPlayOver(string triggerName)
	{
		this.m_isPlaying = true;
		if (!triggerName.Equals("close"))
		{
			base.transform.parent.GetComponent<Highlighter>().enabled = false;
			GameController.getInstance().UIController.HideCardTablesButtons();
			UIController.LockLevel = UIController.UILevel.All;
			Camera.main.transform.GetComponentInChildren<CameraScaleAndRoll>().IsCanMove = false;
			this.m_CameraPos = Camera.main.transform.localPosition;
			this.m_CamereRot = Camera.main.transform.localRotation;
			Camera.main.transform.DOMove(this.CameraPoint.position, 0.5f, false);
			Camera.main.transform.DORotate(this.CameraPoint.rotation.eulerAngles, 0.5f, RotateMode.Fast);
			this.OvenAnimator.Rebind();
			yield return new WaitForSeconds(0.5f);
		}
		this.OvenAnimator.SetTrigger(triggerName);
		yield return new WaitForSeconds(0.53000003f);
		if (!triggerName.Equals("open"))
		{
			base.transform.parent.GetComponent<Highlighter>().enabled = true;
			Camera.main.transform.DOLocalMove(this.m_CameraPos, 0.5f, false);
			Camera.main.transform.DOLocalRotate(this.m_CamereRot.eulerAngles, 0.5f, RotateMode.Fast);
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
		if (this.m_isPlaying || this.OvenAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.open"))
		{
			return;
		}
		base.StartCoroutine(this.WaitForAnimationPlayOver("open"));
	}

	public override void PlayAnimation_Close()
	{
		if (this.m_isPlaying || !this.OvenAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.open"))
		{
			return;
		}
		base.StartCoroutine(this.WaitForAnimationPlayOver("close"));
	}

	public Animator OvenAnimator;

	public Transform SlotPoint;

	public CardSlotData SlotData;

	public Transform CameraPoint;

	private bool m_isPlaying;

	private Transform m_CameraParent;

	private Vector3 m_CameraPos;

	private Quaternion m_CamereRot;
}
