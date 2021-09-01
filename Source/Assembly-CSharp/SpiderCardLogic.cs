using System;
using System.Collections;

public class SpiderCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "吐丝";
		this.Desc = "攻击令目标无法移动。持续2回合。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			this.AddLogic("StunLogic", target.ChildCardData);
			yield break;
		}
		yield break;
	}

	private void AddLogic(string logicName, CardData cd)
	{
		CardLogic cardLogic = Activator.CreateInstance(Type.GetType(logicName)) as CardLogic;
		cardLogic.Init();
		cardLogic.ExistsRound = 1;
		cardLogic.CardData = this.CardData;
		cd.CardLogics.Add(cardLogic);
		cardLogic.OnMerge(this.CardData);
		cardLogic.Init();
	}
}
