using System;
using System.Collections;

public class WierdFlyLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_侵袭");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_侵袭");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_侵袭");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_侵袭");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (from == this.CardData && changedValue < 0)
		{
			player.AddAffix(DungeonAffix.bleeding, 1);
		}
		yield break;
	}

	private bool HasJumped;
}
