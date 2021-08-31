using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_63");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_63");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_63");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_63");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (this.CardData == null)
		{
			yield break;
		}
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<AttackMsg> list = new List<AttackMsg>();
		List<Vector3Int> list2 = new List<Vector3Int>
		{
			Vector3Int.left,
			Vector3Int.right
		};
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target != null && GameController.getInstance().GameData.SlotsOnPlayerTable.Contains(attackMsg.Target.CurrentCardSlotData))
				{
					base.ShowMe();
					List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
					List<CardData> list3 = new List<CardData>();
					if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
					{
						CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - 1];
						if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
						{
							list3.Add(cardSlotData.ChildCardData);
						}
					}
					if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
					{
						CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + 1];
						if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
						{
							list3.Add(cardSlotData2.ChildCardData);
						}
					}
					if (list3.Count > 0)
					{
						foreach (CardData target2 in list3)
						{
							list.Add(new AttackMsg(target2, Mathf.CeilToInt((float)this.CardData.ATK * 1f), false, true, 0, 0, null));
						}
					}
				}
			}
			foreach (Vector3Int vector3Int in list2)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null)
				{
					list.Add(new AttackMsg(ralitiveCardSlotData.ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * 1f), false, true, 0, 0, null));
				}
			}
			if (list != null && list.Count > 0)
			{
				foreach (AttackMsg item in list)
				{
					DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Add(item);
				}
			}
			list.Clear();
		}
		yield break;
	}
}
