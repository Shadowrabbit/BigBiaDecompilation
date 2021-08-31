using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiXueLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "饮血";
		this.Desc = "每次攻击时回复10+(0.1*攻击力*命中敌人数量)生命。";
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player != this.CardData)
		{
			yield break;
		}
		List<CardData> extraTarget2 = new List<CardData>();
		int AttackTimes2 = this.CardData.AttackTimes;
		int num2;
		for (int q = 0; q < AttackTimes2; q = num2 + 1)
		{
			if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData))
			{
				yield break;
			}
			if (this.CardData.AttackExtraRange != null)
			{
				SpaceAreaData dungeonAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
				if (dungeonAreaData != null)
				{
					foreach (Vector3Int vector3Int in this.CardData.AttackExtraRange)
					{
						CardSlotData checkedNeighbourSlotData = dungeonAreaData.GetRalitiveCardSlotData(target.GridPositionX, target.GridPositionY, vector3Int.x, vector3Int.y, false);
						if (checkedNeighbourSlotData != null && checkedNeighbourSlotData.ChildCardData != null && checkedNeighbourSlotData.ChildCardData.HasTag(TagMap.怪物))
						{
							yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, checkedNeighbourSlotData.ChildCardData, 0.1f, null, null, null);
							extraTarget2.Add(checkedNeighbourSlotData.ChildCardData);
							checkedNeighbourSlotData = null;
						}
					}
					List<Vector3Int>.Enumerator enumerator = default(List<Vector3Int>.Enumerator);
				}
				dungeonAreaData = null;
			}
			int num = 10 + Mathf.CeilToInt(0.1f * (float)this.CardData.ATK) * (extraTarget2.Count + 1);
			base.ShowMe();
			this.CardData.HP = ((this.CardData.HP + num > this.CardData.MaxHP) ? this.CardData.MaxHP : (this.CardData.HP + num));
			num2 = q;
		}
		yield break;
		yield break;
	}

	private DungeonHandler DungeonHandler = new DungeonHandler();
}
