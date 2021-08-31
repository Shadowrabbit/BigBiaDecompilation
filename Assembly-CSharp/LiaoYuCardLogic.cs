using System;

public class LiaoYuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖6");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖6");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖6");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖6");
	}
}
