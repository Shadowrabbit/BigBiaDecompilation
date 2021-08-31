using System;
using UnityEngine;

public class OKButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			return;
		}
		if (!this.Enable)
		{
			return;
		}
		this.GameAct.OnActOKButton();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public GameAct GameAct;

	public bool Enable = true;
}
