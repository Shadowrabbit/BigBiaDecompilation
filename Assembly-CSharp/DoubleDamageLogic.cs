using System;
using System.Collections;

public class DoubleDamageLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "暴发";
		this.Desc = "该单位攻击时，攻击力翻倍。";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			this.OriginalAtk = player.ATK;
			player._ATK += player.ATK;
			yield break;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			player._ATK -= this.OriginalAtk;
			this.OriginalAtk = 0;
			yield break;
		}
		yield break;
	}

	private int OriginalAtk;
}
