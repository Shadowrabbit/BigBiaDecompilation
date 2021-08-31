using System;

public class XiangShuiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_香水");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_香水"), base.Layers * this.weight);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_香水");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_香水"), base.Layers * this.weight);
	}

	public int weight = 1;
}
