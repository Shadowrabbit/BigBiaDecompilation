using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeTunPengZhangLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "膨胀";
		this.Desc = "5 同类被击杀后爆炸。";
		if (this.CardData != null && this.CardData.CardGameObject != null)
		{
			this.CardData.CardGameObject.transform.GetChild(4).localScale = Vector3.one;
		}
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target != this.CardData)
		{
			List<CardSlotData> myBattleArea = base.GetMyBattleArea();
			if (myBattleArea == null)
			{
				yield break;
			}
			using (List<CardSlotData>.Enumerator enumerator = myBattleArea.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardSlotData cardSlotData = enumerator.Current;
					if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID.Equals("河豚"))
					{
						base.ShowMe();
						this.CardData.MP++;
						this.CardData.CardGameObject.transform.GetChild(4).transform.DOScale(this.CardData.CardGameObject.transform.GetChild(4).transform.localScale + Vector3.one * 0.3f, 0.2f);
						yield break;
					}
				}
				yield break;
			}
		}
		yield break;
	}
}
