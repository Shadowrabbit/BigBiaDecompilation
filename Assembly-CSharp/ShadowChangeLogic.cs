using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChangeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "影替";
		this.Desc = "受到伤害前，若场上有影子，消灭1个影子，获得1护甲";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData == this.CardData)
		{
			List<CardSlotData> cardSlotDatas = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId].CardSlotDatas;
			List<CardData> list = new List<CardData>();
			foreach (CardSlotData cardSlotData in cardSlotDatas)
			{
				if (cardSlotData.ChildCardData != null && (cardSlotData.ChildCardData.ModID == "虚无之影" || cardSlotData.ChildCardData.ModID == "真实之影"))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (list.Count > 0)
			{
				CardData cardData = list[UnityEngine.Random.Range(0, list.Count)];
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, -cardData.HP, cardData, false, 0, true, false);
				this.CardData.MaxArmor++;
				this.CardData.Armor++;
			}
		}
		yield break;
	}
}
