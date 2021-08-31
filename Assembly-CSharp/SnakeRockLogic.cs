using System;
using System.Collections;

public class SnakeRockLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "石化";
		this.Desc = "当前单位不可控。";
		this.ExistsRound = 3;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		return base.OnEndTurn(isPlayerTurn);
	}
}
