using System;
using System.Collections;
using System.Collections.Generic;

public class MummyLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = "锈蚀";
		this.Desc = "回合结束时，若有未攻击的随从，摧毁其所有护甲。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			yield break;
		}
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		if (allCurrentMinions == null || allCurrentMinions.Count == 0)
		{
			yield break;
		}
		base.ShowMe();
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData.Armor > 0 && !cardData.IsAttacked)
			{
				cardData.Armor = 0;
			}
		}
		yield break;
	}
}
