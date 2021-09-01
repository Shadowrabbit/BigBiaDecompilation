using System;

public class TanYu3Logic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_掠夺3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_掠夺3");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_掠夺3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_掠夺3");
	}
}
