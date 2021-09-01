using System;
using System.Collections;

public class AddPoitionByDmgCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_174");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_174"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_174");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_174"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (from == this.CardData && changedValue < 0 && !DungeonOperationMgr.Instance.CheckCardDead(player) && player != from)
		{
			player.AddAffix(DungeonAffix.poisoning, base.Layers);
		}
		yield break;
	}
}
