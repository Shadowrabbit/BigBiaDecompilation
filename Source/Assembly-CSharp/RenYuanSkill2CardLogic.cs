using System;
using System.Collections;
using UnityEngine;

[CardLogicRequireRare(4)]
public class RenYuanSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_140");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_140"), 7);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_140");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_140"), 7);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.isUsed = false;
		yield break;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && player.HP < Mathf.CeilToInt((float)player.MaxHP * 0.1f))
		{
			player.AddAffix(DungeonAffix.heal, 7);
		}
		yield break;
	}

	private bool isUsed;
}
