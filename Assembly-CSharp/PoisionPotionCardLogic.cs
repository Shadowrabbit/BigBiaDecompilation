using System;

public class PoisionPotionCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_114");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_114"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_114");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_114"), base.Layers);
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.AddAffix(DungeonAffix.poisoning, base.Layers);
		base.RemoveCardLogic(this.CardData, typeof(PoisionPotionCardLogic), "PoisionPotionCardLogic");
	}
}
