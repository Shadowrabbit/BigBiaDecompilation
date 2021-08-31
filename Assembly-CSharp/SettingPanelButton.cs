using System;
using UnityEngine;

public class SettingPanelButton : MonoBehaviour
{
	private void Start()
	{
	}

	private void OnMouseDown()
	{
		if ((UIController.UILevel.PlayerSlot & UIController.LockLevel) > UIController.UILevel.None)
		{
			return;
		}
		GlobalController.Instance.ShowSettingPanel();
	}
}
