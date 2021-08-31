using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YongDouPengDaRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("M_N_3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("M_D_3");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("M_N_3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("M_D_3");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData)
		{
			List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
			if (enemiesBattleArea == null)
			{
				yield break;
			}
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			Vector3Int vector3Int = Vector3Int.down + Vector3Int.left;
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(target.GridPositionX, target.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData == null || !enemiesBattleArea.Contains(ralitiveCardSlotData))
			{
				yield break;
			}
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物) && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData))
			{
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, ralitiveCardSlotData.ChildCardData, this.CardData.ATK, 0.2f, false, 0, null, null);
			}
		}
		yield break;
	}
}
