using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
	}

	public override void BeforeInit()
	{
		if (base.Data.CardSlotDatas == null || base.Data.CardSlotDatas.Count == 0)
		{
			base.Data.CardSlotDatas = new List<CardSlotData>();
			this.EnemyCardArea = new List<CardSlotData>();
			DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
			for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
			{
				for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotType = CardSlotData.Type.Freeze;
					cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
					cardSlotData.TagWhiteList = 17179869184UL;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
					cardSlotData.IconIndex = 0;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.DisplayPositionX = (float)j - 7.6f;
					cardSlotData.DisplayPositionZ = (float)(-(float)i - 4);
					cardSlotData.CurrentAreaData = base.Data;
					if ((base.Data as SpaceAreaData).GridOpenState[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j] > 0)
					{
						cardSlotData = new CardSlotData();
						cardSlotData.SlotType = CardSlotData.Type.OnlyPut;
						cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
						cardSlotData.TagWhiteList = 17179869184UL;
						cardSlotData.GridPositionX = j;
						cardSlotData.GridPositionY = i;
						cardSlotData.IconIndex = 3;
						cardSlotData.OnlyAcceptOneCard = true;
						cardSlotData.DisplayPositionX = (float)j - 7.6f;
						cardSlotData.DisplayPositionZ = (float)(-(float)i - 4);
						cardSlotData.CurrentAreaData = base.Data;
						if (j < 5)
						{
							if (!cardSlotData.Attrs.ContainsKey("Col"))
							{
								cardSlotData.Attrs.Add("Col", j % 5 - 2);
							}
							else
							{
								cardSlotData.Attrs["Col"] = j % 5 - 2;
							}
							DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData);
						}
						if (i == 4)
						{
							if (j > 8 && j < 16)
							{
								this.EnemyCardArea.Add(cardSlotData);
							}
							if (j == 16)
							{
								this.ExitsSlot = cardSlotData;
							}
						}
					}
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
			this.m_EnemyCard = GameController.ins.CardDataModMap.getCardDataByModID("无尽怪物出口");
			this.m_EnemyCard = CardData.CopyCardData(this.m_EnemyCard, true);
			this.m_EnemyCard.PutInSlotData(this.ExitsSlot, true);
			return;
		}
		this.EnemyCardArea = new List<CardSlotData>();
		DungeonOperationMgr.Instance.BattleArea = new List<CardSlotData>();
		for (int k = 0; k < (base.Data as SpaceAreaData).CardSlotGridHeight; k++)
		{
			for (int l = 0; l < (base.Data as SpaceAreaData).CardSlotGridWidth; l++)
			{
				CardSlotData cardSlotData2 = (base.Data as SpaceAreaData).CardSlotDatas[k * (base.Data as SpaceAreaData).CardSlotGridWidth + l];
				if ((base.Data as SpaceAreaData).GridOpenState[k * (base.Data as SpaceAreaData).CardSlotGridWidth + l] > 0)
				{
					if (l < 5)
					{
						if (!cardSlotData2.Attrs.ContainsKey("Col"))
						{
							cardSlotData2.Attrs.Add("Col", l % 5 - 2);
						}
						else
						{
							cardSlotData2.Attrs["Col"] = l % 5 - 2;
						}
						DungeonOperationMgr.Instance.BattleArea.Add(cardSlotData2);
					}
					if (k == 4)
					{
						if (l > 8 && l < 16)
						{
							this.EnemyCardArea.Add(cardSlotData2);
						}
						if (l == 16)
						{
							this.ExitsSlot = cardSlotData2;
						}
					}
				}
			}
		}
		this.m_EnemyCard = this.ExitsSlot.ChildCardData;
	}

	public override IEnumerator OnAlreadEnter()
	{
		yield return this.freshHero();
		BGMusicManager.Instance.PlayBGMusic(18, 0, null);
		yield return null;
		if (GameController.ins.GameData.step == 0)
		{
			ActData actData = new ActData();
			actData.Type = "Act/BattleTavern";
			actData.Model = "ActTable/营地商店";
			(GameController.ins.GameData.PlayerCardData.CardGameObject.StartAct(actData) as BattleTavernAct).InitBattleAct("");
		}
		this.EnemyCardArea[0].CardSlotGameObject.transform.localPosition = new Vector3(1.38f, 0.24f, -8f);
		yield return GameController.ins.ShowTable(TableType.BattleTable, false);
		for (int i = this.m_EnemyCard.CardLogics.Count - 1; i >= 0; i--)
		{
			GameController.getInstance().StartCoroutine(this.m_EnemyCard.CardLogics[i].OnEnterArea("Infinity"));
		}
		yield break;
	}

	public override void OnExit()
	{
	}

	private IEnumerator freshHero()
	{
		yield return null;
		yield return null;
		if (GameController.ins.PlayerToy == null)
		{
			GameController.ins.PlayerToy = GameController.ins.GameData.PlayerCardData.CardGameObject;
			GameController.ins.PlayerToy.gameObject.AddComponent<Hero>();
		}
		if (GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>() == null)
		{
			GameController.ins.PlayerToy.gameObject.AddComponent<Hero>();
		}
		DungeonController.Instance.m_Hero = GameController.ins.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
		for (int i = 0; i < GameController.ins.GameData.SlotsOnPlayerTable.Count; i++)
		{
			if (GameController.ins.GameData.SlotsOnPlayerTable[i].Attrs.ContainsKey("Col"))
			{
				GameController.ins.GameData.SlotsOnPlayerTable[i].Attrs["Col"] = int.Parse(GameController.ins.GameData.SlotsOnPlayerTable[i].Attrs["Col"].ToString());
			}
		}
		if (GlobalController.Instance.IsLoadGame)
		{
			GameController.ins.PlayerCardSlot = GameController.ins.GameData.PlayerCardData.CurrentCardSlotData.CardSlotGameObject;
			GameController.ins.UIController.EnergyUI.refreshEnery();
		}
		yield break;
	}

	public CardSlotData ChessmanSlot;

	public List<CardSlotData> EnemyCardArea;

	public CardSlotData ExitsSlot;

	private CardData m_EnemyCard;
}
