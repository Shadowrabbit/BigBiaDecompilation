using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PxButton : MonoBehaviour
{
	public void SetButtonClickHandler(int val, UnityAction<int> callBack)
	{
		this.val = val;
		this.callBack = callBack;
		this.button.onClick.RemoveAllListeners();
		this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
	}

	private void OnButtonClick()
	{
		UnityAction<int> unityAction = this.callBack;
		if (unityAction == null)
		{
			return;
		}
		unityAction(this.val);
	}

	public void AddButtonClickHandler(UnityAction action)
	{
		this.button.onClick.AddListener(action);
	}

	public Button button;

	public TextMeshProUGUI text;

	public int val;

	public UnityAction<int> callBack;
}
