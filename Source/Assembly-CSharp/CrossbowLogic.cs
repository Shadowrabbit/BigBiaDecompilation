using System;

public class CrossbowLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "元戎";
		this.Desc = "【发射】改为-1充能。攻击后若有充能，重置自身行动。";
	}
}
