using System;
using System.Collections;

public class ShuiCaiBiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_水彩笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_水彩笔"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_水彩笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_水彩笔"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue < 0)
		{
			this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
		}
		yield break;
	}
}
