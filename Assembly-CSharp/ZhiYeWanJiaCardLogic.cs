using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhiYeWanJiaCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_反杀");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_反杀");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_反杀");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_反杀");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		base.OnAfterAttack(player, target);
		if (target.ChildCardData == this.CardData && !DungeonOperationMgr.Instance.CheckCardDead(this.CardData) && base.GetMyBattleArea().Contains(target) && this.HaveJumped)
		{
			this.HaveJumped = false;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
			CardData cardData = this.FanSha();
			if (!DungeonOperationMgr.Instance.CheckCardDead(cardData))
			{
				yield return DungeonOperationMgr.Instance.Attack(this.CardData, cardData, GameController.getInstance().GetCurrentAreaData().ID);
			}
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

	public CardData FanSha()
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
		if (cardData == null)
		{
			foreach (CardData cardData3 in allCurrentMinions)
			{
				if ((int)cardData3.CurrentCardSlotData.Attrs["Col"] == (int)GameController.ins.GameData.PlayerCardData.CurrentCardSlotData.Attrs["Col"])
				{
					if (cardData != null)
					{
						List<CardSlotData> enemiesBattleArea2 = base.GetEnemiesBattleArea();
						if (enemiesBattleArea2.IndexOf(cardData.CurrentCardSlotData) <= enemiesBattleArea2.IndexOf(cardData3.CurrentCardSlotData))
						{
							cardData = cardData3;
						}
					}
					else
					{
						cardData = cardData3;
					}
				}
			}
		}
		return cardData;
	}

	private bool HaveJumped = true;
}
