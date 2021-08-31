using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HengSaoCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_横扫");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_横扫"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_横扫");
		this.Desc = string.Format(LocalizationMgr.Instance.GetLocalizationWord("CT_D_横扫"), Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), (this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f);
	}

	public override IEnumerator CustomAttack(CardSlotData target)
	{
		base.CustomAttack(target);
		if (DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count == 0 && !DungeonOperationMgr.Instance.CheckCardDead(target.ChildCardData))
		{
			yield return DungeonOperationMgr.Instance.DefaultAttack(this.CardData, target);
		}
		base.ShowMe();
		List<Vector3Int> list = new List<Vector3Int>
		{
			Vector3Int.left,
			Vector3Int.right
		};
		List<CardData> list2 = new List<CardData>();
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		for (int i = 0; i < DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets.Count; i++)
		{
			foreach (AttackMsg attackMsg in DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i])
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(attackMsg.Target))
				{
					foreach (Vector3Int vector3Int in list)
					{
						CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(attackMsg.Target.CurrentCardSlotData.GridPositionX, attackMsg.Target.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
						if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
						{
							list2.Add(ralitiveCardSlotData.ChildCardData);
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				foreach (CardData target2 in list2)
				{
					AttackMsg item = new AttackMsg(target2, Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)), false, true, 0, 0, null);
					DungeonOperationMgr.Instance.CurrentAttackMsgStruct.Targets[i].Add(item);
				}
			}
		}
		yield break;
	}

	private float baseDmg;

	private float increaseDmg = 0.15f;
}
