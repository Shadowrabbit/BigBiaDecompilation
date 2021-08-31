using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Freeze;
					cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
					cardSlotData.TagWhiteList = 8521215115264UL;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)j - 9.44f;
					cardSlotData.DisplayPositionZ = (float)(-(float)i) + 59.05f;
					cardSlotData.IconIndex = 13;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
		}
		this.m_CameraPos = Camera.main.transform.localPosition;
		this.m_CameraRotate = Camera.main.transform.localRotation;
		Camera.main.transform.localPosition = new Vector3(0.02f, 54.54f, 20.65f);
		Camera.main.transform.localRotation = Quaternion.Euler(-4.631f, 0f, 0f);
		UnityEngine.Object.FindObjectOfType<BuildingArea>().SlotDatas = base.Data.CardSlotDatas;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().UIController.HideMoneyPanel();
		GameController.ins.UIController.HideBlackMask(delegate
		{
			GameController.getInstance().UIController.HideCardTablesButtons();
		}, 0.5f);
		int num = 0;
		foreach (CardSlotData cardSlotData in base.Data.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && !string.IsNullOrEmpty(cardSlotData.ChildCardData.ModID) && !cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				num += cardSlotData.ChildCardData.CoveredWidth * cardSlotData.ChildCardData.CoveredHeight;
			}
		}
		UnityEngine.Object.FindObjectOfType<BuildingArea>().InitAreaDataDesc(num);
		yield break;
	}

	public override void OnExit()
	{
		UnityEngine.Object.FindObjectOfType<BuildingArea>().ExitArea();
		GameController.getInstance().UIController.ShowCardTablesButtons();
		GameController.getInstance().UIController.ShowMoneyPanel();
	}

	private Vector3 m_CameraPos;

	private Quaternion m_CameraRotate;
}
