using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YanJiangQiuLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "";
		this.Desc = "";
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target == this.CardData)
		{
			yield return this.Explode();
		}
		yield break;
	}

	private IEnumerator Explode()
	{
		base.ShowMe();
		List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
		new List<CardData>();
		if (allCurrentMinions.Count > 0)
		{
			using (List<CardData>.Enumerator enumerator = allCurrentMinions.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData = enumerator.Current;
					GameController.getInstance().StartCoroutine(DungeonOperationMgr.Instance.Hit(this.CardData, cardData, Mathf.CeilToInt((float)cardData.MaxHP * 0.05f), 0.2f, false, 0, null, null));
				}
				yield break;
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			GameController.getInstance().ShowAmountText(this.CardData.CardGameObject.transform.position, LocalizationMgr.Instance.GetLocalizationWord("T_9"), UnityEngine.Color.white, 0, false, false);
			this.CardData.DeleteCardData();
		}
		yield break;
	}
}
