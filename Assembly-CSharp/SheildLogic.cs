using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_182");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_182"), base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_182");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_182"), base.Layers);
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData) || DungeonOperationMgr.Instance.CheckCardDead(player) || player != this.CardData || target.ChildCardData.HasTag(TagMap.BOSS))
		{
			yield break;
		}
		List<List<AttackMsg>> targets = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets;
		if (targets == null || targets.Count == 0)
		{
			yield break;
		}
		foreach (List<AttackMsg> list in targets)
		{
			if (list != null && list.Count != 0)
			{
				foreach (AttackMsg msg in list)
				{
					if (msg.Target != null && !DungeonOperationMgr.Instance.CheckCardDead(msg.Target))
					{
						int num;
						for (int i = 0; i < base.Layers; i = num + 1)
						{
							base.ShowMe();
							yield return base.Shifting(msg.Target.CurrentCardSlotData, Vector3Int.down, base.GetEnemiesBattleArea());
							num = i;
						}
						msg = null;
					}
				}
				List<AttackMsg>.Enumerator enumerator2 = default(List<AttackMsg>.Enumerator);
			}
		}
		List<List<AttackMsg>>.Enumerator enumerator = default(List<List<AttackMsg>>.Enumerator);
		yield break;
		yield break;
	}
}
