using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyStealPowerLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "能量掠夺";
		this.Desc = "3回合后，该单位偷取玩家所有随从本单位攻击力的能量并逃离。";
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.m_Round++;
			if (this.m_Round > 3)
			{
				List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
				foreach (CardData cardData in allCurrentMinions)
				{
					if (cardData.MP > 0)
					{
						cardData.MP = ((cardData.MP - this.CardData.ATK > 0) ? (cardData.MP - this.CardData.ATK) : 0);
						yield return DungeonOperationMgr.Instance.DungeonHandler.GetVoxelAnimate(this.CardData.ATK, cardData.CardGameObject.transform.position, this.CardData.CardGameObject.transform.position);
					}
				}
				List<CardData>.Enumerator enumerator = default(List<CardData>.Enumerator);
				this.displayName = "能量都是我的！";
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
		this.displayName = "能量掠夺";
		this.Desc = (3 - this.m_Round).ToString() + "回合后，该单位偷取玩家所有随从本单位攻击力的能量并逃离。";
	}

	private int m_Round;
}
