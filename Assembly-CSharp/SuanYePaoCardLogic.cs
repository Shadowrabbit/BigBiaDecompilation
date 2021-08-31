using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SuanYePaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖2");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖2");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖2");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.CardData._ATK = 3;
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		List<AttackMsg> list = new List<AttackMsg>();
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target != null)
				{
					base.ShowMe();
					List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
					List<CardData> list2 = new List<CardData>();
					if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3 * 2)
					{
						CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
						if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
						{
							list2.Add(cardSlotData.ChildCardData);
						}
						cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3 * 2];
						if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
						{
							list2.Add(cardSlotData.ChildCardData);
						}
					}
					else if (slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) >= slotsOnPlayerTable.Count / 3)
					{
						CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
						if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
						{
							list2.Add(cardSlotData2.ChildCardData);
						}
						cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) - slotsOnPlayerTable.Count / 3];
						if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
						{
							list2.Add(cardSlotData2.ChildCardData);
						}
					}
					else
					{
						CardSlotData cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3];
						if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
						{
							list2.Add(cardSlotData3.ChildCardData);
						}
						cardSlotData3 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(attackMsg.Target.CurrentCardSlotData) + slotsOnPlayerTable.Count / 3 * 2];
						if (cardSlotData3.ChildCardData != null && cardSlotData3.ChildCardData.HasTag(TagMap.随从))
						{
							list2.Add(cardSlotData3.ChildCardData);
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
			if (list != null && list.Count > 0)
			{
				foreach (AttackMsg item in list)
				{
					DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Add(item);
				}
			}
			list.Clear();
		}
		for (int j = 0; j < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; j++)
		{
			foreach (AttackMsg attackMsg2 in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[j])
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(attackMsg2.Target))
				{
					attackMsg2.Target.AddAffix(DungeonAffix.frail, 2);
				}
			}
		}
		UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("ShuPen");
		yield return this.AttackShuPen();
		yield break;
	}

	private IEnumerator AttackShuPen()
	{
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/大虫子攻击", 0.5f);
			particleObject.transform.position = UnityEngine.Object.FindObjectOfType<BossWarmArea>().CardSlot.transform.position;
			Vector3 tarPos = DungeonOperationMgr.Instance.PlayerBattleArea[7].CardSlotGameObject.transform.position;
			tarPos = new Vector3(tarPos.x, tarPos.y, tarPos.z + 0.5f);
			tarPos = new Vector3(tarPos.x, tarPos.y, tarPos.z - (float)(3 * i) / 10f);
			particleObject.transform.DOMove(tarPos, 0.5f, false).OnComplete(delegate
			{
				ParticlePoolManager.Instance.Spawn("Effect/大虫子命中", 2f).transform.position = tarPos;
			});
			yield return new WaitForSeconds(0.05f);
			num = i;
		}
		yield return null;
		yield break;
	}
}
