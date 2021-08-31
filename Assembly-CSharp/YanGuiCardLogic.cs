using System;
using System.Collections;

public class YanGuiCardLogic : VolcanoLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_烟雾");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_烟雾");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_烟雾");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_烟雾");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (player == this.CardData && value.value < 0 && from != null && from.HasTag(TagMap.随从))
		{
			value.value = -1;
		}
		yield break;
	}
}
