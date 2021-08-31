using System;
using System.Collections.Generic;

public class ShuiGuoPingPanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_190");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_190") + base.Layers.ToString();
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_190");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_190") + base.Layers.ToString();
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从))
		{
			List<CardLogic> cardLogics = this.CardData.CardLogics;
			new List<CardLogic>();
			if (cardLogics.Count > 0)
			{
				foreach (CardLogic cardLogic in cardLogics)
				{
					if (!(cardLogic.GetType() == typeof(ShuiGuoPingPanCardLogic)) && cardLogic.Layers > 0)
					{
						cardLogic.Layers += base.Layers;
					}
				}
			}
			base.RemoveCardLogic(this.CardData, typeof(ShuiGuoPingPanCardLogic), "ShuiGuoPingPanCardLogic");
		}
	}
}
