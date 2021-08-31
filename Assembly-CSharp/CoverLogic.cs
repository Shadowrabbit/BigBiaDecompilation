using System;
using System.Collections;
using System.Collections.Generic;

public class CoverLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "掩护";
		this.Desc = "同排友军攻击前，对目标造成等同于攻击力伤害";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		List<CardSlotData> PlayerSlots = GameController.getInstance().GameData.SlotsOnPlayerTable;
		int num;
		for (int i = PlayerSlots.Count / 3; i < PlayerSlots.Count / 3 * 2; i = num + 1)
		{
			if (PlayerSlots[i].ChildCardData == player && player != this.CardData)
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, this.CardData.ATK, 0.2f, false, 0, null, null);
			}
			num = i;
		}
		yield break;
	}
}
