using System;

public class JifengLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "疾风";
		this.Desc = "攻击次数+1";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "疾风";
		this.Desc = "攻击次数+1";
	}
}
