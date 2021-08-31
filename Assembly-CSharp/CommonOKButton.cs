using System;
using UnityEngine;

public class CommonOKButton : MonoBehaviour
{
	private void OnMouseUpAsButton()
	{
		Action onClickOkButton = this.OnClickOkButton;
		if (onClickOkButton == null)
		{
			return;
		}
		onClickOkButton();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public Action OnClickOkButton;
}
