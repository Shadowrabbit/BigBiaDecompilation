using System;
using System.Collections;

public class LuJiaoBiShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_123");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_123");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_123");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_123");
	}

	public override IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		base.OnUserAsArms(origin, Target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(Target))
		{
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(Target, -this.CardData.ATK, origin, false, 0, true, false);
			Target.wATK--;
		}
		yield break;
	}
}
