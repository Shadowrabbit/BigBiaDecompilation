using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeiQiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_192");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_192"), this.baseDmg + this.increaseDmg * (float)base.Layers);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_192");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_192"), this.baseDmg + this.increaseDmg * (float)base.Layers);
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
						if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null)
						{
							yield break;
						}
					}
					base.ShowMe();
					attackMsg.IsRealDmg = true;
					attackMsg.Dmg *= attackMsg.Target.HP;
				}
			}
		}
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.ShotEffects.Add("");
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.HitEffects.Add("Effect/Damaged");
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 1f;
}
