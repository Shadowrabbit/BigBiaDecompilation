using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class BossSnakeEat : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇3");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇3");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇3");
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (isPlayerTurn)
		{
			if (this.eatRounds > 0)
			{
				this.eatRounds--;
				if (this.eatRounds == 0 && this.m_EatedCard != null)
				{
					UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("BeAttacked");
					this.m_EatedCard.PutInSlotData(this.GetEmptySlotFromPlayerTable(), true);
					this.m_EatedCard.CardGameObject.gameObject.SetActive(true);
					this.m_EatedCard = null;
				}
			}
			this.rounds++;
			if (this.rounds % 2 == 0)
			{
				List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
				List<CardData> list = new List<CardData>();
				foreach (CardSlotData cardSlotData in battleArea)
				{
					if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData != this.CardData)
					{
						list.Add(cardSlotData.ChildCardData);
					}
				}
				if (list.Count > 0)
				{
					CardData enemy = list[UnityEngine.Random.Range(0, list.Count)];
					yield return this.EatCard(enemy, delegate
					{
						this.CardData.HP = ((this.CardData.HP + enemy.HP > this.CardData.MaxHP) ? this.CardData.MaxHP : (this.CardData.HP + enemy.HP));
						enemy.DeleteCardData();
						this.m_EatedCard = null;
					});
					yield break;
				}
				yield break;
			}
		}
		yield break;
		yield break;
	}

	private IEnumerator EatCard(CardData target, BossSnakeEat.EatCardCallBack call)
	{
		this.eatRounds = 1;
		this.m_EatedCard = target;
		this.CardData.Armor++;
		target.CardGameObject.transform.DOMove(UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position, 1f, false).OnComplete(delegate
		{
			string name = "Effect/HealHp";
			ParticlePoolManager.Instance.Spawn(name, 3f).transform.position = UnityEngine.Object.FindObjectOfType<BossSnakeArea>().CardSlot.transform.position;
		});
		UnityEngine.Object.FindObjectOfType<BossSnakeArea>().Boss.GetComponent<Animator>().SetTrigger("BeAttacked");
		yield return new WaitForSeconds(1f);
		if (target.HP < target.MaxHP / 5)
		{
			this.CardData.HP = ((this.CardData.HP + target.HP > this.CardData.MaxHP) ? this.CardData.MaxHP : (this.CardData.HP + target.HP));
			yield return DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(target, -target.HP, target, true, 0, true, false);
			this.m_EatedCard = null;
		}
		else
		{
			this.CardData.HP = ((this.CardData.HP + target.MaxHP / 2 > this.CardData.MaxHP) ? this.CardData.MaxHP : (this.CardData.HP + target.MaxHP / 2));
			target.HP -= target.MaxHP / 5;
			target.Armor = 0;
			this.m_EatedCard = target;
			this.m_EatedCard.CardGameObject.gameObject.SetActive(false);
			this.m_EatedCard.CurrentCardSlotData.ClearCardData();
		}
		call();
		yield break;
	}

	private CardSlotData GetEmptySlotFromPlayerTable()
	{
		foreach (CardSlotData cardSlotData in base.GetEnemiesBattleArea())
		{
			if (cardSlotData.ChildCardData == null)
			{
				return cardSlotData;
			}
		}
		return null;
	}

	private int rounds;

	private int eatRounds;

	private CardData m_EatedCard;

	public delegate void EatCardCallBack();
}
