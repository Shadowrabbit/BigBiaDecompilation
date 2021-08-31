using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuoSheDanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_113");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_113");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_113");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_113");
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			list.Add(Vector3Int.down);
			list.Add(Vector3Int.down * 2);
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			List<CardData> list2 = new List<CardData>();
			foreach (Vector3Int vector3Int in list)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && (ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物) || ralitiveCardSlotData.ChildCardData.HasTag(TagMap.衍生物)))
				{
					list2.Add(ralitiveCardSlotData.ChildCardData);
				}
			}
			if (list2.Count > 0)
			{
				using (List<CardData>.Enumerator enumerator2 = list2.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						CardData targetCardData = enumerator2.Current;
						DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, 15, 0.2f, false, 0, null, null));
					}
					yield break;
				}
			}
		}
		yield break;
	}
}
