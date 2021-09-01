using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class SlimeDivisionLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_分裂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_分裂");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_分裂");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_分裂");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			yield break;
		}
		if (this.CardData.HP <= this.CardData.MaxHP / 2)
		{
			yield return this.Division();
		}
		yield break;
	}

	public IEnumerator Division()
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		if (myBattleArea == null)
		{
			yield break;
		}
		List<CardSlotData> emptySlot = new List<CardSlotData>();
		foreach (CardSlotData cardSlotData in myBattleArea)
		{
			if (cardSlotData.ChildCardData == null)
			{
				emptySlot.Add(cardSlotData);
			}
		}
		if (emptySlot.Count <= 0)
		{
			yield break;
		}
		List<CardSlotData> targets = new List<CardSlotData>();
		for (int i = 0; i < ((emptySlot.Count - 2 >= 0) ? 2 : 1); i++)
		{
			CardSlotData cardSlotData2 = emptySlot[UnityEngine.Random.Range(0, emptySlot.Count)];
			while (cardSlotData2.ChildCardData != null || targets.Contains(cardSlotData2))
			{
				cardSlotData2 = emptySlot[UnityEngine.Random.Range(0, emptySlot.Count)];
			}
			targets.Add(cardSlotData2);
		}
		base.ShowMe();
		yield return DOTween.Sequence().Append(this.CardData.CardGameObject.transform.DOScale(Vector3.one * 0.7f, 0.3f)).Append(this.CardData.CardGameObject.transform.DOScale(Vector3.one * 1.2f, 0.2f).SetEase(Ease.OutBack)).Append(this.CardData.CardGameObject.transform.DOScale(Vector3.one, 0.1f)).WaitForCompletion();
		CardSlotData curSlotData = this.CardData.CurrentCardSlotData;
		this.CardData.DeleteCardData();
		CardData copyData = CardData.CopyCardData(this.CardData, true);
		copyData.MaxHP = (copyData.HP = this.CardData.HP);
		copyData._ATK = this.CardData.ATK;
		copyData.Armor = (copyData.MaxArmor = this.CardData.Armor);
		copyData.PutInSlotData(curSlotData, true);
		CardData cardData = copyData;
		yield return cardData.CardGameObject.JumpToSlot(targets[0].CardSlotGameObject, 0.5f, true);
		CardData cardData2 = CardData.CopyCardData(copyData, true);
		cardData2.PutInSlotData(curSlotData, true);
		CardSlotData cardSlotData3 = curSlotData;
		CardData cardData3 = cardData2;
		if (emptySlot.Count > 1)
		{
			cardSlotData3 = targets[1];
		}
		yield return cardData3.CardGameObject.JumpToSlot(cardSlotData3.CardSlotGameObject, 0.5f, true);
		yield break;
	}
}
