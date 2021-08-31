using System;
using System.Collections;

public class SharpenLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_46");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_46"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_46");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_46"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData) && changedValue < 0)
		{
			this.CardData.MaxHP += base.Layers;
		}
		yield break;
	}
}
