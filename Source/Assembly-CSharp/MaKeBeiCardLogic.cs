using System;

public class MaKeBeiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_194");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_194");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_194");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_194");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (mergeBy.HasTag(TagMap.药水))
		{
			this.CardData.MergeBy(mergeBy, false, false);
		}
	}
}
