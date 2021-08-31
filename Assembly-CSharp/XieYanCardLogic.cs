using System;

public class XieYanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大蛇4");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大蛇4");
	}
}
