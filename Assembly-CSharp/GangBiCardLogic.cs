using System;

public class GangBiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钢笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钢笔"), 3 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_钢笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_钢笔"), 3 * base.Layers);
	}
}
