using System;
using System.Collections;

public class ArmorBreakLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "破甲";
		this.Desc = "攻击前，若自身充能数大于目标护甲，消灭其所有护甲。";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			if (this.CardData.MP > target.ChildCardData.Armor)
			{
				target.ChildCardData.Armor = 0;
			}
			yield break;
		}
		yield break;
	}

	private int Count;
}
