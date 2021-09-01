using System;

public class SavingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "积蓄";
		this.Desc = "无法移动时，获得+" + base.Layers.ToString() + "生命值";
	}
}
