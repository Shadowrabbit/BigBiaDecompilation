using System;
using System.Collections;

public class FaYuHeXinCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_发育");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_发育");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_发育");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_发育");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.CardData._ATK++;
			this.CardData.MaxHP += 5;
			this.CardData._CRIT += 10;
			yield return base.Cure(this.CardData, 5, this.CardData);
		}
		yield break;
	}

	private bool HaveJumped = true;
}
