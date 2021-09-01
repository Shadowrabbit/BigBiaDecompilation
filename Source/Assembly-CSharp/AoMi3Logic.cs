using System;

public class AoMi3Logic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_精明3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_精明3");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_精明3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_精明3");
	}
}
