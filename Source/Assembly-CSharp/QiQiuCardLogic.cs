using System;
using System.Collections;

public class QiQiuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_气球");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_气球"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_气球");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_气球"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0)
		{
			base.ShowMe();
			yield return base.FeiDan(this.CardData, base.Layers);
		}
		yield break;
	}
}
