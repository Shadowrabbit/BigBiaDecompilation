using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaJiYanYuanLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_100");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_100");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_100");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_100");
	}

	public override IEnumerator OnCardBeforeUseSkill(CardData user, CardLogic origin)
	{
		this.HasJumped = false;
		return base.OnCardBeforeUseSkill(user, origin);
	}

	public override IEnumerator OnCardAfterUseSkill(CardData user, CardLogic origin)
	{
		if (user == this.CardData)
		{
			yield break;
		}
		if (this.HasJumped)
		{
			yield break;
		}
		base.ShowMe();
		yield return this.TryJump(this.CardData.CurrentCardSlotData);
		this.ZaShua();
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
		list.Add(Vector3Int.left);
		list.Add(Vector3Int.right);
		List<CardSlotData> targets = new List<CardSlotData>();
		foreach (Vector3Int vector3Int in list)
		{
			CardSlotData ralitiveCardSlotData = spaceAreaData.GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, vector3Int.x, vector3Int.y, false);
			if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null && myBattleArea.Contains(ralitiveCardSlotData))
			{
				targets.Add(ralitiveCardSlotData);
			}
		}
		if (targets.Count == 0)
		{
			yield break;
		}
		CardData card = csd.ChildCardData;
		this.HasJumped = true;
		yield return card.CardGameObject.JumpToSlot(targets[SYNCRandom.Range(0, targets.Count)].CardSlotGameObject, 0.2f, true);
		if (card.Attrs.ContainsKey("Col"))
		{
			card.Attrs["Col"] = targets[0].Attrs["Col"];
		}
		yield break;
	}

	private void ZaShua()
	{
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		CardData cardData = null;
		foreach (CardData cardData2 in allCurrentMinions)
		{
			if ((int)cardData2.CurrentCardSlotData.Attrs["Col"] == (int)this.CardData.CurrentCardSlotData.Attrs["Col"])
			{
				if (cardData != null)
				{
					List<CardSlotData> enemiesBattleArea = base.GetEnemiesBattleArea();
					if (enemiesBattleArea.IndexOf(cardData.CurrentCardSlotData) <= enemiesBattleArea.IndexOf(cardData2.CurrentCardSlotData))
					{
						cardData = cardData2;
					}
				}
				else
				{
					cardData = cardData2;
				}
			}
		}
		if (cardData != null)
		{
			GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, Mathf.CeilToInt((float)this.CardData.ATK * 0.05f), 0.2f, false, 0, null, null));
		}
	}

	private bool HasJumped;
}
