using System;
using System.Collections;

public class OuXiangGeShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_旋律");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_旋律");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_旋律");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_旋律");
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		if (user == this.CardData || !user.HasTag(TagMap.随从))
		{
			yield break;
		}
		base.OnCardAfterUseSkill(user, origin);
		base.ShowMe();
		this.CardData.NextAttackTimes++;
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData || !player.HasTag(TagMap.随从))
		{
			yield break;
		}
		base.ShowMe();
		this.CardData.NextAttackTimes++;
		yield break;
	}
}
