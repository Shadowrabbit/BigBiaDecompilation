using System;
using System.Collections;

public class DashLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "冲击";
		this.Desc = "击杀敌人后，重置自身行动";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		this.CurrentTarget = target.ChildCardData;
		yield break;
	}

	public override IEnumerator OnFinishAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && (target.ChildCardData == null || target.ChildCardData != this.CurrentTarget))
		{
			this.CardData.IsAttacked = false;
		}
		yield break;
	}

	private CardData CurrentTarget;
}
