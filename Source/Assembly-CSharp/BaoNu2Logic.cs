using System;
using System.Collections;

public class BaoNu2Logic : FaithCardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_暴怒2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_暴怒2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_暴怒2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_暴怒2");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (from != null && from == this.CardData)
		{
			base.ShowMe();
			this.CardData.InBattleATK += 5;
			ParticlePoolManager.Instance.Spawn("Effect/HealATK", 3f).transform.position = this.CardData.CardGameObject.transform.position;
		}
		yield break;
	}
}
