using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllustratedBookAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		this.CameraOldPosition = Camera.main.transform.localPosition;
		Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, -2.18f, 10.09f);
		Camera.main.gameObject.AddComponent<CameraScaleAndRoll>().MCamera = Camera.main;
		Debug.Log("相机组价加载完毕");
	}

	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Normal;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)j - 9.5f;
					cardSlotData.DisplayPositionZ = (float)i - 3.2f - (float)(base.Data as SpaceAreaData).CardSlotGridHeight - 1f;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
			Card.InitCardDataByID("不华鱼屋").PutInSlotData(base.Data.CardSlotDatas[7], true);
			Card.InitCardDataByID("商会").PutInSlotData(base.Data.CardSlotDatas[414], true);
			Card.InitCardDataByID("典当行").PutInSlotData(base.Data.CardSlotDatas[412], true);
			Card.InitCardDataByID("农场").PutInSlotData(base.Data.CardSlotDatas[410], true);
			Card.InitCardDataByID("厨房").PutInSlotData(base.Data.CardSlotDatas[408], true);
			Card.InitCardDataByID("地下城生成器").PutInSlotData(base.Data.CardSlotDatas[405], true);
		}
	}

	public override void OnGameLoaded()
	{
		base.OnGameLoaded();
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.ins.UIController.HideBlackMask(null, 0.5f);
		yield break;
	}

	public override void OnExit()
	{
		UnityEngine.Object.Destroy(Camera.main.GetComponent<CameraScaleAndRoll>());
		Camera.main.transform.localPosition = this.CameraOldPosition;
	}

	private Vector3 CameraOldPosition;
}
