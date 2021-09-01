using System;

public class ATKLevelUpLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (base.Layers < 1)
		{
			base.Layers = 1;
		}
		this.displayName = "增加攻击";
		this.Desc = "攻击力+6。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData._ATK += 6;
	}
}
