using System;
using System.Collections.Generic;
using UnityEngine;

public class Logic_TouQie : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_163");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_163");
		if (this.CardData != null)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			for (int i = allCurrentMinions.Count - 1; i >= 0; i--)
			{
				if (allCurrentMinions[i].CardLogics.Count < 2 || allCurrentMinions[i] == this.CardData)
				{
					allCurrentMinions.Remove(allCurrentMinions[i]);
				}
			}
			if (allCurrentMinions.Count < 1)
			{
				return;
			}
			CardData cardData = allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)];
			List<CardLogic> cardLogics = cardData.CardLogics;
			CardLogic cardLogic = cardLogics[SYNCRandom.Range(0, cardLogics.Count)];
			while (cardLogic.displayName.Equals("攻击"))
			{
				cardLogic = cardLogics[SYNCRandom.Range(0, cardLogics.Count)];
			}
			cardLogic.CardData = this.CardData;
			this.CardData.CardLogics.Add(cardLogic);
			cardLogic.OnMerge(this.CardData);
			cardData.CardLogics.Remove(cardLogic);
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, string.Concat(new string[]
			{
				cardData.Name,
				" ",
				cardData.PersonName,
				" ",
				LocalizationMgr.Instance.GetLocalizationWord("T_53")
			}), UnityEngine.Color.white, 0, false, false);
		}
	}
}
