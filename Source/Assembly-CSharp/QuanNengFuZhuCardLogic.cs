using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanNengFuZhuCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_保护");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_保护");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_保护");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_保护");
	}

	public override IEnumerator OnBeforeHpChange(CardData player, RefInt value, CardData from)
	{
		base.OnBeforeHpChange(player, value, from);
		if (value.value >= 0 || player.ModID == this.CardData.ModID)
		{
			yield break;
		}
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
		if (list.Contains(player))
		{
			base.ShowMe();
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.CardData, value.value, from, false, 0, true, false);
			value.value = 0;
		}
		yield break;
	}

	private bool HaveJumped = true;
}
