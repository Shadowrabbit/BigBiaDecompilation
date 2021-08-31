using System;

public class DaQiTongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_打气筒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_打气筒");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_打气筒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_打气筒");
	}
}
