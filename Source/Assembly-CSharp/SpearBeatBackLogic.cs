using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBeatBackLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_枪棘");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_枪棘"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_枪棘");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_枪棘"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		List<CardSlotData> list = new List<CardSlotData>();
		if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
		{
			CardSlotData item = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
			list.Add(item);
		}
		if (list.Count <= 0)
		{
			yield break;
		}
		using (List<CardSlotData>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == target && !DungeonOperationMgr.Instance.CheckCardDead(player) && player._ATK > 0)
				{
					base.ShowMe();
					int damage = Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
					yield return DungeonOperationMgr.Instance.Hit(this.CardData, player, damage, 0.2f, false, 0, null, null);
				}
			}
		}
		List<CardSlotData>.Enumerator enumerator = default(List<CardSlotData>.Enumerator);
		yield break;
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.2f;
}
