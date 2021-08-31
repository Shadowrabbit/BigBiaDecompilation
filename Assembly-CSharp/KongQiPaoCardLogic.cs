using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KongQiPaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_127");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_127");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_127");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_127");
	}

	public override void OnMerge(CardData mergeBy)
	{
		DungeonOperationMgr.Instance.StartCoroutine(this.TryJump(mergeBy.CurrentCardSlotData));
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
		if (battleArea == null || csd.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(csd.ChildCardData))
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		Vector3Int down = Vector3Int.down;
		CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, down.x, down.y, false);
		if (ralitiveCardSlotData == null || battleArea.IndexOf(csd) <= 2)
		{
			yield break;
		}
		if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(ralitiveCardSlotData.CardSlotGameObject, 0.2f, true);
			yield break;
		}
		yield break;
	}
}
