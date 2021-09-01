using System;
using System.Collections;
using System.Collections.Generic;

public class ViolentCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_7");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_7");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_7");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_7");
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			if (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Red) < this.needEnergy)
			{
				yield break;
			}
			base.ShowMe();
			int num;
			for (int i = 0; i < this.needEnergy; i = num + 1)
			{
				yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Red, this.CardData.CardGameObject.transform);
				num = i;
			}
			List<CardLogic> list = new List<CardLogic>();
			foreach (CardLogic cardLogic in this.CardData.CardLogics)
			{
				if (cardLogic.Color == CardLogicColor.red && cardLogic.GetType().GetMethod("OnUseSkill").DeclaringType == cardLogic.GetType())
				{
					list.Add(cardLogic);
				}
			}
			if (list.Count > 0)
			{
				yield return list[SYNCRandom.Range(0, list.Count)].OnUseSkill();
			}
		}
		yield break;
	}

	public override void RemakeSkillEffect()
	{
		this.SkillEffect = "暴力本能释放";
	}

	private int needEnergy = 2;
}
