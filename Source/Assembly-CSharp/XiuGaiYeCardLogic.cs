using System;
using System.Collections.Generic;

public class XiuGaiYeCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_修改液");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_修改液"), 2);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_修改液");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_修改液"), 2);
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		List<CardLogic> list = new List<CardLogic>();
		if (this.CardData == null)
		{
			return;
		}
		if (this.CardData.HasTag(TagMap.BOSS))
		{
			this.CardData.RemoveCardLogic(this);
			return;
		}
		foreach (CardLogic cardLogic in this.CardData.CardLogics)
		{
			if (cardLogic.Color != CardLogicColor.yellow && !(cardLogic is MinionLogic) && cardLogic.GetType() != base.GetType() && !(cardLogic is PersonCardLogic))
			{
				list.Add(cardLogic);
			}
		}
		if (list.Count > 0)
		{
			base.ShowMe();
			this.CardData.RemoveCardLogic(list[SYNCRandom.Range(0, list.Count)]);
		}
		this.CardData._ATK += 2;
		this.CardData.RemoveCardLogic(this);
	}
}
