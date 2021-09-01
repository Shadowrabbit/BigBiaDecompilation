using System;
using System.Collections;

public class MinceMeatLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = "绞肉";
		this.Desc = "自身杀死一名敌人时，+1充能";
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		if (originCarddata != null && originCarddata == this.CardData)
		{
			this.CardData.MP++;
		}
		yield break;
	}
}
