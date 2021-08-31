using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangYinShaoNianTaBaLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_106");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_106");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_106");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_106");
	}

	public override IEnumerator OnTurnStart()
	{
		List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
		CardData cardData = null;
		foreach (CardData cardData2 in allCurrentMonsters)
		{
			if (cardData2.ModID.Equals("网瘾少年"))
			{
				cardData = cardData2;
				this.CardData._ATK += Mathf.CeilToInt((float)this.CardData.ATK * 0.2f);
			}
		}
		if (cardData != null)
		{
			float num = Mathf.Pow((float)(cardData.CurrentCardSlotData.GridPositionX - this.CardData.CurrentCardSlotData.GridPositionX), 2f);
			float num2 = Mathf.Pow((float)(cardData.CurrentCardSlotData.GridPositionY - this.CardData.CurrentCardSlotData.GridPositionY), 2f);
			if (num + num2 > 1f)
			{
				GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_7"), UnityEngine.Color.white, 0, false, false);
				yield return this.TryJumpTo(this.CardData.CurrentCardSlotData, cardData.CurrentCardSlotData);
			}
		}
		yield break;
	}

	public IEnumerator TryJumpTo(CardSlotData me, CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		SpaceAreaData spaceAreaData = GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData;
		List<Vector3Int> list = new List<Vector3Int>();
		if (csd.GridPositionY > me.GridPositionY)
		{
			list.Add(Vector3Int.up);
		}
		if (csd.GridPositionY < me.GridPositionY)
		{
			list.Add(Vector3Int.down);
		}
		if (csd.GridPositionX > me.GridPositionX)
		{
			list.Add(Vector3Int.right);
		}
		if (csd.GridPositionX < me.GridPositionX)
		{
			list.Add(Vector3Int.left);
		}
		List<CardSlotData> list2 = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(me.GridPositionX, me.GridPositionY, vector3Int.x, vector3Int.y, false);
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
		if (me.ChildCardData.CardGameObject != null)
		{
			yield return me.ChildCardData.CardGameObject.JumpToSlot(target.CardSlotGameObject, 0.2f, true);
		}
		if (me.ChildCardData != null && me.ChildCardData.Attrs.ContainsKey("Col"))
		{
			me.ChildCardData.Attrs["Col"] = target.Attrs["Col"];
		}
		yield break;
	}
}
