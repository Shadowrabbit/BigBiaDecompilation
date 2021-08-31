using System;
using System.Collections;

public class ChongNengLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "充能";
		this.Desc = "若未攻击，+" + base.Layers.ToString() + "充能。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !this.CardData.IsAttacked)
		{
			this.CardData.MP += base.Layers;
		}
		yield break;
	}
}
