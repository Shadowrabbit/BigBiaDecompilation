using System;

public class JieDuJiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_118");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_118");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_118");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_118");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.RemoveAffix(DungeonAffix.poisoning);
		base.RemoveCardLogic(this.CardData, typeof(JieDuJiCardLogic), "JieDuJiCardLogic");
	}
}
