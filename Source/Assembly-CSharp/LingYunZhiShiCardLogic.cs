using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingYunZhiShiCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.Color = CardLogicColor.white;
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_豪情");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_豪情");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_豪情");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_豪情");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMonsters.Count <= 0)
			{
				yield break;
			}
			base.ShowMe();
			foreach (CardData cardData in allCurrentMonsters)
			{
				DungeonOperationMgr.Instance.StartCoroutine(base.wATKUp(this.CardData.CardGameObject.transform.position, 0, cardData));
				cardData._ATK++;
			}
			yield return new WaitForSeconds(0.5f);
		}
		yield break;
	}
}
