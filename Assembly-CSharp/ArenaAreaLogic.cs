using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ArenaAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		this.oldCamTrans = Camera.main.transform.position;
		Camera.main.transform.DOMove(this.camTrans, 2f, false).OnComplete(new TweenCallback(this.StartBattle));
	}

	public override void BeforeInit()
	{
		this.isWork = false;
		this.StartBattleButton = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/开始战斗"));
		this.StartBattleButton.transform.position = new Vector3(13.21f, 0f, 8f);
		this.StartBattleButton.SetActive(false);
	}

	public override void OnExit()
	{
		Camera.main.transform.DOMove(this.oldCamTrans, 2f, false);
	}

	public override void OnGameLoaded()
	{
		base.OnGameLoaded();
	}

	private void StartBattle()
	{
		for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
		{
			for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
			{
				CardData childCardData = base.Data.CardSlotDatas[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j].ChildCardData;
				if (childCardData != null)
				{
					if (i < 7)
					{
						if (childCardData.Attrs.ContainsKey("Flag"))
						{
							childCardData.Attrs["Flag"] = 2;
						}
						else if (childCardData.Name == "战斗核心")
						{
							childCardData.Attrs.Add("Flag", 2);
							childCardData.MaxHP = 200;
							childCardData.HP = 200;
						}
						try
						{
							childCardData.CardGameObject.DisplayGameObjectOnAreaTable.SetActive(true);
							childCardData.CardGameObject.DisplayGameObjectOnPlayerTable.SetActive(false);
						}
						catch
						{
							Debug.LogError("没事");
						}
						childCardData.CardGameObject.BottomGameObject.SetActive(false);
					}
					else if (childCardData.Attrs.ContainsKey("Flag"))
					{
						childCardData.Attrs["Flag"] = 1;
					}
					else if (childCardData.Name == "战斗核心")
					{
						childCardData.Attrs.Add("Flag", 1);
						childCardData.MaxHP = 10000;
						childCardData.HP = 10000;
					}
				}
			}
		}
		this.isWork = true;
	}

	public override void OnTick()
	{
		base.OnTick();
		if (!this.isWork)
		{
			return;
		}
		GameController.getInstance().ChangeTimeScale(2f);
		if (this.EnemyHeart == null || this.EnemyHeart.HP <= 0)
		{
			DialogueManager.StartConversation("战斗情境胜利");
			this.isWork = false;
			this.ExitArea();
		}
		if (this.AllyHeart == null || this.AllyHeart.HP <= 0)
		{
			DialogueManager.StartConversation("战斗情境胜利");
			this.isWork = false;
			this.ExitArea();
		}
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
		{
			Collider collider = raycastHit.collider;
			if (this.StartBattleButton != null)
			{
				collider == this.StartBattleButton.GetComponent<BoxCollider>();
			}
		}
		List<CardSlotData> inputCardSlotDataList = base.Data.InputCardSlotDataList;
		for (int i = 0; i < inputCardSlotDataList.Count; i++)
		{
			if (inputCardSlotDataList[i].ChildCardData == null || string.IsNullOrEmpty(inputCardSlotDataList[i].ChildCardData.ID))
			{
				CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("弩箭"), true);
				cardData.Count = 99;
				cardData.ChangeCardSlot(inputCardSlotDataList[i]);
			}
		}
	}

	public void ExitArea()
	{
		foreach (CardSlotData cardSlotData in this.m_Data.ParentArea.CardSlotDatas)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.Attrs.ContainsKey("AreaDataID") && cardSlotData.ChildCardData.Attrs["AreaDataID"].ToString() == this.m_Data.ID)
			{
				cardSlotData.ChildCardData.DeleteCardData();
			}
		}
		GameController.getInstance().OnTableChange(this.m_Data.ParentArea, true);
		UnityEngine.Object.Destroy(this.StartBattleButton);
	}

	private CardData EnemyHeart;

	private CardData AllyHeart;

	private GameObject StartBattleButton;

	private Vector3 camTrans = new Vector3(0f, 23.5f, -2.6f);

	private Vector3 oldCamTrans;

	private bool isWork = true;
}
