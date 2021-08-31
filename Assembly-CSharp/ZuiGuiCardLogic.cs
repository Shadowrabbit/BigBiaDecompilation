using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuiGuiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.yellow;
		if (this.CardData != null)
		{
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_42");
			this.Desc = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("CT_D_42_1"),
				Mathf.CeilToInt((float)this.CardData.ATK * (0.15f + 0.25f * (float)base.Layers)).ToString(),
				LocalizationMgr.Instance.GetLocalizationWord("CT_D_42_2"),
				(15 + 25 * base.Layers).ToString(),
				LocalizationMgr.Instance.GetLocalizationWord("CT_D_42_3")
			});
		}
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (isPlayerTurn && !this.HasJumped)
		{
			base.ShowMe();
			this.HasJumped = true;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
			yield return base.Cure(this.CardData, Mathf.CeilToInt((float)this.CardData.ATK * (0.15f + 0.25f * (float)base.Layers)), this.CardData);
			if (this.CardData.CurrentCardSlotData.Color != CardSlotData.LineColor.Yellow)
			{
				this.HasJumped = false;
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

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.Color = CardLogicColor.yellow;
		if (this.CardData != null)
		{
			this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_42");
			this.Desc = string.Concat(new string[]
			{
				LocalizationMgr.Instance.GetLocalizationWord("CT_D_42_1"),
				Mathf.CeilToInt((float)this.CardData.ATK * (0.15f + 0.25f * (float)base.Layers)).ToString(),
				LocalizationMgr.Instance.GetLocalizationWord("CT_D_42_2"),
				(15 + 25 * base.Layers).ToString(),
				LocalizationMgr.Instance.GetLocalizationWord("CT_D_42_3")
			});
		}
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		List<CardSlotData> list = new List<CardSlotData>();
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) < myBattleArea.Count / 3 * 2 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + myBattleArea.Count / 3].ChildCardData == null)
		{
			CardSlotData item = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + myBattleArea.Count / 3];
			list.Add(item);
		}
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) >= myBattleArea.Count / 3 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - myBattleArea.Count / 3].ChildCardData == null)
		{
			CardSlotData item2 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - myBattleArea.Count / 3];
			list.Add(item2);
		}
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != 0 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 * 2 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 1].ChildCardData == null)
		{
			CardSlotData item3 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) - 1];
			list.Add(item3);
		}
		if (myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 - 1 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count / 3 * 2 - 1 && myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) != myBattleArea.Count - 1 && myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 1].ChildCardData == null)
		{
			CardSlotData item4 = myBattleArea[myBattleArea.IndexOf(this.CardData.CurrentCardSlotData) + 1];
			list.Add(item4);
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardSlotData cardSlotData = list[SYNCRandom.Range(0, list.Count)];
		CardData childCardData = csd.ChildCardData;
		base.ShowMe();
		yield return childCardData.CardGameObject.JumpToSlot(cardSlotData.CardSlotGameObject, 0.2f, true);
		yield break;
	}

	private bool HasJumped;
}
