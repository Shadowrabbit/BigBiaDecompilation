using System;
using System.Collections;

public class BallistaLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		if (this.CardData != null)
		{
			switch (this.CardData.Rare)
			{
			case 1:
				this.Scale = 5;
				break;
			case 2:
				this.Scale = 10;
				break;
			case 3:
				this.Scale = 20;
				break;
			default:
				this.Scale = 5;
				break;
			}
		}
		this.displayName = "发射";
		this.Desc = "攻击时，将每点充能转化为" + this.Scale.ToString() + "点攻击。攻击后，清空攻击力。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		this.CardData._ATK += this.CardData.MP * this.Scale;
		if (base.GetLogic(this.CardData, typeof(CrossbowLogic)) != null)
		{
			this.CardData.MP--;
		}
		else
		{
			this.CardData.MP = 0;
		}
		yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (this.CardData == player)
		{
			this.CardData._ATK = 0;
		}
		if (base.GetLogic(this.CardData, typeof(CrossbowLogic)) != null && this.CardData.MP > 0)
		{
			this.CardData.IsAttacked = false;
		}
		yield break;
	}

	private int Scale;
}
