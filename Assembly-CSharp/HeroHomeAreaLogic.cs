using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroHomeAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		this.m_CameraPos = Camera.main.transform.localPosition;
		this.m_CameraRotate = Camera.main.transform.localRotation;
		Camera.main.transform.localPosition = new Vector3(0.02f, 51.25f, 20.6f);
		Camera.main.transform.localRotation = Quaternion.Euler(-12.288f, 0f, 0f);
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.ins.UIController.HideBlackMask(delegate
		{
			GameController.getInstance().UIController.ShowBackToHomeButton();
		}, 0.5f);
		Camera.main.transform.GetComponent<PhysicsRaycaster>().enabled = true;
		yield break;
	}

	public override void OnExit()
	{
		Camera.main.transform.GetComponent<PhysicsRaycaster>().enabled = false;
	}

	private Vector3 m_CameraPos;

	private Quaternion m_CameraRotate;
}
