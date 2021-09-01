using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuiHuoYiRenLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_102");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_102");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_102");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_102");
	}

	public override IEnumerator OnTurnStart()
	{
		if (!this.m_IsJump)
		{
			this.m_IsJump = true;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.m_IsJump = false;
			yield break;
		}
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
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (!myBattleArea.Contains(this.CardData.CurrentCardSlotData))
		{
			yield break;
		}
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) < myBattleArea.Count / 3 * 2)
		{
			yield break;
		}
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
							base.ShowMe();
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

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.up);
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && myBattleArea.Contains(ralitiveCardSlotData))
			{
				list2.Add(ralitiveCardSlotData);
			}
		}
		if (list2.Count == 0)
		{
			yield break;
		}
		CardSlotData target = list2[SYNCRandom.Range(0, list2.Count)];
		if (csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		}
		myBattleArea = base.GetMyBattleArea();
		if (csd.ChildCardData != null && csd.ChildCardData.Attrs.ContainsKey("Col"))
		{
			csd.ChildCardData.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	private bool m_IsJump;
}
