using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class ZhengZhiLaoShiSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.NeedEnergyCount = new Vector3Int(0, 2, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_考试自由发挥");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_考试自由发挥"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg * (float)base.Layers)), this.baseDmg * (float)base.Layers * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_考试自由发挥");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_考试自由发挥"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg * (float)base.Layers)), this.baseDmg * (float)base.Layers * 100f);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player == this.CardData)
		{
			this.count++;
		}
		yield break;
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.count = 0;
		yield break;
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		base.ShowMe();
		int num;
		for (int i = 0; i < this.count; i = num + 1)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			CardData targetCardData = allCurrentMonsters[SYNCRandom.Range(0, allCurrentMonsters.Count)];
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg * (float)base.Layers)), 0.2f, false, 0, null, null);
			num = i;
		}
		yield break;
	}

	private float baseDmg = 0.1f;

	public int count;
}
