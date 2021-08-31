using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuCheLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_165");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_165"), (float)base.Layers * 0.2f * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_165");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_165"), (float)base.Layers * 0.2f * 100f);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<List<AttackMsg>> targets = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets;
		List<AttackMsg> list = new List<AttackMsg>();
		if (targets != null && targets.Count > 0)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				List<AttackMsg> list2 = targets[i];
				foreach (AttackMsg attackMsg in list2)
				{
					if (attackMsg.Target != null && !DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
					{
						foreach (CardData cardData in base.GetAllCurrentMonsters())
						{
							if (!DungeonOperationMgr.Instance.CheckCardDead(cardData) && (int)cardData.CurrentCardSlotData.Attrs["Col"] == (int)attackMsg.Target.CurrentCardSlotData.Attrs["Col"] && cardData != attackMsg.Target && base.GetEnemiesBattleArea().IndexOf(cardData.CurrentCardSlotData) < base.GetEnemiesBattleArea().IndexOf(attackMsg.Target.CurrentCardSlotData))
							{
								list.Add(new AttackMsg(cardData, Mathf.CeilToInt((float)this.CardData.ATK * ((float)base.Layers * 0.2f)), false, true, 0, 0, null));
							}
						}
					}
				}
				if (list != null && list.Count > 0)
				{
					foreach (AttackMsg item in list)
					{
						list2.Add(item);
					}
					base.ShowMe();
					list.Clear();
				}
			}
		}
		yield break;
	}
}
