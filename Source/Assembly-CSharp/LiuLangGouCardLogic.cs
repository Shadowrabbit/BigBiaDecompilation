using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiuLangGouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_3");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_3"), Mathf.CeilToInt((float)this.CardData.ATK * this.baseDmg), base.Layers);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		CardData DefaultTarget = base.GetDefaultTarget();
		if (player.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && slotsOnPlayerTable.IndexOf(player.CurrentCardSlotData) == slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3)
		{
			base.ShowMe();
			int num;
			for (int i = 0; i < base.Layers; i = num + 1)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(DefaultTarget))
				{
					yield return DungeonOperationMgr.Instance.Hit(this.CardData, DefaultTarget, Mathf.CeilToInt((float)this.CardData.ATK * this.baseDmg), 0.2f, false, 0, null, null);
				}
				num = i;
			}
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_3");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_3"), Mathf.CeilToInt((float)this.CardData.ATK * this.baseDmg), base.Layers);
	}

	private float baseDmg = 0.1f;

	private WaitForSeconds waitSeconds = new WaitForSeconds(0.3f);
}
