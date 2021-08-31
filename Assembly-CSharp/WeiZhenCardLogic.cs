using System;
using System.Collections;

public class WeiZhenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_81");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_81");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_81");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_81");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && this.CardData.Armor > 0)
		{
			target.ChildCardData.AddAffix(DungeonAffix.paralysis, 2);
		}
		yield break;
	}
}
