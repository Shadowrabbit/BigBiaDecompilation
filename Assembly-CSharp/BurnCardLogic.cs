using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.blue;
		this.NeedEnergyCount = new Vector3Int(3, 0, 0);
		this.displayName = "点燃";
		this.Desc = string.Concat(new string[]
		{
			"对目标及其相邻的最多4个单位造成",
			Mathf.CeilToInt((float)this.CardData.ATK * (0.7f + 0.1f * (float)base.Layers)).ToString(),
			"[",
			(70 + 10 * base.Layers).ToString(),
			"%攻击力]的伤害。"
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "点燃";
		this.Desc = string.Concat(new string[]
		{
			"对目标及其相邻的最多4个单位造成",
			Mathf.CeilToInt((float)this.CardData.ATK * (0.7f + 0.1f * (float)base.Layers)).ToString(),
			"[",
			(70 + 10 * base.Layers).ToString(),
			"%攻击力]的伤害。"
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		this.CardData.IsAttacked = true;
		List<CardSlotData> CardSlots = base.GetEnemiesBattleArea();
		if (CardSlots == null)
		{
			yield break;
		}
		int num;
		for (int i = CardSlots.Count - 1; i >= 0; i = num - 1)
		{
			if (CardSlots[i].GetAttr("Col") == this.CardData.CurrentCardSlotData.GetAttr("Col") && CardSlots[i].ChildCardData != null && CardSlots[i].ChildCardData.HasTag(TagMap.怪物))
			{
				base.ShowMe();
				yield return DungeonOperationMgr.Instance.Hit(this.CardData, CardSlots[i].ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (0.7f + 0.1f * (float)base.Layers)), 0.2f, false, 0, null, null);
				List<Vector3Int> list = new List<Vector3Int>
				{
					Vector3Int.up,
					Vector3Int.left,
					Vector3Int.right,
					Vector3Int.down
				};
				foreach (Vector3Int vector3Int in list)
				{
					CardSlotData ralitiveCardSlotData = (GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData).GetRalitiveCardSlotData(CardSlots[i].GridPositionX, CardSlots[i].GridPositionY, vector3Int.x, vector3Int.y, false);
					if (ralitiveCardSlotData == null || ralitiveCardSlotData.ChildCardData == null || !ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
					{
						yield break;
					}
					yield return DungeonOperationMgr.Instance.Hit(this.CardData, ralitiveCardSlotData.ChildCardData, Mathf.CeilToInt((float)this.CardData.ATK * (0.7f + 0.1f * (float)base.Layers)), 0.2f, false, 0, null, null);
				}
				List<Vector3Int>.Enumerator enumerator = default(List<Vector3Int>.Enumerator);
				yield break;
			}
			num = i;
		}
		yield break;
		yield break;
	}
}
