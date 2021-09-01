using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideCanvasController : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ShowGuideContent(int startIndex, int endIndex, GuideCanvasController.ShowGuideCallBack call)
	{
		call();
		this.currentSpriteIndex = startIndex;
		this.firstSpriteIndex = startIndex;
		this.lastSpriteIndex = endIndex;
		this.MainSprite.sprite = this.SpriteList[this.currentSpriteIndex];
		this.MainSprite.gameObject.SetActive(true);
		if (endIndex == startIndex)
		{
			this.ContinueBtn.SetActive(false);
			this.BackBtn.SetActive(false);
			this.OKBtn.SetActive(true);
			return;
		}
		this.ContinueBtn.SetActive(true);
		this.BackBtn.SetActive(false);
		this.OKBtn.SetActive(false);
	}

	public void NextSprite()
	{
		if (this.currentSpriteIndex < this.lastSpriteIndex)
		{
			this.currentSpriteIndex++;
			this.MainSprite.sprite = this.SpriteList[this.currentSpriteIndex];
			if (this.currentSpriteIndex == this.lastSpriteIndex)
			{
				this.ContinueBtn.SetActive(false);
				this.OKBtn.SetActive(true);
			}
			this.BackBtn.SetActive(true);
		}
	}

	public void PreSprite()
	{
		if (this.currentSpriteIndex > this.firstSpriteIndex)
		{
			this.currentSpriteIndex--;
			this.MainSprite.sprite = this.SpriteList[this.currentSpriteIndex];
			if (this.currentSpriteIndex == this.firstSpriteIndex)
			{
				this.BackBtn.SetActive(false);
			}
			this.OKBtn.SetActive(false);
			this.ContinueBtn.SetActive(true);
		}
	}

	public void OnOKBtnClick()
	{
		GameController.getInstance().ChangeTimePause(false);
		Time.timeScale = 1f;
		base.gameObject.SetActive(false);
	}

	public void OnCloseBtn()
	{
		GameController.getInstance().ChangeTimePause(false);
		Time.timeScale = 1f;
		base.gameObject.SetActive(false);
	}

	public Image MainSprite;

	public GameObject BackBtn;

	public GameObject ContinueBtn;

	public GameObject OKBtn;

	[Header("应到面板图片集合")]
	public List<Sprite> SpriteList;

	private int currentSpriteIndex;

	private int firstSpriteIndex;

	private int lastSpriteIndex;

	public delegate void ShowGuideCallBack();
}
