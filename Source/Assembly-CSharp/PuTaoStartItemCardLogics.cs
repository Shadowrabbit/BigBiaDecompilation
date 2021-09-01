using System;
using System.Collections;
using UnityEngine;

public class PuTaoStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_葡萄的味道");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_葡萄的味道");
	}

	public override IEnumerator OnBattleEnd()
	{
		this.times++;
		if (this.times == 3)
		{
			if (this.CardData != null && this.CardData.HasTag(TagMap.随从))
			{
				base.ShowMe();
				yield return new WaitForSeconds(0.2f);
				this.CardData._ATK++;
			}
			this.times = 0;
		}
		yield break;
	}

	private int times;
}
