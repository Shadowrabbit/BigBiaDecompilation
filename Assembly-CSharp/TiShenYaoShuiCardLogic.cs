using System;

public class TiShenYaoShuiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_119");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_119");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_119");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_119");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.RemoveAffix(DungeonAffix.dizzy);
		base.RemoveCardLogic(this.CardData, typeof(TiShenYaoShuiCardLogic), "TiShenYaoShuiCardLogic");
	}
}
