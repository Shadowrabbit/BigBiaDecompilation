using System;
using System.Collections;

public class FireGhostLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "燃烧";
		this.Desc = "回合结束时，使自己的攻击力翻倍";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		yield return base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			base.ShowMe();
			this.CardData._ATK *= 2;
			yield break;
		}
		yield break;
	}
}
