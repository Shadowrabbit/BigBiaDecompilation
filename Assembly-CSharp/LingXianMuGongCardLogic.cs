using System;
using System.Collections;

public class LingXianMuGongCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_124");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_124");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_124");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_124");
	}

	public override IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		base.OnUserAsArms(origin, Target);
		if (!DungeonOperationMgr.Instance.CheckCardDead(Target))
		{
			int num = SYNCRandom.Range(0, 100);
			int num2 = this.CardData.ATK;
			if (num < 15)
			{
				num2 *= 2;
			}
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(Target, -num2, origin, false, 0, true, false);
		}
		yield break;
	}
}
