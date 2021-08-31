using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JieQiuShouCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_55");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_55");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_55");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_55");
	}

	public override IEnumerator OnAfterAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && !this.HasJumped)
		{
			this.HasJumped = true;
			yield return this.TryJump(this.CardData.CurrentCardSlotData);
		}
		yield break;
	}

	public override IEnumerator OnBeforeAttack(CardData player, CardSlotData target)
	{
		if (player == this.CardData && this.HasJumped)
		{
			this.HasJumped = false;
			yield break;
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd)
	{
		List<CardSlotData> playerSlotSets = GameController.getInstance().PlayerSlotSets;
		List<CardSlotData> list = new List<CardSlotData>();
		if (playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) >= playerSlotSets.Count / 3 && playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) - playerSlotSets.Count / 3].ChildCardData == null)
		{
			CardSlotData item = playerSlotSets[playerSlotSets.IndexOf(this.CardData.CurrentCardSlotData) - playerSlotSets.Count / 3];
			list.Add(item);
		}
		if (list.Count == 0)
		{
			yield break;
		}
		CardSlotData cardSlotData = list[UnityEngine.Random.Range(0, list.Count)];
		CardData childCardData = csd.ChildCardData;
		base.ShowMe();
		yield return childCardData.CardGameObject.JumpToSlot(cardSlotData.CardSlotGameObject, 0.2f, true);
		yield break;
	}

	private bool HasJumped;
}
