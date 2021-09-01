using System;
using System.Collections;

public class ShuiQiangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_水枪");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_水枪"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_水枪");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_水枪"), base.Layers);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (!this.CardData.HasTag(TagMap.随从))
		{
			yield break;
		}
		if (player.HasTag(TagMap.随从) && this.CardData != player && base.GetMinionLine(player) == base.GetMinionLine(this.CardData))
		{
			base.ShowMe();
			yield return base.FeiDan(this.CardData, base.Layers);
		}
		yield break;
	}
}
