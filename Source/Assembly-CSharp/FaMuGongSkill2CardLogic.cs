using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CardLogicRequireRare(4)]
public class FaMuGongSkill2CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.NeedEnergyCount = new Vector3Int(0, 0, 0);
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_伐木工2");
		this.Desc = string.Concat(new string[]
		{
			"消耗所有黄色充能。每消耗1点便对前方第一个敌人及其左右的单位造成",
			Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)).ToString(),
			"[",
			((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f).ToString(),
			"%攻击力]的伤害。"
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_伐木工2");
		this.Desc = string.Concat(new string[]
		{
			"消耗所有黄色充能。每消耗1点便对前方第一个敌人及其左右的单位造成",
			Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)).ToString(),
			"[",
			((this.baseDmg + this.increaseDmg * (float)base.Layers) * 100f).ToString(),
			"%攻击力]的伤害。"
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Yellow) <= 0)
		{
			base.ShowLogic("缺少黄色充能！");
			this.CardData.IsAttacked = true;
			yield break;
		}
		base.ShowMe();
		while (GameController.ins.GameData.GetEnergyCount(EnergyUI.EnergyType.Yellow) > 0)
		{
			yield return GameController.ins.UIController.EnergyUI.RemoveEnergy(EnergyUI.EnergyType.Yellow, this.CardData.CardGameObject.transform);
			this.CardData.IsAttacked = true;
			CardData defaultTarget = base.GetDefaultTarget();
			List<CardData> list = new List<CardData>();
			if (defaultTarget == null)
			{
				yield break;
			}
			list.Add(defaultTarget);
			List<Vector3Int> list2 = new List<Vector3Int>();
			list2.Add(Vector3Int.left);
			list2.Add(Vector3Int.right);
			SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
			foreach (Vector3Int vector3Int in list2)
			{
				CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(defaultTarget.CurrentCardSlotData.GridPositionX, defaultTarget.CurrentCardSlotData.GridPositionY, vector3Int.x, vector3Int.y, false);
				if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null && ralitiveCardSlotData.ChildCardData.HasTag(TagMap.怪物))
				{
					list.Add(ralitiveCardSlotData.ChildCardData);
				}
			}
			if (list.Count <= 0)
			{
				yield break;
			}
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			foreach (CardData cardData in list)
			{
				if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
				{
					dictionary.Add(cardData, -Mathf.CeilToInt((float)this.CardData.ATK * (this.baseDmg + this.increaseDmg * (float)base.Layers)));
				}
			}
			yield return base.AOE(dictionary, this.CardData, false, 0, true);
		}
		yield break;
	}

	private float baseDmg = 1f;

	private float increaseDmg = 0.5f;
}
