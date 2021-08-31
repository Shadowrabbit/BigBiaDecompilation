using System;

public class HuoXueYaoJiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_120");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_120");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_120");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_120");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.RemoveAffix(DungeonAffix.paralysis);
		base.RemoveCardLogic(this.CardData, typeof(HuoXueYaoJiCardLogic), "HuoXueYaoJiCardLogic");
	}
}
