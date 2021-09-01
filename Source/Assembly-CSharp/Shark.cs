using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

public class Shark : MonoBehaviour
{
	private void Start()
	{
		this.SharkTeeth = base.GetComponentsInChildren<SharkTooth>();
		for (int i = 0; i < this.SharkTeeth.Length; i++)
		{
			this.SharkTeeth[i].Shark = this;
			this.SharkTeeth[i].Num = i;
		}
		this.SharkRedButton = base.GetComponentInChildren<SharkRedButton>();
		this.SharkRedButton.Shark = this;
		this.SelectedToothNum = UnityEngine.Random.Range(0, this.SharkTeeth.Length);
		this.cameraTrans = Camera.main.transform;
		this.completeCallBack = new TweenCallback(this.OnAniCompleted);
		this.originColor = this.TipText[0].color;
		this.Finger.gameObject.SetActive(false);
		this.Blood.gameObject.SetActive(false);
		this.Point = 0;
		this.NextGold = new int[]
		{
			10,
			10,
			10,
			15,
			15,
			20,
			20,
			30,
			40,
			60,
			80,
			200,
			999
		};
		this.NextGoldText.text = (this.NextGold[0].ToString() ?? "");
		this.Gold = 0;
		this.pushedNum = 0;
	}

	private void Update()
	{
		for (int i = 0; i < this.TipText.Length; i++)
		{
			this.rand = UnityEngine.Random.Range(0f, 0.2f);
			this.TipText[i].color = this.originColor + new Color(0f, 0f, 0f, -this.rand);
		}
		this.rand = UnityEngine.Random.Range(0f, 0.2f);
		this.NextGoldText.color = this.originColor + new Color(0f, 0f, 0f, -this.rand);
	}

	public void OnSelected()
	{
		this.SharkRedButton.isEnd = true;
		for (int i = 0; i < this.SharkTeeth.Length; i++)
		{
			this.SharkTeeth[i].IsPushed = true;
		}
		GameController.getInstance().MainCamera.transform.GetChild(0).GetComponent<CameraShake>().StartAnimate(0.2f, 0.1f, false);
		this.Finger.gameObject.SetActive(true);
		this.Finger.SetTrigger("play");
		this.Blood.gameObject.SetActive(true);
		this.Blood.SetTrigger("play");
		for (int j = 0; j < this.BloodParts.Length; j++)
		{
			this.BloodParts[j].gameObject.SetActive(true);
		}
		Sequence sequence = DOTween.Sequence();
		UnityEngine.Random.Range(-0.5f, 0.5f);
		sequence.Insert(1.1f, this.Finger.transform.DOMove(new Vector3(0.2f, 4.92f, -5.8f), 2f, false).SetEase(Ease.InCubic));
		sequence.Insert(0f, this.Finger.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.42f));
		sequence.Insert(2.5f, this.Blood.GetComponent<SpriteRenderer>().DOFade(0f, 3f));
		for (int k = 0; k < this.BloodParts.Length; k++)
		{
			sequence.Insert(2.5f, this.BloodParts[k].DOFade(0f, 3f));
		}
		sequence.Insert(0f, this.SharkHeadObject.transform.DORotate(new Vector3(0f, 0f, 0f), 0.5f, RotateMode.Fast));
		sequence.OnComplete(this.completeCallBack);
	}

	private void OnAniCompleted()
	{
		Camera.main.transform.position = this.cameraTrans.position;
		this.OnSharkEnd();
	}

	public void OnSharkEnd()
	{
		AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
		GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
		GameController.getInstance().OnTableChange(parentArea, true);
	}

	public SharkTooth[] SharkTeeth;

	public int SelectedToothNum;

	public GameObject SharkHeadObject;

	public SharkRedButton SharkRedButton;

	public int Point;

	public TextMeshProUGUI[] TipText;

	public int[] NextGold;

	public TextMeshProUGUI NextGoldText;

	public int Gold;

	public TextMeshProUGUI GoldText;

	public Animator Finger;

	public Animator Blood;

	public SpriteRenderer[] BloodParts;

	private Transform cameraTrans;

	private TweenCallback completeCallBack;

	private Color originColor;

	private float rand;

	private int pushedNum;
}
