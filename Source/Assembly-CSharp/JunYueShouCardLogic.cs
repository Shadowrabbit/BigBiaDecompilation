using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunYueShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_175");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_175"), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_175");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_175"), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			List<CardSlotData> myBattleArea = base.GetMyBattleArea();
			List<CardData> list = new List<CardData>();
			if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) < myBattleArea.Count / 3 * 2)
			{
				CardSlotData cardSlotData = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + myBattleArea.Count / 3];
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (list.Count <= 0)
			{
				yield break;
			}
			using (List<CardData>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					cardData.wATK += Mathf.CeilToInt((float)cardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
				}
				yield break;
			}
		}
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.3f;
}
