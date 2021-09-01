using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingShiZhaDanCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "定时炸弹";
		this.Desc = this.time.ToString() + "回合后爆炸，被击杀时对相邻4格的单位造成8点伤害。";
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "定时炸弹";
		this.Desc = this.time.ToString() + "回合后爆炸，被击杀时对相邻4格的单位造成8点伤害。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.time--;
			if (this.time < 0)
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, -999, this.CardData, false, 0, true, false);
			}
		}
		yield break;
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
						DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, targetCardData, 8, 0.2f, false, 0, null, null));
					}
					yield break;
				}
			}
		}
		yield break;
	}

	private int time = 3;
}
