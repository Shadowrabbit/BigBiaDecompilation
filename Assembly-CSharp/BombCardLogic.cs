using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_168");
		this.Desc = "死亡时，对相邻单位造成自身最大生命值的伤害。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_168");
		this.Desc = "死亡时，对相邻单位造成自身最大生命值的伤害。";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		base.OnKill(target, value, from);
		if (target == this.CardData)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			list.Add(Vector3Int.left);
			list.Add(Vector3Int.right);
			list.Add(Vector3Int.up);
			list.Add(Vector3Int.down);
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			List<CardData> list2 = new List<CardData>();
			foreach (Vector3Int vector3Int in list)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null)
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
						DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, this.CardData.MaxHP, 0.2f, false, 0, null, null));
					}
					yield break;
				}
			}
		}
		yield break;
	}
}
