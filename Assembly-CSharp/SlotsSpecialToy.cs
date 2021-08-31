using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotsSpecialToy : MonoBehaviour
{
	private void Start()
	{
		this.isCompleted = false;
		this.StartMouseControl = false;
		this.rollStep = 0.18f;
		this.rollSpeed = 0.02f;
		this.rollCount = 0;
		this.rollMoney = 20;
		this.numResults = new int[3];
		this.maxJackpot = 888;
		this.minJackpot = 88;
		this.originColor = this.LeftTipText.color;
		if (GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy < this.minJackpot)
		{
			GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy = this.minJackpot;
		}
	}

	private void Update()
	{
		this.JackpotText.text = (GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy.ToString() ?? "");
		float num = UnityEngine.Random.Range(0f, 0.2f);
		this.LeftTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		this.JackpotTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		this.JackpotText.color = this.originColor + new Color(0f, 0f, 0f, -num);
		num = UnityEngine.Random.Range(0f, 0.2f);
		this.RightTipText.color = this.originColor + new Color(0f, 0f, 0f, -num);
	}

	public void OnSlotsLever()
	{
		switch (this.state)
		{
		case 0:
			if (GameController.getInstance().GameData.Money >= this.rollMoney)
			{
				DungeonOperationMgr.Instance.ChangeMoney(-this.rollMoney);
				this.state = 1;
				this.rollStep = UnityEngine.Random.Range(0.1f, 0.2f);
				this.rollSpeed = UnityEngine.Random.Range(0.02f, 0.05f);
				this.rollCount++;
				base.StartCoroutine(this.ImageRoll());
				return;
			}
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_55"), 1f, 2f, 1f, 1f);
			return;
		case 1:
			this.state = 2;
			base.StartCoroutine(this.ImageRollEnd(this.image[0], 1));
			return;
		case 2:
			this.state = 3;
			base.StartCoroutine(this.ImageRollEnd(this.image[1], 2));
			return;
		case 3:
			this.state = 4;
			base.StartCoroutine(this.ImageRollEnd(this.image[2], 3));
			return;
		default:
			return;
		}
	}

	private IEnumerator ImageRoll()
	{
		while (this.state == 1)
		{
			foreach (RawImage rawImage in this.image)
			{
				this.ImageRoll(rawImage, rawImage.uvRect.y + this.rollStep);
			}
			yield return new WaitForSeconds(this.rollSpeed);
		}
		while (this.state == 2)
		{
			this.ImageRoll(this.image[1], this.image[1].uvRect.y + this.rollStep);
			this.ImageRoll(this.image[2], this.image[2].uvRect.y + this.rollStep);
			yield return new WaitForSeconds(this.rollSpeed);
		}
		while (this.state == 3)
		{
			this.ImageRoll(this.image[2], this.image[2].uvRect.y + this.rollStep);
			yield return new WaitForSeconds(this.rollSpeed);
		}
		yield break;
	}

	private void ImageRoll(RawImage img, float endpos)
	{
		Rect uvRect = img.uvRect;
		uvRect.y = endpos;
		uvRect.y -= (float)((int)uvRect.y);
		img.uvRect = uvRect;
	}

	private IEnumerator ImageRollEnd(RawImage img, int instate)
	{
		int num = (int)((img.uvRect.y - (float)((int)img.uvRect.y) + 0.1f) / 0.2f);
		float endpos = (float)num * 0.2f + (float)((int)img.uvRect.y) + 1f;
		float startpos = img.uvRect.y;
		int num2;
		for (int i = 1; i <= 10; i = num2 + 1)
		{
			this.ImageRoll(img, Mathf.Lerp(startpos, endpos, 0.1f * (float)i));
			yield return new WaitForSeconds(this.rollSpeed);
			num2 = i;
		}
		if (instate == 3 && this.state == 4)
		{
			this.Calculate();
		}
		yield break;
	}

	private void Calculate()
	{
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			float num2 = this.image[i].uvRect.y - (float)((int)this.image[i].uvRect.y);
			this.numResults[i] = (int)((num2 + 0.1f) / 0.2f);
		}
		if (this.numResults[0] == this.numResults[1])
		{
			num++;
		}
		if (this.numResults[2] == this.numResults[1])
		{
			num++;
		}
		if (this.numResults[0] == this.numResults[2])
		{
			num++;
		}
		if (num == 0)
		{
			GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy += Mathf.CeilToInt((float)this.rollMoney * 1.2f);
			if (GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy > this.maxJackpot)
			{
				GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy = this.maxJackpot;
			}
		}
		else if (num == 1)
		{
			DungeonOperationMgr.Instance.ChangeMoney(Mathf.CeilToInt((float)this.rollMoney * 1.5f));
		}
		else if (num == 3)
		{
			if (this.numResults[0] == 1)
			{
				this.FireBoomEffect.Play();
				this.FireBoomAudio.Play();
				if (GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy > this.minJackpot)
				{
					GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy = this.minJackpot;
				}
			}
			else
			{
				DungeonOperationMgr.Instance.ChangeMoney(GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy);
				GlobalController.Instance.GlobalData.JackpotOfSlotsSpecialToy = this.minJackpot;
			}
		}
		this.rollMoney += this.rollCount * 10;
		this.RightTipText.text = this.rollMoney.ToString() + LocalizationMgr.Instance.GetLocalizationWord("WJ_老虎机4");
		this.state = 0;
	}

	public void OnSlotsEndButton()
	{
		if (this.state != 0)
		{
			GameController.getInstance().CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_56"), 1f, 2f, 1f, 1f);
			return;
		}
		this.isCompleted = true;
		AreaData parentArea = base.GetComponentInParent<OppositeTable>().areaData.ParentArea;
		GameController.getInstance().GameEventManager.EnterArea(parentArea.Name);
		GameController.getInstance().OnTableChange(parentArea, true);
	}

	public bool StartMouseControl;

	public bool isCompleted;

	public TextMeshProUGUI LeftTipText;

	public TextMeshProUGUI RightTipText;

	public TextMeshProUGUI JackpotTipText;

	public TextMeshProUGUI JackpotText;

	public RawImage[] image;

	public ParticleSystem FireBoomEffect;

	public AudioSource FireBoomAudio;

	private int state;

	private int[] numResults;

	private float rollStep;

	private float rollSpeed;

	private int rollCount;

	private int rollMoney;

	private int maxJackpot;

	private int minJackpot;

	private Color originColor;
}
