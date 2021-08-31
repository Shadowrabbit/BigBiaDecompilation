using System;
using System.Collections;

public class Logic_GaoXing : PersonCardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.ExistsRound < 1 || this.ExistsRound > 1000)
		{
			this.ExistsRound = 3;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_150");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_150");
	}

	public override void OnMerge(CardData mergeBy)
	{
		if (this.CardData != null)
		{
			this.CardData.EXATK += 30;
		}
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		if (this.CardData != null)
		{
			this.CardData.EXATK -= 30;
		}
		yield break;
	}
}
