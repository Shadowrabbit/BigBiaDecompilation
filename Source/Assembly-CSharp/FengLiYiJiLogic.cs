using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FengLiYiJiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = "奋力一击";
		this.Desc = "每次攻击时" + (35 + base.Layers * 25).ToString() + "%的概率击晕敌人 2 层。";
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		if (UnityEngine.Random.Range(0, 100) > 35 + base.Layers * 25)
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
			yield break;
		}
		List<CardData> extraTarget2 = new List<CardData>();
		CardData targetCardData2 = target.ChildCardData;
		int AttackTimes2 = this.CardData.AttackTimes;
		int num;
		for (int q = 0; q < AttackTimes2; q = num + 1)
		{
			if (DungeonOperationMgr.Instance.CheckCardDead(this.CardData) || DungeonOperationMgr.Instance.CheckCardDead(targetCardData2))
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
						CardSlotData checkedNeighbourSlotData = dungeonAreaData.GetRalitiveCardSlotData(targetCardData2.CurrentCardSlotData.GridPositionX, targetCardData2.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
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
			yield return DungeonOperationMgr.Instance.PlayerAttackEffect(this.CardData, targetCardData2, 1f, null, null, null);
			foreach (CardData cardData in extraTarget2)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					cardData.DizzyLayer += 2;
					yield return this.DungeonHandler.ChangeHp(cardData, -this.CardData.ATK, this.CardData, false, 0, true, false);
				}
			}
			List<CardData>.Enumerator enumerator2 = default(List<CardData>.Enumerator);
			if (!DungeonOperationMgr.Instance.CheckCardDead(targetCardData2))
			{
				target.ChildCardData.DizzyLayer += 2;
				yield return this.DungeonHandler.ChangeHp(targetCardData2, -this.CardData.ATK, this.CardData, false, 0, true, false);
			}
			base.ShowMe();
			num = q;
		}
		yield break;
		yield break;
	}

	private DungeonHandler DungeonHandler = new DungeonHandler();
}
