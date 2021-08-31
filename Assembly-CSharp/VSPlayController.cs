using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VSPlayController : MonoBehaviour
{
	private void Awake()
	{
		VSPlayController.Instance = this;
	}

	private void Start()
	{
		this.P1Name.text = VSModeController.Instance.MyName + "(Rank:" + VSModeController.Instance.Rank.ToString() + ")";
		this.P2Name.text = VSModeController.Instance.OPName + "(Rank:" + VSModeController.Instance.OPRank.ToString() + ")";
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
			if (cardData.HasTag(TagMap.随从) && cardData.Rare == 1 && !cardData.HasTag(TagMap.衍生物) && !cardData.Attrs.ContainsKey("VS"))
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
			cardData2.CardTags |= 32768UL;
			list2.Add(cardData2);
		}
		return list2;
	}

	public TMP_Text P1Name;

	public TMP_Text P2Name;

	public static VSPlayController Instance;

	public List<CardSlotData> P1AreaSlots = new List<CardSlotData>();
}
