using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class BasketballSpecialToy : MonoBehaviour
{
	private void Start()
	{
		this.Speed = 18;
		this.rotateSpeed = 100f;
		this.shootTime = 0;
		this.shootNum = new int[]
		{
			1,
			2,
			3,
			8
		};
		this.isCompleted = false;
		this.isShooting = false;
		this.gapTime = 0;
		this.Point = 0;
		this.StartMouseControl = false;
		this.BasketTrigger = base.GetComponentInChildren<BasketTrigger>();
		this.BasketTrigger.BasketballSpecialToy = this;
		this.originColor = this.TimeText.color;
		this.originCameraPos = Camera.main.transform.position;
		this.originCameraRot = Camera.main.transform.rotation.eulerAngles;
		Camera.main.transform.DOLocalMove(this.CameraTrans.localPosition, 0.5f, false);
		Camera.main.transform.DOLocalRotate(this.CameraTrans.localRotation.eulerAngles, 0.5f, RotateMode.Fast);
	}

	private void Update()
	{
		if (this.StartMouseControl && Input.GetMouseButtonUp(0) && !this.isCompleted && !this.isShooting)
		{
			this.isShooting = true;
			if (this.shootTime < 4)
			{
				this.Shooter.transform.DOPunchPosition(-this.Shooter.transform.right, 0.25f, 1, 1f, false).SetLoops(this.shootNum[this.shootTime]);
				base.StartCoroutine(this.Shoot());
			}
			else
			{
				this.OnBasketballEnd();
			}
		}
		float num = UnityEngine.Random.Range(0f, 0.2f);
		this.TimeText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		num = UnityEngine.Random.Range(0f, 0.2f);
		this.PointText.color = this.originColor + new Color(0f, 0f, 0f, -num);
	}

	private IEnumerator Shoot()
	{
		this.shootTime++;
		int i = 0;
		while (i < this.shootNum[this.shootTime - 1] && !this.isCompleted)
		{
			this.gapTime++;
			if (this.gapTime >= 10)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Basketball, this.ShootPoint.position, this.ShootPoint.rotation, base.transform);
				gameObject.SetActive(true);
				float x = UnityEngine.Random.Range(-0.001f, 0.001f);
				gameObject.GetComponent<Rigidbody>().velocity = base.transform.TransformDirection(this.ShootPoint.forward * (float)this.Speed + new Vector3(x, 0f, 0f));
				int num = i;
				i = num + 1;
				this.gapTime = 0;
			}
			yield return new WaitForSeconds(0.02f);
		}
		if (this.shootTime >= 4)
		{
			yield return new WaitForSeconds(2f);
		}
		if (this.shootTime >= 4)
		{
			this.TimeText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_投篮2");
			this.TimeText.fontSize = 0.2f;
		}
		else
		{
			this.TimeText.text = LocalizationMgr.Instance.GetLocalizationWord("WJ_投篮1") + this.shootNum[this.shootTime].ToString();
		}
		this.isShooting = false;
		yield break;
	}

	private void FixedUpdate()
	{
		if (this.StartMouseControl)
		{
			this.Shooter.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * this.rotateSpeed, Space.Self);
			if (this.Shooter.transform.rotation.eulerAngles.z < 0f || this.Shooter.transform.rotation.eulerAngles.z >= 180f)
			{
				this.Shooter.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			}
			if (this.Shooter.transform.rotation.eulerAngles.z > 25f && this.Shooter.transform.rotation.eulerAngles.z < 180f)
			{
				this.Shooter.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 25f));
			}
		}
	}

	public void OnGetPoint()
	{
		this.Point += 12;
		this.PointText.text = this.Point.ToString();
	}

	private void OnBasketballEnd()
	{
		this.isCompleted = true;
		Camera.main.transform.DOMove(this.originCameraPos, 0.5f, false);
		Camera.main.transform.DORotate(this.originCameraRot, 0.5f, RotateMode.Fast);
		DungeonOperationMgr.Instance.ChangeMoney(this.Point);
		AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
		GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
		GameController.getInstance().OnTableChange(parentArea, true);
	}

	public GameObject Basketball;

	public GameObject Shooter;

	public BasketTrigger BasketTrigger;

	public Transform ShootPoint;

	public Transform CameraTrans;

	public TextMeshProUGUI TimeText;

	public TextMeshProUGUI PointText;

	public bool StartMouseControl;

	public int Point;

	public int Speed;

	private int shootTime;

	private int[] shootNum;

	private int gapTime;

	private float rotateSpeed;

	private bool isCompleted;

	private bool isShooting;

	private Color originColor;

	private Vector3 originCameraPos;

	private Vector3 originCameraRot;
}
