using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenGunLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_12");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_12"), Mathf.CeilToInt(0.5f * (float)base.Layers * (float)this.CardData.ATK), 50 * base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.red;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_12");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_12"), Mathf.CeilToInt(0.5f * (float)base.Layers * (float)this.CardData.ATK), 50 * base.Layers);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (target.ChildCardData == null)
		{
			yield break;
		}
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<Vector3Int> list = new List<Vector3Int>
		{
			Vector3Int.left,
			Vector3Int.right,
			Vector3Int.up,
			Vector3Int.down
		};
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target != null && !DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					foreach (Vector3Int vector3Int in list)
					{
						CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(attackMsg.Target.CurrentCardSlotData.GridPositionX, attackMsg.Target.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
						if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
						{
							yield break;
						}
					}
					base.ShowMe();
					attackMsg.Dmg += Mathf.CeilToInt(0.5f * (float)base.Layers * (float)this.CardData.ATK);
				}
			}
		}
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.ShotEffects.Add("Effect/刺杀");
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.HitEffects.Add("Effect/刺杀命中");
		yield break;
	}
}
