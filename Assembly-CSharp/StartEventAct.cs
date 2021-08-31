using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class StartEventAct : GameAct
{
	private void Start()
	{
		this.Init();
		GameController.getInstance().DialogueController.Actor = GameController.getInstance().PlayerToy;
		GameController.getInstance().DialogueController.Conversant = this.Source;
		GameController.getInstance().DialogueController.ConversantSlot = this.Source.CurrentCardSlot;
		GameController.getInstance().GameEventManager.OpenGameUI();
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		CardData cardData2;
		if (this.Source.CardData.HasTag(TagMap.基本))
		{
			foreach (CardData cardData in cards)
			{
				if (cardData.HasTag(TagMap.事件) && !cardData.HasTag(TagMap.基本) && !cardData.HasTag(TagMap.特殊) && cardData.Attrs.ContainsKey("Theme"))
				{
					DungeonTheme dungeonTheme = (DungeonTheme)Enum.Parse(typeof(DungeonTheme), cardData.GetAttr("Theme"));
					if (GameController.ins.GameData.DungeonTheme == DungeonTheme.Arena)
					{
						if (dungeonTheme == DungeonTheme.Arena)
						{
							list.Add(CardData.CopyCardData(cardData, true));
						}
					}
					else if (dungeonTheme == GameController.ins.GameData.DungeonTheme || dungeonTheme == DungeonTheme.Normal)
					{
						list.Add(CardData.CopyCardData(cardData, true));
					}
				}
			}
			cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
		}
		else
		{
			cardData2 = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID(this.Source.CardData.ModID), true);
		}
		DialogueManager.StartConversation(cardData2.ModID, base.transform, this.Source.CurrentCardSlot.transform);
		CardSlotData cardSlotData = this.Source.CurrentCardSlot.CardSlotData;
		GameController.getInstance().GameEventManager.StartTalking();
	}

	public void OnConversationEnd(Transform actor)
	{
		this.isDone = true;
	}

	private void Update()
	{
		if (this.isDone)
		{
			this.Source.CardData.DeleteCardData();
			DungeonOperationMgr.Instance.FlipAllFlopableCards();
			this.ActEnd();
		}
	}

	private bool isDone;
}
