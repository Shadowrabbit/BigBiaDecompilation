using System;
using System.Collections;

public class HuoKuLouCardLogic : VolcanoLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_熔岩重构");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_熔岩重构");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_熔岩重构");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_熔岩重构");
	}

	public override IEnumerator BeFireBallAttacked()
	{
		base.BeFireBallAttacked();
		base.ShowMe();
		yield return base.Cure(this.CardData, 9999, this.CardData);
		yield break;
	}
}
