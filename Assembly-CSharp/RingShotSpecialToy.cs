using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class RingShotSpecialToy : MonoBehaviour
{
	private void Start()
	{
		this.Speed = 10;
		this.moveSpeed = 40f;
		this.isCompleted = false;
		this.isShooting = false;
		this.gapTime = 3;
		this.NeedStay = false;
		this.RingNum = 0;
		this.gotNum = 0;
		this.StartMouseControl = false;
		this.originColor = this.LeftTipText.color;
	}

	private void Update()
	{
		this.RingText.text = (this.RingNum.ToString() ?? "");
		float num = UnityEngine.Random.Range(0f, 0.2f);
		this.LeftTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		this.RingText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		num = UnityEngine.Random.Range(0f, 0.2f);
		this.RightTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		if (this.isStart && this.StartMouseControl && Input.GetMouseButtonUp(0) && this.isStart && !this.isCompleted && !this.isShooting)
		{
			if (this.RingNum > 0 && this.gotNum < 4)
			{
				this.RingNum--;
				this.Shooter.transform.DOPunchPosition(-this.Shooter.transform.forward, 0.5f, 1, 1f, false);
				base.StartCoroutine(this.Shoot());
				return;
			}
			Cursor.visible = true;
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_52"), 1f, 2f, 1f, 1f);
			this.isCompleted = true;
			AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
			GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
			GameController.getInstance().OnTableChange(parentArea, true);
		}
	}

	private IEnumerator Shoot()
	{
		this.isShooting = true;
		yield return new WaitForSeconds(0.3f);
		GameObject ring = UnityEngine.Object.Instantiate<GameObject>(this.Ring, this.Shooter.transform.position, this.Shooter.transform.rotation, base.transform);
		ring.SetActive(true);
		this.RingModel.SetActive(false);
		ring.GetComponent<Rigidbody>().AddRelativeForce(this.Shooter.transform.forward * (float)this.Speed, ForceMode.Impulse);
		yield return new WaitForSeconds((float)this.gapTime);
		if (!this.NeedStay)
		{
			ring.SetActive(false);
		}
		else
		{
			this.NeedStay = false;
		}
		this.RingModel.SetActive(true);
		this.isShooting = false;
		yield break;
	}

	private void FixedUpdate()
	{
		if (this.isStart && this.StartMouseControl)
		{
			this.Shooter.transform.Translate(Input.GetAxis("Mouse X") * Time.deltaTime * this.moveSpeed, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * this.moveSpeed, Space.Self);
			if (this.Shooter.transform.position.x <= -4f)
			{
				this.Shooter.transform.position = new Vector3(-4f, this.Shooter.transform.position.y, this.Shooter.transform.position.z);
			}
			if (this.Shooter.transform.position.x >= 4f)
			{
				this.Shooter.transform.position = new Vector3(4f, this.Shooter.transform.position.y, this.Shooter.transform.position.z);
			}
			if (this.Shooter.transform.position.z <= 0f)
			{
				this.Shooter.transform.position = new Vector3(this.Shooter.transform.position.x, this.Shooter.transform.position.y, 0f);
			}
			if (this.Shooter.transform.position.z >= 4f)
			{
				this.Shooter.transform.position = new Vector3(this.Shooter.transform.position.x, this.Shooter.transform.position.y, 4f);
			}
		}
	}

	public void OnBuyRing()
	{
		if (!this.isStart)
		{
			if (GameController.getInstance().GameData.Money >= 10)
			{
				DungeonOperationMgr.Instance.ChangeMoney(-10);
				this.RingNum += 3;
				return;
			}
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_53"), 1f, 2f, 1f, 1f);
		}
	}

	public void OnRingShotStartButton()
	{
		if (!this.isStart)
		{
			this.isStart = true;
			this.LeftTipText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_套圈3");
			this.RightTipText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_套圈4");
			Cursor.visible = false;
		}
	}

	public GameObject Ring;

	public GameObject RingModel;

	public GameObject Shooter;

	public TextMeshProUGUI LeftTipText;

	public TextMeshProUGUI RightTipText;

	public TextMeshProUGUI RingText;

	public bool StartMouseControl;

	public int RingNum;

	public bool NeedStay;

	public int gotNum;

	private bool isStart;

	private bool isShooting;

	public bool isCompleted;

	public int Speed;

	private float moveSpeed;

	private int gapTime;

	private Color originColor;
}
