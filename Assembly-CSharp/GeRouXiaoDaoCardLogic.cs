using System;
using System.Collections;
using System.Collections.Generic;

public class GeRouXiaoDaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "割肉";
		this.Desc = "攻击后获得一块肉。";
	}

	public override IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		base.OnUserAsArms(origin, Target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(origin))
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(origin, -this.CardData.ATK, origin, false, 0, true, false);
			List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
			CardSlotData cardSlotData = null;
			foreach (CardSlotData cardSlotData2 in playerSlotSets)
			{
				if (cardSlotData2 != null && (cardSlotData2.TagWhiteList == 0UL || (cardSlotData2.TagWhiteList & 65536UL) != 0UL) && cardSlotData2.ChildCardData == null)
				{
					cardSlotData = cardSlotData2;
					break;
				}
			}
			if (cardSlotData == null)
			{
				yield break;
			}
			List<string> list = new List<string>();
			foreach (CardData cardData in GameController.ins.CardDataModMap.Cards)
			{
				if (cardData.HasTag(TagMap.肉) && cardData.Rare == 1)
				{
					list.Add(cardData.ModID);
				}
			}
			if (list.Count <= 0)
			{
				yield break;
			}
			Card.InitCardDataByID(list[SYNCRandom.Range(0, list.Count)]).PutInSlotData(cardSlotData, true);
		}
		yield break;
	}
}
