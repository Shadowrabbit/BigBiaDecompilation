using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTreeSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null)
		{
			if (logic.Layers == 1)
			{
				this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树2");
				this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树2");
				return;
			}
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树3");
			this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树3");
		}
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		CardLogic logic = base.GetLogic(this.CardData, typeof(BossTreeCardLogic));
		if (logic != null)
		{
			if (logic.Layers == 1)
			{
				List<AttackMsg> list = new List<AttackMsg>();
				for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
				{
					using (List<AttackMsg>.Enumerator enumerator = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.Target != null)
							{
								List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
								List<CardData> list2 = new List<CardData>();
								for (int j = playerSlotSets.Count / 3 * 2; j < playerSlotSets.Count; j++)
								{
									if (playerSlotSets[j] != null && playerSlotSets[j].ChildCardData != null && playerSlotSets[j].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[j].ChildCardData))
									{
										list2.Add(playerSlotSets[j].ChildCardData);
									}
									else if (playerSlotSets[j - playerSlotSets.Count / 3] != null && playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData != null && playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData))
									{
										list2.Add(playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData);
									}
									else if (playerSlotSets[j - playerSlotSets.Count / 3 * 2] != null && playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData != null && playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData))
									{
										list2.Add(playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData);
									}
								}
								if (list2.Count > 0)
								{
									foreach (CardData target2 in list2)
									{
										list.Add(new AttackMsg(target2, this.CardData.ATK, false, true, 0, 0, null));
									}
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
			else
			{
				List<AttackMsg> list3 = new List<AttackMsg>();
				List<Vector3Int> list4 = new List<Vector3Int>();
				list4.Add(Vector3Int.left);
				list4.Add(Vector3Int.right);
				AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
				for (int k = 0; k < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; k++)
				{
					foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[k])
					{
						if (attackMsg.Target != null)
						{
							base.ShowMe();
							List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
							List<CardData> list5 = new List<CardData>();
							if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3 * 2)
							{
								CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
								if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
								{
									list5.Add(cardSlotData.ChildCardData);
								}
								cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3 * 2];
								if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
								{
									list5.Add(cardSlotData.ChildCardData);
								}
							}
							else if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
							{
								CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
								if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
								{
									list5.Add(cardSlotData2.ChildCardData);
								}
								cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
								if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
								{
									list5.Add(cardSlotData2.ChildCardData);
								}
							}
							else
							{
								CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
								if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
								{
									list5.Add(cardSlotData3.ChildCardData);
								}
								cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3 * 2];
								if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
								{
									list5.Add(cardSlotData3.ChildCardData);
								}
							}
							if (list5.Count > 0)
							{
								foreach (CardData target3 in list5)
								{
									list3.Add(new AttackMsg(target3, this.CardData.ATK, false, true, 0, 0, null));
								}
							}
						}
					}
					if (list3 != null && list3.Count > 0)
					{
						foreach (AttackMsg item2 in list3)
						{
							DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[k].Add(item2);
						}
					}
					list3.Clear();
				}
			}
		}
		yield break;
	}
}
