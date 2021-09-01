using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyStealGirlLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "采花";
		this.Desc = "3回合后，该单位偷取玩家一名女性随从并逃离。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.m_Round++;
			if (this.m_Round > 3)
			{
				List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
				foreach (CardData minion in allCurrentMinions)
				{
					if (minion.ModID.Contains("女") || minion.ModID.Equals("人鱼") || minion.ModID.Equals("偶像歌手"))
					{
						this.displayName = "来吧，美人儿~";
						base.ShowMe();
						minion.CardGameObject.transform.DOMove(this.CardData.CardGameObject.transform.position + new Vector3(0f, 0.2f, 0f), 1f, false);
						yield return new WaitForSeconds(1f);
						minion.DeleteCardData();
						this.CardData.DeleteCardData();
						yield break;
					}
					minion = null;
				}
				List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
				this.displayName = "一堆老爷们儿玩个什么劲啊！";
				base.ShowMe();
				this.CardData.DeleteCardData();
			}
		}
		yield break;
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "采花";
		this.Desc = (3 - this.m_Round).ToString() + "回合后，该单位偷取玩家一名女性随从并逃离。";
	}

	private int m_Round;
}
