using System;
using System.Collections.Generic;

public class BaDaoLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_26");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_26");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_26");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_26");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		List<CardLogic> list = new List<CardLogic>();
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			if (cardLogic.Color != CardLogicColor.yellow && !cardLogic.displayName.Equals("攻击") && cardLogic.GetType() != base.GetType())
			{
				list.Add(cardLogic);
			}
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			list[SYNCRandom.Range(0, list.Count)].Color = CardLogicColor.yellow;
		}
	}
}
