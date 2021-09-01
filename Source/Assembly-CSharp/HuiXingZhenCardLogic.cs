using System;
using System.Collections;

public class HuiXingZhenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_回形针");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_回形针"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_回形针");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_回形针"), base.Layers);
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player.HasTag(TagMap.随从) && this.CardData.HasTag(TagMap.随从) && player.CurrentCardSlotData.Color == this.CardData.CurrentCardSlotData.Color && changedValue < 0)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
		}
		yield break;
	}
}
