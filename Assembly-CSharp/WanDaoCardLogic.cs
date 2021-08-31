using System;

public class WanDaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "刀剑";
		this.Desc = "左右随从攻击时，武器会随同攻击";
	}
}
