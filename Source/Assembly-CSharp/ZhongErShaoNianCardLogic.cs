using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ZhongErShaoNianCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_发漫画");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_发漫画");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_发漫画");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_发漫画");
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
		}
		if (list.Count > 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord(LocalizationMgr.Instance.GetLocalizationWord("T_这本漫画特好看")));
			CardSlotData t = list[SYNCRandom.Range(0, list.Count)];
			CardData target = Card.InitCardDataByID("漫画");
			GameObject tempCard = Card.InitWithOutData(target, true);
			tempCard.transform.position = this.CardData.CardGameObject.transform.position;
			yield return tempCard.transform.DOJump(t.CardSlotGameObject.transform.position, 0.5f, 1, 0.5f, false).WaitForCompletion();
			UnityEngine.Object.DestroyImmediate(tempCard);
			target.PutInSlotData(t, true);
			target.IsAttacked = true;
			yield return new WaitForSeconds(0.5f);
			t = null;
			target = null;
			tempCard = null;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		List<CardSlotData> list = new List<CardSlotData>();
		foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
		{
			if (cardSlotData.ChildCardData == null)
			{
				list.Add(cardSlotData);
			}
		}
		if (list.Count > 0)
		{
			base.ShowLogic(LocalizationMgr.Instance.GetLocalizationWord(LocalizationMgr.Instance.GetLocalizationWord("T_这本漫画特好看")));
			CardSlotData t = list[SYNCRandom.Range(0, list.Count)];
			CardData target = Card.InitCardDataByID("漫画");
			GameObject tempCard = Card.InitWithOutData(target, true);
			tempCard.transform.position = this.CardData.CardGameObject.transform.position;
			yield return tempCard.transform.DOJump(t.CardSlotGameObject.transform.position, 0.5f, 1, 0.5f, false).WaitForCompletion();
			UnityEngine.Object.DestroyImmediate(tempCard);
			target.PutInSlotData(t, true);
			target.IsAttacked = true;
			yield return new WaitForSeconds(0.5f);
			t = null;
			target = null;
			tempCard = null;
		}
		yield break;
	}
}
