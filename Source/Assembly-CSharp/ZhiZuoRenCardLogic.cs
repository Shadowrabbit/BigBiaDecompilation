using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhiZuoRenCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_鸡汤");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_鸡汤");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_鸡汤");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_鸡汤");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		if (this.Jumped)
		{
			yield break;
		}
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		List<Vector3Int> list2 = new List<Vector3Int>
		{
			Vector3Int.up,
			Vector3Int.down,
			Vector3Int.left,
			Vector3Int.right
		};
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (cardData != this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				bool flag = false;
				foreach (Vector3Int vector3Int in list2)
				{
					CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(cardData.CurrentCardSlotData.GridPositionX, cardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
					if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && base.GetMyBattleArea().Contains(ralitiveCardSlotData))
					{
						flag = true;
					}
				}
				if (flag)
				{
					list.Add(cardData);
				}
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData target = list[SYNCRandom.Range(0, list.Count)];
		List<CardSlotData> list3 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int2 in list2)
		{
			CardSlotData ralitiveCardSlotData2 = spaceAreaData.GetRalitiveCardSlotData(target.CurrentCardSlotData.GridPositionX, target.CurrentCardSlotData.GridPositionY, vector3Int2.x, vector3Int2.y, false);
			if (ralitiveCardSlotData2 != null && ralitiveCardSlotData2.ChildCardData == null && base.GetMyBattleArea().Contains(ralitiveCardSlotData2) && ralitiveCardSlotData2.ChildCardData == null)
			{
				list3.Add(ralitiveCardSlotData2);
			}
		}
		yield return this.CardData.CardGameObject.JumpToSlot(list3[SYNCRandom.Range(0, list3.Count)].CardSlotGameObject, 0.2f, true);
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_未来的总裁就是你"));
		yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, target);
		target.AddAffix(DungeonAffix.strength, 2);
		target.AddAffix(DungeonAffix.heal, 2);
		this.Jumped = true;
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (this.Jumped)
		{
			yield break;
		}
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		if (allCurrentMonsters.Count == 0)
		{
			yield break;
		}
		List<CardData> list = new List<CardData>();
		List<Vector3Int> list2 = new List<Vector3Int>
		{
			Vector3Int.up,
			Vector3Int.down,
			Vector3Int.left,
			Vector3Int.right
		};
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (CardData cardData in allCurrentMonsters)
		{
			if (cardData != this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				bool flag = false;
				foreach (Vector3Int vector3Int in list2)
				{
					CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(cardData.CurrentCardSlotData.GridPositionX, cardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
					if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && base.GetMyBattleArea().Contains(ralitiveCardSlotData))
					{
						flag = true;
					}
				}
				if (flag)
				{
					list.Add(cardData);
				}
			}
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardData target = list[SYNCRandom.Range(0, list.Count)];
		List<CardSlotData> list3 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int2 in list2)
		{
			CardSlotData ralitiveCardSlotData2 = spaceAreaData.GetRalitiveCardSlotData(target.CurrentCardSlotData.GridPositionX, target.CurrentCardSlotData.GridPositionY, vector3Int2.x, vector3Int2.y, false);
			if (ralitiveCardSlotData2 != null && ralitiveCardSlotData2.ChildCardData == null && base.GetMyBattleArea().Contains(ralitiveCardSlotData2) && ralitiveCardSlotData2.ChildCardData == null)
			{
				list3.Add(ralitiveCardSlotData2);
			}
		}
		yield return this.CardData.CardGameObject.JumpToSlot(list3[SYNCRandom.Range(0, list3.Count)].CardSlotGameObject, 0.2f, true);
		base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord("T_未来的总裁就是你"));
		yield return base.wATKUp(this.CardData.CardGameObject.transform.position, 0, target);
		target.AddAffix(DungeonAffix.strength, 2);
		target.AddAffix(DungeonAffix.heal, 2);
		this.Jumped = true;
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.Jumped = false;
		}
		yield break;
	}

	private bool Jumped;
}
