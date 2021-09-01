using System;
using System.Collections;

public class KitchenKnifeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "屠刀";
		this.Desc = "每第五次攻击前，造成等同于充能层数的额外伤害。";
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			base.Layers++;
			if (base.Layers >= 5)
			{
				base.Layers = 0;
				this.TempATK = this.CardData.MP;
				this.CardData._ATK += this.TempATK;
				yield break;
			}
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && this.TempATK > 0)
		{
			this.CardData._ATK -= this.TempATK;
			this.TempATK = 0;
			yield break;
		}
		yield break;
	}

	private int TempATK;
}
