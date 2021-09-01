using System;
using TMPro;
using UnityEngine;

public class FaithPanelController : MonoBehaviour
{
	private void Start()
	{
		GameController.ins.GameData.CurFaithPoint++;
		this.CurPoint.text = (GameController.ins.GameData.CurFaithPoint.ToString() ?? "");
	}

	private void Update()
	{
	}

	public void OnClose()
	{
		UnityEngine.Object.Destroy(base.gameObject);
		GameController.ins.UIController.ShowBlackMask(delegate
		{
			GameController.ins.UIController.HideBlackMask(delegate
			{
			}, 0.5f);
		}, 0.5f);
	}

	public TMP_Text CurPoint;
}
