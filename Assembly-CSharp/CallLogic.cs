using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "召唤";
		this.Desc = string.Concat(new string[]
		{
			"回合结束时在地图上生成一个",
			this.CardData.ATK.ToString(),
			"/",
			this.CardData.MaxHP.ToString(),
			"的怪物衍生物"
		});
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardSlotData> allEmptyAreaSlots = base.GetAllEmptyAreaSlots();
			CardData cardData = CardData.CopyCardData(GameController.getInstance().CardDataModMap.getCardDataByModID("冰立方"), true);
			cardData._ATK = this.CardData.ATK;
			cardData.MaxHP = this.CardData.MaxHP;
			if (allEmptyAreaSlots == null || allEmptyAreaSlots.Count == 0)
			{
				yield break;
			}
			cardData.PutInSlotData(allEmptyAreaSlots[UnityEngine.Random.Range(0, allEmptyAreaSlots.Count)], true);
		}
		yield break;
	}
}
