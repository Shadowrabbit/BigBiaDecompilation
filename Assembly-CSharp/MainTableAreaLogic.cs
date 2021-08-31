using System;
using System.Collections.Generic;
using UnityEngine;

public class MainTableAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		this.CameraOldPosition = Camera.main.transform.localPosition;
		this.CameraOldRotation = Camera.main.transform.localRotation;
		Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, -14.5f, -0.15f);
		Camera.main.transform.localEulerAngles = new Vector3(-38.55f, 0f, 0f);
		GameController.ins.UIController.MainLight.intensity = 1.1f;
		BGMusicManager.Instance.PlayBGMusic(1, 0, null);
	}

	public override void BeforeInit()
	{
	}

	public override void OnGameLoaded()
	{
		base.OnGameLoaded();
	}

	public override void OnExit()
	{
		GameController.ins.UIController.MainLight.intensity = 1f;
		GlobalController.Instance.GlobalData.MainTableCardsWithPos = new Dictionary<int, string>();
		for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotDatas.Count; i++)
		{
			if (base.Data.CardSlotDatas[i].ChildCardData != null)
			{
				GlobalController.Instance.GlobalData.MainTableCardsWithPos.Add(i, base.Data.CardSlotDatas[i].ChildCardData.ModID);
			}
		}
		UnityEngine.Object.Destroy(Camera.main.GetComponent<CameraScaleAndRoll>());
		Camera.main.transform.localPosition = this.CameraOldPosition;
		Camera.main.transform.localRotation = this.CameraOldRotation;
	}

	private Vector3 CameraOldPosition;

	private Quaternion CameraOldRotation;
}
