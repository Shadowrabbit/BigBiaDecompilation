using System;
using System.Collections.Generic;

public class XiangJiaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_187");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_187");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_187");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_187");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从))
		{
			List<CardLogic> cardLogics = this.CardData.CardLogics;
			List<CardLogic> list = new List<CardLogic>();
			if (cardLogics.Count > 0)
			{
				foreach (CardLogic cardLogic in cardLogics)
				{
					if (cardLogic.Color == CardLogicColor.yellow && cardLogic.Layers > 0)
					{
						list.Add(cardLogic);
					}
				}
				if (list.Count > 0)
				{
					CardLogic cardLogic2 = list[SYNCRandom.Range(0, list.Count)];
					int layers = cardLogic2.Layers;
					cardLogic2.Layers = layers + 1;
				}
			}
			base.RemoveCardLogic(this.CardData, typeof(XiangJiaoCardLogic), "XiangJiaoCardLogic");
		}
	}
}
