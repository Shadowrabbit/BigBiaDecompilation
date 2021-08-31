using System;
using System.Collections;
using UnityEngine;

public class QiaoKeLiStartItemCardLogics : CardLogic
{
	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_巧克力的味道");
		if (2 - this.times == 0)
		{
			this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_巧克力的味道1");
			return;
		}
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_巧克力的味道2"), 2 - this.times);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		this.times++;
		if (this.times >= 3)
		{
			if (this.CardData != null && this.CardData.HasTag(TagMap.随从) && this.CardData == player)
			{
				base.ShowMe();
				yield return new WaitForSeconds(0.2f);
				this.CardData.wCRIT += 100;
				this.AddCRIT = 100;
			}
			this.times = 0;
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从) && this.CardData == player && this.AddCRIT > 0)
		{
			this.CardData.wCRIT -= this.AddCRIT;
			this.AddCRIT = 0;
		}
		yield break;
	}

	public int times;

	public int AddCRIT;
}
