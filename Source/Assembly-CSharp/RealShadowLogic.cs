using System;

public class RealShadowLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "立影";
		this.Desc = "你的影子不会自行消失。";
	}
}
