using System;
using System.Collections;

public class LaBiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蜡笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_蜡笔"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_蜡笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_蜡笔"), base.Layers);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		base.GetAllCurrentMinions();
		if (this.CardData.HasTag(TagMap.随从) && this.CardData == user)
		{
			this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
		}
		yield break;
	}
}
