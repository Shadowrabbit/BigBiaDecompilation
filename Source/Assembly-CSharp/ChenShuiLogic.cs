using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChenShuiLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_沉睡");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_沉睡");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_沉睡");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_沉睡");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn && this.CardData.HP < this.CardData.MaxHP)
		{
			List<CardSlotData> myBattleArea = base.GetMyBattleArea();
			if (myBattleArea == null)
			{
				yield break;
			}
			List<CardSlotData> list = new List<CardSlotData>();
			foreach (CardSlotData cardSlotData in myBattleArea)
			{
				if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID.Equals("石棺"))
				{
					list.Add(cardSlotData);
				}
			}
			if (list.Count > 0)
			{
				yield return this.TryJump(this.CardData.CurrentCardSlotData, list[SYNCRandom.Range(0, list.Count)]);
			}
		}
		yield break;
	}

	public IEnumerator TryJump(CardSlotData csd, CardSlotData target)
	{
		CardData card = csd.ChildCardData;
		CardData targetCard = target.ChildCardData;
		card.CardGameObject.transform.DOJump(target.CardSlotGameObject.transform.position, 0.3f, 1, 0.2f, false);
		yield return new WaitForSeconds(0.2f);
		if (targetCard.Attrs.ContainsKey("Child"))
		{
			(targetCard.Attrs["Child"] as Dictionary<CardData, int>).Add(card, 1);
		}
		else
		{
			Dictionary<CardData, int> dictionary = new Dictionary<CardData, int>();
			dictionary.Add(card, 1);
			targetCard.Attrs.Add("Child", dictionary);
		}
		card.DeleteCardData();
		yield break;
	}
}
