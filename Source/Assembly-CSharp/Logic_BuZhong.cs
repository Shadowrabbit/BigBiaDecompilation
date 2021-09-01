using System;
using System.Collections;

public class Logic_BuZhong : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		if (this.ExistsRound < 1 || this.ExistsRound > 1000)
		{
			this.ExistsRound = 3;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_158");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_158");
	}

	public override IEnumerator OnTurnStart()
	{
		if (SYNCRandom.Range(0, 100) > 70)
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_47"));
			this.CardData.IsAttacked = true;
		}
		yield break;
	}
}
