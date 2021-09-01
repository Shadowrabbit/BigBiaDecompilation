using System;

public class BaiLuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_65");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_65");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_65");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_65");
	}
}
