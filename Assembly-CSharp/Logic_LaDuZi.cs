using System;
using System.Collections;

public class Logic_LaDuZi : PersonCardLogic
{
	public override void Init()
	{
		this.IsDebuff = true;
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_159");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_159");
	}

	public override void OnMerge(CardData mergeBy)
	{
		if (this.CardData != null)
		{
			this.CardData._CRIT += 30;
		}
	}

	public override IEnumerator Terminate(CardSlotData cardSlotData)
	{
		if (this.CardData != null)
		{
			this.CardData._CRIT -= 30;
		}
		yield break;
	}
}
