using System;
using System.Collections;
using System.Collections.Generic;

public class YingJiFanYingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "应激反应";
		this.Desc = "受到伤害时，消耗3Y,随机触发1个黄色主动。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (target.ChildCardData != this.CardData)
		{
			yield break;
		}
		List<CardLogic> skills = new List<CardLogic>();
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			if (cardLogic.GetType().GetMethod("OnUseSkill").DeclaringType == cardLogic.GetType() && cardLogic.Color == CardLogicColor.yellow)
			{
				skills.Add(cardLogic);
			}
		}
		if (skills.Count > 0 && GameController.getInstance().GameData.GetEnergyCount(EnergyUI.EnergyType.Yellow) > 3)
		{
			base.ShowMe();
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy((EnergyUI.EnergyType)this.CardData.CurrentCardSlotData.Color, this.CardData.CardGameObject.transform);
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy((EnergyUI.EnergyType)this.CardData.CurrentCardSlotData.Color, this.CardData.CardGameObject.transform);
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy((EnergyUI.EnergyType)this.CardData.CurrentCardSlotData.Color, this.CardData.CardGameObject.transform);
			yield return skills[SYNCRandom.Range(0, skills.Count)].OnUseSkill();
		}
		yield break;
	}
}
