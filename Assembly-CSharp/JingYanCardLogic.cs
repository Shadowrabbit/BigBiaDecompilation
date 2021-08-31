using System;

public class JingYanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "经验";
		this.Desc = "BIA：消灭此特性。使所有其他蓝色特性等级+1";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.CardLogicClassNames.Remove("JingYanCardLogic");
		this.CardData.CardLogics.Remove(this);
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			if (cardLogic.Layers > 0)
			{
				CardLogic cardLogic2 = cardLogic;
				int layers = cardLogic2.Layers;
				cardLogic2.Layers = layers + 1;
			}
		}
	}
}
