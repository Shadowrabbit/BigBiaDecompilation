using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhengZhiLaoShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_课本倒背如流");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_课本倒背如流"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg * (float)base.Layers)), this.baseDmg * (float)base.Layers * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_课本倒背如流");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_课本倒背如流"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg * (float)base.Layers)), this.baseDmg * (float)base.Layers * 100f);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (!this.targets.Contains(attackMsg.Target) && !DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					this.targets.Add(attackMsg.Target);
				}
			}
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (player != this.CardData)
		{
			yield break;
		}
		if (this.targets.Count == 0)
		{
			yield break;
		}
		Dictionary<CardData, int> currentTargets = new Dictionary<CardData, int>();
		for (int i = 0; i < this.targets.Count; i++)
		{
			if (this.targets[i].HasTag(TagMap.怪物))
			{
				if (DungeonOperationMgr.Instance.CheckCardDead(this.targets[i]))
				{
					this.targets.RemoveAt(i);
				}
				else
				{
					currentTargets.Add(this.targets[i], -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg * (float)base.Layers)));
				}
			}
		}
		if (currentTargets.Count > 0)
		{
			base.ShowMe();
			yield return base.AOE(currentTargets, this.CardData, false, 0, true);
			if (base.GetLogic(this.CardData, typeof(ZhengZhiLaoShiSkill2CardLogic)) != null)
			{
				(base.GetLogic(this.CardData, typeof(ZhengZhiLaoShiSkill2CardLogic)) as ZhengZhiLaoShiSkill2CardLogic).count += currentTargets.Count;
			}
		}
		yield break;
	}

	public List<CardData> targets = new List<CardData>();

	private float baseDmg = 0.1f;
}
