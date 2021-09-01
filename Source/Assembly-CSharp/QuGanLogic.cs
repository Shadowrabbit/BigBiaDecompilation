using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class QuGanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_16");
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_16_1"),
			Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_16_2"),
			(100 + 50 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_16_3")
		});
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.NeedEnergyCount = new Vector3Int(0, 0, 1);
		this.Desc = string.Concat(new string[]
		{
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_16_1"),
			Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_16_2"),
			(100 + 50 * base.Layers).ToString(),
			LocalizationMgr.Instance.GetLocalizationWord("CT_D_16_3")
		});
	}

	public override IEnumerator OnUseSkill()
	{
		base.OnUseSkill();
		if (base.GetEnemiesBattleArea() == null)
		{
			yield break;
		}
		CardData t = base.GetDefaultTarget();
		if (t == null)
		{
			yield break;
		}
		base.ShowMe();
		yield return DungeonOperationMgr.Instance.Hit(this.CardData, t, Mathf.CeilToInt((1f + 0.5f * (float)base.Layers) * (float)this.CardData.ATK), 0.2f, false, 0, null, null);
		yield return this.TryJump(t.CurrentCardSlotData);
		this.CardData.IsAttacked = true;
		GameController.ins.UIController.AreaAdvocateDesc.transform.parent.DOPunchPosition(Vector3.right * 30f, 0.4f, 10, 1f, false);
		GameController.ins.StartCoroutine(GameController.ins.UIController.EnergyUI.AddEnergy((EnergyUI.EnergyType)this.CardData.CurrentCardSlotData.Color, this.CardData.CardGameObject.transform));
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
		if (enemiesBattleArea == null)
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && enemiesBattleArea.Contains(ralitiveCardSlotData))
			{
				list2.Add(ralitiveCardSlotData);
			}
		}
		if (list2.Count == 0)
		{
			yield break;
		}
		CardSlotData target = list2[SYNCRandom.Range(0, list2.Count)];
		CardData card = csd.ChildCardData;
		yield return card.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		if (card.Attrs.ContainsKey("Col"))
		{
			card.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
