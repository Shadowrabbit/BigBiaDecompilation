using System;
using System.Collections;
using UnityEngine;

public class BeatBackLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从))
		{
			this.Color = CardLogicColor.yellow;
		}
		this.displayName = "棘刺";
		this.Desc = string.Concat(new string[]
		{
			"受到攻击时，对伤害来源造成",
			Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers).ToString(),
			"[",
			(50 * base.Layers).ToString(),
			"%攻击力]点伤害。"
		});
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (!DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && target.ChildCardData == this.CardData)
		{
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), 0.2f, false, 0, null, null);
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "棘刺";
		this.Desc = string.Concat(new string[]
		{
			"受到攻击时，对伤害来源造成",
			Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers).ToString(),
			"[",
			(50 * base.Layers).ToString(),
			"%攻击力]点伤害。"
		});
	}
}
