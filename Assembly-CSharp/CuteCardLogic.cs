using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "萌物";
		this.Desc = "回合开始时发出喵~的叫声，使同列所有敌人在本回合内攻击力-30%";
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		base.ShowLogic("喵~");
		using (List<CardData>.Enumerator enumerator = base.GetAllCurrentMinions().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CardData cardData = enumerator.Current;
				if (cardData.CurrentCardSlotData.GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col"))
				{
					cardData.wATK -= Mathf.CeilToInt((float)cardData.ATK * 0.3f);
				}
			}
			yield break;
		}
		yield break;
	}
}
