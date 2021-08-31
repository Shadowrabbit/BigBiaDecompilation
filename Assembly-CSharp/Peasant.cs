using System;

public class Peasant : CardLogic
{
	public Peasant()
	{
		this.displayName = "乌合之众";
	}

	public override int GetATKBonus()
	{
		return this.CardData.Count / 3;
	}
}
