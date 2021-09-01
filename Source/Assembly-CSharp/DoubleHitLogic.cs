using System;

public class DoubleHitLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "多重攻击";
		this.Desc = "攻击次数:+" + base.Layers.ToString() + "，攻击力减少50%。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData._AttackTimes += base.Layers;
		this.CardData._ATK -= this.CardData.ATK / 2;
	}
}
