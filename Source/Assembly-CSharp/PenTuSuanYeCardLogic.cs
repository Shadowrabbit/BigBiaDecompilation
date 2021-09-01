using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class PenTuSuanYeCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖1");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_白胖1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_白胖1");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.CardData._ATK = 5;
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
		{
			yield break;
		}
		if (!base.GetMyBattleArea().Contains(this.CardData.CurrentCardSlotData))
		{
			yield break;
		}
		List<AttackMsg> list = new List<AttackMsg>();
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			using (List<AttackMsg>.Enumerator enumerator = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Target != null)
					{
						base.ShowMe();
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
				DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Clear();
				foreach (AttackMsg item in list)
				{
					DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Add(item);
				}
			}
			list.Clear();
		}
		for (int k = 0; k < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; k++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[k])
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					attackMsg.Target.AddAffix(DungeonAffix.frail, 2);
				}
			}
		}
		UnityEngine.Object.FindObjectOfType<BossWarmArea>().Boss.GetComponent<Animator>().SetTrigger("HengPen");
		yield return new WaitForSeconds(1.5f);
		yield return this.AttackHengPen();
		yield break;
	}

	private IEnumerator AttackHengPen()
	{
		int num;
		for (int i = 0; i < 10; i = num + 1)
		{
			ParticleObject particleObject = ParticlePoolManager.Instance.Spawn("Effect/大虫子攻击", 0.5f);
			particleObject.transform.position = UnityEngine.Object.FindObjectOfType<BossWarmArea>().CardSlot.transform.position;
			Vector3 tarPos = DungeonOperationMgr.Instance.PlayerBattleArea[8].CardSlotGameObject.transform.position;
			tarPos = new Vector3(tarPos.x + 0.5f, tarPos.y, tarPos.z);
			tarPos = new Vector3(tarPos.x - (float)(3 * i) / 10f, tarPos.y, tarPos.z);
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
