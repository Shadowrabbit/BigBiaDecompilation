using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_60");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_60");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_60");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_60");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (base.GetMyBattleArea().Contains(target) && this.HaveJumped)
		{
			this.HaveJumped = false;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		this.HaveJumped = true;
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<Vector3Int> list = new List<Vector3Int>();
		list.Add(Vector3Int.up);
		list.Add(Vector3Int.down);
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && myBattleArea.Contains(ralitiveCardSlotData))
			{
				list2.Add(ralitiveCardSlotData);
			}
		}
		if (list2.Count == 0)
		{
			yield break;
		}
		CardSlotData target = list2[SYNCRandom.Range(0, list2.Count)];
		if (csd.ChildCardData.CardGameObject != null)
		{
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		}
		if (csd.ChildCardData != null && csd.ChildCardData.Attrs.ContainsKey("Col"))
		{
			csd.ChildCardData.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}

	private bool HaveJumped = true;
}
