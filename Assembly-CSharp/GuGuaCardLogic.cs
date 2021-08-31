using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuGuaCardLogic : CardLogic
{
	public override void Init()
	{
		this.Color = CardLogicColor.red;
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_FFF");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_FFF"), Mathf.CeilToInt((float)this.CardData.ATK * (this.increaseDmg * (float)base.Layers)), this.increaseDmg * (float)base.Layers * 100f);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
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
		List<CardData> list2 = new List<CardData>();
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					foreach (Vector3Int vector3Int in list)
					{
						CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(attackMsg.Target.CurrentCardSlotData.GridPositionX, attackMsg.Target.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
						if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData))
						{
							list2.Add(ralitiveCardSlotData.ChildCardData);
						}
					}
					if (list2.Count == 1)
					{
						attackMsg.Dmg += Mathf.CeilToInt((float)this.CardData.ATK * (this.increaseDmg * (float)base.Layers));
						base.ShowMe();
					}
				}
			}
		}
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 0.5f;
}
