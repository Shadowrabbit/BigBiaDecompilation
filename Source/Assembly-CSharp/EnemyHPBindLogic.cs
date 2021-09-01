using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBindLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = "生命捆绑";
		this.Desc = "该单位每2回合会随机挑选一名随从并绑定生命，被绑定的随从每次承受同等伤害。";
	}

	public override IEnumerator OnTurnStart()
	{
		if (this.m_target != null)
		{
			yield break;
		}
		if (this.m_Round % 2 == 1)
		{
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			this.m_target = allCurrentMinions[UnityEngine.Random.Range(0, allCurrentMinions.Count)];
			this.m_ChainGo = this.GetChainLighting(this.CardData, this.m_target);
		}
		yield return base.OnTurnStart();
		yield break;
	}

	private GameObject GetChainLighting(CardData from, CardData to)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainHPLine"));
		UVChainLightning component = gameObject.GetComponent<UVChainLightning>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
		return gameObject;
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		if (player == this.CardData)
		{
			if (this.CardData.DizzyLayer > 0)
			{
				if (this.m_target != null)
				{
					this.m_target = null;
					if (this.m_ChainGo != null)
					{
						UnityEngine.Object.Destroy(this.m_ChainGo);
					}
				}
			}
			else if (this.m_target != null)
			{
				yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(this.m_target, changedValue, from, true, 0, true, false);
				if (DungeonOperationMgr.Instance.CheckCardDead(this.m_target))
				{
					this.m_target = null;
					if (this.m_ChainGo != null)
					{
						UnityEngine.Object.Destroy(this.m_ChainGo);
					}
				}
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			this.m_Round++;
		}
		if (!isPlayerTurn && this.m_target != null)
		{
			this.m_target = null;
			if (this.m_ChainGo != null)
			{
				UnityEngine.Object.Destroy(this.m_ChainGo);
			}
		}
		yield break;
	}

	private int m_Round;

	private CardData m_target;

	private GameObject m_ChainGo;
}
