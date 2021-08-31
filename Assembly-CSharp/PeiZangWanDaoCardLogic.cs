using System;
using System.Collections;

public class PeiZangWanDaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_125");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_125");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_125");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_125");
	}

	public override IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		base.OnUserAsArms(origin, Target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(Target))
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(Target, -this.CardData.ATK, origin, false, 0, true, false);
			Target.AddAffix(DungeonAffix.bleeding, 1);
		}
		yield break;
	}
}
