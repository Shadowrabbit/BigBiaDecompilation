using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class LiuLangGouSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(0, 3, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_130");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_130");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 3, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_130");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_130");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		this.isUsing = true;
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.isUsing = false;
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.isUsing = false;
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		CardData DefaultTarget = base.GetDefaultTarget();
		if (player.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) && slotsOnPlayerTable.IndexOf(player.CurrentCardSlotData) != slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3 && this.isUsing)
		{
			base.ShowMe();
			if (base.GetLogic(this.CardData, typeof(LiuLangGouCardLogic)) == null)
			{
				yield break;
			}
			int num;
			for (int i = 0; i < base.GetLogic(this.CardData, typeof(LiuLangGouCardLogic)).Layers; i = num + 1)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(DefaultTarget))
				{
					if (i == base.GetLogic(this.CardData, typeof(LiuLangGouCardLogic)).Layers - 1)
					{
						yield return DungeonOperationMgr.Instance.Hit(this.CardData, DefaultTarget, Mathf.CeilToInt((float)this.CardData.ATK * this.baseDmg), 0.2f, false, 0, null, null);
					}
					else
					{
						GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, DefaultTarget, Mathf.CeilToInt((float)this.CardData.ATK * this.baseDmg), 0.2f, false, 0, null, null));
						yield return this.waitSeconds;
					}
				}
				num = i;
			}
		}
		yield break;
	}

	private bool isUsing;

	private float baseDmg = 0.1f;

	private WaitForSeconds waitSeconds = new WaitForSeconds(0.3f);
}
