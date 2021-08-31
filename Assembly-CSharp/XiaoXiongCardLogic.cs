using System;

public class XiaoXiongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小熊");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_小熊");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_小熊");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_小熊");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.AddAffix(DungeonAffix.strength, 5);
		base.RemoveCardLogic(this.CardData, typeof(StrengthPotionCardLogic), "XiaoXiongCardLogic");
	}
}
