using System;

public class StunPotionCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "眩晕喷剂";
		this.Desc = "令使用者眩晕1回合";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.ExistsRound = 1;
		mergeBy.DizzyLayer++;
	}
}
