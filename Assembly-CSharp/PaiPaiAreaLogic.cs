using System;
using System.Collections;
using UnityEngine;

public class PaiPaiAreaLogic : AreaLogic
{
	public override IEnumerator OnAlreadEnter()
	{
		GameController.ins.UIController.HideBlackMask(null, 0.5f);
		Camera.main.transform.localPosition = new Vector3(0f, 25.56f, -8.44f);
		Camera.main.transform.localRotation = Quaternion.Euler(19.4f, 0f, 0f);
		yield return null;
		yield break;
	}

	public override void BeforeInit()
	{
	}

	public override void BeforeEnter()
	{
	}

	public override void OnExit()
	{
	}
}
