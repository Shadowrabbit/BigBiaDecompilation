using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		if (this.CardData != null)
		{
			this.displayName = "耍酒疯";
			this.Desc = string.Concat(new string[]
			{
				"攻击造成",
				Mathf.CeilToInt((float)this.CardData.ATK * (0.5f * (float)base.Layers)).ToString(),
				"[",
				(50 * base.Layers).ToString(),
				"%攻击力]点额外伤害。同时也对左右两格的友军造成此伤害。"
			});
		}
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		AreaData areaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId];
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (attackMsg.Target != null)
				{
					base.ShowMe();
					attackMsg.Dmg += Mathf.CeilToInt(0.5f * (float)base.Layers * (float)this.CardData.ATK);
				}
			}
			List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
			List<CardData> list = new List<CardData>();
			if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != 0 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2)
			{
				CardSlotData cardSlotData = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) - 1];
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData.ChildCardData);
				}
			}
			if (slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count / 3 * 2 - 1 && slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) != slotsOnPlayerTable.Count - 1)
			{
				CardSlotData cardSlotData2 = slotsOnPlayerTable[slotsOnPlayerTable.IndexOf(this.CardData.CurrentCardSlotData) + 1];
				if (cardSlotData2.ChildCardData != null && cardSlotData2.ChildCardData.HasTag(TagMap.随从))
				{
					list.Add(cardSlotData2.ChildCardData);
				}
			}
			if (list.Count > 0)
			{
				foreach (CardData target2 in list)
				{
					DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Add(new AttackMsg(target2, Mathf.CeilToInt((float)this.CardData.ATK * 0.5f), false, true, 0, 0, null));
				}
			}
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.yellow;
		if (this.CardData != null)
		{
			this.displayName = "耍酒疯";
			this.Desc = string.Concat(new string[]
			{
				"攻击造成",
				Mathf.CeilToInt((float)this.CardData.ATK * (0.5f * (float)base.Layers)).ToString(),
				"[",
				(50 * base.Layers).ToString(),
				"%攻击力]点额外伤害。同时也对左右两格的友军造成此伤害。"
			});
		}
	}
}
