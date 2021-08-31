using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayArea : MonoBehaviour
{
	private void Awake()
	{
		MultiPlayArea.Instance = this;
	}

	public IEnumerator GetEnemyTurn()
	{
		while (MultiPlayerController.Instance.GameState != MultiPlayerController.GameStateType.P1Turn)
		{
			yield return 1;
		}
		DungeonController.Instance.StartCoroutine(DungeonController.Instance.GetAndPickTheFlipedCards(this.GetEnemyList(), false));
		yield break;
	}

	public void GetAndPutMinionTurn()
	{
		List<CardData> minionList = this.GetMinionList();
		for (int i = 0; i < this.P1AreaSlots.Count; i++)
		{
			minionList[i].PutInSlotData(this.P1AreaSlots[i], true);
		}
	}

	public void OnTurnEnd()
	{
	}

	private List<CardData> GetMinionList()
	{
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.随从) && cardData.Rare == 1 && !cardData.HasTag(TagMap.衍生物))
			{
				list.Add(cardData);
			}
		}
		List<CardData> list2 = new List<CardData>();
		for (int i = 0; i < 6; i++)
		{
			CardData cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
			while (list2.Contains(cardData2))
			{
				cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
			}
			cardData2 = CardData.CopyCardData(cardData2, true);
			list2.Add(cardData2);
		}
		return list2;
	}

	private List<CardData> GetEnemyList()
	{
		List<CardData> list = new List<CardData>();
		foreach (CardData cardData in GameController.getInstance().CardDataModMap.Cards)
		{
			if (cardData.HasTag(TagMap.怪物) && !cardData.HasTag(TagMap.衍生物) && !cardData.HasTag(TagMap.BOSS) && cardData.Level == 1)
			{
				list.Add(cardData);
			}
		}
		List<CardData> list2 = new List<CardData>();
		int num = UnityEngine.Random.Range(3, 10);
		for (int i = 0; i < num; i++)
		{
			CardData cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
			while (list2.Contains(cardData2))
			{
				cardData2 = list[UnityEngine.Random.Range(0, list.Count)];
			}
			cardData2 = CardData.CopyCardData(cardData2, true);
			DungeonOperationMgr.Instance.SetMultPlayMonster(cardData2, num);
			Card.InitCard(cardData2);
			cardData2.CardGameObject.transform.position = this.EnemyShowPoint.position;
			list2.Add(cardData2);
		}
		return list2;
	}

	public static MultiPlayArea Instance;

	public Transform EnemyShowPoint;

	public List<CardSlotData> P1AreaSlots = new List<CardSlotData>();

	public List<CardSlotData> P2AreaSlots = new List<CardSlotData>();
}
