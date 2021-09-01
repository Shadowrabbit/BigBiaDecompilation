using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChestLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "宝箱";
		this.Desc = "该单位会随机掉落一件道具。";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			this.StartGiftAct();
		}
		yield break;
	}

	private void StartGiftAct()
	{
		List<CardData> cards = GameController.getInstance().CardDataModMap.Cards;
		List<string> lockedItemsModID = GlobalController.Instance.GlobalData.LockedItemsModID;
		List<string> list = new List<string>();
		foreach (CardData cardData in cards)
		{
			if (cardData.HasTag(TagMap.道具) && !lockedItemsModID.Contains(cardData.ModID))
			{
				list.Add(cardData.ModID);
			}
		}
		ActData actData = new ActData();
		actData.Type = "Act/Gift";
		actData.Model = "ActTable/Gift";
		(GameController.getInstance().GameData.PlayerCardData.CardGameObject.StartAct(actData) as GiftAct).GiftNames.Add(list[UnityEngine.Random.Range(0, list.Count)]);
	}
}
