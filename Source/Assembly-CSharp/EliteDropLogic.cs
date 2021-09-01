using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteDropLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "精英掉落";
		this.Desc = "击杀本单位来获得一件物品...";
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.道具))
			{
				list.Add(cardData);
			}
		}
		CardData cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
		base.GameController.DialogueController.StartGift(cardData2.ModID);
		if (this.CardData != null && this.CardData.Attrs.ContainsKey("UnlockItem") && !GlobalController.Instance.GlobalData.LockedItemsModID.Contains(this.CardData.Attrs["UnlockItem"].ToString()) && !GlobalController.Instance.GlobalData.UnLockedItemsModID.Contains(this.CardData.Attrs["UnlockItem"].ToString()))
		{
			GlobalController.Instance.TempLockedObjs.Add(Card.InitCardDataByID(this.CardData.Attrs["UnlockItem"].ToString()));
		}
		yield break;
	}
}
