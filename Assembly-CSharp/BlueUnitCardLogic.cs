using System;

public class BlueUnitCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蓝色组件");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_蓝色组件");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蓝色组件");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_蓝色组件");
	}
}
