using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongJiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖5");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖5");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖5");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖5");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (this.CanAttack)
		{
			this.CardData._ATK = 20;
		}
		else
		{
			this.CardData._ATK = 0;
		}
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (!this.CanAttack)
		{
			yield break;
		}
		UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("XuLi");
		yield return new WaitForSeconds(1f);
		if (base.GetLogic(this.CardData, typeof(BossWormCardLogic)) != null)
		{
			CardData lockedTarget = (base.GetLogic(this.CardData, typeof(BossWormCardLogic)) as BossWormCardLogic).LockedTarget;
			if (!DungeonOperationMgr.Instance.CheckCardDead(lockedTarget))
			{
				yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, lockedTarget.CurrentCardSlotData);
				List<AttackMsg> list = new List<AttackMsg>();
				for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
				{
					foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
					{
						if (attackMsg.Target != null && GameController.getInstance().GameData.SlotsOnPlayerTable.Contains(attackMsg.Target.CurrentCardSlotData))
						{
							base.ShowMe();
							List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
							List<CardData> list2 = new List<CardData>();
							if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) < slotsOnPlayerTable.Count / 3 * 2)
							{
								CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
								if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
								{
									list2.Add(cardSlotData.ChildCardData);
								}
							}
							if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
							{
								CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - 1];
								if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
								{
									list2.Add(cardSlotData2.ChildCardData);
								}
							}
							if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
							{
								CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + 1];
								if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
								{
									list2.Add(cardSlotData3.ChildCardData);
								}
							}
							if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
							{
								CardSlotData cardSlotData4 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
								if (cardSlotData4.ChildCardData != null && cardSlotData4.ChildCardData.HasTag(TagMap.随从))
								{
									list2.Add(cardSlotData4.ChildCardData);
								}
							}
							if (list2.Count > 0)
							{
								foreach (CardData target2 in list2)
								{
									list.Add(new AttackMsg(target2, 10, false, true, 0, 0, null));
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
				yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
			}
			for (int j = 0; j < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; j++)
			{
				foreach (AttackMsg attackMsg2 in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[j])
				{
					int count = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[j].Count;
					attackMsg2.Dmg = Mathf.CeilToInt((float)this.CardData.ATK / (float)count);
				}
			}
		}
		yield break;
	}

	public int Count = 1;

	public bool CanAttack;
}
