using System;

public class HealPotionCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_115");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_115"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_115");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_115"), base.Layers);
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.AddAffix(DungeonAffix.heal, base.Layers);
		base.RemoveCardLogic(this.CardData, typeof(HealPotionCardLogic), "HealPotionCardLogic");
	}
}
