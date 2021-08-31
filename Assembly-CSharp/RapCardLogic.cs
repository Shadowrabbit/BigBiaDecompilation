using System;
using System.Collections;

public class RapCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = "Rap";
		this.Desc = "释放技能后回复1蓝色充能。";
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		yield return GameController.ins.UIController.EnergyUI.AddEnergy(EnergyUI.EnergyType.Blue, this.CardData.CardGameObject.transform);
		yield break;
	}
}
