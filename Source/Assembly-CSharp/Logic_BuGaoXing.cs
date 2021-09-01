using System;
using System.Collections;

public class Logic_BuGaoXing : PersonCardLogic
{
	public override void Init()
	{
		base.Init();
		this.IsDebuff = true;
		if (this.ExistsRound < 1 || this.ExistsRound > 1000)
		{
			this.ExistsRound = 3;
		}
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_149");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_149");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_149");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_149");
	}

	public override void OnMerge(CardData mergeBy)
	{
		base.OnMerge(mergeBy);
		if (this.CardData != null)
		{
			this.CardData.EXATK -= 30;
		}
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		if (this.CardData != null)
		{
			this.CardData.EXATK += 30;
		}
		yield break;
	}
}
