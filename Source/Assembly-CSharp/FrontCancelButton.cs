using System;
using UnityEngine;

public class FrontCancelButton : MonoBehaviour
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
		this.GameAct.OnActFrontCancelButton();
	}

	public GameAct GameAct;

	public bool Enable = true;
}
