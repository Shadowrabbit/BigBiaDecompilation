using System;
using System.Collections;

public class ChaTouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_插头");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_插头"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_插头");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_插头"), base.Layers);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		base.OnCardAfterUseSkill(user, origin);
		if (user == this.CardData)
		{
			this.CardData.AddAffix(DungeonAffix.beatBack, base.Layers);
		}
		yield break;
	}
}
