using System;
using System.Collections;
using System.Collections.Generic;

public class ShuoYiGeJiuYiGeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "说一个就一个";
		this.Desc = "在同一回合内，每种卡片只能对本单位造成一次伤害。";
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt changedValue, CardData from)
	{
		if (player == this.CardData)
		{
			if (!this.m_AttackerID.Contains(from.ModID))
			{
				this.m_AttackerID.Add(from.ModID);
			}
			else if (changedValue.value < 0)
			{
				base.ShowMe();
				changedValue.value = 0;
			}
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		this.m_AttackerID = new List<string>();
		yield break;
	}

	private List<string> m_AttackerID = new List<string>();
}
