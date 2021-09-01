using System;
using System.Collections.Generic;
using UnityEngine;

public class MinionLogic : CardLogic
{
	public MinionLogic()
	{
		this.displayName = "攻击";
	}

	public override void OnLeftClick(List<Vector2[]> res)
	{
		if (!CardUtils.IsUserCard(this.CardData))
		{
			return;
		}
		if (VSModeController.Instance != null || MultiPlayerController.Instance != null)
		{
			return;
		}
		Hero component = base.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
		List<CardSlotData> slotsOnPlayerTable = GameController.getInstance().GameData.SlotsOnPlayerTable;
		if (GameController.ins.GameData.isInDungeon && (DungeonOperationMgr.Instance != null & DungeonOperationMgr.Instance.BattleArea != null))
		{
			for (int i = 0; i < DungeonOperationMgr.Instance.BattleArea.Count; i++)
			{
				if (DungeonOperationMgr.Instance.BattleArea[i].ChildCardData != null)
				{
					if (Convert.ToInt32(DungeonOperationMgr.Instance.BattleArea[i].Attrs["Col"]) != Convert.ToInt32(this.CardData.CurrentCardSlotData.Attrs["Col"]) && Convert.ToInt32(DungeonOperationMgr.Instance.BattleArea[i].Attrs["Col"]) < 2147483647)
					{
						DungeonOperationMgr.Instance.BattleArea[i].ChildCardData.CardGameObject.CanBeSelected = false;
					}
					else
					{
						int num = 0;
						for (int j = i + 3; j < DungeonOperationMgr.Instance.BattleArea.Count; j += 3)
						{
							if (DungeonOperationMgr.Instance.BattleArea[j].ChildCardData != null && DungeonOperationMgr.Instance.BattleArea[j].Attrs.ContainsKey("Col") && Convert.ToInt32(DungeonOperationMgr.Instance.BattleArea[i].Attrs["Col"]) == Convert.ToInt32(DungeonOperationMgr.Instance.BattleArea[i].Attrs["Col"]) && (DungeonOperationMgr.Instance.BattleArea[j].ChildCardData.HasTag(TagMap.怪物) || DungeonOperationMgr.Instance.BattleArea[j].ChildCardData.HasTag(TagMap.放置物)))
							{
								num++;
							}
						}
						if (num > this.CardData.ATKRange)
						{
							DungeonOperationMgr.Instance.BattleArea[i].ChildCardData.CardGameObject.CanBeSelected = false;
						}
					}
				}
			}
		}
		component.SetDirectionalSkill(this.CardData);
	}

	public override bool OnUse(List<Vector2[]> res)
	{
		if (!CardUtils.IsUserCard(this.CardData))
		{
			return false;
		}
		Hero component = base.GameController.GameData.PlayerCardData.CardGameObject.GetComponent<Hero>();
		CardData target = component.Target;
		if (target != null && (target.HasTag(TagMap.怪物) || (target.HasTag(TagMap.衍生物) && !target.HasTag(TagMap.随从)) || target.HasTag(TagMap.放置物) || target.HasTag(TagMap.装备)))
		{
			if (target.CardGameObject != null && !target.CardGameObject.CanBeSelected)
			{
				return false;
			}
			List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
			DungeonOperationMgr.Instance.OnLeftClicked(this.CardData, component.Target);
		}
		component.OnReleasedSkill();
		return true;
	}

	public string particleName = "Effect/snowball";

	public string particleName1 = "Effect/snowball_hero";
}
