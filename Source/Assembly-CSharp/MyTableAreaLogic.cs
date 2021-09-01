using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTableAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		this.CameraOldPosition = Camera.main.transform.localPosition;
		Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x, -3.6f, 2.1f);
		Camera.main.gameObject.AddComponent<CameraScaleAndRoll>().MCamera = Camera.main;
		Debug.Log("相机组价加载完毕");
	}

	private void OnCardPutInSlot(CardSlotData arg1, CardData arg2)
	{
		GlobalController.Instance.GlobalData.MainTableCardsWithPos = new Dictionary<int, string>();
		for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotDatas.Count; i++)
		{
			if (base.Data.CardSlotDatas[i].ChildCardData != null)
			{
				GlobalController.Instance.GlobalData.MainTableCardsWithPos.Add(i, base.Data.CardSlotDatas[i].ChildCardData.ModID);
			}
		}
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
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.TagWhiteList = 32UL;
					cardSlotData.DisplayPositionX = (float)j - 9.5f;
					cardSlotData.DisplayPositionZ = (float)i - 3.2f - (float)(base.Data as SpaceAreaData).CardSlotGridHeight - 1f;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
			if (GlobalController.Instance.GlobalData.MainTableCardsWithPos != null && GlobalController.Instance.GlobalData.MainTableCardsWithPos.Count > 0)
			{
				bool flag = false;
				foreach (KeyValuePair<int, string> keyValuePair in GlobalController.Instance.GlobalData.MainTableCardsWithPos)
				{
					if (keyValuePair.Value == "时空挖掘机")
					{
						flag = true;
					}
					Card.InitCardDataByID(keyValuePair.Value).PutInSlotData(base.Data.CardSlotDatas[keyValuePair.Key], true);
				}
				if (!flag)
				{
					Card.InitCardDataByID("时空挖掘机").PutInSlotData(base.Data.CardSlotDatas[410], true);
				}
			}
			else
			{
				Card.InitCardDataByID("时空挖掘机").PutInSlotData(base.Data.CardSlotDatas[410], true);
			}
		}
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Combine(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
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
		GameEventManager gameEventManager = GameController.ins.GameEventManager;
		gameEventManager.OnCardPutInSlot = (Action<CardSlotData, CardData>)Delegate.Remove(gameEventManager.OnCardPutInSlot, new Action<CardSlotData, CardData>(this.OnCardPutInSlot));
	}

	private Vector3 CameraOldPosition;
}
