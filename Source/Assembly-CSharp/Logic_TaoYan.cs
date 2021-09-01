using System;
using System.Collections;
using UnityEngine;

public class Logic_TaoYan : TwoPeopleCardLogic
{
	public override void Init()
	{
		base.Init();
		this.ExistsRound = 3;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_151");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_151");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_151");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_151");
	}

	public override IEnumerator OnBattleEnd()
	{
		CardData target = base.GetCardByID(this.TargetID);
		if (target != null)
		{
			if (target == this.CardData)
			{
				yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_讨厌1"));
				this.CardData.RemoveCardLogic(this);
				yield break;
			}
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("T_40"));
			int num = 3;
			if (!DungeonOperationMgr.Instance.CheckCardDead(target))
			{
				if (base.GetLogic(target, typeof(ShiLaiMuNiangCardLogic)) != null && Mathf.CeilToInt((float)num * 1.5f) > target.HP)
				{
					num = Mathf.FloorToInt((float)(target.HP - 1) / 1.5f);
				}
				if (num > target.HP)
				{
					num = target.HP - 1;
				}
			}
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target, num, 0.2f, true, 0, null, null);
		}
		else
		{
			yield return base.ShowMePlus(LocalizationMgr.Instance.GetLocalizationWord("SM_讨厌2"));
			this.CardData.RemoveCardLogic(this);
		}
		yield break;
	}
}
