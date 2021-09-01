using System;

public class BiShengTouDaiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_必胜头带");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_必胜头带"), this.pow * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_必胜头带");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_必胜头带"), this.pow * 100f);
	}

	public override void OnMerge(CardData mergeBy)
	{
		this.pow = 0.1f * (float)base.Layers;
	}

	public float pow = 0.1f;
}
