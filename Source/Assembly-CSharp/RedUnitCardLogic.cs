using System;

public class RedUnitCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红色组件");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_红色组件");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红色组件");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_红色组件");
	}
}
