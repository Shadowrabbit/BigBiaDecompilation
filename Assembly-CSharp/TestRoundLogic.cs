using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoundLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "冲锋";
		this.Desc = "身后一格的友军攻击前，对目标造成1点伤害，重复" + base.Layers.ToString() + "次";
		this.ExistsRound = 3;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
		if (player == cardSlotData.ChildCardData)
		{
			int num;
			for (int i = 0; i < base.Layers; i = num + 1)
			{
				if (i == base.Layers - 1)
				{
					yield return DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, 1, 0.2f, false, 0, null, null);
				}
				else
				{
					GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, 1, 0.2f, false, 0, null, null));
					yield return this.waitSeconds;
				}
				num = i;
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		yield break;
	}

	private WaitForSeconds waitSeconds = new WaitForSeconds(0.1f);
}
