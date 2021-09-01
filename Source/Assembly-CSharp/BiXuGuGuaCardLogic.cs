using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiXuGuGuaCardLogic : CardLogic
{
	public override void Init()
	{
	}

	public override void OnShowTips()
	{
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_必须咕呱");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_必须咕呱"), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			base.GetMyBattleArea();
			List<Vector3Int> list = new List<Vector3Int>();
			list.Add(Vector3Int.left);
			list.Add(Vector3Int.right);
			list.Add(Vector3Int.up);
			list.Add(Vector3Int.down);
			List<CardData> list2 = new List<CardData>();
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			foreach (Vector3Int vector3Int in list)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(this.CardData.CurrentCardSlotData.GridPositionX, this.CardData.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData) && !DungeonOperationMgr.Instance.CheckCardDead(ralitiveCardSlotData.ChildCardData))
				{
					list2.Add(ralitiveCardSlotData.ChildCardData);
				}
			}
			if (list2.Count > 0)
			{
				Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
				foreach (CardData key in list2)
				{
					dictionary.Add(key, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)));
				}
				yield return base.AOE(dictionary, this.CardData, false, 0, true);
			}
		}
		yield break;
	}

	private float baseDmg = 0.25f;

	private float increaseDmg = 0.25f;
}
