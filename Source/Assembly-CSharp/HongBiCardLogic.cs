using System;
using System.Collections;

public class HongBiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_红笔"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_红笔");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_红笔"), base.Layers);
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (from != null && from == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			this.CardData.AddAffix(DungeonAffix.strength, base.Layers);
		}
		yield break;
	}
}
