using System;

public class SacrificeAlumetLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_169");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_169");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_169");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_169");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.IsAttacked = false;
		base.RemoveCardLogic(this.CardData, typeof(SacrificeAlumetLogic), "SacrificeAlumetLogic");
	}
}
