using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuJiuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_79");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_79");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_79");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_79");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		if (base.GetMyBattleArea().Contains(this.CardData.CurrentCardSlotData) && this.CardData.Armor > 0)
		{
			base.ShowMe();
			List<AttackMsg> list = new List<AttackMsg>();
			List<Vector3Int> list2 = new List<Vector3Int>();
			list2.Add(Vector3Int.left);
			list2.Add(Vector3Int.right);
			AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
			for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
			{
				foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
				{
					if (attackMsg.Target != null)
					{
						base.ShowMe();
						List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
						List<CardData> list3 = new List<CardData>();
						if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3 * 2)
						{
							CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
							if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
							{
								list3.Add(cardSlotData.ChildCardData);
							}
							cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3 * 2];
							if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
							{
								list3.Add(cardSlotData.ChildCardData);
							}
						}
						else if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
						{
							CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
							if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
							{
								list3.Add(cardSlotData2.ChildCardData);
							}
							cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
							if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
							{
								list3.Add(cardSlotData2.ChildCardData);
							}
						}
						else
						{
							CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
							if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
							{
								list3.Add(cardSlotData3.ChildCardData);
							}
							cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3 * 2];
							if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
							{
								list3.Add(cardSlotData3.ChildCardData);
							}
						}
						if (list3.Count > 0)
						{
							foreach (CardData target2 in list3)
							{
								list.Add(new AttackMsg(target2, this.CardData.ATK, false, true, 0, 0, null));
							}
						}
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
		}
		yield break;
	}
}
