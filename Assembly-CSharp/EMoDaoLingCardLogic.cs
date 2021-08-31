using System;
using System.Collections;

public class EMoDaoLingCardLogic : VolcanoLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_火之高兴");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_火之高兴");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_火之高兴");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_火之高兴");
	}

	public override IEnumerator BeFireBallAttacked()
	{
		base.BeFireBallAttacked();
		base.ShowMe();
		yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, this.CardData);
		this.CardData._ATK *= 2;
		yield break;
	}
}
