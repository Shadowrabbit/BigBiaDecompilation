using System;
using System.Collections;

public class FomationBreakLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "交锋";
		this.Desc = "攻击时造成2倍伤害。若目标未死亡，自身受到目标攻击力的伤害";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (target.ChildCardData != null)
		{
			yield return DungeonOperationMgr.Instance.CustomizeAttack(this.CardData, target, this.CardData.ATK * 2, null, 0, false, 0);
			DungeonHandler dungeonHandler = new DungeonHandler();
			if (DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
			{
				yield break;
			}
			yield return dungeonHandler.ChangeHp(this.CardData, -target.ChildCardData.ATK, this.CardData, true, 0, true, false);
		}
		yield break;
	}
}
