using System;
using System.Collections;

public class DouMLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "抖M";
		this.Desc = "受到伤害时+1能量";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData == this.CardData)
		{
			base.ShowMe();
			GameController.ins.StartCoroutine(GameController.ins.UIController.EnergyUI.AddEnergy((EnergyUI.EnergyType)this.CardData.CurrentCardSlotData.Color, this.CardData.CardGameObject.transform));
		}
		yield break;
	}
}
