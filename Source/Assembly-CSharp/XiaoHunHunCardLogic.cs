using System;
using System.Collections;
using UnityEngine;

public class XiaoHunHunCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_2");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_2"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_2");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_2"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (!player.HasTag(TagMap.随从) || this.CardData == player || base.GetMinionLine(player) != base.GetMinionLine(this.CardData))
		{
			yield break;
		}
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null)
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, defaultTarget, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.25f;
}
