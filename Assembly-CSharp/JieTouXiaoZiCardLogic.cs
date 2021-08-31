using System;
using System.Collections;

public class JieTouXiaoZiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_139");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_139");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_139");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_139");
	}

	public override IEnumerator OnBattleEnd()
	{
		base.OnBattleEnd();
		this.CardData.DeleteCardData();
		yield break;
	}
}
