using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampAreaLogic : AreaLogic
{
	public override void BeforeEnter()
	{
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
		this.m_TentCard = Card.InitCardDataByID("帐篷");
		this.NewCampArea.TentCardSlot.SlotOwnerType = CardSlotData.OwnerType.SecondaryAct;
		this.m_TentCard.PutInSlotData(this.NewCampArea.TentCardSlot, true);
		this.m_SellCard = Card.InitCardDataByID("出售");
		this.NewCampArea.SellCardSlot.SlotOwnerType = CardSlotData.OwnerType.SecondaryAct;
		this.m_SellCard.PutInSlotData(this.NewCampArea.SellCardSlot, true);
		this.m_TorchCard = Card.InitCardDataByID("火把");
		this.m_TorchCard.PutInSlotData(this.NewCampArea.TorchCardSlot, true);
		this.m_KeyCard = Card.InitCardDataByID("钥匙");
		this.m_KeyCard.PutInSlotData(this.NewCampArea.KeyCardSlot, true);
	}

	public override void BeforeInit()
	{
		this.NewCampArea = UnityEngine.Object.FindObjectOfType<NewCampArea>();
		base.Data.CardSlotDatas = new List<CardSlotData>();
		for (int i = 0; i < (base.Data as SpaceAreaData).CardSlotGridHeight; i++)
		{
			for (int j = 0; j < (base.Data as SpaceAreaData).CardSlotGridWidth; j++)
			{
				if ((base.Data as SpaceAreaData).GridOpenState[i * (base.Data as SpaceAreaData).CardSlotGridWidth + j] != 0)
				{
					CardSlotData cardSlotData = new CardSlotData();
					cardSlotData.SlotOwnerType = CardSlotData.OwnerType.Area;
					cardSlotData.IconIndex = 1;
					cardSlotData.SlotType = CardSlotData.Type.Freeze;
					cardSlotData.GridPositionX = j;
					cardSlotData.GridPositionY = i;
					cardSlotData.DisplayPositionX = (float)j - 7.6f;
					cardSlotData.DisplayPositionZ = (float)(-(float)i - 4);
					if ((i == 3 || i == 4) && (j == 2 || j == 3 || j == 4))
					{
						if (i == 3)
						{
							cardSlotData.DisplayPositionZ = -5.9f;
						}
						if (i == 4)
						{
							cardSlotData.DisplayPositionZ = -7.4f;
						}
						cardSlotData.IconIndex = 4;
						this.NewCampArea.FoodSlotDatas.Add(cardSlotData);
					}
					if (i == 5 && (j == 2 || j == 3 || j == 4))
					{
						cardSlotData.DisplayPositionZ = -8.9f;
						cardSlotData.IconIndex = 4;
						this.NewCampArea.MedicineOrToolSlotDatas.Add(cardSlotData);
					}
					if (i == 4 && j > 12)
					{
						this.NewCampArea.MinionSlotDatas.Add(cardSlotData);
					}
					if (i == 4 && j == 7)
					{
						cardSlotData.IconIndex = 0;
						this.NewCampArea.SellCardSlot = cardSlotData;
					}
					if (i == 4 && j == 8)
					{
						cardSlotData.IconIndex = 0;
						this.NewCampArea.TentCardSlot = cardSlotData;
					}
					if (i == 5 && j == 7)
					{
						cardSlotData.IconIndex = 0;
						this.NewCampArea.TorchCardSlot = cardSlotData;
					}
					if (i == 5 && j == 8)
					{
						cardSlotData.IconIndex = 0;
						this.NewCampArea.KeyCardSlot = cardSlotData;
					}
					cardSlotData.TagWhiteList = 0UL;
					cardSlotData.OnlyAcceptOneCard = true;
					cardSlotData.CurrentAreaData = base.Data;
					base.Data.CardSlotDatas.Add(cardSlotData);
				}
			}
		}
	}

	public override IEnumerator OnAlreadEnter()
	{
		yield return this.freshHero();
		yield return 1;
		this.m_TorchCard.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)this.m_TorchCard.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
		this.m_TorchCard.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
		this.m_KeyCard.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)this.m_TorchCard.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
		this.m_KeyCard.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
		yield return this.CreateCardToSlotDatas(this.NewCampArea.FoodSlotDatas, TagMap.食物);
		yield return this.CreateCardToSlotDatas(this.NewCampArea.MinionSlotDatas, TagMap.随从);
		yield return this.CreateCardToSlotDatas(this.NewCampArea.MedicineOrToolSlotDatas, TagMap.工具 | TagMap.药水);
		foreach (CardSlotData cardSlotData in this.NewCampArea.FoodSlotDatas)
		{
			if (cardSlotData.ChildCardData != null)
			{
				cardSlotData.ChildCardData.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardSlotData.ChildCardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
				cardSlotData.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
			}
		}
		foreach (CardSlotData cardSlotData2 in this.NewCampArea.MedicineOrToolSlotDatas)
		{
			if (cardSlotData2.ChildCardData != null)
			{
				cardSlotData2.ChildCardData.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardSlotData2.ChildCardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
				cardSlotData2.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
			}
		}
		foreach (CardSlotData cardSlotData3 in this.NewCampArea.MinionSlotDatas)
		{
			if (cardSlotData3.ChildCardData != null)
			{
				cardSlotData3.ChildCardData.CardGameObject.PriceText.text = (Mathf.CeilToInt((float)cardSlotData3.ChildCardData.Price * DungeonOperationMgr.Instance.MoneyRate).ToString() ?? "");
				cardSlotData3.ChildCardData.CardGameObject.PriceText.transform.parent.gameObject.SetActive(true);
			}
		}
		GameController.getInstance().GameEventManager.EnterCamp();
		yield break;
	}

	public override void OnExit()
	{
	}

	private IEnumerator CreateCardToSlotDatas(List<CardSlotData> slotDatas, TagMap type)
	{
		List<CardData> cardList = new List<CardData>();
		foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
		{
			if (type == TagMap.随从)
			{
				if (cardData.HasTag(type) && !cardData.HasTag(TagMap.特殊) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.英雄))
				{
					CardData cardData2 = CardData.CopyCardData(cardData, true);
					cardData2.Price = 50 * (GameController.ins.GameData.BuyMinionCount + 1);
					cardList.Add(cardData2);
				}
			}
			else if (cardData.HasTag(type) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.特殊) && cardData.Rare <= GameController.ins.GameData.level + 1)
			{
				CardData cardData3 = CardData.CopyCardData(cardData, true);
				cardData3.Price = cardData3.Rare * 100 + SYNCRandom.Range(-20, 21);
				if (cardData3.HasTag(TagMap.药水) || cardData3.HasTag(TagMap.工具) || cardData3.HasTag(TagMap.放置物))
				{
					cardData3.Price = Mathf.RoundToInt((float)cardData3.Price * 0.8f + (float)SYNCRandom.Range(-10, 11));
				}
				cardList.Add(cardData3);
			}
		}
		List<CardData> hadCard = new List<CardData>();
		foreach (CardSlotData slotData in slotDatas)
		{
			CardData cardData4 = cardList[SYNCRandom.Range(0, cardList.Count)];
			while (hadCard.Contains(cardData4))
			{
				cardData4 = cardList[SYNCRandom.Range(0, cardList.Count)];
			}
			hadCard.Add(cardData4);
			cardData4.PutInSlotData(slotData, true);
			yield return 1;
		}
		List<CardSlotData>.Enumerator enumerator2 = default(List<CardSlotData>.Enumerator);
		yield break;
		yield break;
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
		int num = UnityEngine.Random.Range(0, 5);
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
			if (!GlobalController.Instance.IsLoadGame)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_22"), 1f, 2f, 1f, 1f);
				GlobalController.Instance.ChangeTwistedEggCoupon(1);
			}
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志8"), null, null, null, null, null, null));
		}
		else if (num == 3)
		{
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志9"), null, null, null, null, null, null));
		}
		else if (num == 4)
		{
			if (!GlobalController.Instance.IsLoadGame)
			{
				GameController.ins.CreateSubtitle(LocalizationMgr.Instance.GetLocalizationWord("ZM_22"), 1f, 2f, 1f, 1f);
				GlobalController.Instance.ChangeTwistedEggCoupon(1);
			}
			JournalsConversationManager.PutJournals(new JournalsBean(LocalizationMgr.Instance.GetLocalizationWord("SM_日志10"), null, null, null, null, null, null));
		}
		yield break;
	}

	public NewCampArea NewCampArea;

	private CardData m_TentCard;

	private CardData m_SellCard;

	private CardData m_TorchCard;

	private CardData m_KeyCard;
}
