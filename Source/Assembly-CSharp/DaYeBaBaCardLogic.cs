using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaYeBaBaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_GANK");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_GANK");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_GANK");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_GANK");
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		if (this.Jumped)
		{
			yield break;
		}
		List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
		if (allEmptySlotsInMyBattleArea.Count == 0)
		{
			yield break;
		}
		base.ShowMe();
		yield return this.CardData.CardGameObject.JumpToSlot(allEmptySlotsInMyBattleArea[SYNCRandom.Range(0, allEmptySlotsInMyBattleArea.Count)].CardSlotGameObject, 0.2f, true);
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

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		List<CardData> list = new List<CardData>();
		List<Vector3Int> list2 = new List<Vector3Int>();
		list2.Add(Vector3Int.up);
		list2.Add(Vector3Int.down);
		list2.Add(Vector3Int.left);
		list2.Add(Vector3Int.right);
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		foreach (Vector3Int vector3Int in list2)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null)
			{
				list.Add(ralitiveCardSlotData.ChildCardData);
			}
		}
		if (list.Count <= 0)
		{
			yield break;
		}
		if (list.Contains(player) && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.Hit(this.CardData, target.ChildCardData, this.CardData.ATK, 0.2f, false, 0, null, null);
		}
		yield break;
	}

	private bool Jumped;
}
