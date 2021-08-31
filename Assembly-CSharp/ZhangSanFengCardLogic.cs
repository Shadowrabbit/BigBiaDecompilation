using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhangSanFengCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_一日三疯");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_一日三疯"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_一日三疯");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_一日三疯"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player != this.CardData)
		{
			yield break;
		}
		this.count++;
		if (this.count == 1)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_一"));
		}
		if (this.count == 2)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_二"));
		}
		if (this.count >= 3)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_三"));
		}
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		if (this.count >= 3)
		{
			for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
			{
				foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
				{
					attackMsg.Dmg = Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers));
					this.targets.Add(attackMsg.Target);
				}
			}
		}
		yield break;
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (this.count >= 3 && this.targets.Count > 0 && player == this.CardData)
		{
			foreach (CardData cardData in this.targets)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && !cardData.HasTag(TagMap.BOSS))
				{
					cardData.DizzyLayer = 1;
				}
			}
			this.count = 0;
			this.targets.Clear();
		}
		yield break;
	}

	private List<CardData> targets = new List<CardData>();

	private float baseDmg = 1f;

	private float increaseDmg = 0.25f;

	private int count;
}
