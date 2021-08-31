using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemyRoundLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "逃遁";
		this.Desc = base.Layers.ToString() + "回合后逃跑。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.m_Round++;
			if (this.m_Round > base.Layers)
			{
				this.displayName = "溜了~";
				base.ShowMe();
				int num;
				for (int i = 0; i < 4; i = num + 1)
				{
					this.CardData.CardGameObject.transform.DOLocalJump(new Vector3(this.CardData.CardGameObject.transform.localPosition.x, this.CardData.CardGameObject.transform.localPosition.y, this.CardData.CardGameObject.transform.localPosition.z + 1f), 0.2f, 1, 0.2f, false);
					yield return new WaitForSeconds(0.3f);
					num = i;
				}
				this.CardData.DeleteCardData();
			}
		}
		yield break;
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = "逃遁";
		this.Desc = (base.Layers - this.m_Round).ToString() + "回合后逃跑。";
	}

	private int m_Round = 1;
}
