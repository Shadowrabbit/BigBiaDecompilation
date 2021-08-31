using System;
using System.Collections;
using System.Collections.Generic;

public class GongMingCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_36");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_36");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_36");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_36");
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Blue) < this.needEnergy)
		{
			yield break;
		}
		base.ShowMe();
		int num;
		for (int i = 0; i < this.needEnergy; i = num + 1)
		{
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Blue, this.CardData.CardGameObject.transform);
			num = i;
		}
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		List<CardData> allMonsters = base.GetAllCurrentMonsters();
		foreach (CardData cardData in allCurrentMinions)
		{
			if (cardData != this.CardData)
			{
				foreach (CardLogic cardLogic in cardData.CardLogics)
				{
					if (cardLogic.GetType() == origin.GetType())
					{
						yield return cardLogic.OnUseSkill();
					}
				}
				List<CardLogic>.Enumerator enumerator2 = default(List<CardLogic>.Enumerator);
			}
		}
		List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
		foreach (CardData cardData2 in allMonsters)
		{
			if (cardData2 != this.CardData)
			{
				foreach (CardLogic cardLogic2 in cardData2.CardLogics)
				{
					if (cardLogic2.GetType() == origin.GetType())
					{
						yield return cardLogic2.OnUseSkill();
					}
				}
				List<CardLogic>.Enumerator enumerator2 = default(List<CardLogic>.Enumerator);
			}
		}
		enumerator = default(List<CardData>.Enumerator);
		yield break;
		yield break;
	}

	private int Count = 10;

	private int needEnergy = 3;
}
