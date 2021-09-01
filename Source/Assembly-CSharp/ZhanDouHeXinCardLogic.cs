using System;

public class ZhanDouHeXinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_战斗核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_战斗核心");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_战斗核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_战斗核心");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (base.GetLogic(this.CardData, typeof(LostMemoryRobotCardLogic)) != null && base.GetLogic(this.CardData, typeof(RedUnitCardLogic)) != null && base.GetLogic(this.CardData, typeof(RedUnitCardLogic)).Layers >= 2)
		{
			this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(RedUnitCardLogic)));
			this.CardData.AddLogic("HuiMieCardLogic", 1);
			this.CardData.RemoveLogic(this);
		}
	}
}
