using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSnakeCallSacrifice : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇6");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇6");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_BOSS蛇6");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_BOSS蛇6");
	}

	public override IEnumerator OnTurnStart()
	{
		List<CardSlotData> myBattleArea = base.GetMyBattleArea();
		bool flag = true;
		foreach (CardSlotData cardSlotData in myBattleArea)
		{
			if (cardSlotData.ChildCardData != null && cardSlotData.ChildCardData.ModID.Equals("血祭之卵"))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			this.CardData.CardGameObject.transform.parent.GetComponent<BoxCollider>().enabled = flag;
			int childCount = this.CardData.CardGameObject.transform.childCount;
			this.CardData.CardGameObject.transform.GetChild(0).gameObject.SetActive(flag);
			this.CardData.CardGameObject.transform.GetChild(childCount - 1).gameObject.SetActive(flag);
		}
		else
		{
			this.CardData.CardGameObject.transform.parent.GetComponent<BoxCollider>().enabled = flag;
			int childCount2 = this.CardData.CardGameObject.transform.childCount;
			this.CardData.CardGameObject.transform.GetChild(0).gameObject.SetActive(flag);
			this.CardData.CardGameObject.transform.GetChild(childCount2 - 1).gameObject.SetActive(flag);
		}
		yield break;
	}

	public override IEnumerator OnKill(CardData target, int value, CardData from)
	{
		if (target.ModID.Equals("血祭之卵"))
		{
			List<CardSlotData> myBattleArea = base.GetMyBattleArea();
			bool flag = true;
			foreach (CardSlotData cardSlotData in myBattleArea)
			{
				if (cardSlotData.ChildCardData != null && !DungeonOperationMgr.Instance.CheckCardDead(cardSlotData.ChildCardData) && cardSlotData.ChildCardData != target && cardSlotData.ChildCardData.ModID.Equals("血祭之卵"))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				this.CardData.CardGameObject.transform.parent.GetComponent<BoxCollider>().enabled = flag;
				int childCount = this.CardData.CardGameObject.transform.childCount;
				this.CardData.CardGameObject.transform.GetChild(0).gameObject.SetActive(flag);
				this.CardData.CardGameObject.transform.GetChild(childCount - 1).gameObject.SetActive(flag);
			}
			else
			{
				this.CardData.CardGameObject.transform.parent.GetComponent<BoxCollider>().enabled = flag;
				int childCount2 = this.CardData.CardGameObject.transform.childCount;
				this.CardData.CardGameObject.transform.GetChild(0).gameObject.SetActive(flag);
				this.CardData.CardGameObject.transform.GetChild(childCount2 - 1).gameObject.SetActive(flag);
			}
		}
		yield break;
	}

	public override IEnumerator OnEndTurn(bool isPlayerTurn)
	{
		if (!isPlayerTurn)
		{
			this.rounds++;
			List<CardSlotData> battleArea = DungeonOperationMgr.Instance.BattleArea;
			if (this.rounds % 2 == 0)
			{
				for (int i = 0; i < 3; i++)
				{
					List<CardSlotData> list = new List<CardSlotData>();
					foreach (CardSlotData cardSlotData in battleArea)
					{
						if (cardSlotData.ChildCardData == null)
						{
							list.Add(cardSlotData);
						}
					}
					if (list.Count <= 0)
					{
						break;
					}
					UnityEngine.Random.Range(0, list.Count);
					Card.InitCardDataByID("血祭之卵").PutInSlotData(list[i], true);
				}
			}
		}
		yield break;
	}

	private int rounds;
}
