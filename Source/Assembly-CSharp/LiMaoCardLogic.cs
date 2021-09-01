using System;
using System.Collections;

public class LiMaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_礼帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_礼帽"), base.Layers + 1);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_礼帽");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_礼帽"), base.Layers + 1);
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target != null && target.HasTag(TagMap.怪物) && from == this.CardData)
		{
			base.ShowMe();
			this.CardData.AddAffix(DungeonAffix.crit, base.Layers + 1);
		}
		yield break;
	}
}
