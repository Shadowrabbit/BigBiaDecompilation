using System;
using System.Collections;

public class JiaGongGuaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_加攻挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_加攻挂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_加攻挂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_加攻挂");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.CardData._ATK *= 2;
			yield break;
		}
		yield break;
	}
}
