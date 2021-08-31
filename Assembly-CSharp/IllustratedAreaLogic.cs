﻿using System;
using System.Collections;
using UnityEngine;

public class IllustratedAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		this.m_CameraPos = Camera.main.transform.localPosition;
		this.m_CameraRotate = Camera.main.transform.localRotation;
		Camera.main.transform.localPosition = new Vector3(-0.86f, 2.69f, 4.71f);
		Camera.main.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.ins.UIController.HideBlackMask(delegate
		{
		}, 0.5f);
		yield break;
	}

	public override void OnExit()
	{
	}

	private Vector3 m_CameraPos;

	private Quaternion m_CameraRotate;
}
