using System;
using System.Collections;

public class JingDaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_23");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_23");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_23");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_23");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (from == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			player.AddAffix(DungeonAffix.bleeding, 1);
			yield break;
		}
		yield break;
	}

	private float dmg = 0.1f;
}
