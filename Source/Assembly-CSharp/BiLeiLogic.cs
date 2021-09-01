using System;
using System.Collections;

public class BiLeiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "壁垒";
		this.Desc = "受到伤害后，若自己仍有护甲，令伤害来源眩晕。";
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		if (player == this.CardData && this.CardData.Armor > 0)
		{
			base.ShowMe();
			from.DizzyLayer++;
		}
		yield break;
	}
}
