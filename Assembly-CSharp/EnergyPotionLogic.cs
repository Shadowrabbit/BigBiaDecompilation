using System;
using System.Collections.Generic;

public class EnergyPotionLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "能量药水";
		this.Desc = "所有随从回复" + base.Layers.ToString() + "能量";
	}

	public override void OnMerge(CardData mergeBy)
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions.Count <= 0)
		{
			return;
		}
		foreach (CardData cardData in allCurrentMinions)
		{
			cardData.MP += base.Layers;
		}
		base.OnMerge(mergeBy);
		base.RemoveCardLogic(mergeBy, base.GetType(), "EnergyPotionLogic");
	}
}
