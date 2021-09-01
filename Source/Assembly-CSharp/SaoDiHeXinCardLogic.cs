using System;

public class SaoDiHeXinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_扫地核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_扫地核心");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_扫地核心");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_扫地核心");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (base.GetLogic(this.CardData, typeof(LostMemoryRobotCardLogic)) != null && base.GetLogic(this.CardData, typeof(BlueUnitCardLogic)) != null && base.GetLogic(this.CardData, typeof(BlueUnitCardLogic)).Layers >= 1 && base.GetLogic(this.CardData, typeof(RedUnitCardLogic)) != null && base.GetLogic(this.CardData, typeof(RedUnitCardLogic)).Layers >= 1 && base.GetLogic(this.CardData, typeof(YellowUnitCardLogic)) != null && base.GetLogic(this.CardData, typeof(YellowUnitCardLogic)).Layers >= 1)
		{
			this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(YellowUnitCardLogic)));
			this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(RedUnitCardLogic)));
			this.CardData.RemoveCardLogic(base.GetLogic(this.CardData, typeof(BlueUnitCardLogic)));
			this.CardData.AddLogic("DaSaoChuCardLogic", 1);
			this.CardData.RemoveLogic(this);
		}
	}
}
