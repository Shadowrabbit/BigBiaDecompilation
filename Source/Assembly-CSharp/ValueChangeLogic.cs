using System;
using System.Collections;
using UnityEngine;

public class ValueChangeLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_贬值");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_贬值");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_贬值");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_贬值");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData)
		{
			float num = (float)this.CardData.HP * 1f / (float)this.CardData.MaxHP;
			this.CardData.Price = Mathf.CeilToInt(300f * num);
			yield break;
		}
		yield break;
	}

	public override void OnMerge(CardData mergeBy)
	{
		float num = (float)this.CardData.HP * 1f / (float)this.CardData.MaxHP;
		this.CardData.Price = Mathf.CeilToInt(300f * num);
	}
}
