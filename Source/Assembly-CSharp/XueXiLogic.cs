using System;
using System.Collections;

public class XueXiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "学习";
		this.Desc = "若未攻击，+" + base.Layers.ToString() + "充能。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			yield break;
		}
		if (this.CardData.IsAttacked)
		{
			yield break;
		}
		base.ShowMe();
		this.CardData.MP += base.Layers;
		yield break;
	}
}
