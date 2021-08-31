using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCampAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
		List<CardSlotData> cardSlotDatas = base.Data.CardSlotDatas;
		foreach (CardSlotData cardSlotData in cardSlotDatas)
		{
			cardSlotData.SlotType = CardSlotData.Type.Freeze;
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.DeleteCardData();
			}
		}
		try
		{
			if (!GlobalController.Instance.IsLoadGame)
			{
				GameController.ins.SaveGame();
			}
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_21"), 1f, 2f, 1f, 1f);
		}
		catch
		{
			Debug.Log("储存游戏失败");
		}
		if (GameController.ins.GameData.level == 1 || GameController.ins.GameData.level == 3)
		{
			if (cardSlotDatas[0].ChildCardData == null)
			{
				this.m_Tarven = Card.InitCardDataByID("事件酒馆");
				this.m_Tarven.PutInSlotData(cardSlotDatas[0], true);
			}
			if (cardSlotDatas[1].ChildCardData == null)
			{
				this.m_Shop = Card.InitCardDataByID("商铺");
				this.m_Shop.PutInSlotData(cardSlotDatas[1], true);
			}
			if (cardSlotDatas[2].ChildCardData == null)
			{
				this.m_BonFire = Card.InitCardDataByID("帐篷");
				this.m_BonFire.PutInSlotData(cardSlotDatas[2], true);
			}
		}
		else
		{
			if (cardSlotDatas[1].ChildCardData == null)
			{
				this.m_Shop = Card.InitCardDataByID("商铺");
				this.m_Shop.PutInSlotData(cardSlotDatas[0], true);
			}
			if (cardSlotDatas[2].ChildCardData == null)
			{
				this.m_BonFire = Card.InitCardDataByID("帐篷");
				this.m_BonFire.PutInSlotData(cardSlotDatas[1], true);
			}
		}
		GameController.ins.StartCoroutine(this.freshHero());
	}

	public override void BeforeInit()
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
		int num = SYNCRandom.Range(0, 5);
		if (num == 0)
		{
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志6"), null, null, null, null, null, null));
		}
		else if (num == 1)
		{
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志7"), null, null, null, null, null, null));
		}
		else if (num == 2)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_22"), 1f, 2f, 1f, 1f);
			GlobalController.Instance.ChangeTwistedEggCoupon(1);
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志8"), null, null, null, null, null, null));
		}
		else if (num == 3)
		{
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志9"), null, null, null, null, null, null));
		}
		else if (num == 4)
		{
			GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_22"), 1f, 2f, 1f, 1f);
			GlobalController.Instance.ChangeTwistedEggCoupon(1);
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志10"), null, null, null, null, null, null));
		}
		yield break;
	}

	public override IEnumerator OnAlreadEnter()
	{
		GameController.getInstance().GameEventManager.EnterCamp();
		yield break;
	}

	public override void OnExit()
	{
	}

	private CardSlotData GetEmptySlotFromPlayerTable()
	{
		for (int i = 0; i < GameController.getInstance().PlayerSlotSets.Count; i++)
		{
			if (i % (GameController.getInstance().PlayerSlotSets.Count / 3) < 9 && GameController.getInstance().PlayerSlotSets[i].ChildCardData == null && GameController.getInstance().PlayerSlotSets[i].TagWhiteList == 128UL)
			{
				return GameController.getInstance().PlayerSlotSets[i];
			}
		}
		return null;
	}

	private CardData m_Tarven;

	private CardData m_Train;

	private CardData m_Shop;

	private CardData m_CastingRoom;

	private CardData m_BonFire;

	private CardData m_TrainingRoom;
}
