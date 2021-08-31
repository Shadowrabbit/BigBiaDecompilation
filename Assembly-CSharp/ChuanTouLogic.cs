using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuanTouLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		if (this.CardData != null)
		{
			this.displayName = "穿透";
			this.Desc = string.Concat(new string[]
			{
				"攻击对所有目标身后1格的单位造成",
				Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers).ToString(),
				"【",
				(50 * base.Layers).ToString(),
				"%攻击力】伤害。"
			});
		}
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<Vector3Int> list = new List<Vector3Int>();
		Vector3Int down = Vector3Int.down;
		list.Add(down);
		List<List<AttackMsg>> targets = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets;
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<AttackMsg> list2 = new List<AttackMsg>();
		if (targets != null && targets.Count > 0)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				List<AttackMsg> list3 = targets[i];
				foreach (AttackMsg attackMsg in list3)
				{
					if (attackMsg.Target != null && !DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
					{
						foreach (Vector3Int vector3Int in list)
						{
							CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(attackMsg.Target.CurrentCardSlotData.GridPositionX, attackMsg.Target.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
							if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
							{
								list2.Add(new AttackMsg(ralitiveCardSlotData.ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers), false, true, 0, 0, null));
							}
						}
					}
				}
				if (list2 != null && list2.Count > 0)
				{
					foreach (AttackMsg item in list2)
					{
						list3.Add(item);
					}
					base.ShowMe();
					list2.Clear();
				}
			}
		}
		DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets = targets;
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.red;
		this.displayName = "穿透";
		this.Desc = string.Concat(new string[]
		{
			"攻击对目标身后1格的单位造成",
			Mathf.CeilToInt((float)this.CardData.ATK * 0.5f * (float)base.Layers).ToString(),
			"【",
			(50 * base.Layers).ToString(),
			"%攻击力】伤害。"
		});
	}
}
