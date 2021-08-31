using System;

public class FaQiaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_发卡");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_发卡");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_发卡");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_发卡");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.AddAffix(DungeonAffix.beatBack, 10);
		base.RemoveCardLogic(this.CardData, typeof(FaQiaCardLogic), "FaQiaCardLogic");
	}
}
