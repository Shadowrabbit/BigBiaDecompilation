using System;

public class YellowUnitCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_黄色组件");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_黄色组件");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_黄色组件");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_黄色组件");
	}
}
