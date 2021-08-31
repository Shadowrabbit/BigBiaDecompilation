using System;

public class LuZhangHeXinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_路障核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_路障核心");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_路障核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_路障核心");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (base.GetLogic(this.CardData, typeof(LostMemoryRobotCardLogic)) != null && base.GetLogic(this.CardData, typeof(YellowUnitCardLogic)) != null && base.GetLogic(this.CardData, typeof(YellowUnitCardLogic)).Layers >= 2)
		{
			this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(YellowUnitCardLogic)));
			this.CardData.AddLogic("ZiWoXiuFuCardLogic", 1);
			this.CardData.RemoveLogic(this);
		}
	}
}
