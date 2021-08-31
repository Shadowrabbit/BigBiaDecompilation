using System;
using System.Collections;
using UnityEngine;

public class ChangGongShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_49");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_49"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_49");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_49"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player.HasTag(TagMap.随从) && this.CardData.HasTag(TagMap.随从) && this.CardData != player && base.GetMinionLine(player) == base.GetMinionLine(this.CardData) && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
		}
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.2f;
}
