using System;
using System.Collections.Generic;
using UnityEngine;

public class SavageCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "野蛮";
		this.Desc = "BIA:消灭1个随机其他特性，使你的攻击力提高20%。";
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData.CardLogics.Count > 0)
		{
			List<CardLogic> list = new List<CardLogic>();
			foreach (CardLogic cardLogic in this.CardData.CardLogics)
			{
				if (cardLogic.GetType() != typeof(SavageCardLogic) && cardLogic.GetType() != typeof(MinionLogic))
				{
					list.Add(cardLogic);
				}
			}
			this.CardData.CardLogics.Remove(list[SYNCRandom.Range(0, list.Count)]);
		}
		this.CardData._ATK = Mathf.CeilToInt((float)this.CardData.ATK * 1.2f);
	}
}
