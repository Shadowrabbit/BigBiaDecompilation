using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiGangCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		if (this.CardData != null && this.CardData.HasTag(TagMap.随从))
		{
			this.Color = CardLogicColor.blue;
		}
		this.NeedEnergyCount = new Vector3Int(1, 0, 0);
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_40");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_40");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_40");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_40");
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		base.ShowMe();
		this.CardData.IsAttacked = true;
		CardData defaultTarget = base.GetDefaultTarget();
		if (defaultTarget == null)
		{
			yield break;
		}
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		list.Add(Vector3Int.up);
		list.Add(Vector3Int.down);
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<CardData> list2 = new List<CardData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(defaultTarget.CurrentCardSlotData.GridPositionX, defaultTarget.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
			{
				list2.Add(ralitiveCardSlotData.ChildCardData);
			}
		}
		if (list2.Count > 0)
		{
			yield return DungeonOperationMgr.Instance.AttackProcess(defaultTarget, list2[SYNCRandom.Range(0, list2.Count)]);
		}
		yield break;
	}
}
