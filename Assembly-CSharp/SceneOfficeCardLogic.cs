using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOfficeCardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
	}

	private new void GetChainLighting(Vector3 from, Vector3 to, int duration = 1)
	{
		ChainLightningByVector3 component = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Effect/ChainLightingByVector3")).GetComponent<ChainLightningByVector3>();
		component.start = from;
		component.target = to;
		component.gameObject.SetActive(true);
	}

	public override IEnumerator OnBattleStart()
	{
		base.OnBattleStart();
		this.RoundCount = 1;
		this.CardList.Clear();
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		base.OnEndTurn(isPlayerTurn);
		if (!isPlayerTurn)
		{
			this.RoundCount++;
			List<CardData> allCurrentMinions = base.GetAllCurrentMinions();
			List<CardData> allCurrentMonsters = base.GetAllCurrentMonsters();
			if (allCurrentMinions.Count == 0 || allCurrentMonsters.Count == 0)
			{
				yield break;
			}
			foreach (CardData cardData in allCurrentMinions)
			{
				if (!this.CardList.ContainsKey(cardData))
				{
					this.CardList.Add(cardData, cardData.MaxHP);
				}
				cardData.MaxHP += Mathf.CeilToInt((float)cardData.MaxHP * this.buff);
			}
			using (List<CardData>.Enumerator enumerator = allCurrentMonsters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData2 = enumerator.Current;
					cardData2.MaxHP += Mathf.CeilToInt((float)cardData2.MaxHP * this.buff);
				}
				yield break;
			}
		}
		yield break;
	}

	public override IEnumerator OnAfterKill(CardSlotData cardSlot, CardData originCarddata)
	{
		base.OnAfterKill(cardSlot, originCarddata);
		List<CardData> allMinions = base.GetAllCurrentMinions();
		if (base.GetAllCurrentMonsters().Count == 0)
		{
			if (this.RoundCount <= 3 && allMinions.Count != 0)
			{
				yield return GameController.ins.UIController.TabooUIPunchEffect();
				foreach (CardData cardData in allMinions)
				{
					this.GetChainLighting(new Vector3(-8.7f, 0f, 6.9f), cardData.CardGameObject.transform.position, 1);
					DungeonOperationMgr.Instance.StartCoroutine(DungeonOperationMgr.Instance.DungeonHandler.ChangeHp(cardData, -Mathf.CeilToInt((float)cardData.MaxHP * this.debuff), cardData, false, 0, true, false));
				}
			}
			using (List<CardData>.Enumerator enumerator = allMinions.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CardData cardData2 = enumerator.Current;
					if (this.CardList.ContainsKey(cardData2))
					{
						cardData2.MaxHP = this.CardList[cardData2];
						if (cardData2.HP > cardData2.MaxHP)
						{
							cardData2.HP = cardData2.MaxHP;
						}
					}
				}
				yield break;
			}
		}
		yield break;
	}

	private float debuff = 0.2f;

	private float buff = 0.1f;

	private Dictionary<CardData, int> CardList = new Dictionary<CardData, int>();

	private int RoundCount;
}
