using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_122");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_122");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_122");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_122");
	}

	public override IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		base.OnUserAsArms(origin, Target);
		CardData cardData = null;
		List<Vector3Int> list = new List<Vector3Int>();
		Vector3Int down = Vector3Int.down;
		list.Add(down);
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		if (Target != null)
		{
			foreach (Vector3Int vector3Int in list)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(Target.CurrentCardSlotData.GridPositionX, Target.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
				{
					cardData = ralitiveCardSlotData.ChildCardData;
				}
			}
		}
		if (Target != null && !DungeonOperationMgr.Instance.CheckCardDead(Target))
		{
			DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(Target, -this.CardData.ATK, origin, false, 0, true, false));
		}
		if (cardData != null && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
		{
			DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, -this.CardData.ATK, origin, false, 0, true, false));
		}
		yield break;
	}
}
