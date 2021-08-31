using System;
using System.Collections;

public class ZhanShouDaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_126");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_126");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_126");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_126");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (from != null && from == this.CardData)
		{
			this.CardData._ATK++;
			yield break;
		}
		yield break;
	}
}
