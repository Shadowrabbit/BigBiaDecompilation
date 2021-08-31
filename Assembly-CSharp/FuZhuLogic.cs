using System;
using System.Collections;
using System.Collections.Generic;

public class FuZhuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "辅助";
		this.Desc = "若未攻击，将自己的充能转移至上方1格的随从";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			yield break;
		}
		if (this.CardData.IsAttacked)
		{
			yield break;
		}
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
			{
				base.ShowMe();
				cardSlotData.ChildCardData.MP += this.CardData.MP;
				this.CardData.MP -= this.CardData.MP;
			}
		}
		yield break;
	}
}
