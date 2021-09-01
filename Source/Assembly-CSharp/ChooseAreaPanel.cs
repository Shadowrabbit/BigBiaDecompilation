using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseAreaPanel : MonoBehaviour
{
	private void Start()
	{
		this.button.onClick.AddListener(new UnityAction(this.ClosePanel));
	}

	private void Update()
	{
	}

	private void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	public Button button;
}
