using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropDownScreen : ScreenBase
{
	public DropDownScreen() : base(UIPathConstant.DropDown)
	{
	}

	public override void OnLoadComplete(object asset)
	{
		base.OnLoadComplete(asset);
		this.dropDownPanel = (this.uIControlBase as DropDownPanel);
		this.OnOpen();
	}

	public override void OnOpen()
	{
		base.OnOpen();
		this.SetDropDown();
	}

	public override void OnClose()
	{
		base.OnClose();
	}

	public void SetDropDown()
	{
		if (this.objects == null || this.objects.Length == 0)
		{
			this.OnCloseDropDown();
			return;
		}
		ScrollRect scrollRect = this.dropDownPanel.scrollRect;
		Vector3 v = (Vector3)this.objects[0];
		List<Dropdown.OptionData> collection = this.objects[1] as List<Dropdown.OptionData>;
		UnityAction<int> callBack = this.objects[2] as UnityAction<int>;
		this.DropDownList.Clear();
		this.DropDownList.AddRange(collection);
		this.DropDownList.Add(this.cancelOption);
		RectTransform component = scrollRect.GetComponent<RectTransform>();
		Vector2 screenPos = v;
		this.ComputeAnchorPosition(component, screenPos, this.DropDownList.Count);
		Vector2 sizeDelta = new Vector2(165f, (float)(30 * this.DropDownList.Count + 4 * (this.DropDownList.Count + 1)));
		scrollRect.GetComponent<RectTransform>().sizeDelta = sizeDelta;
		if (this.DropDownList.Count > this.dropDownPanel.Buttons.Count)
		{
			this.AddButton(this.DropDownList.Count);
		}
		this.SetAllButtonsState(false);
		for (int i = 0; i < this.DropDownList.Count; i++)
		{
			PxButton pxButton = this.dropDownPanel.Buttons[i];
			pxButton.text.text = this.DropDownList[i].text;
			pxButton.gameObject.SetActive(true);
			pxButton.SetButtonClickHandler(i, callBack);
			pxButton.AddButtonClickHandler(new UnityAction(this.OnCloseDropDown));
		}
		this.PlayUIAnim();
	}

	private void CloseDropDown(int level)
	{
		base.GameUIController.CloseUI<DropDownScreen>();
	}

	private void AddButton(int optionCount)
	{
		RectTransform component = this.dropDownPanel.Buttons[this.dropDownPanel.Buttons.Count - 1].GetComponent<RectTransform>();
		int num = optionCount - this.dropDownPanel.Buttons.Count;
		for (int i = 0; i < num; i++)
		{
			PxButton pxButton = UnityEngine.Object.Instantiate<PxButton>(this.dropDownPanel.button);
			pxButton.transform.SetParent(this.dropDownPanel.buttonParent);
			RectTransform component2 = pxButton.GetComponent<RectTransform>();
			component2.anchoredPosition3D = component.anchoredPosition - new Vector2(0f, (float)((i + 1) * 34));
			component2.localRotation = Quaternion.identity;
			component2.localScale = Vector3.one;
			this.dropDownPanel.Buttons.Add(pxButton);
		}
	}

	private void SetAllButtonsState(bool active)
	{
		foreach (PxButton pxButton in this.dropDownPanel.Buttons)
		{
			pxButton.gameObject.SetActive(active);
		}
	}

	private void PlayUIAnim()
	{
		this.dropDownPanel.scrollRect.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
		this.dropDownPanel.scrollRect.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
	}

	public void OnCloseDropDown()
	{
		base.GameUIController.CloseUI<DropDownScreen>();
	}

	private void ComputeAnchorPosition(RectTransform rect, Vector2 screenPos, int optionCount)
	{
		float x = (float)(Screen.width / 2);
		float num = (float)(Screen.height / 2);
		screenPos -= new Vector2(x, num + (float)(optionCount * 18));
		rect.anchoredPosition = screenPos;
	}

	public DropDownPanel dropDownPanel;

	public List<Dropdown.OptionData> DropDownList = new List<Dropdown.OptionData>();

	public Dropdown.OptionData cancelOption = new Dropdown.OptionData("取消");
}
