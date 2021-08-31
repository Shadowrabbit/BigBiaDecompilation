using System;

public class YanGuiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_95");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_95");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_95");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_95");
	}
}
