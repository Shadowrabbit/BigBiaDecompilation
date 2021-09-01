using System;
using System.Collections;
using System.Collections.Generic;

public class Logic_FaFeng : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		if (this.ExistsRound < 1 || this.ExistsRound > 1000)
		{
			this.ExistsRound = 3;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_164");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_164");
	}

	public override IEnumerator OnBattleEnd()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		CardData target = allCurrentMinions[SYNCRandom.Range(0, allCurrentMinions.Count)];
		yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_54"));
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, 3, 0.2f, true, 0, null, null);
		yield break;
	}
}
