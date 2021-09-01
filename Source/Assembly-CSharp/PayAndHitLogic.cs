using System;
using System.Collections;

public class PayAndHitLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData.HasTag(TagMap.随从))
		{
			this.Color = CardLogicColor.red;
		}
		base.Layers = this.CardData.Level;
		if (base.Layers < 1)
		{
			base.Layers = 1;
		}
		this.displayName = "给钱干活";
		this.Desc = "如金币足够，攻击后将消耗1金币并造成额外5点伤害";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && GameController.getInstance().GameData.Money >= 1 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			DungeonOperationMgr.Instance.ChangeMoney(-1);
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, 5, 0.2f, false, 0, null, null);
		}
		yield break;
	}
}
