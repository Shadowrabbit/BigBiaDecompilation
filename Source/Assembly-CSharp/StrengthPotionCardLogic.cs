using System;

public class StrengthPotionCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_116");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_116"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_116");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_116"), base.Layers);
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
		base.RemoveCardLogic(this.CardData, typeof(StrengthPotionCardLogic), "StrengthPotionCardLogic");
	}
}
