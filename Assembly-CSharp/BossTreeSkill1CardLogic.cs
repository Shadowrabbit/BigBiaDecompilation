using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossTreeSkill1CardLogic : CardLogic
{
	public override void Init()
	{
		base.Init();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树1");
	}

	public override void OnShowTips()
	{
		base.OnShowTips();
		this.displayName = LocalizationMgr.Instance.GetLocalizationWord("CT_N_大树1");
		this.Desc = LocalizationMgr.Instance.GetLocalizationWord("CT_D_大树1");
	}

	public override IEnumerator OnHpChange(CardData player, int changedValue, CardData from)
	{
		base.OnHpChange(player, changedValue, from);
		if (player == this.CardData && changedValue <= 0 && !DungeonOperationMgr.Instance.CheckCardDead(player))
		{
			UnityEngine.Object.FindObjectOfType<BossTreeArea>().Boss.GetComponent<Animator>().SetTrigger("BeAttacked");
		}
		if (player == this.CardData && changedValue < 0 && from != null)
		{
			this.count++;
			Dictionary<CardData, CardSlotData> dic = new Dictionary<CardData, CardSlotData>();
			for (int j = 0; j < this.count; j++)
			{
				List<CardSlotData> allEmptySlotsInMyBattleArea = base.GetAllEmptySlotsInMyBattleArea();
				List<CardSlotData> list = new List<CardSlotData>();
				if (allEmptySlotsInMyBattleArea == null || (allEmptySlotsInMyBattleArea != null && allEmptySlotsInMyBattleArea.Count == 0))
				{
					break;
				}
				foreach (CardSlotData cardSlotData in allEmptySlotsInMyBattleArea)
				{
					if (!dic.ContainsValue(cardSlotData))
					{
						list.Add(cardSlotData);
					}
				}
				if (list != null && list.Count == 0)
				{
					break;
				}
				CardSlotData value = list[SYNCRandom.Range(0, list.Count)];
				CardData cardData = null;
				switch (SYNCRandom.Range(0, 5))
				{
				case 0:
					cardData = Card.InitCardDataByID("花苞种子");
					break;
				case 1:
					cardData = Card.InitCardDataByID("坚壳种子");
					break;
				case 2:
					cardData = Card.InitCardDataByID("尖叫种子");
					break;
				case 3:
					cardData = Card.InitCardDataByID("火花种子");
					break;
				case 4:
					cardData = Card.InitCardDataByID("狂暴种子");
					break;
				}
				cardData = DungeonOperationMgr.Instance.InitDungeonMonster(cardData, 15);
				dic.Add(cardData, value);
			}
			if (dic.Count > 0)
			{
				List<GameObject> tempCards = new List<GameObject>();
				Dictionary<GameObject, CardSlotData> tempDic = new Dictionary<GameObject, CardSlotData>();
				foreach (KeyValuePair<CardData, CardSlotData> keyValuePair in dic)
				{
					GameObject gameObject = Card.InitWithOutData(keyValuePair.Key, true);
					gameObject.transform.position = new Vector3(-5.5f, 4f, 11.5f);
					tempCards.Add(gameObject);
					tempDic.Add(gameObject, keyValuePair.Value);
				}
				if (tempCards.Count == 0 || tempDic.Count == 0)
				{
					yield break;
				}
				int num;
				for (int i = 0; i < tempCards.Count; i = num + 1)
				{
					GameObject gameObject2 = tempCards[i];
					if (tempDic.ContainsKey(gameObject2))
					{
						CardSlotData cardSlotData2 = tempDic[gameObject2];
						if (i == tempCards.Count - 1)
						{
							yield return gameObject2.transform.DOJump(cardSlotData2.CardSlotGameObject.transform.position, 1f, 1, 1f, false).SetEase(Ease.InQuad).WaitForCompletion();
						}
						else
						{
							gameObject2.transform.DOJump(cardSlotData2.CardSlotGameObject.transform.position, 1f, 1, 1f, false).SetEase(Ease.InQuad);
						}
					}
					num = i;
				}
				foreach (GameObject obj in tempCards)
				{
					UnityEngine.Object.DestroyImmediate(obj);
				}
				foreach (KeyValuePair<CardData, CardSlotData> keyValuePair2 in dic)
				{
					keyValuePair2.Key.PutInSlotData(keyValuePair2.Value, true);
				}
				tempCards = null;
				tempDic = null;
			}
			dic = null;
		}
		yield break;
	}

	public override IEnumerator OnTurnStart()
	{
		base.OnTurnStart();
		this.count = 0;
		yield break;
	}

	public int count;
}
