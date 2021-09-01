using System;

[CardLogicRequireRare(4)]
public class WuNiangSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_剑舞");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_剑舞");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_剑舞");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_剑舞");
	}
}
