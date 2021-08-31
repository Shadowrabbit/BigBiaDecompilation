using System;
using System.Collections;

public class SceneHuaShiCardLogic : CardLogic
{
	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		bool flag = false;
		int num = 1;
		if (player == null)
		{
			yield break;
		}
		CardLogicColor cardLogicColor = CardLogicColor.white;
		foreach (CardLogic cardLogic in player.CardLogics)
		{
			if (cardLogic is ShiGaoCardLogic)
			{
				cardLogicColor = (cardLogic as ShiGaoCardLogic).currentColor;
				flag = true;
				num = cardLogic.Layers;
			}
		}
		if (flag && from != null && from.CurrentCardSlotData != null && from.CurrentCardSlotData.Color == (CardSlotData.LineColor)cardLogicColor)
		{
			value.value = value.value * num * 2;
		}
		yield break;
	}
}
