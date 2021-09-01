using System;
using DG.Tweening;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
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
		base.transform.DOMove(base.transform.position + new Vector3(0f, -0.05f, 0f), 0.1f, false);
	}

	private void OnMouseUp()
	{
		if ((UIController.LockLevel & UIController.UILevel.ActTable) > UIController.UILevel.None)
		{
			return;
		}
		if (!this.Enable)
		{
			return;
		}
		base.transform.DOMove(base.transform.position + new Vector3(0f, 0.05f, 0f), 0.1f, false);
		this.GameAct.OnUpgradeButton();
	}

	public GameAct GameAct;

	public bool Enable = true;
}
