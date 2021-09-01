using System;

public class ZhenChaHeXinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_侦察核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_侦察核心");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_侦察核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_侦察核心");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (base.GetLogic(this.CardData, typeof(LostMemoryRobotCardLogic)) != null && base.GetLogic(this.CardData, typeof(BlueUnitCardLogic)) != null && base.GetLogic(this.CardData, typeof(BlueUnitCardLogic)).Layers >= 2)
		{
			this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(BlueUnitCardLogic)));
			this.CardData.AddLogic("RuoDianJianCeCardLogic", 1);
			this.CardData.RemoveLogic(this);
		}
	}
}
