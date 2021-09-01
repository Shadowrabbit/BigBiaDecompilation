using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class XueQiuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_滚雪球");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_滚雪球");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_滚雪球");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_滚雪球");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (this.CardData == null || !this.CardData.HasTag(TagMap.怪物) || this.CardData.HasTag(TagMap.BOSS))
		{
			yield break;
		}
		if (this.HasJumped)
		{
			yield break;
		}
		base.ShowMe();
		if (!isPlayerTurn)
		{
			if (!this.canJump(this.CardData.CurrentCardSlotData, Vector3Int.down, base.GetMyBattleArea()))
			{
				this.currentVec = Vector3Int.left;
			}
			if (!this.canJump(this.CardData.CurrentCardSlotData, Vector3Int.left, base.GetMyBattleArea()))
			{
				this.currentVec = Vector3Int.up;
			}
			if (!this.canJump(this.CardData.CurrentCardSlotData, Vector3Int.up, base.GetMyBattleArea()))
			{
				this.currentVec = Vector3Int.right;
			}
			if (!this.canJump(this.CardData.CurrentCardSlotData, Vector3Int.right, base.GetMyBattleArea()))
			{
				if (!this.canJump(this.CardData.CurrentCardSlotData, Vector3Int.down, base.GetMyBattleArea()))
				{
					this.currentVec = Vector3Int.left;
				}
				else
				{
					this.currentVec = Vector3Int.down;
				}
			}
			if (this.currentVec != Vector3Int.zero)
			{
				yield return this.JumpOrHit(this.CardData.CurrentCardSlotData, this.currentVec, base.GetMyBattleArea());
			}
			else
			{
				yield return this.JumpOrHit(this.CardData.CurrentCardSlotData, Vector3Int.up, base.GetMyBattleArea());
			}
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.HasJumped = false;
		yield break;
	}

	public bool canJump(CardSlotData csd, Vector3Int dir, List<CardSlotData> CardSlots)
	{
		if (csd == null || CardSlots == null || csd.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(csd.ChildCardData))
		{
			return false;
		}
		CardSlotData ralitiveCardSlotData = (GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData).GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, dir.x, dir.y, false);
		return ralitiveCardSlotData != null && CardSlots.Contains(ralitiveCardSlotData);
	}

	public IEnumerator JumpOrHit(CardSlotData csd, Vector3Int dir, List<CardSlotData> CardSlots)
	{
		if (csd == null || CardSlots == null || csd.ChildCardData == null || DungeonOperationMgr.Instance.CheckCardDead(csd.ChildCardData))
		{
			yield break;
		}
		CardSlotData ralitiveCardSlotData = (GameController.getInstance().GameData.AreaMap[GameController.getInstance().GameData.CurrentAreaId] as SpaceAreaData).GetRalitiveCardSlotData(csd.GridPositionX, csd.GridPositionY, dir.x, dir.y, false);
		if (ralitiveCardSlotData == null || !CardSlots.Contains(ralitiveCardSlotData))
		{
			yield break;
		}
		if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData == null)
		{
			if (csd.ChildCardData.HasTag(TagMap.BOSS))
			{
				yield break;
			}
			if (csd.ChildCardData.CardGameObject != null)
			{
				csd.ChildCardData.CardGameObject.transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 0.5f, RotateMode.LocalAxisAdd);
				yield return csd.ChildCardData.CardGameObject.JumpToSlot(ralitiveCardSlotData.CardSlotGameObject, 0.5f, true);
				this.HasJumped = true;
				yield break;
			}
		}
		else if (ralitiveCardSlotData != null && ralitiveCardSlotData.ChildCardData != null)
		{
			this.CardData.MergeBy(ralitiveCardSlotData.ChildCardData, true, false);
			ralitiveCardSlotData.ChildCardData.DeleteCardData();
			csd.ChildCardData.CardGameObject.transform.DOLocalRotate(new Vector3(0f, -360f, 0f), 0.5f, RotateMode.LocalAxisAdd);
			yield return csd.ChildCardData.CardGameObject.JumpToSlot(ralitiveCardSlotData.CardSlotGameObject, 0.5f, true);
			if (this.CardData.CardGameObject != null)
			{
				yield return this.CardData.CardGameObject.transform.DOShakeScale(0.3f, 1f, 10, 90f, true);
			}
			this.HasJumped = true;
		}
		yield break;
	}

	public bool HasJumped;

	private Vector3Int currentVec = Vector3Int.zero;
}
