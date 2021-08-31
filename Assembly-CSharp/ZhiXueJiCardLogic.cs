using System;

public class ZhiXueJiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_117");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_117");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_117");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_117");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.RemoveAffix(DungeonAffix.bleeding);
		base.RemoveCardLogic(this.CardData, typeof(ZhiXueJiCardLogic), "ZhiXueJiCardLogic");
	}
}
