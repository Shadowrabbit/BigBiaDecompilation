using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHornCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_61");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_61");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_61");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_61");
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		base.OnBeforeAttack(player, target);
		if (player == this.CardData && !this.HasJumped)
		{
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.HasJumped = false;
			this.HasAttacked = false;
			yield break;
		}
		yield break;
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !this.HasAttacked)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
			this.HasAttacked = true;
		}
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
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
			this.HasJumped = true;
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		}
		if (csd.ChildCardData != null && csd.ChildCardData.Attrs.ContainsKey("Col"))
		{
			csd.ChildCardData.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	private CardData CurrentData;

	private bool HasJumped;

	private bool HasAttacked;
}
