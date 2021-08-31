using System;
using System.Collections;

public class WindUpLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "上弦";
		this.Desc = "回合结束时,若可行动，+1充能";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !this.CardData.IsAttacked)
		{
			this.CardData.MP++;
		}
		yield break;
	}
}
