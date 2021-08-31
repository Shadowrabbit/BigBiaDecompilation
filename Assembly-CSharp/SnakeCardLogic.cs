using System;
using System.Collections;

public class SnakeCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蛇毒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_蛇毒");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蛇毒");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_蛇毒");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (from == this.CardData && changedValue < 0)
		{
			player.AddAffix(DungeonAffix.poisoning, 1);
		}
		yield break;
	}

	private bool HasJumped;
}
