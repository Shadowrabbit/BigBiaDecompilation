using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class CuCaoZhongJianCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_121");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_121");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_121");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_121");
	}

	public override IEnumerator OnUserAsArms(CardData origin, CardData Target)
	{
		List<CardSlotData> list = base.GetEnemiesBattleArea();
		Vector3 startPos = this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.position;
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOMove(list[8].CardSlotGameObject.transform.position - Vector3.left / 2f, 0.5f, false).WaitForCompletion();
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(Vector3.one * 3f, 0.5f).WaitForCompletion();
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(new Vector3(0f, 60f, 0f), 1f, RotateMode.Fast).SetEase(Ease.OutExpo).WaitForCompletion();
		yield return this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(new Vector3(0f, -85f, 0f), 0.3f, RotateMode.Fast).SetEase(Ease.InExpo).WaitForCompletion();
		yield return new WaitForSeconds(0.5f);
		this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DORotate(Vector3.zero, 0.1f, RotateMode.Fast).SetEase(Ease.InExpo);
		this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOMove(startPos, 0.1f, false).SetEase(Ease.InExpo);
		this.CardData.CardGameObject.DisplayGameObjectOnPlayerTable.transform.DOScale(Vector3.one, 0.1f);
		yield return new WaitForSeconds(0.2f);
		int num;
		for (int i = 0; i < list.Count; i = num + 1)
		{
			if ((i == 2 || i == 4 || i == 6) && list[i].ChildCardData != null)
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(list[i].ChildCardData, -this.CardData.ATK, origin, false, 0, true, false);
			}
			num = i;
		}
		yield break;
	}
}
