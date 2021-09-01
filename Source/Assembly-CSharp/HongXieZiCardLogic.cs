using System;

public class HongXieZiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红鞋子");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_红鞋子");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红鞋子");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_红鞋子");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		this.CardData.AddAffix(DungeonAffix.heal, 10);
		base.RemoveCardLogic(this.CardData, typeof(HongXieZiCardLogic), "HongXieZiCardLogic");
	}
}
