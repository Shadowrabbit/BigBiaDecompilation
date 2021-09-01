using System;
using System.Collections;

public class ExATKTimesCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "额外攻击次数";
		this.Desc = "下次攻击获得" + base.Layers.ToString() + "额外攻击频次。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "额外攻击次数";
		this.Desc = "下次攻击获得" + base.Layers.ToString() + "额外攻击频次。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData._AttackTimes += base.Layers;
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		base.Terminate(cardSlotData);
		this.CardData._AttackTimes -= base.Layers;
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			base.RemoveCardLogic(this.CardData, typeof(ExATKTimesCardLogic), "ExATKTimesCardLogic");
		}
		yield break;
	}
}
