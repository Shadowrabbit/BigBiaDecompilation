using System;
using System.Collections;
using UnityEngine;

public class DaWoDeLian : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_打我的脸");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_打我的脸");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_打我的脸");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_打我的脸");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData && changedValue < 0 && !DungeonOperationMgr.Instance.CheckCardDead(from) && !from.HasTag(TagMap.随从))
		{
			base.ShowMe();
			if (from.ModID.Equals("克苏鲁触手"))
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(from, -UnityEngine.Object.FindObjectOfType<BossCSLArea>().BossCard._ATK, this.CardData, false, 0, true, false);
			}
			else
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(from, -from.ATK, this.CardData, false, 0, true, false);
			}
		}
		yield break;
	}
}
