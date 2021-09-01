using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LieRiJingLingLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_146");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_146");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_146");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_146");
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		if (this.CardData.Armor <= 0)
		{
			yield break;
		}
		base.ShowMe();
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea.Contains(this.CardData.CurrentCardSlotData) && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) >= myBattleArea.Count / 3 * 2)
		{
			List<AttackMsg> list = new List<AttackMsg>();
			List<Vector3Int> list2 = new List<Vector3Int>();
			list2.Add(Vector3Int.left);
			list2.Add(Vector3Int.right);
			AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
			for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
			{
				using (List<AttackMsg>.Enumerator enumerator = DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Target != null)
						{
							List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
							List<CardData> list3 = new List<CardData>();
							for (int j = playerSlotSets.Count / 3 * 2; j < playerSlotSets.Count; j++)
							{
								if (playerSlotSets[j] != null && playerSlotSets[j].ChildCardData != null && playerSlotSets[j].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[j].ChildCardData))
								{
									list3.Add(playerSlotSets[j].ChildCardData);
								}
								else if (playerSlotSets[j - playerSlotSets.Count / 3] != null && playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData != null && playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData))
								{
									list3.Add(playerSlotSets[j - playerSlotSets.Count / 3].ChildCardData);
								}
								else if (playerSlotSets[j - playerSlotSets.Count / 3 * 2] != null && playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData != null && playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData.HasTag(TagMap.随从) && !DungeonOperationMgr.Instance.CheckCardDead(playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData))
								{
									list3.Add(playerSlotSets[j - playerSlotSets.Count / 3 * 2].ChildCardData);
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
