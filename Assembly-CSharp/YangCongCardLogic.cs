using System;
using System.Collections;

public class YangCongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_洋葱");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_洋葱"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_洋葱");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_洋葱"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue > 0)
		{
			this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
		}
		yield break;
	}
}
